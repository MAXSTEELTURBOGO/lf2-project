namespace LFAutomationUI.LFUI
{
    partial class MaterialRecipeForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerRecipeMaintain = new System.Windows.Forms.SplitContainer();
            this.lvChosenMaterialList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvChoosingMaterialList = new System.Windows.Forms.ListView();
            this.colLvMaterialId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvMaterialName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbRecipeType = new System.Windows.Forms.ComboBox();
            this.cmbRecipeId = new System.Windows.Forms.ComboBox();
            this.lblRecipeType = new System.Windows.Forms.Label();
            this.lblRecipeDesc = new System.Windows.Forms.Label();
            this.lblRecipeId = new System.Windows.Forms.Label();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.txtRecipeDesc = new System.Windows.Forms.TextBox();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.btnDelRecipe = new System.Windows.Forms.Button();
            this.btnModifyRecipe = new System.Windows.Forms.Button();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainerRecipeMaintain.Panel1.SuspendLayout();
            this.splitContainerRecipeMaintain.Panel2.SuspendLayout();
            this.splitContainerRecipeMaintain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerRecipeMaintain);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.btnClose);
            this.splitContainerMain.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerMain.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddRecipe);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelRecipe);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModifyRecipe);
            this.splitContainerMain.Size = new System.Drawing.Size(792, 566);
            this.splitContainerMain.SplitterDistance = 515;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerRecipeMaintain
            // 
            this.splitContainerRecipeMaintain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerRecipeMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRecipeMaintain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRecipeMaintain.Name = "splitContainerRecipeMaintain";
            this.splitContainerRecipeMaintain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRecipeMaintain.Panel1
            // 
            this.splitContainerRecipeMaintain.Panel1.Controls.Add(this.lvChosenMaterialList);
            this.splitContainerRecipeMaintain.Panel1.Controls.Add(this.lvChoosingMaterialList);
            // 
            // splitContainerRecipeMaintain.Panel2
            // 
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.cmbRecipeType);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.cmbRecipeId);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.lblRecipeType);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.lblRecipeDesc);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.lblRecipeId);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.lblRecipeName);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.txtRecipeDesc);
            this.splitContainerRecipeMaintain.Panel2.Controls.Add(this.txtRecipeName);
            this.splitContainerRecipeMaintain.Size = new System.Drawing.Size(792, 515);
            this.splitContainerRecipeMaintain.SplitterDistance = 441;
            this.splitContainerRecipeMaintain.TabIndex = 0;
            // 
            // lvChosenMaterialList
            // 
            this.lvChosenMaterialList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvChosenMaterialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvChosenMaterialList.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvChosenMaterialList.Enabled = false;
            this.lvChosenMaterialList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvChosenMaterialList.FullRowSelect = true;
            this.lvChosenMaterialList.GridLines = true;
            this.lvChosenMaterialList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChosenMaterialList.Location = new System.Drawing.Point(451, 0);
            this.lvChosenMaterialList.MultiSelect = false;
            this.lvChosenMaterialList.Name = "lvChosenMaterialList";
            this.lvChosenMaterialList.Size = new System.Drawing.Size(337, 437);
            this.lvChosenMaterialList.TabIndex = 1;
            this.lvChosenMaterialList.UseCompatibleStateImageBehavior = false;
            this.lvChosenMaterialList.View = System.Windows.Forms.View.Details;
            this.lvChosenMaterialList.ItemActivate += new System.EventHandler(this.lvChosenMaterialList_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "物料代码";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "物料名称";
            this.columnHeader2.Width = 203;
            // 
            // lvChoosingMaterialList
            // 
            this.lvChoosingMaterialList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvChoosingMaterialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvMaterialId,
            this.colLvMaterialName});
            this.lvChoosingMaterialList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvChoosingMaterialList.Enabled = false;
            this.lvChoosingMaterialList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvChoosingMaterialList.FullRowSelect = true;
            this.lvChoosingMaterialList.GridLines = true;
            this.lvChoosingMaterialList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChoosingMaterialList.Location = new System.Drawing.Point(0, 0);
            this.lvChoosingMaterialList.MultiSelect = false;
            this.lvChoosingMaterialList.Name = "lvChoosingMaterialList";
            this.lvChoosingMaterialList.Size = new System.Drawing.Size(337, 437);
            this.lvChoosingMaterialList.TabIndex = 0;
            this.lvChoosingMaterialList.UseCompatibleStateImageBehavior = false;
            this.lvChoosingMaterialList.View = System.Windows.Forms.View.Details;
            this.lvChoosingMaterialList.ItemActivate += new System.EventHandler(this.lvChoosingMaterialList_ItemActivate);
            // 
            // colLvMaterialId
            // 
            this.colLvMaterialId.Text = "物料代码";
            this.colLvMaterialId.Width = 130;
            // 
            // colLvMaterialName
            // 
            this.colLvMaterialName.Text = "物料名称";
            this.colLvMaterialName.Width = 203;
            // 
            // cmbRecipeType
            // 
            this.cmbRecipeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeType.Enabled = false;
            this.cmbRecipeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecipeType.FormattingEnabled = true;
            this.cmbRecipeType.Items.AddRange(new object[] {
            "ALLOY",
            "SLAG",
            ""});
            this.cmbRecipeType.Location = new System.Drawing.Point(608, 3);
            this.cmbRecipeType.Name = "cmbRecipeType";
            this.cmbRecipeType.Size = new System.Drawing.Size(147, 28);
            this.cmbRecipeType.TabIndex = 2;
            this.cmbRecipeType.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeType_SelectedIndexChanged);
            // 
            // cmbRecipeId
            // 
            this.cmbRecipeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecipeId.FormattingEnabled = true;
            this.cmbRecipeId.Location = new System.Drawing.Point(113, 3);
            this.cmbRecipeId.Name = "cmbRecipeId";
            this.cmbRecipeId.Size = new System.Drawing.Size(79, 28);
            this.cmbRecipeId.TabIndex = 2;
            this.cmbRecipeId.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeId_SelectedIndexChanged);
            // 
            // lblRecipeType
            // 
            this.lblRecipeType.AutoSize = true;
            this.lblRecipeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeType.Location = new System.Drawing.Point(534, 7);
            this.lblRecipeType.Name = "lblRecipeType";
            this.lblRecipeType.Size = new System.Drawing.Size(73, 20);
            this.lblRecipeType.TabIndex = 1;
            this.lblRecipeType.Text = "配方类型";
            // 
            // lblRecipeDesc
            // 
            this.lblRecipeDesc.AutoSize = true;
            this.lblRecipeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeDesc.Location = new System.Drawing.Point(33, 39);
            this.lblRecipeDesc.Name = "lblRecipeDesc";
            this.lblRecipeDesc.Size = new System.Drawing.Size(73, 20);
            this.lblRecipeDesc.TabIndex = 1;
            this.lblRecipeDesc.Text = "配方描述";
            // 
            // lblRecipeId
            // 
            this.lblRecipeId.AutoSize = true;
            this.lblRecipeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeId.Location = new System.Drawing.Point(33, 7);
            this.lblRecipeId.Name = "lblRecipeId";
            this.lblRecipeId.Size = new System.Drawing.Size(57, 20);
            this.lblRecipeId.TabIndex = 1;
            this.lblRecipeId.Text = "配方号";
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeName.Location = new System.Drawing.Point(225, 7);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(73, 20);
            this.lblRecipeName.TabIndex = 1;
            this.lblRecipeName.Text = "配方名称";
            // 
            // txtRecipeDesc
            // 
            this.txtRecipeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipeDesc.Location = new System.Drawing.Point(112, 36);
            this.txtRecipeDesc.MaxLength = 99;
            this.txtRecipeDesc.Name = "txtRecipeDesc";
            this.txtRecipeDesc.ReadOnly = true;
            this.txtRecipeDesc.Size = new System.Drawing.Size(643, 26);
            this.txtRecipeDesc.TabIndex = 0;
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipeName.Location = new System.Drawing.Point(304, 4);
            this.txtRecipeName.MaxLength = 15;
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.ReadOnly = true;
            this.txtRecipeName.Size = new System.Drawing.Size(186, 26);
            this.txtRecipeName.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(656, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(525, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(394, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(131, 40);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确 认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRecipe.Location = new System.Drawing.Point(1, 1);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(131, 40);
            this.btnAddRecipe.TabIndex = 0;
            this.btnAddRecipe.Text = "新 增";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // btnDelRecipe
            // 
            this.btnDelRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelRecipe.Location = new System.Drawing.Point(263, 1);
            this.btnDelRecipe.Name = "btnDelRecipe";
            this.btnDelRecipe.Size = new System.Drawing.Size(131, 40);
            this.btnDelRecipe.TabIndex = 0;
            this.btnDelRecipe.Text = "删 除";
            this.btnDelRecipe.UseVisualStyleBackColor = true;
            this.btnDelRecipe.Click += new System.EventHandler(this.btnDelRecipe_Click);
            // 
            // btnModifyRecipe
            // 
            this.btnModifyRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyRecipe.Location = new System.Drawing.Point(132, 1);
            this.btnModifyRecipe.Name = "btnModifyRecipe";
            this.btnModifyRecipe.Size = new System.Drawing.Size(131, 40);
            this.btnModifyRecipe.TabIndex = 0;
            this.btnModifyRecipe.Text = "修 改";
            this.btnModifyRecipe.UseVisualStyleBackColor = true;
            this.btnModifyRecipe.Click += new System.EventHandler(this.btnModifyRecipe_Click);
            // 
            // MaterialRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialRecipeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物料配方维护界面";
            this.Load += new System.EventHandler(this.MaterialRecipeForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerRecipeMaintain.Panel1.ResumeLayout(false);
            this.splitContainerRecipeMaintain.Panel2.ResumeLayout(false);
            this.splitContainerRecipeMaintain.Panel2.PerformLayout();
            this.splitContainerRecipeMaintain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerRecipeMaintain;
        private System.Windows.Forms.ListView lvChoosingMaterialList;
        private System.Windows.Forms.ColumnHeader colLvMaterialId;
        private System.Windows.Forms.ListView lvChosenMaterialList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader colLvMaterialName;
        private System.Windows.Forms.ComboBox cmbRecipeId;
        private System.Windows.Forms.Label lblRecipeDesc;
        private System.Windows.Forms.Label lblRecipeId;
        private System.Windows.Forms.Label lblRecipeName;
        private System.Windows.Forms.TextBox txtRecipeDesc;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.ComboBox cmbRecipeType;
        private System.Windows.Forms.Label lblRecipeType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Button btnDelRecipe;
        private System.Windows.Forms.Button btnModifyRecipe;
    }
}