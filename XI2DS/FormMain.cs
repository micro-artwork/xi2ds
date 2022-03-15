using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Exceptions;
using Vortice.XInput;
using XI2DS.Xinput;
using XI2DS.DualShock4;
using System.Reflection;

namespace XI2DS
{
    public partial class FormMain : Form, IFeedBackReceiver
    {
        readonly ViGEmClient client;
        readonly XInputController xInputController;
        readonly DS4Controller[] ds4Controllers;
        readonly Button[] connectionButtons;
        readonly PictureBox[] batteryIndicators;
        readonly PictureBox[] connectionIndicators;
        readonly FormTest formTest;

        public FormMain()
        {
            InitializeComponent();

            this.Text = String.Format("{0} v{1}", AssemblyTitle, AssemblyVersion);

            connectionButtons = new[] {
                uiButtonConnectController1, uiButtonConnectController2,
                uiButtonConnectController3, uiButtonConnectController4
            };

            batteryIndicators = new[] {
                uiImageBatteryInfoController1, uiImageBatteryInfoController2,
                uiImageBatteryInfoController3, uiImageBatteryInfoController4
            };

            connectionIndicators = new[] {
               uiImageConnectionController1, uiImageConnectionController2,
               uiImageConnectionController3, uiImageConnectionController4
            };

            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Show").Click += (object sender, EventArgs e) =>
            {
                ShowApplication();
            };

            notifyIcon.ContextMenuStrip.Items.Add("Hide").Click += (object sender, EventArgs e) =>
            {
                HideApplication();
            };

            notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (object sender, EventArgs e) =>
            {
                ExitApplication();
            };

            try
            {
                client = new ViGEmClient();
                ds4Controllers = new[] {
                    new DS4Controller(client, 0, this),
                    new DS4Controller(client, 1, this),
                    new DS4Controller(client, 2, this),
                    new DS4Controller(client, 3, this)
                };

            }
            catch (VigemBusNotFoundException e)
            {
                if (MessageBox.Show("Cannot find ViGEm bus driver. Please check to install driver. " +
                    "Press OK button to go to driver download page.",
                    "Driver Not Found",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = "https://github.com/ViGEm/ViGEmBus/releases";
                    process.Start();
                }
                throw;
            }

            xInputController = new XInputController();
            xInputController.StateUpdated += XInputController_StateUpdated;
            xInputController.StatusUpdated += XInputController_StatusUpdated;

            formTest = new FormTest(xInputController);

            xInputController.StartScan();

        }

        private void XInputController_StatusUpdated(object sender, XInputStatusEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (e.Status.IsConnected)
                    {
                        connectionButtons[e.UserIndex].Enabled = true;
                    }
                    else
                    {
                        connectionButtons[e.UserIndex].Text = "DS4 Connect";
                        connectionButtons[e.UserIndex].Enabled = false;
                        ds4Controllers[e.UserIndex].Disconnect();
                    }
                    batteryIndicators[e.UserIndex].Image = GetBatteryImage(e.Status.BatteryInfo.BatteryType, e.Status.BatteryInfo.BatteryLevel);
                    connectionIndicators[e.UserIndex].Image = GetConnectionImage(e.Status.IsConnected);
                });
            }
        }

        private void XInputController_StateUpdated(object sender, XInputStateEventArgs e)
        {
            if (ds4Controllers[e.UserIndex].IsConnected)
            {
                ds4Controllers[e.UserIndex].SubmitReport(e.State);
            }
        }


        private string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return "";
            }
        }

        private string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }


        private Image GetBatteryImage(BatteryType type, BatteryLevel level)
        {
            int index;

            switch (type)
            {
                case BatteryType.Alkaline:
                case BatteryType.Nimh:
                    index = (int)level;
                    break;

                case BatteryType.Wired:
                    index = 5;
                    break;
                default:
                case BatteryType.Disconnected:
                case BatteryType.Unknown:
                    index = 4;
                    break;
            }

            return imageListBattery.Images[index];
        }

        private Image GetConnectionImage(bool isConnected)
        {
            return isConnected ? Properties.Resources.controller_connected
                : Properties.Resources.controller_not_connected;
        }

        private void ShowApplication()
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
        }
        private void HideApplication()
        {
            this.ShowInTaskbar = false;
            this.Visible = false;
        }
        private void ExitApplication()
        {
            notifyIcon.Visible = false;

            foreach (DS4Controller controller in ds4Controllers)
            {
                controller.Disconnect();
            }

            xInputController.StopScan();
            client.Dispose();

            Application.ExitThread();
            Application.Exit();

        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int userIndex = Convert.ToInt32(button.Tag);

            if (ds4Controllers[userIndex].IsConnected)
            {
                ds4Controllers[userIndex].Disconnect();
                connectionButtons[userIndex].Text = "DS4 Connect";
            }
            else
            {
                ds4Controllers[userIndex].Connect();
                connectionButtons[userIndex].Text = "DS4 Disconnect";
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideApplication();
        }

        public void OnFeedBackReceived(int userIndex, byte smallMotor, byte largeMotor)
        {
            xInputController.Vibrate(userIndex, smallMotor, largeMotor);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void InputTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formTest.Visible)
            {
                formTest.Hide();
            }
            else
            {
                formTest.Show();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowApplication();
        }

    }
}
