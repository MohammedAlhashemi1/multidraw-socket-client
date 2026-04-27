using ConnectDlg_AlhashemiM_ICA06;
using System.Net.Sockets;

namespace ConnectDlgTestHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnClear.Click += BtnClear_Click;
            btnGoodAddressGoodPort.Click += BtnGoodAddressGoodPort_Click;
            btnGoodAddressBadPort.Click += BtnGoodAddressBadPort_Click;
            btnBadAddress.Click += BtnBadAddress_Click;
            btnCtorBadPort.Click += BtnCtorBadPort_Click;
            btnCtorBadAddress.Click += BtnCtorBadAddress_Click;
            btnNeitherEditable.Click += BtnNeitherEditable_Click;
            btnPortOnly.Click += BtnPortOnly_Click;
            btnAdrressOnly.Click += BtnAdrressOnly_Click;
            btnBothEditable.Click += BtnBothEditable_Click;
            btnDefault.Click += BtnDefault_Click;
        }

        private void BtnDefault_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM();
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnBothEditable_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 80, true, true);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnAdrressOnly_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 80, true, false);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnPortOnly_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 80, false, true);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnNeitherEditable_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 80, false, false);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnCtorBadAddress_Click(object? sender, EventArgs e)
        {
            try
            {
                CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("", 80, false, true);
                dlg.ShowDialog();
                ShowResult(dlg);
            }
            catch (Exception exc)
            {
                Log("Caught : " + exc.Message);
                Log("");
            }
        }

        private void BtnCtorBadPort_Click(object? sender, EventArgs e)
        {
            try
            {
                CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 0, true, false);
                dlg.ShowDialog();
                ShowResult(dlg);
            }
            catch (Exception exc)
            {
                Log("Caught : " + exc.Message);
                Log("");
            }
        }

        private void BtnBadAddress_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("bad.bad.bad.bad", 80, true, true);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnGoodAddressBadPort_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 1, true, true);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnGoodAddressGoodPort_Click(object? sender, EventArgs e)
        {
            CDlg_AlhashemiM dlg = new CDlg_AlhashemiM("www.microsoft.com", 80, true, true);
            dlg.ShowDialog();
            ShowResult(dlg);
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void Log(string sMsg)
        {
            txtLog.AppendText(sMsg + Environment.NewLine);
        }

        private void ShowResult(CDlg_AlhashemiM dlg)
        {
            Log("DialogResult : " + dlg.DialogResult);
            Log("AddressValue : " + dlg.AddressValue);
            Log("PortValue    : " + dlg.PortValue);

            if (dlg.ConnectedSocket == null)
            {
                Log("ConnectedSocket : null");
            }
            else
            {
                Log("ConnectedSocket : connected");

                try
                {
                    dlg.ConnectedSocket.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                }

                try
                {
                    dlg.ConnectedSocket.Close();
                }
                catch (Exception)
                {
                }
            }

            Log("");
        }

    }
}
