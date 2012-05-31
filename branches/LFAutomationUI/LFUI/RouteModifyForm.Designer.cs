namespace LFAutomationUI.LFUI
{
    partial class RouteModifyForm
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
            this.splitContainerRouteInfo = new System.Windows.Forms.SplitContainer();
            this.gBoxRouteInfoList = new System.Windows.Forms.GroupBox();
            this.lvRouteInfoList = new System.Windows.Forms.ListView();
            this.routeCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.routeDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerRouteInfoOperate = new System.Windows.Forms.SplitContainer();
            this.gBoxRouteInfoDesc = new System.Windows.Forms.GroupBox();
            this.txtRouteInfoDesc = new System.Windows.Forms.TextBox();
            this.btnConfirmRoute = new System.Windows.Forms.Button();
            this.btnCloseRoute = new System.Windows.Forms.Button();
            this.btnClearRoute = new System.Windows.Forms.Button();
            this.splitContainerRouteInfo.Panel1.SuspendLayout();
            this.splitContainerRouteInfo.Panel2.SuspendLayout();
            this.splitContainerRouteInfo.SuspendLayout();
            this.gBoxRouteInfoList.SuspendLayout();
            this.splitContainerRouteInfoOperate.Panel1.SuspendLayout();
            this.splitContainerRouteInfoOperate.Panel2.SuspendLayout();
            this.splitContainerRouteInfoOperate.SuspendLayout();
            this.gBoxRouteInfoDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerRouteInfo
            // 
            this.splitContainerRouteInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerRouteInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRouteInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRouteInfo.Name = "splitContainerRouteInfo";
            this.splitContainerRouteInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRouteInfo.Panel1
            // 
            this.splitContainerRouteInfo.Panel1.Controls.Add(this.gBoxRouteInfoList);
            // 
            // splitContainerRouteInfo.Panel2
            // 
            this.splitContainerRouteInfo.Panel2.Controls.Add(this.splitContainerRouteInfoOperate);
            this.splitContainerRouteInfo.Size = new System.Drawing.Size(300, 380);
            this.splitContainerRouteInfo.SplitterDistance = 247;
            this.splitContainerRouteInfo.SplitterWidth = 5;
            this.splitContainerRouteInfo.TabIndex = 0;
            // 
            // gBoxRouteInfoList
            // 
            this.gBoxRouteInfoList.Controls.Add(this.lvRouteInfoList);
            this.gBoxRouteInfoList.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxRouteInfoList.Location = new System.Drawing.Point(3, 3);
            this.gBoxRouteInfoList.Name = "gBoxRouteInfoList";
            this.gBoxRouteInfoList.Size = new System.Drawing.Size(292, 239);
            this.gBoxRouteInfoList.TabIndex = 0;
            this.gBoxRouteInfoList.TabStop = false;
            this.gBoxRouteInfoList.Text = "路径列表";
            // 
            // lvRouteInfoList
            // 
            this.lvRouteInfoList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvRouteInfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.routeCode,
            this.routeDesc});
            this.lvRouteInfoList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvRouteInfoList.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvRouteInfoList.FullRowSelect = true;
            this.lvRouteInfoList.GridLines = true;
            this.lvRouteInfoList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRouteInfoList.Location = new System.Drawing.Point(8, 20);
            this.lvRouteInfoList.MultiSelect = false;
            this.lvRouteInfoList.Name = "lvRouteInfoList";
            this.lvRouteInfoList.Size = new System.Drawing.Size(276, 213);
            this.lvRouteInfoList.TabIndex = 1;
            this.lvRouteInfoList.UseCompatibleStateImageBehavior = false;
            this.lvRouteInfoList.View = System.Windows.Forms.View.Details;
            this.lvRouteInfoList.ItemActivate += new System.EventHandler(this.lvRouteInfoList_ItemActivate);
            // 
            // routeCode
            // 
            this.routeCode.Text = "路径代码";
            this.routeCode.Width = 80;
            // 
            // routeDesc
            // 
            this.routeDesc.Text = "路径描述";
            this.routeDesc.Width = 180;
            // 
            // splitContainerRouteInfoOperate
            // 
            this.splitContainerRouteInfoOperate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerRouteInfoOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRouteInfoOperate.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRouteInfoOperate.Name = "splitContainerRouteInfoOperate";
            this.splitContainerRouteInfoOperate.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRouteInfoOperate.Panel1
            // 
            this.splitContainerRouteInfoOperate.Panel1.Controls.Add(this.gBoxRouteInfoDesc);
            // 
            // splitContainerRouteInfoOperate.Panel2
            // 
            this.splitContainerRouteInfoOperate.Panel2.Controls.Add(this.btnConfirmRoute);
            this.splitContainerRouteInfoOperate.Panel2.Controls.Add(this.btnCloseRoute);
            this.splitContainerRouteInfoOperate.Panel2.Controls.Add(this.btnClearRoute);
            this.splitContainerRouteInfoOperate.Size = new System.Drawing.Size(300, 128);
            this.splitContainerRouteInfoOperate.SplitterDistance = 74;
            this.splitContainerRouteInfoOperate.SplitterWidth = 5;
            this.splitContainerRouteInfoOperate.TabIndex = 0;
            // 
            // gBoxRouteInfoDesc
            // 
            this.gBoxRouteInfoDesc.Controls.Add(this.txtRouteInfoDesc);
            this.gBoxRouteInfoDesc.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxRouteInfoDesc.Location = new System.Drawing.Point(3, 3);
            this.gBoxRouteInfoDesc.Name = "gBoxRouteInfoDesc";
            this.gBoxRouteInfoDesc.Size = new System.Drawing.Size(292, 66);
            this.gBoxRouteInfoDesc.TabIndex = 0;
            this.gBoxRouteInfoDesc.TabStop = false;
            this.gBoxRouteInfoDesc.Text = "冶炼路径";
            // 
            // txtRouteInfoDesc
            // 
            this.txtRouteInfoDesc.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRouteInfoDesc.Location = new System.Drawing.Point(6, 20);
            this.txtRouteInfoDesc.Multiline = true;
            this.txtRouteInfoDesc.Name = "txtRouteInfoDesc";
            this.txtRouteInfoDesc.ReadOnly = true;
            this.txtRouteInfoDesc.Size = new System.Drawing.Size(280, 36);
            this.txtRouteInfoDesc.TabIndex = 1;
            // 
            // btnConfirmRoute
            // 
            this.btnConfirmRoute.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmRoute.Location = new System.Drawing.Point(8, 3);
            this.btnConfirmRoute.Name = "btnConfirmRoute";
            this.btnConfirmRoute.Size = new System.Drawing.Size(75, 40);
            this.btnConfirmRoute.TabIndex = 1;
            this.btnConfirmRoute.Text = "确 认";
            this.btnConfirmRoute.UseVisualStyleBackColor = true;
            this.btnConfirmRoute.Click += new System.EventHandler(this.btnConfirmRoute_Click);
            // 
            // btnCloseRoute
            // 
            this.btnCloseRoute.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseRoute.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseRoute.Location = new System.Drawing.Point(190, 3);
            this.btnCloseRoute.Name = "btnCloseRoute";
            this.btnCloseRoute.Size = new System.Drawing.Size(101, 40);
            this.btnCloseRoute.TabIndex = 0;
            this.btnCloseRoute.Text = "关闭窗口";
            this.btnCloseRoute.UseVisualStyleBackColor = true;
            this.btnCloseRoute.Click += new System.EventHandler(this.btnCloseRoute_Click);
            // 
            // btnClearRoute
            // 
            this.btnClearRoute.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearRoute.Location = new System.Drawing.Point(99, 3);
            this.btnClearRoute.Name = "btnClearRoute";
            this.btnClearRoute.Size = new System.Drawing.Size(75, 40);
            this.btnClearRoute.TabIndex = 0;
            this.btnClearRoute.Text = "清 空";
            this.btnClearRoute.UseVisualStyleBackColor = true;
            this.btnClearRoute.Click += new System.EventHandler(this.btnClearRoute_Click);
            // 
            // RouteModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseRoute;
            this.ClientSize = new System.Drawing.Size(300, 380);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerRouteInfo);
            this.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RouteModifyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RouteModifyInfo";
            this.Load += new System.EventHandler(this.RouteModifyForm_Load);
            this.splitContainerRouteInfo.Panel1.ResumeLayout(false);
            this.splitContainerRouteInfo.Panel2.ResumeLayout(false);
            this.splitContainerRouteInfo.ResumeLayout(false);
            this.gBoxRouteInfoList.ResumeLayout(false);
            this.splitContainerRouteInfoOperate.Panel1.ResumeLayout(false);
            this.splitContainerRouteInfoOperate.Panel2.ResumeLayout(false);
            this.splitContainerRouteInfoOperate.ResumeLayout(false);
            this.gBoxRouteInfoDesc.ResumeLayout(false);
            this.gBoxRouteInfoDesc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerRouteInfo;
        private System.Windows.Forms.SplitContainer splitContainerRouteInfoOperate;
        private System.Windows.Forms.GroupBox gBoxRouteInfoDesc;
        private System.Windows.Forms.TextBox txtRouteInfoDesc;
        private System.Windows.Forms.GroupBox gBoxRouteInfoList;
        private System.Windows.Forms.ListView lvRouteInfoList;
        private System.Windows.Forms.ColumnHeader routeCode;
        private System.Windows.Forms.ColumnHeader routeDesc;
        private System.Windows.Forms.Button btnConfirmRoute;
        private System.Windows.Forms.Button btnClearRoute;
        private System.Windows.Forms.Button btnCloseRoute;
    }
}