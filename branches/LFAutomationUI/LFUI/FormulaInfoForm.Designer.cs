namespace LFAutomationUI.LFUI
{
    partial class FormulaInfoForm
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
            this.splitContainerFormulaInfo = new System.Windows.Forms.SplitContainer();
            this.lvFormulaInfos = new System.Windows.Forms.ListView();
            this.formulaId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formulaType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formulaDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerFormulaOperation = new System.Windows.Forms.SplitContainer();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.lblFormula = new System.Windows.Forms.Label();
            this.txtFormulaType = new System.Windows.Forms.TextBox();
            this.lblFormulaType = new System.Windows.Forms.Label();
            this.txtFormulaId = new System.Windows.Forms.TextBox();
            this.lblFormulaId = new System.Windows.Forms.Label();
            this.btnCloseFormula = new System.Windows.Forms.Button();
            this.btnCancelFormula = new System.Windows.Forms.Button();
            this.btnConfirmFormula = new System.Windows.Forms.Button();
            this.btnModifyFormula = new System.Windows.Forms.Button();
            this.btnNewFoumula = new System.Windows.Forms.Button();
            this.splitContainerFormulaInfo.Panel1.SuspendLayout();
            this.splitContainerFormulaInfo.Panel2.SuspendLayout();
            this.splitContainerFormulaInfo.SuspendLayout();
            this.splitContainerFormulaOperation.Panel1.SuspendLayout();
            this.splitContainerFormulaOperation.Panel2.SuspendLayout();
            this.splitContainerFormulaOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerFormulaInfo
            // 
            this.splitContainerFormulaInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerFormulaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFormulaInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFormulaInfo.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerFormulaInfo.Name = "splitContainerFormulaInfo";
            this.splitContainerFormulaInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFormulaInfo.Panel1
            // 
            this.splitContainerFormulaInfo.Panel1.Controls.Add(this.lvFormulaInfos);
            // 
            // splitContainerFormulaInfo.Panel2
            // 
            this.splitContainerFormulaInfo.Panel2.Controls.Add(this.splitContainerFormulaOperation);
            this.splitContainerFormulaInfo.Size = new System.Drawing.Size(474, 483);
            this.splitContainerFormulaInfo.SplitterDistance = 346;
            this.splitContainerFormulaInfo.TabIndex = 0;
            // 
            // lvFormulaInfos
            // 
            this.lvFormulaInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.formulaId,
            this.formulaType,
            this.formulaDesc});
            this.lvFormulaInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFormulaInfos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvFormulaInfos.FullRowSelect = true;
            this.lvFormulaInfos.GridLines = true;
            this.lvFormulaInfos.Location = new System.Drawing.Point(0, 0);
            this.lvFormulaInfos.Margin = new System.Windows.Forms.Padding(4);
            this.lvFormulaInfos.MultiSelect = false;
            this.lvFormulaInfos.Name = "lvFormulaInfos";
            this.lvFormulaInfos.Size = new System.Drawing.Size(470, 342);
            this.lvFormulaInfos.TabIndex = 0;
            this.lvFormulaInfos.UseCompatibleStateImageBehavior = false;
            this.lvFormulaInfos.View = System.Windows.Forms.View.Details;
            this.lvFormulaInfos.SelectedIndexChanged += new System.EventHandler(this.lvFormulaInfos_SelectedIndexChanged);
            // 
            // formulaId
            // 
            this.formulaId.Text = "公式代码";
            this.formulaId.Width = 85;
            // 
            // formulaType
            // 
            this.formulaType.Text = "公式类型";
            this.formulaType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.formulaType.Width = 110;
            // 
            // formulaDesc
            // 
            this.formulaDesc.Text = "公式";
            this.formulaDesc.Width = 600;
            // 
            // splitContainerFormulaOperation
            // 
            this.splitContainerFormulaOperation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerFormulaOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFormulaOperation.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFormulaOperation.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerFormulaOperation.Name = "splitContainerFormulaOperation";
            this.splitContainerFormulaOperation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFormulaOperation.Panel1
            // 
            this.splitContainerFormulaOperation.Panel1.Controls.Add(this.txtFormula);
            this.splitContainerFormulaOperation.Panel1.Controls.Add(this.lblFormula);
            this.splitContainerFormulaOperation.Panel1.Controls.Add(this.txtFormulaType);
            this.splitContainerFormulaOperation.Panel1.Controls.Add(this.lblFormulaType);
            this.splitContainerFormulaOperation.Panel1.Controls.Add(this.txtFormulaId);
            this.splitContainerFormulaOperation.Panel1.Controls.Add(this.lblFormulaId);
            // 
            // splitContainerFormulaOperation.Panel2
            // 
            this.splitContainerFormulaOperation.Panel2.Controls.Add(this.btnCloseFormula);
            this.splitContainerFormulaOperation.Panel2.Controls.Add(this.btnCancelFormula);
            this.splitContainerFormulaOperation.Panel2.Controls.Add(this.btnConfirmFormula);
            this.splitContainerFormulaOperation.Panel2.Controls.Add(this.btnModifyFormula);
            this.splitContainerFormulaOperation.Panel2.Controls.Add(this.btnNewFoumula);
            this.splitContainerFormulaOperation.Size = new System.Drawing.Size(474, 133);
            this.splitContainerFormulaOperation.SplitterDistance = 74;
            this.splitContainerFormulaOperation.TabIndex = 0;
            // 
            // txtFormula
            // 
            this.txtFormula.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFormula.Location = new System.Drawing.Point(86, 45);
            this.txtFormula.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.ReadOnly = true;
            this.txtFormula.Size = new System.Drawing.Size(427, 29);
            this.txtFormula.TabIndex = 5;
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFormula.Location = new System.Drawing.Point(6, 48);
            this.lblFormula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(42, 21);
            this.lblFormula.TabIndex = 4;
            this.lblFormula.Text = "公式";
            // 
            // txtFormulaType
            // 
            this.txtFormulaType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFormulaType.Location = new System.Drawing.Point(324, 8);
            this.txtFormulaType.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormulaType.Name = "txtFormulaType";
            this.txtFormulaType.ReadOnly = true;
            this.txtFormulaType.Size = new System.Drawing.Size(189, 29);
            this.txtFormulaType.TabIndex = 3;
            // 
            // lblFormulaType
            // 
            this.lblFormulaType.AutoSize = true;
            this.lblFormulaType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFormulaType.Location = new System.Drawing.Point(242, 11);
            this.lblFormulaType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormulaType.Name = "lblFormulaType";
            this.lblFormulaType.Size = new System.Drawing.Size(74, 21);
            this.lblFormulaType.TabIndex = 2;
            this.lblFormulaType.Text = "公式类型";
            // 
            // txtFormulaId
            // 
            this.txtFormulaId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFormulaId.Location = new System.Drawing.Point(86, 8);
            this.txtFormulaId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormulaId.Name = "txtFormulaId";
            this.txtFormulaId.ReadOnly = true;
            this.txtFormulaId.Size = new System.Drawing.Size(110, 29);
            this.txtFormulaId.TabIndex = 1;
            // 
            // lblFormulaId
            // 
            this.lblFormulaId.AutoSize = true;
            this.lblFormulaId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFormulaId.Location = new System.Drawing.Point(6, 11);
            this.lblFormulaId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormulaId.Name = "lblFormulaId";
            this.lblFormulaId.Size = new System.Drawing.Size(74, 21);
            this.lblFormulaId.TabIndex = 0;
            this.lblFormulaId.Text = "公式代码";
            // 
            // btnCloseFormula
            // 
            this.btnCloseFormula.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseFormula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseFormula.Location = new System.Drawing.Point(394, 4);
            this.btnCloseFormula.Name = "btnCloseFormula";
            this.btnCloseFormula.Size = new System.Drawing.Size(119, 43);
            this.btnCloseFormula.TabIndex = 4;
            this.btnCloseFormula.Text = "关闭窗口";
            this.btnCloseFormula.UseVisualStyleBackColor = true;
            this.btnCloseFormula.Click += new System.EventHandler(this.btnCloseFormula_Click);
            // 
            // btnCancelFormula
            // 
            this.btnCancelFormula.Enabled = false;
            this.btnCancelFormula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelFormula.Location = new System.Drawing.Point(297, 4);
            this.btnCancelFormula.Name = "btnCancelFormula";
            this.btnCancelFormula.Size = new System.Drawing.Size(89, 43);
            this.btnCancelFormula.TabIndex = 3;
            this.btnCancelFormula.Text = "取  消";
            this.btnCancelFormula.UseVisualStyleBackColor = true;
            this.btnCancelFormula.Click += new System.EventHandler(this.btnCancelFormula_Click);
            // 
            // btnConfirmFormula
            // 
            this.btnConfirmFormula.Enabled = false;
            this.btnConfirmFormula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmFormula.Location = new System.Drawing.Point(200, 4);
            this.btnConfirmFormula.Name = "btnConfirmFormula";
            this.btnConfirmFormula.Size = new System.Drawing.Size(89, 43);
            this.btnConfirmFormula.TabIndex = 2;
            this.btnConfirmFormula.Text = "确  认";
            this.btnConfirmFormula.UseVisualStyleBackColor = true;
            this.btnConfirmFormula.Click += new System.EventHandler(this.btnConfirmFormula_Click);
            // 
            // btnModifyFormula
            // 
            this.btnModifyFormula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyFormula.Location = new System.Drawing.Point(103, 4);
            this.btnModifyFormula.Name = "btnModifyFormula";
            this.btnModifyFormula.Size = new System.Drawing.Size(89, 43);
            this.btnModifyFormula.TabIndex = 1;
            this.btnModifyFormula.Text = "修  改";
            this.btnModifyFormula.UseVisualStyleBackColor = true;
            this.btnModifyFormula.Click += new System.EventHandler(this.btnModifyFormula_Click);
            // 
            // btnNewFoumula
            // 
            this.btnNewFoumula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewFoumula.Location = new System.Drawing.Point(6, 4);
            this.btnNewFoumula.Name = "btnNewFoumula";
            this.btnNewFoumula.Size = new System.Drawing.Size(89, 43);
            this.btnNewFoumula.TabIndex = 0;
            this.btnNewFoumula.Text = "新  增";
            this.btnNewFoumula.UseVisualStyleBackColor = true;
            this.btnNewFoumula.Click += new System.EventHandler(this.btnNewFoumula_Click);
            // 
            // FormulaInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseFormula;
            this.ClientSize = new System.Drawing.Size(474, 483);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerFormulaInfo);
            this.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormulaInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "公式信息维护界面";
            this.Load += new System.EventHandler(this.FormulaInfoForm_Load);
            this.splitContainerFormulaInfo.Panel1.ResumeLayout(false);
            this.splitContainerFormulaInfo.Panel2.ResumeLayout(false);
            this.splitContainerFormulaInfo.ResumeLayout(false);
            this.splitContainerFormulaOperation.Panel1.ResumeLayout(false);
            this.splitContainerFormulaOperation.Panel1.PerformLayout();
            this.splitContainerFormulaOperation.Panel2.ResumeLayout(false);
            this.splitContainerFormulaOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerFormulaInfo;
        private System.Windows.Forms.ListView lvFormulaInfos;
        private System.Windows.Forms.SplitContainer splitContainerFormulaOperation;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.TextBox txtFormulaType;
        private System.Windows.Forms.Label lblFormulaType;
        private System.Windows.Forms.TextBox txtFormulaId;
        private System.Windows.Forms.Label lblFormulaId;
        private System.Windows.Forms.Button btnCloseFormula;
        private System.Windows.Forms.Button btnCancelFormula;
        private System.Windows.Forms.Button btnConfirmFormula;
        private System.Windows.Forms.Button btnModifyFormula;
        private System.Windows.Forms.Button btnNewFoumula;
        private System.Windows.Forms.ColumnHeader formulaId;
        private System.Windows.Forms.ColumnHeader formulaType;
        private System.Windows.Forms.ColumnHeader formulaDesc;
    }
}