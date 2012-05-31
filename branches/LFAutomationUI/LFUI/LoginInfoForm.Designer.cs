namespace LFAutomationUI.LFUI
{
    partial class LoginInfoForm
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
            this.lvLoginInfo = new System.Windows.Forms.ListView();
            this.columnHeaderMsgId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderMsgTimeStamp = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUserName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderClassId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLoginTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLogoffTime = new System.Windows.Forms.ColumnHeader();
            this.panelOperation = new System.Windows.Forms.Panel();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.groupBoxTimeSpan = new System.Windows.Forms.GroupBox();
            this.btnSearchByTimeSpan = new System.Windows.Forms.Button();
            this.mTextBoxEndTime = new System.Windows.Forms.MaskedTextBox();
            this.mTextBoxStartTime = new System.Windows.Forms.MaskedTextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.btnSearchByUserName = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.panelOperation.SuspendLayout();
            this.groupBoxTimeSpan.SuspendLayout();
            this.groupBoxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLoginInfo
            // 
            this.lvLoginInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMsgId,
            this.columnHeaderMsgTimeStamp,
            this.columnHeaderUserName,
            this.columnHeaderClassId,
            this.columnHeaderLoginTime,
            this.columnHeaderLogoffTime});
            this.lvLoginInfo.FullRowSelect = true;
            this.lvLoginInfo.GridLines = true;
            this.lvLoginInfo.Location = new System.Drawing.Point(3, 3);
            this.lvLoginInfo.Name = "lvLoginInfo";
            this.lvLoginInfo.Size = new System.Drawing.Size(635, 431);
            this.lvLoginInfo.TabIndex = 0;
            this.lvLoginInfo.UseCompatibleStateImageBehavior = false;
            this.lvLoginInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderMsgId
            // 
            this.columnHeaderMsgId.Text = "流水号";
            this.columnHeaderMsgId.Width = 67;
            // 
            // columnHeaderMsgTimeStamp
            // 
            this.columnHeaderMsgTimeStamp.Text = "时间戳";
            this.columnHeaderMsgTimeStamp.Width = 90;
            // 
            // columnHeaderUserName
            // 
            this.columnHeaderUserName.Text = "用户名";
            this.columnHeaderUserName.Width = 78;
            // 
            // columnHeaderClassId
            // 
            this.columnHeaderClassId.Text = "班组";
            this.columnHeaderClassId.Width = 51;
            // 
            // columnHeaderLoginTime
            // 
            this.columnHeaderLoginTime.Text = "登录时间";
            this.columnHeaderLoginTime.Width = 152;
            // 
            // columnHeaderLogoffTime
            // 
            this.columnHeaderLogoffTime.Text = "退出时间";
            this.columnHeaderLogoffTime.Width = 176;
            // 
            // panelOperation
            // 
            this.panelOperation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOperation.Controls.Add(this.btnShowAll);
            this.panelOperation.Controls.Add(this.btnCloseWindow);
            this.panelOperation.Controls.Add(this.groupBoxTimeSpan);
            this.panelOperation.Controls.Add(this.groupBoxUser);
            this.panelOperation.Location = new System.Drawing.Point(3, 442);
            this.panelOperation.Name = "panelOperation";
            this.panelOperation.Size = new System.Drawing.Size(635, 139);
            this.panelOperation.TabIndex = 1;
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Location = new System.Drawing.Point(506, 90);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(106, 36);
            this.btnCloseWindow.TabIndex = 2;
            this.btnCloseWindow.Text = "关闭窗口";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // groupBoxTimeSpan
            // 
            this.groupBoxTimeSpan.Controls.Add(this.btnSearchByTimeSpan);
            this.groupBoxTimeSpan.Controls.Add(this.mTextBoxEndTime);
            this.groupBoxTimeSpan.Controls.Add(this.mTextBoxStartTime);
            this.groupBoxTimeSpan.Controls.Add(this.lblEndTime);
            this.groupBoxTimeSpan.Controls.Add(this.lblStartTime);
            this.groupBoxTimeSpan.Location = new System.Drawing.Point(3, 4);
            this.groupBoxTimeSpan.Name = "groupBoxTimeSpan";
            this.groupBoxTimeSpan.Size = new System.Drawing.Size(308, 128);
            this.groupBoxTimeSpan.TabIndex = 1;
            this.groupBoxTimeSpan.TabStop = false;
            this.groupBoxTimeSpan.Text = "按时间段查找";
            // 
            // btnSearchByTimeSpan
            // 
            this.btnSearchByTimeSpan.Location = new System.Drawing.Point(160, 86);
            this.btnSearchByTimeSpan.Name = "btnSearchByTimeSpan";
            this.btnSearchByTimeSpan.Size = new System.Drawing.Size(113, 36);
            this.btnSearchByTimeSpan.TabIndex = 6;
            this.btnSearchByTimeSpan.Text = "按时间段查询";
            this.btnSearchByTimeSpan.UseVisualStyleBackColor = true;
            this.btnSearchByTimeSpan.Click += new System.EventHandler(this.btnSearchByTimeSpan_Click);
            // 
            // mTextBoxEndTime
            // 
            this.mTextBoxEndTime.Location = new System.Drawing.Point(87, 55);
            this.mTextBoxEndTime.Mask = "0000年90月90日 90时00分";
            this.mTextBoxEndTime.Name = "mTextBoxEndTime";
            this.mTextBoxEndTime.Size = new System.Drawing.Size(186, 23);
            this.mTextBoxEndTime.TabIndex = 5;
            this.mTextBoxEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // mTextBoxStartTime
            // 
            this.mTextBoxStartTime.Location = new System.Drawing.Point(87, 25);
            this.mTextBoxStartTime.Mask = "0000年90月90日 90时00分";
            this.mTextBoxStartTime.Name = "mTextBoxStartTime";
            this.mTextBoxStartTime.Size = new System.Drawing.Size(186, 23);
            this.mTextBoxStartTime.TabIndex = 4;
            this.mTextBoxStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(18, 58);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(63, 14);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "终止时间";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(18, 28);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(63, 14);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "起始时间";
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.btnSearchByUserName);
            this.groupBoxUser.Controls.Add(this.txtUserName);
            this.groupBoxUser.Controls.Add(this.lblUserName);
            this.groupBoxUser.Location = new System.Drawing.Point(321, 4);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(307, 61);
            this.groupBoxUser.TabIndex = 0;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "按用户查找";
            // 
            // btnSearchByUserName
            // 
            this.btnSearchByUserName.Location = new System.Drawing.Point(185, 17);
            this.btnSearchByUserName.Name = "btnSearchByUserName";
            this.btnSearchByUserName.Size = new System.Drawing.Size(106, 36);
            this.btnSearchByUserName.TabIndex = 7;
            this.btnSearchByUserName.Text = "按用户查询";
            this.btnSearchByUserName.UseVisualStyleBackColor = true;
            this.btnSearchByUserName.Click += new System.EventHandler(this.btnSearchByUserName_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(61, 25);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(118, 23);
            this.txtUserName.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(6, 31);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(49, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(382, 90);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(106, 36);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // LoginInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseWindow;
            this.ClientSize = new System.Drawing.Size(636, 582);
            this.ControlBox = false;
            this.Controls.Add(this.panelOperation);
            this.Controls.Add(this.lvLoginInfo);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户登录日志";
            this.Load += new System.EventHandler(this.LoginInfoForm_Load);
            this.panelOperation.ResumeLayout(false);
            this.groupBoxTimeSpan.ResumeLayout(false);
            this.groupBoxTimeSpan.PerformLayout();
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLoginInfo;
        private System.Windows.Forms.Panel panelOperation;
        private System.Windows.Forms.ColumnHeader columnHeaderMsgId;
        private System.Windows.Forms.ColumnHeader columnHeaderMsgTimeStamp;
        private System.Windows.Forms.ColumnHeader columnHeaderUserName;
        private System.Windows.Forms.ColumnHeader columnHeaderClassId;
        private System.Windows.Forms.ColumnHeader columnHeaderLoginTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLogoffTime;
        private System.Windows.Forms.GroupBox groupBoxTimeSpan;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.MaskedTextBox mTextBoxEndTime;
        private System.Windows.Forms.MaskedTextBox mTextBoxStartTime;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSearchByTimeSpan;
        private System.Windows.Forms.Button btnSearchByUserName;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btnShowAll;
    }
}