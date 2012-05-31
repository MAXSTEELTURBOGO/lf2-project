namespace LFAutomationUI.LFUI
{
    partial class SourceForm
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
            this.splitContainerSiloMaintenanceForm = new System.Windows.Forms.SplitContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lvSourceInfo = new System.Windows.Forms.ListView();
            this.colHeaderSourceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderSourceId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderMaterialName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbSourceType = new System.Windows.Forms.ComboBox();
            this.lblSourceType = new System.Windows.Forms.Label();
            this.cmbMaterialName = new System.Windows.Forms.ComboBox();
            this.txtSourceId = new System.Windows.Forms.TextBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblSiloId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnModifyElementInfo = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.splitContainerSiloMaintenanceForm.Panel1.SuspendLayout();
            this.splitContainerSiloMaintenanceForm.Panel2.SuspendLayout();
            this.splitContainerSiloMaintenanceForm.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerSiloMaintenanceForm
            // 
            this.splitContainerSiloMaintenanceForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerSiloMaintenanceForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSiloMaintenanceForm.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSiloMaintenanceForm.Name = "splitContainerSiloMaintenanceForm";
            this.splitContainerSiloMaintenanceForm.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSiloMaintenanceForm.Panel1
            // 
            this.splitContainerSiloMaintenanceForm.Panel1.Controls.Add(this.splitContainer);
            // 
            // splitContainerSiloMaintenanceForm.Panel2
            // 
            this.splitContainerSiloMaintenanceForm.Panel2.Controls.Add(this.btnClose);
            this.splitContainerSiloMaintenanceForm.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerSiloMaintenanceForm.Panel2.Controls.Add(this.btnModifyElementInfo);
            this.splitContainerSiloMaintenanceForm.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerSiloMaintenanceForm.Size = new System.Drawing.Size(534, 420);
            this.splitContainerSiloMaintenanceForm.SplitterDistance = 361;
            this.splitContainerSiloMaintenanceForm.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvSourceInfo);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cmbSourceType);
            this.splitContainer.Panel2.Controls.Add(this.lblSourceType);
            this.splitContainer.Panel2.Controls.Add(this.cmbMaterialName);
            this.splitContainer.Panel2.Controls.Add(this.txtSourceId);
            this.splitContainer.Panel2.Controls.Add(this.lblMaterialName);
            this.splitContainer.Panel2.Controls.Add(this.lblSiloId);
            this.splitContainer.Size = new System.Drawing.Size(534, 361);
            this.splitContainer.SplitterDistance = 312;
            this.splitContainer.TabIndex = 1;
            // 
            // lvSourceInfo
            // 
            this.lvSourceInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderSourceType,
            this.colHeaderSourceId,
            this.colHeaderMaterialName});
            this.lvSourceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSourceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvSourceInfo.FullRowSelect = true;
            this.lvSourceInfo.GridLines = true;
            this.lvSourceInfo.Location = new System.Drawing.Point(0, 0);
            this.lvSourceInfo.MultiSelect = false;
            this.lvSourceInfo.Name = "lvSourceInfo";
            this.lvSourceInfo.Size = new System.Drawing.Size(530, 308);
            this.lvSourceInfo.TabIndex = 1;
            this.lvSourceInfo.UseCompatibleStateImageBehavior = false;
            this.lvSourceInfo.View = System.Windows.Forms.View.Details;
            this.lvSourceInfo.SelectedIndexChanged += new System.EventHandler(this.lvSiloInfo_SelectedIndexChanged);
            // 
            // colHeaderSourceType
            // 
            this.colHeaderSourceType.Text = "物料来源类型";
            this.colHeaderSourceType.Width = 120;
            // 
            // colHeaderSourceId
            // 
            this.colHeaderSourceId.Text = "来源号";
            this.colHeaderSourceId.Width = 150;
            // 
            // colHeaderMaterialName
            // 
            this.colHeaderMaterialName.Text = "物料名称";
            this.colHeaderMaterialName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeaderMaterialName.Width = 290;
            // 
            // cmbSourceType
            // 
            this.cmbSourceType.Enabled = false;
            this.cmbSourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSourceType.FormattingEnabled = true;
            this.cmbSourceType.Items.AddRange(new object[] {
            "料仓",
            "喂丝机"});
            this.cmbSourceType.Location = new System.Drawing.Point(113, 8);
            this.cmbSourceType.Name = "cmbSourceType";
            this.cmbSourceType.Size = new System.Drawing.Size(100, 28);
            this.cmbSourceType.TabIndex = 5;
            // 
            // lblSourceType
            // 
            this.lblSourceType.AutoSize = true;
            this.lblSourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceType.Location = new System.Drawing.Point(3, 12);
            this.lblSourceType.Name = "lblSourceType";
            this.lblSourceType.Size = new System.Drawing.Size(121, 20);
            this.lblSourceType.TabIndex = 4;
            this.lblSourceType.Text = "物料来源类型：";
            // 
            // cmbMaterialName
            // 
            this.cmbMaterialName.Enabled = false;
            this.cmbMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMaterialName.FormattingEnabled = true;
            this.cmbMaterialName.Location = new System.Drawing.Point(416, 8);
            this.cmbMaterialName.Name = "cmbMaterialName";
            this.cmbMaterialName.Size = new System.Drawing.Size(160, 28);
            this.cmbMaterialName.TabIndex = 3;
            // 
            // txtSourceId
            // 
            this.txtSourceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceId.Location = new System.Drawing.Point(278, 9);
            this.txtSourceId.Name = "txtSourceId";
            this.txtSourceId.ReadOnly = true;
            this.txtSourceId.Size = new System.Drawing.Size(55, 26);
            this.txtSourceId.TabIndex = 1;
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialName.Location = new System.Drawing.Point(339, 12);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(89, 20);
            this.lblMaterialName.TabIndex = 2;
            this.lblMaterialName.Text = "物料名称：";
            // 
            // lblSiloId
            // 
            this.lblSiloId.AutoSize = true;
            this.lblSiloId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSiloId.Location = new System.Drawing.Point(213, 12);
            this.lblSiloId.Name = "lblSiloId";
            this.lblSiloId.Size = new System.Drawing.Size(73, 20);
            this.lblSiloId.TabIndex = 0;
            this.lblSiloId.Text = "料仓号：";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(354, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 47);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(237, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 47);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModifyElementInfo
            // 
            this.btnModifyElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyElementInfo.Location = new System.Drawing.Point(6, 2);
            this.btnModifyElementInfo.Name = "btnModifyElementInfo";
            this.btnModifyElementInfo.Size = new System.Drawing.Size(90, 47);
            this.btnModifyElementInfo.TabIndex = 9;
            this.btnModifyElementInfo.Text = "修  改";
            this.btnModifyElementInfo.UseVisualStyleBackColor = true;
            this.btnModifyElementInfo.Click += new System.EventHandler(this.btnModifyElementInfo_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(120, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 47);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "确  认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // SourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(534, 420);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerSiloMaintenanceForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SourceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "料仓维护窗口";
            this.Load += new System.EventHandler(this.SourceForm_Load);
            this.splitContainerSiloMaintenanceForm.Panel1.ResumeLayout(false);
            this.splitContainerSiloMaintenanceForm.Panel2.ResumeLayout(false);
            this.splitContainerSiloMaintenanceForm.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerSiloMaintenanceForm;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnModifyElementInfo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSourceId;
        private System.Windows.Forms.Label lblSiloId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbMaterialName;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.ListView lvSourceInfo;
        private System.Windows.Forms.ColumnHeader colHeaderSourceId;
        private System.Windows.Forms.ColumnHeader colHeaderMaterialName;
        private System.Windows.Forms.ColumnHeader colHeaderSourceType;
        private System.Windows.Forms.ComboBox cmbSourceType;
        private System.Windows.Forms.Label lblSourceType;

    }
}