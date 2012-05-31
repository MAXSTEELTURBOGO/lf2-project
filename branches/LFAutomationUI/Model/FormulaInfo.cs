using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class FormulaInfo
    {
        #region members
        private string heatId;
        private string steelGradeId;
        private string formulaId;
        private string formulaType;
        private string formula;
        #endregion

        #region Properties
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }
        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
        }
        public string FormulaId
        {
            get { return this.formulaId; }
            set { this.formulaId = value; }
        }
        public string FormulaType
        {
            get { return this.formulaType; }
            set { this.formulaType = value; }
        }
        public string Formula
        {
            get { return this.formula; }
            set { this.formula = value; }
        }
        #endregion

        #region Methods

        public FormulaInfo() { }

        public FormulaInfo(string formulaId, string formulaType, string formula)
        {
            this.formulaId = formulaId;
            this.formulaType = formulaType;
            this.formula = formula;
        }

        public FormulaInfo(string steelGradeId, string formulaId, string formulaType, string formula)
        {
            this.steelGradeId = steelGradeId;
            this.formulaId = formulaId;
            this.formulaType = formulaType;
            this.formula = formula;
        }

        public FormulaInfo(string heatId, string steelGradeId, string formulaId, string formulaType, string formula)
        {
            this.heatId = heatId;
            this.steelGradeId = steelGradeId;
            this.formulaId = formulaId;
            this.formulaType = formulaType;
            this.formula = formula;
        }
        #endregion
    }
}
