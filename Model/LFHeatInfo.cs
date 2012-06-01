using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class LFHeatInfo
    {
        #region Internal members

        private DateTime msgTimeStamp;
        //private decimal? planId;
        private string heatId;
        private int treatmentCount;
        private Car car;
        private string factoryCode;
        //private int? planStationId;
        //private int currentStationId;
        private double? arrivalSteelWeight;
        private double? arrivalSlagWeight;
        private SteelGradeDetailInfo steelGrade;
        //private LadleInfo ladle;
        private string S_LD_ID;//钢包号
        private int? FURNACE_TIM;//保龄
        private DateTime? preStartTime;
        private double? targetTemperature;

        private DateTime? arrivalTime;
        private DateTime? departTime;

        private TempOxygenRecordInfo arrivalTemperature;
        private TempOxygenRecordInfo departTemperature;
        private TempOxygenRecordInfo lastHeatTemperature;

        private string currentHeatStatus;
        private int currentDetailStatusId;
        private string currentDetailStatusName;


        private int? arDuration;
        private int? arConsumptin;
        private int? powerDuration;
        private int? powerConsumption;
        private int? arDurationAfterFeed;
        private int? arConsumptionAfterFeed;
        private int? feedSpeed;


        private HeatEquipmentInfo heatEquipment;
        private UserInfo operatorUser;

        private bool selectedFlag;
        private bool visible;

        private IList<RealTimeInfo> reatTimeList;
        private IList<AdditionRecordInfo> additionList;
        private IList<PowerOnRecordInfo> powerOnList;
        private IList<TempOxygenRecordInfo> tempOxygenList;
        private IList<LFHeatStatusInfo> lfHeatStatusList;
        private IList<LFHeatQualityInfo> lfHeatQualityList;
        private IList<HeatSlagQualityInfo> lfHeatSlagQualityList;
        private IList<QualityHorizontalInfo> lfHeatQualityHorizontalList;

        #endregion

        #region Properties

        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }

        /// <summary>
        /// 计划号
        /// </summary>
        //public decimal? PlanId
        //{
        //    get { return planId; }
        //    set { planId = value; }
        //}

        /// <summary>
        /// 炉次号
        /// </summary>
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        /// <summary>
        /// 处理次数
        /// </summary>
        public int TreatmentCount
        {
            get { return treatmentCount; }
            set { treatmentCount = value; }
        }

        /// <summary>
        /// 工位
        /// </summary>
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        /// <summary>
        /// 工厂代码
        /// </summary>
        public string FactoryCode
        {
            get { return factoryCode; }
            set { factoryCode = value; }
        }

        /// <summary>
        /// 计划冶炼站号
        /// </summary>
        //public int? PlanStationId
        //{
        //    get { return planStationId; }
        //    set { planStationId = value; }
        //}


        /// <summary>
        /// 目标温度
        /// </summary>
        public double? TargetTemperature
        {
            get { return targetTemperature; }
            set { targetTemperature = value; }
        }

        /// <summary>
        /// 当前站号
        /// </summary>
        //public int CurrentStationId
        //{
        //    get { return currentStationId; }
        //    set { currentStationId = value; }
        //}

        /// <summary>
        /// 钢水重量
        /// </summary>
        public double? ArrivalSteelWeight
        {
            get { return this.arrivalSteelWeight; }
            set { this.arrivalSteelWeight = value; }
        }

        /// <summary>
        /// 离开时钢水重量
        /// </summary>
        public double? DepartSteelWeight
        {
            get
            {
                if (this.lfHeatStatusList.Count != 0)
                {
                    try
                    {
                        return lfHeatStatusList.Single<LFHeatStatusInfo>(i => i.HeatStatus.StatusId == 6).SteelWeight;
                    }
                    catch
                    {
                        return null;
                    }
                }
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 离开时钢渣量
        /// </summary>
        public double? DepartSlagWeight
        {
            get
            {
                if (this.lfHeatStatusList.Count != 0)
                {
                    try
                    {
                        return lfHeatStatusList.Single<LFHeatStatusInfo>(i => i.HeatStatus.StatusId == 6).SlagWeight;
                    }
                    catch
                    {
                        return null;
                    }
                }
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 到达钢渣重量
        /// </summary>
        public double? ArrivalSlagWeight
        {
            get { return this.arrivalSlagWeight; }
            set { this.arrivalSlagWeight = value; }
        }



        /// <summary>
        /// 钢种详细信息
        /// </summary>
        public SteelGradeDetailInfo SteelGrade
        {
            get { return steelGrade; }
            set { steelGrade = value; }
        }
        
        
      

        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime? ArrivalTime
        {
            get
            {
                if (this.arrivalTime.HasValue == false)
                {
                    if (this.lfHeatStatusList != null && this.lfHeatStatusList.Count > 0)
                    {
                        try
                        {
                            return this.lfHeatStatusList.Single<LFHeatStatusInfo>(i => i.HeatStatus.StatusId == 1).StatusTimeStamp;
                        }
                        catch (Exception)
                        {
                            return null;
                        }

                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return this.arrivalTime;
                }
            }
            set
            {
                this.arrivalTime = value;
            }
        }

        /// <summary>
        /// 离开时间
        /// </summary>
        public DateTime? DepartTime
        {
            get
            {
                if (this.departTime.HasValue == false)
                {
                    if (this.lfHeatStatusList != null && this.lfHeatStatusList.Count > 0)
                    {
                        try
                        {
                            return this.lfHeatStatusList.Single<LFHeatStatusInfo>(i => i.HeatStatus.StatusId == 6).StatusTimeStamp;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return this.departTime;
                }
            }
            set
            {
                this.departTime = value;
            }
        }

        /// <summary>
        /// 到站测温信息
        /// </summary>
        public TempOxygenRecordInfo ArrivalTemperature
        {
            get
            {
                if (this.arrivalTemperature.TemperatureData.HasValue==false)
                {
                    if (this.tempOxygenList != null && this.tempOxygenList.Count > 0)
                    {
                        return this.tempOxygenList.Where<TempOxygenRecordInfo>(j => j.MsgTimeStamp == this.tempOxygenList.Min<TempOxygenRecordInfo, DateTime?>(i => i.MsgTimeStamp)).First<TempOxygenRecordInfo>();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return this.arrivalTemperature;
                }
            }
            set
            {
                this.arrivalTemperature = value;
            }
        }

        /// <summary>
        /// 出站测温信息
        /// </summary>
        public TempOxygenRecordInfo DepartTemperature
        {
            get
            {
                if (this.departTime.HasValue==true)
                {
                    if (this.departTemperature.TemperatureData == null)
                    {
                        if (this.tempOxygenList != null && this.tempOxygenList.Count > 0)
                        {
                            return this.tempOxygenList.Where<TempOxygenRecordInfo>(j => j.MsgTimeStamp == this.tempOxygenList.Max<TempOxygenRecordInfo, DateTime?>(i => i.MsgTimeStamp)).First<TempOxygenRecordInfo>();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return this.departTemperature;
                    }
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.departTemperature = value;
            }
        }

        public TempOxygenRecordInfo LastHeatTemperature
        {
            get { return lastHeatTemperature; }
            set { lastHeatTemperature = value; }
        }

        /// <summary>
        /// 电极插入次数
        /// </summary>
        public int ElectrodeInsCount
        {
            get
            {
                if (this.powerOnList != null)
                {
                    return this.powerOnList.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 取样次数，即取样器消耗量
        /// </summary>
        public int SampleCount
        {
            get
            {
                if (this.lfHeatQualityList != null)
                {
                    return this.lfHeatQualityList.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 测温偶头使用个数
        /// </summary>
        public int ThermCouple
        {
            get
            {
                if (this.tempOxygenList != null)
                {
                    return tempOxygenList.Where<TempOxygenRecordInfo>(i => i.OxygenData == 0 || i.OxygenData == null).Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        public int SampleOCouple
        {
            get
            {
                if (this.tempOxygenList != null)
                {
                    return tempOxygenList.Where<TempOxygenRecordInfo>(i => i.OxygenData != null && i.OxygenData != 0).Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 当前炉次状态 ON GOING,TO BE DONE,DONE
        /// </summary>
        public string CurrentHeatStatus
        {
            get { return currentHeatStatus; }
            set { currentHeatStatus = value; }
        }

        /// <summary>
        /// 当前炉次详细状态 0，1，2，3，4，5，6
        /// </summary>
        public int CurrentDetailStatusId
        {
            get { return currentDetailStatusId; }
            set { currentDetailStatusId = value; }
        }

        /// <summary>
        /// 当前炉次详细状态名称 尚未到达，钢包到达，开始冶炼，冶炼结束，喂丝开始，喂丝结束，钢包离开
        /// </summary>
        public string CurrentDetailStatusName
        {
            get { return currentDetailStatusName; }
            set { currentDetailStatusName = value; }
        }


        /// <summary>
        /// 总吹氩时间
        /// </summary>
        public int? ArDuration
        {
            get { return arDuration; }
            set { arDuration = value; }
        }

        /// <summary>
        /// 氩气总消耗
        /// </summary>
        public int? ArConsumptin
        {
            get { return arConsumptin; }
            set { arConsumptin = value; }
        }


        /// <summary>
        /// 通电时间或加热时间
        /// </summary>
        public int? PowerDuration
        {
            get { return powerDuration; }
            set { powerDuration = value; }
        }

        /// <summary>
        /// 电耗
        /// </summary>
        public int? PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }


        /// <summary>
        /// 喂丝后吹氩时间
        /// </summary>
        public int? ArDurationAfterFeed
        {
            get { return arDurationAfterFeed; }
            set { arDurationAfterFeed = value; }
        }

        /// <summary>
        /// 喂丝后氩气消耗
        /// </summary>
        public int? ArConsumptionAfterFeed
        {
            get { return arConsumptionAfterFeed; }
            set { arConsumptionAfterFeed = value; }
        }

        /// <summary>
        /// 喂丝速度
        /// </summary>
        public int? FeedSpeed
        {
            get { return feedSpeed; }
            set { feedSpeed = value; }
        }
         

        /// <summary>
        /// 预开始时间
        /// </summary>
        public string SLD_ID
        {
            get { return S_LD_ID; }
            set { S_LD_ID = value; }
        }
        /// <summary>
        /// 预开始时间
        /// </summary>
        public int? FurnaceTim
        {
            get { return FURNACE_TIM; }
            set { FURNACE_TIM = value; }
        }
        /// <summary>
        /// 预开始时间
        /// </summary>
        public DateTime? PreStartTime
        {
            get { return preStartTime; }
            set { preStartTime = value; }
        }

        /// <summary>
        /// 冶炼该炉次的设备信息
        /// </summary>
        public HeatEquipmentInfo HeatEquipment
        {
            get { return heatEquipment; }
            set { heatEquipment = value; }
        }

        /// <summary>
        /// 该炉次的操作用户信息 以炉次冶炼结束前最后一次操作该炉次的用户为准
        /// </summary>
        public UserInfo OperatorUser
        {
            get { return operatorUser; }
            set { operatorUser = value; }
        }

        /// <summary>
        /// 选择标志位
        /// </summary>
        public bool SelectedFlag
        {
            get { return selectedFlag; }
            set { selectedFlag = value; }
        }

        /// <summary>
        /// 炉次信息的可见性
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }


        /// <summary>
        /// 实时信息
        /// </summary>
        public IList<RealTimeInfo> ReatTimeList
        {
            get { return this.reatTimeList; }
            set { this.reatTimeList = value; }
        }

        /// <summary>
        /// 炉次的加料记录
        /// </summary>
        public IList<AdditionRecordInfo> AdditionList
        {
            get { return additionList; }
            set { additionList = value; }
        }

        /// <summary>
        /// 炉次的家电记录
        /// </summary>
        public IList<PowerOnRecordInfo> PowerOnList
        {
            get { return powerOnList; }
            set { powerOnList = value; }
        }

        /// <summary>
        /// 炉次的测温测氧记录
        /// </summary>
        public IList<TempOxygenRecordInfo> TempOxygenList
        {
            get { return tempOxygenList; }
            set { tempOxygenList = value; }
        }

        /// <summary>
        /// 炉次的冶炼进程记录
        /// </summary>
        public IList<LFHeatStatusInfo> LFHeatStatusList
        {
            get { return lfHeatStatusList; }
            set { lfHeatStatusList = value; }
        }

        /// <summary>
        /// 炉次的化验信息列表
        /// </summary>
        public IList<LFHeatQualityInfo> LFHeatQualityList
        {
            get { return this.lfHeatQualityList; }
            set { this.lfHeatQualityList = value; }
        }

        /// <summary>
        /// 炉次的渣化验信息
        /// </summary>
        public IList<HeatSlagQualityInfo> LFHeatSlagQualityList
        {
            get { return this.lfHeatSlagQualityList; }
            set { this.lfHeatSlagQualityList = value; }
        }

        public IList<QualityHorizontalInfo> LfHeatQualityHorizontalList
        {
            get { return this.lfHeatQualityHorizontalList; }
            set { this.lfHeatQualityHorizontalList = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Default Construction methods
        /// </summary>
        public LFHeatInfo()
        {
            this.arrivalTemperature = new TempOxygenRecordInfo();
            this.departTemperature = new TempOxygenRecordInfo();
            this.lastHeatTemperature = new TempOxygenRecordInfo();
            this.steelGrade = new SteelGradeDetailInfo();
            this.heatEquipment = new HeatEquipmentInfo();
            
            this.operatorUser = new UserInfo();
            this.reatTimeList = new List<RealTimeInfo>();
            this.additionList = new List<AdditionRecordInfo>();
            this.powerOnList = new List<PowerOnRecordInfo>();
            this.tempOxygenList = new List<TempOxygenRecordInfo>();
            this.lfHeatStatusList = new List<LFHeatStatusInfo>();
            this.lfHeatQualityList = new List<LFHeatQualityInfo>();
            this.lfHeatSlagQualityList = new List<HeatSlagQualityInfo>();
            this.lfHeatQualityHorizontalList = new List<QualityHorizontalInfo>();
        }
        public LFHeatInfo(DateTime msgTimeStamp, string heatId, int treatmentCount)
        {
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
        }

        public LFHeatInfo(string heatId, int treatmentCount)
        {
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
        }

        public int? IntParseCar()
        {
            return this.car == Car.One ? new Nullable<int>(1) : (this.car == Car.Two ? new Nullable<int>(2) : null);
        }
        public static int? IntParseCar(Car car)
        {
            return car == Car.One ? new Nullable<int>(1) : (car == Car.Two ? new Nullable<int>(2) : null);
        }
        #endregion
    }
}
