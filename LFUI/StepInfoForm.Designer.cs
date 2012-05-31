namespace LFAutomationUI.LFUI
{
    partial class StepInfoForm
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
            this.splitContainerStepInfo = new System.Windows.Forms.SplitContainer();
            this.lvStepInfo = new System.Windows.Forms.ListView();
            this.colStepId = new System.Windows.Forms.ColumnHeader();
            this.colStepInfo = new System.Windows.Forms.ColumnHeader();
            this.splitContainerControlBox = new System.Windows.Forms.SplitContainer();
            this.txtStepName = new System.Windows.Forms.TextBox();
            this.lblStepInfo = new System.Windows.Forms.Label();
            this.txtStepId = new System.Windows.Forms.TextBox();
            this.lblStepId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnModifyStep = new System.Windows.Forms.Button();
            this.btnNewStep = new System.Windows.Forms.Button();
            this.splitContainerStepInfo.Panel1.SuspendLayout();
            this.splitContainerStepInfo.Panel2.SuspendLayout();
            this.splitContainerStepInfo.SuspendLayout();
            this.splitContainerControlBox.Panel1.SuspendLayout();
            this.splitContainerControlBox.Panel2.SuspendLayout();
            this.splitContainerControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerStepInfo
            // 
            this.splitContainerStepInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerStepInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStepInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStepInfo.Name = "splitContainerStepInfo";
            this.splitContainerStepInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStepInfo.Panel1
            // 
            this.splitContainerStepInfo.Panel1.Controls.Add(this.lvStepInfo);
            // 
            // splitContainerStepInfo.Panel2
            // 
            this.splitContainerStepInfo.Panel2.Controls.Add(this.splitContainerControlBox);
            this.splitContainerStepInfo.Size = new System.Drawing.Size(323, 299);
            this.splitContainerStepInfo.SplitterDistance = 224;
            this.splitContainerStepInfo.TabIndex = 0;
            // 
            // lvStepInfo
            // 
            this.lvStepInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStepId,
            this.colStepInfo});
            this.lvStepInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvStepInfo.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvStepInfo.FullRowSelect = true;
            this.lvStepInfo.GridLines = true;
            this.lvStepInfo.Location = new System.Drawing.Point(3, 3);
            this.lvStepInfo.MultiSelect = false;
            this.lvStepInfo.Name = "lvStepInfo";
            this.lvStepInfo.Size = new System.Drawing.Size(313, 214);
            this.lvStepInfo.TabIndex = 0;
            this.lvStepInfo.UseCompatibleStateImageBehavior = false;
            this.lvStepInfo.View = System.Windows.Forms.View.Details;
            this.lvStepInfo.SelectedIndexChanged += new System.EventHandler(this.lvStepInfo_SelectedIndexChanged);
            // 
            // colStepId
            // 
            this.colStepId.Text = "步骤代号";
            this.colStepId.Width = 100;
            // 
            // colStepInfo
            // 
            this.colStepInfo.Text = "步骤信息";
            this.colStepInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStepInfo.Width = 190;
            // 
            // splitContainerControlBox
            // 
            this.splitContainerControlBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlBox.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlBox.Name = "splitContainerControlBox";
            this.splitContainerControlBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerControlBox.Panel1
            // 
            this.splitContainerControlBox.Panel1.Controls.Add(this.txtStepName);
            this.splitContainerControlBox.Panel1.Controls.Add(this.lblStepInfo);
            this.splitContainerControlBox.Panel1.Controls.Add(this.txtStepId);
            this.splitContainerControlBox.Panel1.Controls.Add(this.lblStepId);
            // 
            // splitContainerControlBox.Panel2
            // 
            this.splitContainerControlBox.Panel2.Controls.Add(this.btnClose);
            this.splitContainerControlBox.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerControlBox.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerControlBox.Panel2.Controls.Add(this.btnModifyStep);
            this.splitContainerControlBox.Panel2.Controls.Add(this.btnNewStep);
            this.splitContainerControlBox.Size = new System.Drawing.Size(323, 71);
            this.splitContainerControlBox.SplitterDistance = 37;
            this.splitContainerControlBox.TabIndex = 0;
            // 
            // txtStepName
            // 
            this.txtStepName.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStepName.Location = new System.Drawing.Point(208, 4);
            this.txtStepName.Name = "txtStepName";
            this.txtStepName.ReadOnly = true;
            this.txtStepName.Size = new System.Drawing.Size(103, 25);
            this.txtStepName.TabIndex = 1;
            // 
            // lblStepInfo
            // 
            this.lblStepInfo.AutoSize = true;
            this.lblStepInfo.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStepInfo.Location = new System.Drawing.Point(125, 10);
            this.lblStepInfo.Name = "lblStepInfo";
            this.lblStepInfo.Size = new System.Drawing.Size(87, 15);
            this.lblStepInfo.TabIndex = 0;
            this.lblStepInfo.Text = "步骤信息：";
            // 
            // txtStepId
            // 
            this.txtStepId.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStepId.Location = new System.Drawing.Point(68, 4);
            this.txtStepId.Name = "txtStepId";
            this.txtStepId.ReadOnly = true;
            this.txtStepId.Size = new System.Drawing.Size(51, 25);
            this.txtStepId.TabIndex = 1;
            // 
            // lblStepId
            // 
            this.lblStepId.AutoSize = true;
            this.lblStepId.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStepId.Location = new System.Drawing.Point(3, 10);
            this.lblStepId.Name = "lblStepId";
            this.lblStepId.Size = new System.Drawing.Size(71, 15);
            this.lblStepId.TabIndex = 0;
            this.lblStepId.Text = "步骤号：";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(231, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(174, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(117, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(51, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnModifyStep
            // 
            this.btnModifyStep.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyStep.Location = new System.Drawing.Point(60, 3);
            this.btnModifyStep.Name = "btnModifyStep";
            this.btnModifyStep.Size = new System.Drawing.Size(51, 23);
            this.btnModifyStep.TabIndex = 0;
            this.btnModifyStep.Text = "修改";
            this.btnModifyStep.UseVisualStyleBackColor = true;
            this.btnModifyStep.Click += new System.EventHandler(this.btnModifyStep_Click);
            // 
            // btnNewStep
            // 
            this.btnNewStep.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewStep.Location = new System.Drawing.Point(3, 3);
            this.btnNewStep.Name = "btnNewStep";
            this.btnNewStep.Size = new System.Drawing.Size(51, 23);
            this.btnNewStep.TabIndex = 0;
            this.btnNewStep.Text = "新增";
            this.btnNewStep.UseVisualStyleBackColor = true;
            this.btnNewStep.Click += new System.EventHandler(this.btnNewStep_Click);
            // 
            // StepInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(323, 299);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerStepInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StepInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "步骤信息维护窗口";
            this.Load += new System.EventHandler(this.StepInfoForm_Load);
            this.splitContainerStepInfo.Panel1.ResumeLayout(false);
            this.splitContainerStepInfo.Panel2.ResumeLayout(false);
            this.splitContainerStepInfo.ResumeLayout(false);
            this.splitContainerControlBox.Panel1.ResumeLayout(false);
            this.splitContainerControlBox.Panel1.PerformLayout();
            this.splitContainerControlBox.Panel2.ResumeLayout(false);
            this.splitContainerControlBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerStepInfo;
        private System.Windows.Forms.ListView lvStepInfo;
        private System.Windows.Forms.ColumnHeader colStepId;
        private System.Windows.Forms.ColumnHeader colStepInfo;
        private System.Windows.Forms.SplitContainer splitContainerControlBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnModifyStep;
        private System.Windows.Forms.Button btnNewStep;
        private System.Windows.Forms.TextBox txtStepId;
        private System.Windows.Forms.Label lblStepId;
        private System.Windows.Forms.TextBox txtStepName;
        private System.Windows.Forms.Label lblStepInfo;
    }
}