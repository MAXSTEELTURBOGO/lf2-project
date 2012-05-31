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
    public partial class SelectCarForm : Form
    {
        public Car Car;
        private string heatId;

        public SelectCarForm()
        {
            InitializeComponent();
            Car = Car.None;
        }

        public SelectCarForm(string heatId)
        {
            InitializeComponent();
            Car = Car.None;
            this.heatId = heatId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.rdbCarOne.Checked == false && this.rdbCarTwo.Checked == false)
            {
                MessageBox.Show("你未选择任何工位！", "提示");
            }
            else
            {
                if (this.rdbCarOne.Checked)
                {
                    Car = Car.One;
                }
                else
                {
                    Car = Car.Two;
                }
                if (MessageBox.Show("你确定要选择工位"+LFHeatInfo.IntParseCar(Car).ToString()+"冶炼炉次号为"+this.heatId+"炉次吗?","确认选择",MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
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
    }
}
