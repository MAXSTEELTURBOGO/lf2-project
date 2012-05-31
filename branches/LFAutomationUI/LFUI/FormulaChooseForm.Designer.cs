namespace LFAutomationUI.LFUI
{
    partial class FormulaChooseForm
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
            this.formulaId = new System.Windows.Forms.ColumnHeader();
            this.formulaType = new System.Windows.Forms.ColumnHeader();
            this.formulaDesc = new System.Windows.Forms.ColumnHeader();
            this.lvFormulaInfos = new System.Windows.Forms.ListView();
            this.btnCloseFormula = new System.Windows.Forms.Button();
            this.btnNewModifyFoumula = new System.Windows.Forms.Button();
            this.colLvCheckBox = new System.Windows.Forms.ColumnHeader();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.splitContainerFormulaInfo.Panel1.SuspendLayout();
            this.splitContainerFormulaInfo.Panel2.SuspendLayout();
            this.splitContainerFormulaInfo.SuspendLayout();
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
            this.splitContainerFormulaInfo.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerFormulaInfo.Panel2.Controls.Add(this.btnCloseFormula);
            this.splitContainerFormulaInfo.Panel2.Controls.Add(this.btnNewModifyFoumula);
            this.splitContainerFormulaInfo.Size = new System.Drawing.Size(823, 408);
            this.splitContainerFormulaInfo.SplitterDistance = 354;
            this.splitContainerFormulaInfo.TabIndex = 1;
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
            // lvFormulaInfos
            // 
            this.lvFormulaInfos.CheckBoxes = true;
            this.lvFormulaInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvCheckBox,
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
            this.lvFormulaInfos.Size = new System.Drawing.Size(819, 350);
            this.lvFormulaInfos.TabIndex = 0;
            this.lvFormulaInfos.UseCompatibleStateImageBehavior = false;
            this.lvFormulaInfos.View = System.Windows.Forms.View.Details;
            this.lvFormulaInfos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvFormulaInfos_ItemChecked);
            // 
            // btnCloseFormula
            // 
            this.btnCloseFormula.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseFormula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseFormula.Location = new System.Drawing.Point(690, 2);
            this.btnCloseFormula.Name = "btnCloseFormula";
            this.btnCloseFormula.Size = new System.Drawing.Size(119, 43);
            this.btnCloseFormula.TabIndex = 6;
            this.btnCloseFormula.Text = "关闭窗口";
            this.btnCloseFormula.UseVisualStyleBackColor = true;
            this.btnCloseFormula.Click += new System.EventHandler(this.btnCloseFormula_Click);
            // 
            // btnNewModifyFoumula
            // 
            this.btnNewModifyFoumula.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewModifyFoumula.Location = new System.Drawing.Point(10, 2);
            this.btnNewModifyFoumula.Name = "btnNewModifyFoumula";
            this.btnNewModifyFoumula.Size = new System.Drawing.Size(203, 43);
            this.btnNewModifyFoumula.TabIndex = 5;
            this.btnNewModifyFoumula.Text = "新增修改公式信息";
            this.btnNewModifyFoumula.UseVisualStyleBackColor = true;
            this.btnNewModifyFoumula.Click += new System.EventHandler(this.btnNewModifyFoumula_Click);
            // 
            // colLvCheckBox
            // 
            this.colLvCheckBox.Text = "";
            this.colLvCheckBox.Width = 30;
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(555, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(119, 43);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确  认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FormulaChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 408);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerFormulaInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormulaChooseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "钢种公式选择界面";
            this.Load += new System.EventHandler(this.FormulaChooseForm_Load);
            this.splitContainerFormulaInfo.Panel1.ResumeLayout(false);
            this.splitContainerFormulaInfo.Panel2.ResumeLayout(false);
            this.splitContainerFormulaInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerFormulaInfo;
        private System.Windows.Forms.ListView lvFormulaInfos;
        private System.Windows.Forms.ColumnHeader formulaId;
        private System.Windows.Forms.ColumnHeader formulaType;
        private System.Windows.Forms.ColumnHeader formulaDesc;
        private System.Windows.Forms.Button btnCloseFormula;
        private System.Windows.Forms.Button btnNewModifyFoumula;
        private System.Windows.Forms.ColumnHeader colLvCheckBox;
        private System.Windows.Forms.Button btnConfirm;
    }
}