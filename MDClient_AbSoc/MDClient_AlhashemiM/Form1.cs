using AbSoc_AlhashemiM;
using ConnectDlg_AlhashemiM_ICA06;
using MultiDraw2022; // provides LineSegment class
using System.Drawing;

namespace MDClient_AlhashemiM
{
    public partial class Form1 : Form
    {
        private AbSoc? _abSoc = null;                 // networking wrapper

        private bool _bConnected = false;
        private bool _bDrawing = false;

        private Point _lastPoint = Point.Empty;       // previous mouse position
        private Color _currentColour = Color.Black;
        private byte _currentThickness = 5;

        private int _iAlpha = 255;                    // alpha (transparency)
        private bool _bAKey = false;                  // track if A key is held

        public Form1()
        {
            InitializeComponent();

            UI_Connect_btn.Click += UI_Connect_btn_Click;
            UI_Colour_btn.Click += UI_Colour_btn_Click;
            UI_Disconnect_btn.Click += UI_Disconnect_btn_Click;

            MouseWheel += Form1_MouseWheel;           // thickness / alpha control
            KeyDown += Form1_KeyDown;                 // detect A key
            KeyUp += Form1_KeyUp;

            MouseDown += Form1_MouseDown;             // start drawing
            MouseMove += Form1_MouseMove;             // draw segments
            MouseUp += Form1_MouseUp;                 // stop drawing

            FormClosing += Form1_FormClosing;

            KeyPreview = true;                        // form receives key events first

            ResetUI();
        }

        private void UI_Disconnect_btn_Click(object? sender, EventArgs e)
        {
            if(!_bConnected)
            {
                return;
            }

            try
            {
                if(_abSoc != null)
                {
                    _abSoc.Connected = false;
                }
            }
            catch
            {

            }

            _abSoc = null;
            ResetUI();
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                _bAKey = true;                        // A pressed   switch to alpha mode
        }

        private void Form1_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                _bAKey = false;                       // A released  back to thickness
        }

        private void Form1_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (!_bConnected)
                return;

            if (_bAKey)                              // A + wheel change alpha
            {
                if (e.Delta > 0)
                {
                    if (_iAlpha < 255)
                        _iAlpha++;
                }
                else
                {
                    if (_iAlpha > 0)
                        _iAlpha--;
                }

                UI_Alpha_lbl.Text = $"Alpha : {_iAlpha}";
            }
            else                                     // wheel only change thickness
            {
                if (e.Delta > 0)
                {
                    if (_currentThickness < 50)
                        _currentThickness++;
                }
                else
                {
                    if (_currentThickness > 1)
                        _currentThickness--;
                }

                UI_Thickness_lbl.Text = $"Thickness : {_currentThickness}";
            }
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!_bConnected || _abSoc == null)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            _bDrawing = true;                         // begin drawing
            _lastPoint = e.Location;                  // store start point
        }

        private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_bConnected || _abSoc == null)
                return;

            if (!_bDrawing)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            LineSegment seg = new LineSegment();      // create line segment

            seg.SX = (short)_lastPoint.X;             // start = previous point
            seg.SY = (short)_lastPoint.Y;
            seg.EX = (short)e.X;                      // end = current point
            seg.EY = (short)e.Y;

            seg.C = Color.FromArgb(_iAlpha, _currentColour); // apply alpha + colour
            seg.T = _currentThickness;                // apply thickness

            string sJson = seg.LineSegmentToJSON();   // convert to JSON

            if (sJson.Length > 0)
                _abSoc.Send(sJson);                  // send to server (do NOT draw here)

            _lastPoint = e.Location;                  // update last point
        }

        private void Form1_MouseUp(object? sender, MouseEventArgs e)
        {
            _bDrawing = false;                        // stop drawing
        }

        private void ResetUI()
        {
            _bConnected = false;
            _bDrawing = false;
            _bAKey = false;

            _lastPoint = Point.Empty;
            _currentColour = Color.Black;

            _currentThickness = 5;
            _iAlpha = 255;

            UI_Connect_btn.Enabled = true;
            UI_Colour_btn.Enabled = false;
            UI_Disconnect_btn.Enabled = false;

            UI_Thickness_lbl.Text = "Thickness : 5";
            UI_Alpha_lbl.Text = "Alpha : 255";

            UI_Frames_lbl.Text = "Frames RX'ed : 0";
            UI_Fragments_lbl.Text = "Fragments : 0";
            UI_Destack_lbl.Text = "Destack Avg. : 0.00";
            UI_Bytes_lbl.Text = "Bytes RX'ed : 0 unit";
        }

        private void UpdateStats()
        {
            if (_abSoc == null)
                return;

            UI_Frames_lbl.Text = $"Frames RX'ed : {_abSoc.RXFrames}";   // full frames received
            UI_Fragments_lbl.Text = $"Fragments : {_abSoc.Fragments}"; // partial frames
            UI_Destack_lbl.Text = $"Destack Avg. : {_abSoc.DestackAverage:0.00}";
            UI_Bytes_lbl.Text = $"Bytes RX'ed : {FormatEngineering(_abSoc.TotalBytesReceived)}";
        }

        private string FormatEngineering(long iValue)
        {
            double dValue = iValue;
            string[] sPrefixes = { "unit", "k", "M", "G", "T", "P", "E" };
            int iIndex = 0;

            while (dValue >= 1000 && iIndex < sPrefixes.Length - 1)
            {
                dValue /= 1000.0;                    // convert to engineering unit
                iIndex++;
            }

            return $"{dValue:0.##}{sPrefixes[iIndex]}";
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            try
            {
                if (_abSoc != null)
                    _abSoc.Connected = false;       // clean disconnect
            }
            catch
            {
            }
        }

        private void UI_Colour_btn_Click(object? sender, EventArgs e)
        {
            if (!_bConnected)
                return;

            ColorDialog dlg = new ColorDialog();

            dlg.Color = _currentColour;
            dlg.FullOpen = true;

            if (dlg.ShowDialog() == DialogResult.OK)
                _currentColour = dlg.Color;          // store selected colour
        }

        private void UI_Connect_btn_Click(object? sender, EventArgs e)
        {
            if (_bConnected)
                return;

            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM();

            if (dlg.ShowDialog() == DialogResult.OK && dlg.ConnectedSocket != null)
            {
                try
                {
                    _abSoc = new AbSoc(dlg.ConnectedSocket, HandleError, HandleData);

                    _bConnected = true;

                    UI_Connect_btn.Enabled = false;
                    UI_Colour_btn.Enabled = true;
                    UI_Disconnect_btn.Enabled = true;

                    UI_Thickness_lbl.Text = $"Thickness : {_currentThickness}";
                    UI_Alpha_lbl.Text = $"Alpha : {_iAlpha}";

                    UpdateStats();
                    Focus();                         // ensure wheel + keys work
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    _abSoc = null;
                    ResetUI();
                }
            }
        }

        private void HandleData(string sJson)
        {
            if (IsDisposed || Disposing)
                return;

            if (InvokeRequired)
            {
                if (!IsDisposed && !Disposing)
                    Invoke(new Action<string>(HandleData), sJson); // switch to UI thread
                return;
            }

            LineSegment? seg = LineSegment.JSONToLineSegment(sJson);

            if (seg != null)
            {
                using (Graphics gr = CreateGraphics()) // draw on form
                    seg.Render(gr);
            }

            UpdateStats();
        }

        private void HandleError(string sMsg)
        {
            if (IsDisposed || Disposing)
                return;

            if (InvokeRequired)
            {
                if (!IsDisposed && !Disposing)
                    Invoke(new Action<string>(HandleError), sMsg); // UI thread
                return;
            }

            try
            {
                if (_abSoc != null)
                    _abSoc.Connected = false;
            }
            catch
            {
            }

            _abSoc = null;
            ResetUI();

            if (!IsDisposed && !Disposing)
                MessageBox.Show(sMsg);
        }
    }
}

