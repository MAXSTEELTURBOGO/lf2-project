using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LFAutomationUI.Model;
using LFAutomationUI.BLL;

namespace LFAutomationUI.LFUI
{
    public partial class ChooseHeatOptionForm : Form
    {
        public ChooseOption Option;
        private LFHeatInfo existedLFHeat;
        private LFHeatInfo lfHeat;
        private Car car;
        public ChooseHeatOptionForm(LFHeatInfo lfHeat,LFHeatInfo existedLFHeat,Car car)
        {
            InitializeComponent();
            this.car = car;
            this.lfHeat = lfHeat;
            this.existedLFHeat = existedLFHeat;
            this.lblTip.Text = string.Format(this.lblTip.Text, LFHeatInfo.IntParseCar(car), this.existedLFHeat.HeatId,lfHeat.HeatId);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.rdbEndLastAndStartNew.Checked)
            {
                this.Option = ChooseOption.EndLastAndStartNew;
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                if (this.rdbReplace.Checked)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Option = ChooseOption.ReplaceExistHeat;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("你尚未选择任何选项!请选择后点击确定!","提示");
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes || this.DialogResult == DialogResult.No)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

    }
}
