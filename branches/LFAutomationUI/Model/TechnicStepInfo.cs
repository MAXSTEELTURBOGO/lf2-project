using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.Model
{
    public class TechnicStepInfo
    {
        #region members
        private int? technicId;
        private StepInfo steps;
        private int? planDuration;
        private int? planPowerDuration;
        private int? planTopArConsumption;
        private int? planBottomArConsumption;
        private int? sequence;
        private TransformerParamInfo transformerParams;
        #endregion

        #region Properties
        public int? TechnicId
        {
            get { return this.technicId; }
            set { this.technicId = value; }
        }
        public StepInfo Steps
        {
            get { return this.steps; }
            set { this.steps = value; }
        }
        public int? PlanDuration
        {
            get { return this.planDuration; }
            set { this.planDuration = value; }
        }
        public int? PlanPowerDuration
        {
            get { return this.planPowerDuration; }
            set { this.planPowerDuration = value; }
        }
        public int? PlanTopArConsumption
        {
            get { return this.planTopArConsumption; }
            set { this.planTopArConsumption = value; }
        }
        public int? PlanBottomArConsumption
        {
            get { return this.planBottomArConsumption; }
            set { this.planBottomArConsumption = value; }
        }
        public int? Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }
        public TransformerParamInfo TransFormerParams
        {
            get { return this.transformerParams; }
            set { this.transformerParams = value; }
        }

        #endregion

        #region Methods
        public TechnicStepInfo()
        {
            this.steps = new StepInfo();
            this.transformerParams = new TransformerParamInfo();
        }

        public TechnicStepInfo(StepInfo steps, int? planDuration, int? planPowerDuration, int? planTopArConsumption, int? planBottomArConsumption, int? sequence, TransformerParamInfo transformerParams)
        {
            this.steps = new StepInfo();
            this.transformerParams = new TransformerParamInfo();
            this.steps = steps;
            this.planDuration = planDuration;
            this.planPowerDuration = planPowerDuration;
            this.planTopArConsumption = planTopArConsumption;
            this.planBottomArConsumption = planBottomArConsumption;
            this.sequence = sequence;
            this.transformerParams = transformerParams;
        }

        public TechnicStepInfo(int? technicId, StepInfo steps, int? planDuration, int? planPowerDuration, int? planTopArConsumption, int? planBottomArConsumption, int? sequence, TransformerParamInfo transformerParams)
        {
            this.steps = new StepInfo();
            this.transformerParams = new TransformerParamInfo();
            this.technicId = technicId;
            this.steps = steps;
            this.planDuration = planDuration;
            this.planPowerDuration = planPowerDuration;
            this.planTopArConsumption = planTopArConsumption;
            this.planBottomArConsumption = planBottomArConsumption;
            this.sequence = sequence;
            this.transformerParams = transformerParams;
        }
        #endregion
    }
}
