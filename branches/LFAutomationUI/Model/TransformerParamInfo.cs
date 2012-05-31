using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class TransformerParamInfo
    {
        #region members
        private int? tapPosition;
        private int? tapPositionPoint;
        private double? voltage;
        private double? current;
        private double? tempPerMin;
        private double? power;
        #endregion

        #region Properties
        public int? TapPosition
        {
            get { return this.tapPosition; }
            set { this.tapPosition = value; }
        }
        public int? TapPositionPoint
        {
            get { return this.tapPositionPoint; }
            set { this.tapPositionPoint = value; }
        }
        public double? Voltage
        {
            get { return this.voltage; }
            set { this.voltage = value; }
        }
        public double? Current
        {
            get { return this.current; }
            set { this.current = value; }
        }
        public double? TempPerMin
        {
            get { return this.tempPerMin; }
            set { this.tempPerMin = value; }
        }
        public double? Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
        #endregion

        #region Methods
        public TransformerParamInfo()
        { }
        public TransformerParamInfo(int? tapPosition, int? tapPositionPoint)
        {
            this.tapPosition = tapPosition;
            this.tapPositionPoint = tapPositionPoint;
        }
        public TransformerParamInfo(int? tapPosition, int? tapPositionPoint, double? voltage, double? current, double? tempPerMin, double? power)
        {
            this.tapPosition = tapPosition;
            this.tapPositionPoint = tapPositionPoint;
            this.voltage = voltage;
            this.current = current;
            this.tempPerMin = tempPerMin;
            this.power = power;
        }
        #endregion
    }
}
