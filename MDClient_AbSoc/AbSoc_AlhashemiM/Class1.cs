//***********************************************************************************
// Program: CMPE2800
// Submission Code : 2800_1252_A07
// Description:
// A library class that wraps a Socket and provides error/data delivery.
// Date: April. 8, 2026
// Author: Mohammed Alhashemi
// Course: CMPE2800
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AbSoc_AlhashemiM
{
    public class AbSoc
    {
        // Connected socket supplied by the constructor
        private Socket _soc;

        // Callbacks for error delivery and data delivery
        private Action<string> _errorHandler;
        private Action<string> _dataHandler;

        // Transient receive buffer size
        private int _iBufferSize;

        // Shared connected state used by all threads
        private volatile bool _bConnected = true;

        // The 3 manual threads required by the assignment
        private Thread _rxThread;
        private Thread _processThread;
        private Thread _sendThread;

        // Queues shown in the assignment diagram
        private Queue<string> _rxQueue = new Queue<string>();
        private Queue<string> _txQueue = new Queue<string>();

        // Locks for shared queue access
        private object _rxLock = new object();
        private object _txLock = new object();

        // Running accumulation buffer for partial JSON receives
        private string _sAccum = "";

        // Stats required by the assignment
        public long TotalBytesReceived { get; private set; } = 0;
        public long TotalBytesTransmitted { get; private set; } = 0;
        public int ReceiveEventCount { get; private set; } = 0;
        public int Fragments { get; private set; } = 0;
        public int RXFrames { get; private set; } = 0;
        public int TXFrames { get; private set; } = 0;

        // Destack Average = coherent frames received / number of receive events
        public double DestackAverage
        {
            get
            {
                double dAvg = 0;

                if (ReceiveEventCount > 0)
                    dAvg = (double)RXFrames / ReceiveEventCount;

                return dAvg;
            }
        }

        // Callback properties may be reassigned after construction
        public Action<string> ErrorHandler
        {
            get { return _errorHandler; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _errorHandler = value;
            }
        }

        public Action<string> DataHandler
        {
            get { return _dataHandler; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _dataHandler = value;
            }
        }

        // Manual Connected property required by the assignment
        public bool Connected
        {
            get
            {
                bool bState = false;

                if (_soc != null)
                    bState = _bConnected && _soc.Connected;

                return bState;
            }
            set
            {
                if (value == false)
                {
                    _bConnected = false;

                    try { _soc.Shutdown(SocketShutdown.Both); }
                    catch { }

                    try { _soc.Close(); }
                    catch { }
                }
            }
        }

        // Constructor required by the assignment
        public AbSoc(Socket soc, Action<string> errorHandler, Action<string> dataHandler, int iBufferSize = 4096)
        {
            if (soc == null)
                throw new ArgumentNullException(nameof(soc));

            if (!soc.Connected)
                throw new ArgumentException("Socket must be connected.");

            if (errorHandler == null)
                throw new ArgumentNullException(nameof(errorHandler));

            if (dataHandler == null)
                throw new ArgumentNullException(nameof(dataHandler));

            if (iBufferSize == 0)
                throw new ArgumentException("Buffer size must be non-zero.");

            _soc = soc;
            _errorHandler = errorHandler;
            _dataHandler = dataHandler;
            _iBufferSize = iBufferSize;

            // Create and start the 3 manual threads upon construction
            _rxThread = new Thread(RxThread);
            _processThread = new Thread(ProcessThread);
            _sendThread = new Thread(SendThread);

            _rxThread.IsBackground = true;
            _processThread.IsBackground = true;
            _sendThread.IsBackground = true;

            _rxThread.Start();
            _processThread.Start();
            _sendThread.Start();
        }

        // Queues a JSON string for the Send Thread
        public void Send(string sJson)
        {
            if (sJson == null)
                throw new ArgumentNullException(nameof(sJson));

            if (!Connected)
                throw new InvalidOperationException("Socket is not connected.");

            lock (_txLock)
                _txQueue.Enqueue(sJson);
        }

        // Receive Thread
        private void RxThread()
        {
            while (_bConnected)
            {
                try
                {
                    byte[] abBuffer = new byte[_iBufferSize];
                    int iBytes = _soc.Receive(abBuffer);

                    if (iBytes == 0)
                    {
                        lock (_rxLock)
                            _rxQueue.Enqueue("ERROR:Socket disconnected."); // send error via process thread

                        Connected = false;
                        return;
                    }

                    string sData = Encoding.UTF8.GetString(abBuffer, 0, iBytes);

                    TotalBytesReceived += iBytes;
                    ReceiveEventCount++;

                    lock (_rxLock)
                    {
                        _sAccum += sData;

                        bool bFoundFrame = true;

                        while (bFoundFrame)
                        {
                            int iStart = _sAccum.IndexOf('{');
                            int iEnd = -1;

                            bFoundFrame = false;

                            if (iStart >= 0)
                                iEnd = _sAccum.IndexOf('}', iStart + 1);

                            if (iStart >= 0 && iEnd > iStart)
                            {
                                string sFrame = _sAccum.Substring(iStart, iEnd - iStart + 1);

                                _sAccum = _sAccum.Substring(iEnd + 1);

                                _rxQueue.Enqueue(sFrame);
                                RXFrames++;

                                bFoundFrame = true;
                            }
                        }

                        if (_sAccum.Length > 0)
                            Fragments++;
                    }
                }
                catch (Exception exc)
                {
                    lock (_rxLock)
                        _rxQueue.Enqueue("ERROR:" + exc.Message); // route error through process thread

                    Connected = false;
                    return;
                }
            }
        }

        // Process Thread
        private void ProcessThread()
        {
            while (_bConnected)
            {
                string sFrame = "";

                lock (_rxLock)
                {
                    if (_rxQueue.Count > 0)
                        sFrame = _rxQueue.Dequeue();
                }

                if (sFrame.Length > 0)
                {
                    try
                    {
                        if (sFrame.StartsWith("ERROR:"))
                            _errorHandler(sFrame.Substring(6)); // dispatch error ONLY from here
                        else
                            _dataHandler(sFrame);
                    }
                    catch (Exception exc)
                    {
                        _errorHandler(exc.Message);
                    }
                }
                else
                    Thread.Sleep(0); // required by checklist
            }
        }

        // Send Thread
        private void SendThread()
        {
            while (_bConnected)
            {
                string sJson = "";

                lock (_txLock)
                {
                    if (_txQueue.Count > 0)
                        sJson = _txQueue.Dequeue();
                }

                if (sJson.Length > 0)
                {
                    try
                    {
                        byte[] abData = Encoding.UTF8.GetBytes(sJson);
                        int iSent = _soc.Send(abData);

                        TotalBytesTransmitted += iSent;
                        TXFrames++;
                    }
                    catch (Exception exc)
                    {
                        lock (_rxLock)
                            _rxQueue.Enqueue("ERROR:" + exc.Message); // send error to process thread

                        Connected = false;
                        return;
                    }
                }
                else
                    Thread.Sleep(0); // required by checklist
            }
        }
    }
}

