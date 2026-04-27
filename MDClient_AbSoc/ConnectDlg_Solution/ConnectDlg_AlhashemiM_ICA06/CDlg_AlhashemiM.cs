using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectDlg_AlhashemiM_ICA06
{
    public partial class CDlg_AlhashemiM : Form
    {
        bool _bAddressEdit = true;
        bool _bPortEdit = true;
        bool _bConnecting = false;
        string _sCtorStatus = "";

        public Socket? ConnectedSocket { get; private set; } = null;

        public string AddressValue
        {
            get { return txtAddress.Text.Trim(); }
        }

        public int PortValue
        {
            get
            {
                int iPort = 0;
                int.TryParse(txtPort.Text.Trim(), out iPort);
                return iPort;
            }
        }


        public CDlg_AlhashemiM(string sAddress = "www.microsoft.com",
          int iPort = 80,
          bool bAddressEdit = true,
          bool bPortEdit = true)
        {
            InitializeComponent();

            _bAddressEdit = bAddressEdit;
            _bPortEdit = bPortEdit;

            // Validate constructor arguments according to rubric
            if (sAddress.Trim().Length < 1 && !_bAddressEdit)
                throw new ArgumentException("CTOR:ArgumentException : Address invalid while not editable.");

            if (iPort < 1 && !_bPortEdit)
                throw new ArgumentException("CTOR:ArgumentException : Port invalid while not editable.");

            if (sAddress.Trim().Length < 1 && _bAddressEdit)
                _sCtorStatus = "CTOR:Status : Address invalid.";

            if (iPort < 1 && _bPortEdit)
            {
                if (_sCtorStatus.Length > 0)
                    _sCtorStatus += " ";
                _sCtorStatus += "CTOR:Status : Port invalid.";
            }

            txtAddress.Text = sAddress;
            txtPort.Text = iPort.ToString();

            txtAddress.ReadOnly = !_bAddressEdit;
            txtPort.ReadOnly = !_bPortEdit;
            txtStatus.ReadOnly = true;

            ControlBox = false;

            Shown += CDlg_AlhashemiM_Shown;
            FormClosing += CDlg_AlhashemiM_FormClosing;

            btnConnect.Click += BtnConnect_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            if (_bConnecting)
                return;

            ConnectedSocket = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void BtnConnect_Click(object? sender, EventArgs e)
        {
            string sAddress = txtAddress.Text.Trim();
            int iPort = 0;

            if (sAddress.Length < 1)
            {
                SetStatus("Connect:Status : Address invalid.");
                return;
            }

            if (!int.TryParse(txtPort.Text.Trim(), out iPort) || iPort < 1)
            {
                SetStatus("Connect:Status : Port invalid.");
                return;
            }

            _bConnecting = true;
            ToggleUi(false);
            UseWaitCursor = true;
            SetStatus("Connect:Pending...");

            Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                await soc.ConnectAsync(sAddress, iPort);

                ConnectedSocket = soc;
                SetStatus("Connect:Success");
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            catch (SocketException exc)
            {
                ConnectedSocket = null;
                SetStatus("Connect:SocketException : " + exc.Message);

                try
                {
                    soc.Close();
                }
                catch (Exception)
                {
                }
            }
            catch (Exception exc)
            {
                ConnectedSocket = null;
                SetStatus("Connect:Exception : " + exc.Message);

                try
                {
                    soc.Close();
                }
                catch (Exception)
                {
                }
            }

            UseWaitCursor = false;
            _bConnecting = false;
            ToggleUi(true);
        }

        private void CDlg_AlhashemiM_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && DialogResult != DialogResult.Cancel)
                e.Cancel = true;
        }

        private void CDlg_AlhashemiM_Shown(object? sender, EventArgs e)
        {
            if (_sCtorStatus.Length > 0)
                SetStatus(_sCtorStatus);
            else
                SetStatus("Ready.");
        }



        private void ToggleUi(bool bEnable)
        {
            txtAddress.ReadOnly = !_bAddressEdit || !bEnable;
            txtPort.ReadOnly = !_bPortEdit || !bEnable;

            btnConnect.Enabled = bEnable;
            btnCancel.Enabled = bEnable;
        }

        private void SetStatus(string sMsg)
        {
            txtStatus.Text = sMsg;
        }
    }
}
