namespace LFAutomationUI.LFUI
{
    partial class AlloyRecipeSelectForm
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
            this.groupBoxAlloyRecipeSelectBtn = new System.Windows.Forms.GroupBox();
            this.btnAlloyRecipeSelectClose = new System.Windows.Forms.Button();
            this.btnAlloyRecipeSelectCancel = new System.Windows.Forms.Button();
            this.btnAlloyRecipeSelectOK = new System.Windows.Forms.Button();
            this.lvChoosingMaterialList = new System.Windows.Forms.ListView();
            this.columnHeaderChoosingMaterialCode = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChoosingMaterialName = new System.Windows.Forms.ColumnHeader();
            this.lvChosenMaterialList = new System.Windows.Forms.ListView();
            this.columnHeaderChosenMaterialCode = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderChosenMateialName = new System.Windows.Forms.ColumnHeader();
            this.groupBoxAlloyRecipeSelectBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAlloyRecipeSelectBtn
            // 
            this.groupBoxAlloyRecipeSelectBtn.Controls.Add(this.btnAlloyRecipeSelectClose);
            this.groupBoxAlloyRecipeSelectBtn.Controls.Add(this.btnAlloyRecipeSelectCancel);
            this.groupBoxAlloyRecipeSelectBtn.Controls.Add(this.btnAlloyRecipeSelectOK);
            this.groupBoxAlloyRecipeSelectBtn.Location = new System.Drawing.Point(12, 408);
            this.groupBoxAlloyRecipeSelectBtn.Name = "groupBoxAlloyRecipeSelectBtn";
            this.groupBoxAlloyRecipeSelectBtn.Size = new System.Drawing.Size(538, 74);
            this.groupBoxAlloyRecipeSelectBtn.TabIndex = 1;
            this.groupBoxAlloyRecipeSelectBtn.TabStop = false;
            // 
            // btnAlloyRecipeSelectClose
            // 
            this.btnAlloyRecipeSelectClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAlloyRecipeSelectClose.Location = new System.Drawing.Point(313, 20);
            this.btnAlloyRecipeSelectClose.Name = "btnAlloyRecipeSelectClose";
            this.btnAlloyRecipeSelectClose.Size = new System.Drawing.Size(75, 43);
            this.btnAlloyRecipeSelectClose.TabIndex = 2;
            this.btnAlloyRecipeSelectClose.Text = "关闭界面";
            this.btnAlloyRecipeSelectClose.UseVisualStyleBackColor = true;
            this.btnAlloyRecipeSelectClose.Click += new System.EventHandler(this.btnAlloyRecipeSelectClose_Click);
            // 
            // btnAlloyRecipeSelectCancel
            // 
            this.btnAlloyRecipeSelectCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAlloyRecipeSelectCancel.Location = new System.Drawing.Point(232, 20);
            this.btnAlloyRecipeSelectCancel.Name = "btnAlloyRecipeSelectCancel";
            this.btnAlloyRecipeSelectCancel.Size = new System.Drawing.Size(75, 43);
            this.btnAlloyRecipeSelectCancel.TabIndex = 1;
            this.btnAlloyRecipeSelectCancel.Text = "取消";
            this.btnAlloyRecipeSelectCancel.UseVisualStyleBackColor = true;
            this.btnAlloyRecipeSelectCancel.Click += new System.EventHandler(this.btnAlloyRecipeSelectCancel_Click);
            // 
            // btnAlloyRecipeSelectOK
            // 
            this.btnAlloyRecipeSelectOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAlloyRecipeSelectOK.Location = new System.Drawing.Point(151, 20);
            this.btnAlloyRecipeSelectOK.Name = "btnAlloyRecipeSelectOK";
            this.btnAlloyRecipeSelectOK.Size = new System.Drawing.Size(75, 43);
            this.btnAlloyRecipeSelectOK.TabIndex = 0;
            this.btnAlloyRecipeSelectOK.Text = "确定";
            this.btnAlloyRecipeSelectOK.UseVisualStyleBackColor = true;
            this.btnAlloyRecipeSelectOK.Click += new System.EventHandler(this.btnAlloyRecipeSelectOK_Click);
            // 
            // lvChoosingMaterialList
            // 
            this.lvChoosingMaterialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChoosingMaterialCode,
            this.columnHeaderChoosingMaterialName});
            this.lvChoosingMaterialList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvChoosingMaterialList.FullRowSelect = true;
            this.lvChoosingMaterialList.GridLines = true;
            this.lvChoosingMaterialList.Location = new System.Drawing.Point(12, 12);
            this.lvChoosingMaterialList.Name = "lvChoosingMaterialList";
            this.lvChoosingMaterialList.Size = new System.Drawing.Size(263, 390);
            this.lvChoosingMaterialList.TabIndex = 2;
            this.lvChoosingMaterialList.UseCompatibleStateImageBehavior = false;
            this.lvChoosingMaterialList.View = System.Windows.Forms.View.Details;
            this.lvChoosingMaterialList.ItemActivate += new System.EventHandler(this.lvChoosingMaterialList_ItemActivate);
            // 
            // columnHeaderChoosingMaterialCode
            // 
            this.columnHeaderChoosingMaterialCode.Text = "物料代码";
            this.columnHeaderChoosingMaterialCode.Width = 100;
            // 
            // columnHeaderChoosingMaterialName
            // 
            this.columnHeaderChoosingMaterialName.Text = "物料名称";
            this.columnHeaderChoosingMaterialName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderChoosingMaterialName.Width = 150;
            // 
            // lvChosenMaterialList
            // 
            this.lvChosenMaterialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChosenMaterialCode,
            this.columnHeaderChosenMateialName});
            this.lvChosenMaterialList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvChosenMaterialList.FullRowSelect = true;
            this.lvChosenMaterialList.GridLines = true;
            this.lvChosenMaterialList.Location = new System.Drawing.Point(287, 12);
            this.lvChosenMaterialList.Name = "lvChosenMaterialList";
            this.lvChosenMaterialList.Size = new System.Drawing.Size(263, 390);
            this.lvChosenMaterialList.TabIndex = 3;
            this.lvChosenMaterialList.UseCompatibleStateImageBehavior = false;
            this.lvChosenMaterialList.View = System.Windows.Forms.View.Details;
            this.lvChosenMaterialList.ItemActivate += new System.EventHandler(this.lvChosenMaterialList_ItemActivate);
            // 
            // columnHeaderChosenMaterialCode
            // 
            this.columnHeaderChosenMaterialCode.Text = "物料代码";
            this.columnHeaderChosenMaterialCode.Width = 100;
            // 
            // columnHeaderChosenMateialName
            // 
            this.columnHeaderChosenMateialName.Text = "物料名称";
            this.columnHeaderChosenMateialName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderChosenMateialName.Width = 150;
            // 
            // AlloyRecipeSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 494);
            this.ControlBox = false;
            this.Controls.Add(this.lvChosenMaterialList);
            this.Controls.Add(this.lvChoosingMaterialList);
            this.Controls.Add(this.groupBoxAlloyRecipeSelectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlloyRecipeSelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择合金加料配方";
            this.Load += new System.EventHandler(this.AlloyRecipeSelectForm_Load);
            this.groupBoxAlloyRecipeSelectBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAlloyRecipeSelectBtn;
        private System.Windows.Forms.Button btnAlloyRecipeSelectClose;
        private System.Windows.Forms.Button btnAlloyRecipeSelectCancel;
        private System.Windows.Forms.Button btnAlloyRecipeSelectOK;
        private System.Windows.Forms.ListView lvChoosingMaterialList;
        private System.Windows.Forms.ColumnHeader columnHeaderChoosingMaterialCode;
        private System.Windows.Forms.ColumnHeader columnHeaderChoosingMaterialName;
        private System.Windows.Forms.ListView lvChosenMaterialList;
        private System.Windows.Forms.ColumnHeader columnHeaderChosenMaterialCode;
        private System.Windows.Forms.ColumnHeader columnHeaderChosenMateialName;
    }
}