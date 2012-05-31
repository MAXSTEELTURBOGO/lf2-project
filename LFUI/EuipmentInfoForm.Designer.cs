namespace LFAutomationUI.LFUI
{
    partial class EuipmentInfoForm
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
            this.panelEquipmentInfo = new System.Windows.Forms.Panel();
            this.lvEquipmentInfo = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerEditEquipmentInfo = new System.Windows.Forms.SplitContainer();
            this.btnResetEquipmentAge = new System.Windows.Forms.Button();
            this.txtEquipmentAge = new System.Windows.Forms.TextBox();
            this.txtEquipmentDescription = new System.Windows.Forms.TextBox();
            this.lbl_EquipmentAge = new System.Windows.Forms.Label();
            this.lbl_EquipmentDescription = new System.Windows.Forms.Label();
            this.lblEquipmentName = new System.Windows.Forms.Label();
            this.lbl_EquipmentName = new System.Windows.Forms.Label();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDeleteEquipment = new System.Windows.Forms.Button();
            this.btnNewEquipment = new System.Windows.Forms.Button();
            this.btnEditEquipment = new System.Windows.Forms.Button();
            this.panelEquipmentInfo.SuspendLayout();
            this.splitContainerEditEquipmentInfo.Panel1.SuspendLayout();
            this.splitContainerEditEquipmentInfo.Panel2.SuspendLayout();
            this.splitContainerEditEquipmentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEquipmentInfo
            // 
            this.panelEquipmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEquipmentInfo.Controls.Add(this.lvEquipmentInfo);
            this.panelEquipmentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEquipmentInfo.Location = new System.Drawing.Point(0, 0);
            this.panelEquipmentInfo.Name = "panelEquipmentInfo";
            this.panelEquipmentInfo.Size = new System.Drawing.Size(592, 346);
            this.panelEquipmentInfo.TabIndex = 0;
            // 
            // lvEquipmentInfo
            // 
            this.lvEquipmentInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderAge,
            this.columnHeaderDescription});
            this.lvEquipmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEquipmentInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvEquipmentInfo.FullRowSelect = true;
            this.lvEquipmentInfo.GridLines = true;
            this.lvEquipmentInfo.Location = new System.Drawing.Point(0, 0);
            this.lvEquipmentInfo.MultiSelect = false;
            this.lvEquipmentInfo.Name = "lvEquipmentInfo";
            this.lvEquipmentInfo.Size = new System.Drawing.Size(588, 342);
            this.lvEquipmentInfo.TabIndex = 0;
            this.lvEquipmentInfo.UseCompatibleStateImageBehavior = false;
            this.lvEquipmentInfo.View = System.Windows.Forms.View.Details;
            this.lvEquipmentInfo.SelectedIndexChanged += new System.EventHandler(this.lvEquipmentInfo_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "设备名称";
            this.columnHeaderName.Width = 210;
            // 
            // columnHeaderAge
            // 
            this.columnHeaderAge.Text = "设备寿命";
            this.columnHeaderAge.Width = 100;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "设备描述";
            this.columnHeaderDescription.Width = 320;
            // 
            // splitContainerEditEquipmentInfo
            // 
            this.splitContainerEditEquipmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerEditEquipmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditEquipmentInfo.Location = new System.Drawing.Point(0, 346);
            this.splitContainerEditEquipmentInfo.Name = "splitContainerEditEquipmentInfo";
            this.splitContainerEditEquipmentInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEditEquipmentInfo.Panel1
            // 
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.btnResetEquipmentAge);
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.txtEquipmentAge);
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.txtEquipmentDescription);
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.lbl_EquipmentAge);
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.lbl_EquipmentDescription);
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.lblEquipmentName);
            this.splitContainerEditEquipmentInfo.Panel1.Controls.Add(this.lbl_EquipmentName);
            // 
            // splitContainerEditEquipmentInfo.Panel2
            // 
            this.splitContainerEditEquipmentInfo.Panel2.Controls.Add(this.btnCloseWindow);
            this.splitContainerEditEquipmentInfo.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerEditEquipmentInfo.Panel2.Controls.Add(this.btnOK);
            this.splitContainerEditEquipmentInfo.Panel2.Controls.Add(this.btnDeleteEquipment);
            this.splitContainerEditEquipmentInfo.Panel2.Controls.Add(this.btnNewEquipment);
            this.splitContainerEditEquipmentInfo.Panel2.Controls.Add(this.btnEditEquipment);
            this.splitContainerEditEquipmentInfo.Size = new System.Drawing.Size(592, 97);
            this.splitContainerEditEquipmentInfo.SplitterDistance = 49;
            this.splitContainerEditEquipmentInfo.TabIndex = 1;
            // 
            // btnResetEquipmentAge
            // 
            this.btnResetEquipmentAge.Enabled = false;
            this.btnResetEquipmentAge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResetEquipmentAge.Location = new System.Drawing.Point(463, 14);
            this.btnResetEquipmentAge.Name = "btnResetEquipmentAge";
            this.btnResetEquipmentAge.Size = new System.Drawing.Size(153, 57);
            this.btnResetEquipmentAge.TabIndex = 7;
            this.btnResetEquipmentAge.Text = "更换设备\r\n设备寿命归零";
            this.btnResetEquipmentAge.UseVisualStyleBackColor = true;
            this.btnResetEquipmentAge.Click += new System.EventHandler(this.btnResetEquipmentAge_Click);
            // 
            // txtEquipmentAge
            // 
            this.txtEquipmentAge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEquipmentAge.Location = new System.Drawing.Point(340, 11);
            this.txtEquipmentAge.Name = "txtEquipmentAge";
            this.txtEquipmentAge.ReadOnly = true;
            this.txtEquipmentAge.Size = new System.Drawing.Size(95, 29);
            this.txtEquipmentAge.TabIndex = 6;
            // 
            // txtEquipmentDescription
            // 
            this.txtEquipmentDescription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEquipmentDescription.Location = new System.Drawing.Point(84, 44);
            this.txtEquipmentDescription.Name = "txtEquipmentDescription";
            this.txtEquipmentDescription.ReadOnly = true;
            this.txtEquipmentDescription.Size = new System.Drawing.Size(351, 29);
            this.txtEquipmentDescription.TabIndex = 5;
            // 
            // lbl_EquipmentAge
            // 
            this.lbl_EquipmentAge.AutoSize = true;
            this.lbl_EquipmentAge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_EquipmentAge.Location = new System.Drawing.Point(260, 14);
            this.lbl_EquipmentAge.Name = "lbl_EquipmentAge";
            this.lbl_EquipmentAge.Size = new System.Drawing.Size(74, 21);
            this.lbl_EquipmentAge.TabIndex = 4;
            this.lbl_EquipmentAge.Text = "设备寿命";
            // 
            // lbl_EquipmentDescription
            // 
            this.lbl_EquipmentDescription.AutoSize = true;
            this.lbl_EquipmentDescription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_EquipmentDescription.Location = new System.Drawing.Point(8, 47);
            this.lbl_EquipmentDescription.Name = "lbl_EquipmentDescription";
            this.lbl_EquipmentDescription.Size = new System.Drawing.Size(74, 21);
            this.lbl_EquipmentDescription.TabIndex = 2;
            this.lbl_EquipmentDescription.Text = "设备描述";
            // 
            // lblEquipmentName
            // 
            this.lblEquipmentName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEquipmentName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEquipmentName.Location = new System.Drawing.Point(84, 10);
            this.lblEquipmentName.Name = "lblEquipmentName";
            this.lblEquipmentName.Size = new System.Drawing.Size(170, 28);
            this.lblEquipmentName.TabIndex = 1;
            this.lblEquipmentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_EquipmentName
            // 
            this.lbl_EquipmentName.AutoSize = true;
            this.lbl_EquipmentName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_EquipmentName.Location = new System.Drawing.Point(8, 14);
            this.lbl_EquipmentName.Name = "lbl_EquipmentName";
            this.lbl_EquipmentName.Size = new System.Drawing.Size(74, 21);
            this.lbl_EquipmentName.TabIndex = 0;
            this.lbl_EquipmentName.Text = "设备名称";
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseWindow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseWindow.Location = new System.Drawing.Point(528, 1);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(105, 50);
            this.btnCloseWindow.TabIndex = 5;
            this.btnCloseWindow.Text = "关闭窗口";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(423, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(318, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 50);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDeleteEquipment
            // 
            this.btnDeleteEquipment.Enabled = false;
            this.btnDeleteEquipment.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteEquipment.Location = new System.Drawing.Point(213, 1);
            this.btnDeleteEquipment.Name = "btnDeleteEquipment";
            this.btnDeleteEquipment.Size = new System.Drawing.Size(105, 50);
            this.btnDeleteEquipment.TabIndex = 2;
            this.btnDeleteEquipment.Text = "删除";
            this.btnDeleteEquipment.UseVisualStyleBackColor = true;
            // 
            // btnNewEquipment
            // 
            this.btnNewEquipment.Enabled = false;
            this.btnNewEquipment.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewEquipment.Location = new System.Drawing.Point(3, 1);
            this.btnNewEquipment.Name = "btnNewEquipment";
            this.btnNewEquipment.Size = new System.Drawing.Size(105, 50);
            this.btnNewEquipment.TabIndex = 1;
            this.btnNewEquipment.Text = "新增";
            this.btnNewEquipment.UseVisualStyleBackColor = true;
            // 
            // btnEditEquipment
            // 
            this.btnEditEquipment.Enabled = false;
            this.btnEditEquipment.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditEquipment.Location = new System.Drawing.Point(108, 1);
            this.btnEditEquipment.Name = "btnEditEquipment";
            this.btnEditEquipment.Size = new System.Drawing.Size(105, 50);
            this.btnEditEquipment.TabIndex = 0;
            this.btnEditEquipment.Text = "修改";
            this.btnEditEquipment.UseVisualStyleBackColor = true;
            this.btnEditEquipment.Click += new System.EventHandler(this.btnEditEquipment_Click);
            // 
            // EuipmentInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseWindow;
            this.ClientSize = new System.Drawing.Size(592, 443);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerEditEquipmentInfo);
            this.Controls.Add(this.panelEquipmentInfo);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EuipmentInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备信息管理";
            this.Load += new System.EventHandler(this.EuipmentInfoForm_Load);
            this.panelEquipmentInfo.ResumeLayout(false);
            this.splitContainerEditEquipmentInfo.Panel1.ResumeLayout(false);
            this.splitContainerEditEquipmentInfo.Panel1.PerformLayout();
            this.splitContainerEditEquipmentInfo.Panel2.ResumeLayout(false);
            this.splitContainerEditEquipmentInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEquipmentInfo;
        private System.Windows.Forms.ListView lvEquipmentInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderAge;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.SplitContainer splitContainerEditEquipmentInfo;
        private System.Windows.Forms.Label lblEquipmentName;
        private System.Windows.Forms.Label lbl_EquipmentName;
        private System.Windows.Forms.Label lbl_EquipmentDescription;
        private System.Windows.Forms.Label lbl_EquipmentAge;
        private System.Windows.Forms.TextBox txtEquipmentAge;
        private System.Windows.Forms.TextBox txtEquipmentDescription;
        private System.Windows.Forms.Button btnNewEquipment;
        private System.Windows.Forms.Button btnEditEquipment;
        private System.Windows.Forms.Button btnDeleteEquipment;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnResetEquipmentAge;

    }
}