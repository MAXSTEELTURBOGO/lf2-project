namespace LFAutomationUI.LFUI
{
    partial class TransformerParamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerTransParamForm = new System.Windows.Forms.SplitContainer();
            this.splitContainerTransFormInfo = new System.Windows.Forms.SplitContainer();
            this.lvTransParamInfo = new System.Windows.Forms.ListView();
            this.TapPosition = new System.Windows.Forms.ColumnHeader();
            this.TapPositionPoint = new System.Windows.Forms.ColumnHeader();
            this.Voltage = new System.Windows.Forms.ColumnHeader();
            this.Current = new System.Windows.Forms.ColumnHeader();
            this.TempPerMin = new System.Windows.Forms.ColumnHeader();
            this.Power = new System.Windows.Forms.ColumnHeader();
            this.txtTempPerMin = new System.Windows.Forms.TextBox();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.txtTapPositionPoint = new System.Windows.Forms.TextBox();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.txtTapPosition = new System.Windows.Forms.TextBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.lblTempPerMin = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblTapPositionPoint = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblTapPosition = new System.Windows.Forms.Label();
            this.btnAddNewElementInfo = new System.Windows.Forms.Button();
            this.btnDeleteElementInfo = new System.Windows.Forms.Button();
            this.btnModifyElementInfo = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainerTransParamForm.Panel1.SuspendLayout();
            this.splitContainerTransParamForm.Panel2.SuspendLayout();
            this.splitContainerTransParamForm.SuspendLayout();
            this.splitContainerTransFormInfo.Panel1.SuspendLayout();
            this.splitContainerTransFormInfo.Panel2.SuspendLayout();
            this.splitContainerTransFormInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerTransParamForm
            // 
            this.splitContainerTransParamForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTransParamForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTransParamForm.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTransParamForm.Name = "splitContainerTransParamForm";
            this.splitContainerTransParamForm.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTransParamForm.Panel1
            // 
            this.splitContainerTransParamForm.Panel1.Controls.Add(this.splitContainerTransFormInfo);
            // 
            // splitContainerTransParamForm.Panel2
            // 
            this.splitContainerTransParamForm.Panel2.Controls.Add(this.btnAddNewElementInfo);
            this.splitContainerTransParamForm.Panel2.Controls.Add(this.btnDeleteElementInfo);
            this.splitContainerTransParamForm.Panel2.Controls.Add(this.btnModifyElementInfo);
            this.splitContainerTransParamForm.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerTransParamForm.Panel2.Controls.Add(this.btnCLose);
            this.splitContainerTransParamForm.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerTransParamForm.Size = new System.Drawing.Size(642, 566);
            this.splitContainerTransParamForm.SplitterDistance = 518;
            this.splitContainerTransParamForm.TabIndex = 0;
            // 
            // splitContainerTransFormInfo
            // 
            this.splitContainerTransFormInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTransFormInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTransFormInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTransFormInfo.Name = "splitContainerTransFormInfo";
            this.splitContainerTransFormInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTransFormInfo.Panel1
            // 
            this.splitContainerTransFormInfo.Panel1.Controls.Add(this.lvTransParamInfo);
            // 
            // splitContainerTransFormInfo.Panel2
            // 
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.txtTempPerMin);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.txtCurrent);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.txtPower);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.txtTapPositionPoint);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.txtVoltage);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.txtTapPosition);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.lblVoltage);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.lblTempPerMin);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.lblCurrent);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.lblTapPositionPoint);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.lblPower);
            this.splitContainerTransFormInfo.Panel2.Controls.Add(this.lblTapPosition);
            this.splitContainerTransFormInfo.Size = new System.Drawing.Size(642, 518);
            this.splitContainerTransFormInfo.SplitterDistance = 441;
            this.splitContainerTransFormInfo.TabIndex = 0;
            // 
            // lvTransParamInfo
            // 
            this.lvTransParamInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TapPosition,
            this.TapPositionPoint,
            this.Voltage,
            this.Current,
            this.TempPerMin,
            this.Power});
            this.lvTransParamInfo.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvTransParamInfo.FullRowSelect = true;
            this.lvTransParamInfo.GridLines = true;
            this.lvTransParamInfo.Location = new System.Drawing.Point(3, 3);
            this.lvTransParamInfo.MultiSelect = false;
            this.lvTransParamInfo.Name = "lvTransParamInfo";
            this.lvTransParamInfo.Size = new System.Drawing.Size(632, 431);
            this.lvTransParamInfo.TabIndex = 0;
            this.lvTransParamInfo.UseCompatibleStateImageBehavior = false;
            this.lvTransParamInfo.View = System.Windows.Forms.View.Details;
            this.lvTransParamInfo.SelectedIndexChanged += new System.EventHandler(this.lvTransParamInfo_SelectedIndexChanged);
            // 
            // TapPosition
            // 
            this.TapPosition.Text = "档位";
            this.TapPosition.Width = 50;
            // 
            // TapPositionPoint
            // 
            this.TapPositionPoint.Text = "档位设定点";
            this.TapPositionPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TapPositionPoint.Width = 100;
            // 
            // Voltage
            // 
            this.Voltage.Text = "电压设定值";
            this.Voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Voltage.Width = 110;
            // 
            // Current
            // 
            this.Current.Text = "电流设定值";
            this.Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Current.Width = 130;
            // 
            // TempPerMin
            // 
            this.TempPerMin.Text = "温度上升度数";
            this.TempPerMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TempPerMin.Width = 120;
            // 
            // Power
            // 
            this.Power.Text = "档位功率";
            this.Power.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Power.Width = 100;
            // 
            // txtTempPerMin
            // 
            this.txtTempPerMin.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTempPerMin.Location = new System.Drawing.Point(512, 39);
            this.txtTempPerMin.Name = "txtTempPerMin";
            this.txtTempPerMin.Size = new System.Drawing.Size(116, 25);
            this.txtTempPerMin.TabIndex = 1;
            // 
            // txtCurrent
            // 
            this.txtCurrent.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrent.Location = new System.Drawing.Point(287, 39);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(96, 25);
            this.txtCurrent.TabIndex = 1;
            // 
            // txtPower
            // 
            this.txtPower.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPower.Location = new System.Drawing.Point(512, 4);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(116, 25);
            this.txtPower.TabIndex = 1;
            // 
            // txtTapPositionPoint
            // 
            this.txtTapPositionPoint.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTapPositionPoint.Location = new System.Drawing.Point(287, 4);
            this.txtTapPositionPoint.Name = "txtTapPositionPoint";
            this.txtTapPositionPoint.Size = new System.Drawing.Size(96, 25);
            this.txtTapPositionPoint.TabIndex = 1;
            // 
            // txtVoltage
            // 
            this.txtVoltage.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVoltage.Location = new System.Drawing.Point(108, 39);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(75, 25);
            this.txtVoltage.TabIndex = 1;
            // 
            // txtTapPosition
            // 
            this.txtTapPosition.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTapPosition.Location = new System.Drawing.Point(108, 4);
            this.txtTapPosition.Name = "txtTapPosition";
            this.txtTapPosition.Size = new System.Drawing.Size(75, 25);
            this.txtTapPosition.TabIndex = 1;
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVoltage.Location = new System.Drawing.Point(10, 43);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(103, 15);
            this.lblVoltage.TabIndex = 0;
            this.lblVoltage.Text = "档位电压值：";
            // 
            // lblTempPerMin
            // 
            this.lblTempPerMin.AutoSize = true;
            this.lblTempPerMin.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTempPerMin.Location = new System.Drawing.Point(397, 43);
            this.lblTempPerMin.Name = "lblTempPerMin";
            this.lblTempPerMin.Size = new System.Drawing.Size(119, 15);
            this.lblTempPerMin.TabIndex = 0;
            this.lblTempPerMin.Text = "温升[℃/MIN]：";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrent.Location = new System.Drawing.Point(189, 43);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(103, 15);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "档位电流值：";
            // 
            // lblTapPositionPoint
            // 
            this.lblTapPositionPoint.AutoSize = true;
            this.lblTapPositionPoint.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTapPositionPoint.Location = new System.Drawing.Point(189, 7);
            this.lblTapPositionPoint.Name = "lblTapPositionPoint";
            this.lblTapPositionPoint.Size = new System.Drawing.Size(103, 15);
            this.lblTapPositionPoint.TabIndex = 0;
            this.lblTapPositionPoint.Text = "档位设定点：";
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPower.Location = new System.Drawing.Point(413, 7);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(103, 15);
            this.lblPower.TabIndex = 0;
            this.lblPower.Text = "档位功率值：";
            // 
            // lblTapPosition
            // 
            this.lblTapPosition.AutoSize = true;
            this.lblTapPosition.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTapPosition.Location = new System.Drawing.Point(10, 7);
            this.lblTapPosition.Name = "lblTapPosition";
            this.lblTapPosition.Size = new System.Drawing.Size(103, 15);
            this.lblTapPosition.TabIndex = 0;
            this.lblTapPosition.Text = "变压器档位：";
            // 
            // btnAddNewElementInfo
            // 
            this.btnAddNewElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNewElementInfo.Location = new System.Drawing.Point(4, 3);
            this.btnAddNewElementInfo.Name = "btnAddNewElementInfo";
            this.btnAddNewElementInfo.Size = new System.Drawing.Size(80, 35);
            this.btnAddNewElementInfo.TabIndex = 13;
            this.btnAddNewElementInfo.Text = "新  增";
            this.btnAddNewElementInfo.UseVisualStyleBackColor = true;
            this.btnAddNewElementInfo.Click += new System.EventHandler(this.btnAddNewElementInfo_Click);
            // 
            // btnDeleteElementInfo
            // 
            this.btnDeleteElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteElementInfo.Location = new System.Drawing.Point(212, 3);
            this.btnDeleteElementInfo.Name = "btnDeleteElementInfo";
            this.btnDeleteElementInfo.Size = new System.Drawing.Size(80, 35);
            this.btnDeleteElementInfo.TabIndex = 15;
            this.btnDeleteElementInfo.Text = "删  除";
            this.btnDeleteElementInfo.UseVisualStyleBackColor = true;
            this.btnDeleteElementInfo.Click += new System.EventHandler(this.btnDeleteElementInfo_Click);
            // 
            // btnModifyElementInfo
            // 
            this.btnModifyElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyElementInfo.Location = new System.Drawing.Point(108, 3);
            this.btnModifyElementInfo.Name = "btnModifyElementInfo";
            this.btnModifyElementInfo.Size = new System.Drawing.Size(80, 35);
            this.btnModifyElementInfo.TabIndex = 14;
            this.btnModifyElementInfo.Text = "修  改";
            this.btnModifyElementInfo.UseVisualStyleBackColor = true;
            this.btnModifyElementInfo.Click += new System.EventHandler(this.btnModifyElementInfo_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(316, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 35);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "确  认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCLose.Location = new System.Drawing.Point(524, 3);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(111, 35);
            this.btnCLose.TabIndex = 18;
            this.btnCLose.Text = "关闭窗口";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(420, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TransformerParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCLose;
            this.ClientSize = new System.Drawing.Size(642, 566);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerTransParamForm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransformerParamForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "变压器参数维护界面";
            this.Load += new System.EventHandler(this.TransformerParamMaintenanceForm_Load);
            this.splitContainerTransParamForm.Panel1.ResumeLayout(false);
            this.splitContainerTransParamForm.Panel2.ResumeLayout(false);
            this.splitContainerTransParamForm.ResumeLayout(false);
            this.splitContainerTransFormInfo.Panel1.ResumeLayout(false);
            this.splitContainerTransFormInfo.Panel2.ResumeLayout(false);
            this.splitContainerTransFormInfo.Panel2.PerformLayout();
            this.splitContainerTransFormInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTransParamForm;
        private System.Windows.Forms.SplitContainer splitContainerTransFormInfo;
        private System.Windows.Forms.ListView lvTransParamInfo;
        private System.Windows.Forms.ColumnHeader TapPosition;
        private System.Windows.Forms.ColumnHeader TapPositionPoint;
        private System.Windows.Forms.ColumnHeader Voltage;
        private System.Windows.Forms.ColumnHeader Current;
        private System.Windows.Forms.ColumnHeader TempPerMin;
        private System.Windows.Forms.ColumnHeader Power;
        private System.Windows.Forms.Button btnAddNewElementInfo;
        private System.Windows.Forms.Button btnDeleteElementInfo;
        private System.Windows.Forms.Button btnModifyElementInfo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTapPosition;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label lblTempPerMin;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblTapPositionPoint;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.TextBox txtTempPerMin;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.TextBox txtTapPositionPoint;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.TextBox txtTapPosition;
    }
}