using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BootstrapWindowsFormsApp
{
    public partial class MainForm : Form
    {
        // CONFIG
        public static int PortNumber = 1234;
        public static string BaseFilesLocation = "C:/PATH_TO_BOOTSTRAP_TEMPLATE/FOR_EXAMPLE/startbootstrap-sb-admin-gh-pages/dist/";

        private RestServer restServer = null;
        public MainForm()
        {
            InitializeComponent();

            // Start REST Server
            this.restServer = new RestServer();
            {
                this.restServer.Port = MainForm.PortNumber.ToString();
                this.restServer.Start();
            }

            // TODO: Condition this with a boolean?
            this.OpenDashboard();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.restServer != null)
                this.restServer.Stop();
        }

        public void OpenDashboard()
        {
            Process.Start("http://localhost:" + MainForm.PortNumber);
        }

        private void buttonOpenDashboard_Click(object sender, EventArgs e)
        {
            this.OpenDashboard();
        }
    }
}
