using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LFAutomationUI.Model;

namespace LFAutomationUI.LFUI
{
    public partial class ManualControlForm : Form
    {
        private ManualSignal manualSignal;

        public ManualSignal ManualSignal
        {
            get { return manualSignal; }
            set { manualSignal = value; }
        }

        public ManualControlForm()
        {
            InitializeComponent();
        }

        private void rdbLadleArrival_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbLadleArrival.Checked)
            {
                this.btnOK.Enabled = true;
                this.manualSignal = ManualSignal.LadleArrival;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes  || this.DialogResult == DialogResult.No)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void rdbLadleDepart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbLadleDepart.Checked)
            {
                this.btnOK.Enabled = true;
                this.manualSignal = ManualSignal.LadleDepart;
            }
        }

        private void rdbPowerStart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbPowerStart.Checked)
            {
                this.btnOK.Enabled = true;
                this.manualSignal = ManualSignal.PowerStart;
            }
        }

        private void rdbPowerStop_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbPowerStop.Checked)
            {
                this.btnOK.Enabled = true;
                this.manualSignal = ManualSignal.PowerStop;
            }
        }

        private void rdbFeedStart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbFeedStart.Checked)
            {
                this.btnOK.Enabled = true;
                this.manualSignal = ManualSignal.FeedStart;
            }
        }

        private void rdbFeedStop_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbFeedStop.Checked)
            {
                this.btnOK.Enabled = true;
                this.manualSignal = ManualSignal.FeedStop;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
