// Decompiled with JetBrains decompiler
// Type: PB_Widget_Designer.AirScan
// Assembly: PB_Widget_Designer, Version=6.0.5.0, Culture=neutral, PublicKeyToken=null
// MVID: EB01E1C9-6FF1-4F17-ACB9-02E955698E32
// Assembly location: D:\Projects\Other\Widget Designer 6.0.5\PB_Widget_Designer.exe

using Clx;
using Clx.Sync;
using MathLibX;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PB_Widget_Designer.Wd.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;


namespace PB_Widget_Designer
{
    [JsonObject(MemberSerialization.OptIn)]
    [ToolboxItem(false)]
    public class AirScan
    {
        [JsonIgnore]
       // public DialogAirScanProperties Dialog;
        public int ID;
        private double m_Prediction;
        private double m_PredictionFactor;
        private bool m_UseMotionPrediction;
        private double SigProcDamping;
        private SigProcX SigProcP1X;
        private SigProcX SigProcP1Y;
        private double m_AlphaP1X;
        private double m_AlphaP1Y;
        private double m_BetaP1X;
        private double m_BetaP1Y;
        private SigProcX SigProcP2X;
        private SigProcX SigProcP2Y;
        private double m_AlphaP2X;
        private double m_AlphaP2Y;
        private double m_BetaP2X;
        private double m_BetaP2Y;
        private Rectangle m_AirScanArea;
        private Point m_AirScanOffset;
        private Rectangle m_AirScanSafeArea;
        private int m_AirScanRangeFar;
        private int m_AirScanRangeNear;
        private int m_AirScanOutputWidth;
        private int m_AirScanOutputHeight;
        private int m_AirScanOutputZoom;
        private bool m_AirScanInvX;
        private bool m_AirScanInvY;
        private bool m_AirScanSwapXY;
        private bool m_AirScanMuteMouse;
        private bool m_AirScanEnableMouse;
        private bool m_AirScanEnableGui;
        private bool m_AirScanEnableMouseClick;
        private int m_AirScanMouseClickMode;
        private bool m_AirScanMouseDownOnMove;
        private bool m_mouseIgnoreOutputSize;
        private int m_AirScanPointThreshold;
        private int m_AirScanPointCount;
        private AirScan.ScanVectorXY[] m_Airscans;
        private Point m_AirScanPoint1;
        private Point m_AirScanRawPoint1;
        private Point m_AirScanPoint1Delta;
        private Point m_AirScanPoint1DeltaLast;
        private Point m_AirScanPoint2;
        private Point m_AirScanRawPoint2;
        private Point m_AirScanPoint2Delta;
        private Point m_AirScanPoint2DeltaLast;
        private int m_AirScanDistanceDelta;
        private int m_AirScanDistanceDeltaLast;
        private int m_AirScanAngleDelta;
        private int m_AirScanAngleDeltaLast;
        private bool m_AirScanPoint1Active;
        private bool m_AirScanPoint2Active;
        private bool m_AirScanPoint1Enter;
        private bool m_AirScanPoint2Enter;
        private bool m_AirScanPoint1Leave;
        private bool m_AirScanPoint2Leave;
        private bool m_AirScanP1EnterProperty;
        private bool m_AirScanP2EnterProperty;
        private bool m_AirScanP1LeaveProperty;
        private bool m_AirScanP2LeaveProperty;
        private bool m_AirScanPoint1inUse;
        private bool m_AirScanPoint2inUse;
        private int m_AirScanAngle;
        private int m_AirScanDistance;
        private Rectangle m_AirscanScreenArea;
        private bool m_AirScanToTUIO;
        public Point ViewOffset;
        public int ViewZoom;
        [JsonProperty]
        [DefaultValue("")]
        public string IP;
        public string AirScanAdapter;
        private int m_AirScanPort;
        private bool m_Autoconnect;
        private bool m_isconnected;
        private double m_PointAngle;
        private double m_PointDistance;
        private Thread m_AirScanThreadReceive;
        private bool m_sendTouchdata;
        private int m_MaxDelta;
        public int CurrentActivePointCount;
        public int CalibrateP1X;
        public int CalibrateP1Y;
        private byte[] rbytes;
        private byte[] procbytes;
        private bool t_receivemode;
        private double pointOneX;
        private double pointOneY;
        private double pointTwoX;
        private double pointTwoY;
        private double m_DegAngle;
        private double m_RadAngle;
        private AirScan.ScanVectorXY[] m_vector;
        private AirScan.Point1Info m_Point1Info;
        private AirScan.Point2Info m_Point2Info;
        private Collection m_PointOne;
        private Collection m_PointTwo;
        private bool m_pointOneWrite;
        private bool m_pointTwoWrite;
        private bool m_pointOneDone;
        private bool m_pointTwoDone;
        private AirScan.DoEventsSub IDDelegate;
        private AirScanPointTracker2D m_Tracker;
        private Collection m_NewPointCollection;
        private int m_MaxPointCount;
        private int m_StartX;
        private int m_StartY;
        private int m_RWidth;
        private int m_RHeight;
        private int m_PointIDOffset;
        private List<PointF> m_AirScanROI;
        private bool m_CalcScanOutline;
        private bool PointValid;
        private int PointValidationIndex;
        private int t_PointValidationCount;
        private bool t_IgnoreRays;
        private int t_PointInvalidationCount;
        private int t_TrimCount;
        private int PointInvalidationIndex;
        private Collection RayCheckCollection;
        private int StartedRay;
        private int StoppedRay;
        private int CenterRay;
        private double AverageDistance;
        private bool t_CalcOutline;
        private double t_Prediction;
        private bool t_UseMotionPrediction;
        private double t_MotionPredictionFactor;
        private int t_MaxDelta;
        private double t_SigProcDamping;
        private int t_NearRange;
        private int t_FarRange;
        private int t_StartRay;
        private int t_StopRay;
        private double t_NearPoint; t_Rwidth
        private double t_FarPoint;
        private AirScan.ScanVectorXY t_startpoint;
        private AirScan.ScanVectorXY t_stoppoint;
        private AirScan.ScanVectorXY t_NewPoint;
        private AirScan.ScanVectorXY t_CalcPoint;
        private AirScan.ScanVectorXY t_Checkpoint;
        private Rectangle t_AirScanArea;
        private Point t_AirScanOffset;
        private Rectangle t_AirScanSafeArea;
        private Size t_AirScanOutputResolution;
        private int t_newpointindex;
        private bool t_Swap;
        private bool t_InvX;
        private bool t_InvY;
        private int t_StartX;
        private int t_StartY;
        private int t_Rwidth;
        private int t_RHeight;
        private int t_PointIDOffset;
        private PointF[] t_AirScanROI;
        private bool m_PointInZone;
        public object m_sync;
        private double m_DevicePosX;
        private double m_DevicePosY;
        private double m_DeviceOrientation;
        private int iFrame;

        [JsonProperty]
        [DefaultValue(false)]
        public bool AirScanToTUIO
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanToTUIO;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanToTUIO = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        public event AirScan.AirScanChangedEventHandler AirScanChanged;

        public event AirScan.AirScanPoint1EnterEventHandler AirScanPoint1Enter;

        public event AirScan.AirScanPoint1MoveEventHandler AirScanPoint1Move;

        public event AirScan.AirScanPoint1LeaveEventHandler AirScanPoint1Leave;

        public event AirScan.AirScanPoint2EnterEventHandler AirScanPoint2Enter;

        public event AirScan.AirScanPoint2MoveEventHandler AirScanPoint2Move;

        public event AirScan.AirScanPoint2LeaveEventHandler AirScanPoint2Leave;

        public AirScan(int iid)
        {
            AirScan iAirScan = this;
           // this.Dialog = new DialogAirScanProperties(ref iAirScan);
            this.ID = 0;
            this.m_Prediction = 0.2;
            this.m_PredictionFactor = 0.0;
            this.m_UseMotionPrediction = false;
            this.m_AirScanMuteMouse = false;
            this.m_mouseIgnoreOutputSize = false;
            this.m_AirScanToTUIO = false;
            this.ViewZoom = 10;
            this.IP = "";
            this.AirScanAdapter = "";
            this.m_AirScanPort = 9008;
            this.m_Autoconnect = false;
            this.m_sendTouchdata = true;
            this.m_MaxDelta = 0;
            this.CurrentActivePointCount = 0;
            this.rbytes = new byte[1201];
            this.procbytes = new byte[1201];
            this.t_receivemode = true;
            this.m_vector = new AirScan.ScanVectorXY[501];
            this.m_PointOne = new Collection();
            this.m_PointTwo = new Collection();
            this.m_pointOneWrite = false;
            this.m_pointTwoWrite = false;
            this.m_pointOneDone = false;
            this.m_pointTwoDone = false;
            this.IDDelegate = new AirScan.DoEventsSub(this.DoEvents);
            this.m_NewPointCollection = new Collection();
            this.m_AirScanROI = new List<PointF>();
            this.m_CalcScanOutline = true;
            this.PointValid = false;
            this.PointValidationIndex = 0;
            this.t_PointValidationCount = 2;
            this.t_PointInvalidationCount = 5;
            this.t_TrimCount = 0;
            this.PointInvalidationIndex = 530;
            this.RayCheckCollection = new Collection();
            this.t_NearRange = 300;
            this.t_FarRange = 500;
            this.t_StartRay = 0;
            this.t_StopRay = 499;
            this.t_NearPoint = 65000.0;
            this.t_FarPoint = 0.0;
            this.t_startpoint = new AirScan.ScanVectorXY();
            this.t_stoppoint = new AirScan.ScanVectorXY();
            this.t_NewPoint = new AirScan.ScanVectorXY();
            this.t_CalcPoint = new AirScan.ScanVectorXY();
            this.t_Checkpoint = new AirScan.ScanVectorXY();
            this.t_newpointindex = 1;
            this.m_sync = RuntimeHelpers.GetObjectValue(new object());
            this.iFrame = 0;
            this.ID = iid;
            this.m_AirScanArea.X = -600;
            this.m_AirScanArea.Y = -600;
            this.m_AirScanArea.Width = 1200;
            this.m_AirScanArea.Height = 800;
            this.m_AirScanSafeArea.X = -650;
            this.m_AirScanSafeArea.Y = -550;
            this.m_AirScanSafeArea.Width = 1300;
            this.m_AirScanSafeArea.Height = 900;
            this.m_AirScanRangeNear = 100;
            this.m_AirScanRangeFar = 1750;
            this.m_AirScanOutputZoom = 10;
            this.m_AirScanInvX = false;
            this.m_AirScanEnableMouse = false;
            this.m_AirScanEnableMouseClick = false;
            this.m_AirScanPointThreshold = 50;
            this.m_AirScanPointCount = 0;
            this.SigProcDamping = 0.1;
            this.m_AirScanOutputWidth = VbGlobals.PB_GUI_INSTANCE.Width;
            this.m_AirScanOutputHeight = VbGlobals.PB_GUI_INSTANCE.Height;
            this.StartX = 0;
            this.StartY = 0;
            this.RangeWidth = VbGlobals.PB_GUI_INSTANCE.Width;
            this.RangeHeight = VbGlobals.PB_GUI_INSTANCE.Height;
            this.PointIDOffset = 0;
            this.SigProcP1X = new SigProcX();
            this.SigProcP1Y = new SigProcX();
            this.SigProcP2X = new SigProcX();
            this.SigProcP2Y = new SigProcX();
            this.MaxDelta = 100;
            this.MaxPointCount = 8;
            this.m_Tracker = new AirScanPointTracker2D(this.MaxPointCount);
        }

        protected override void Dispose(bool disposing)
        {
            this.AirScanDisconnect();
        }

        public void AirScanConnect(string iIP)
        {
            this.m_sendTouchdata = true;
            this.IP = iIP;
            try
            {
                this.m_AirScanThreadReceive = new Thread(new ThreadStart(this.m_ReceiveMessages));
                this.m_AirScanThreadReceive.Start();
                this.m_isconnected = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ClxException.Throw("AirScan.AirScanConnect", (object)ex);
                ProjectData.ClearProjectError();
            }
        }

        public void EnableTouch()
        {
            this.m_sendTouchdata = true;
        }

        public void DisableTouch()
        {
            this.m_sendTouchdata = false;
        }

        public void AirScanDisconnect()
        {
            this.m_isconnected = false;
        }

        public bool IsConnected
        {
            get
            {
                return this.m_isconnected;
            }
        }

        [JsonProperty]
        [DefaultValue(false)]
        public bool AutoConnect
        {
            get
            {
                return this.m_Autoconnect;
            }
            set
            {
                this.m_Autoconnect = value;
            }
        }

        [JsonProperty]
        public double Damping
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.SigProcDamping;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.SigProcDamping = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public double Prediction
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_Prediction;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_Prediction = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public double Predictionfactor
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_PredictionFactor;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_PredictionFactor = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool UseMotionPrediction
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_UseMotionPrediction;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_UseMotionPrediction = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int MaxDelta
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_MaxDelta;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_MaxDelta = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int AirScanPointThreshold
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanPointThreshold;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanPointThreshold = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int AirScanPointCount
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanPointCount;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanPointCount = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        public bool AirScanMuteMouse
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanMuteMouse;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanMuteMouse = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanEnableMouse
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanEnableMouse;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanEnableMouse = value;
                    MouseControl.Enabled = (object)value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanEnableGui
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanEnableGui;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanEnableGui = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanEnableMouseClick
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanEnableMouseClick;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanEnableMouseClick = value;
                    MouseControl.ClickEnabled = (object)value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int AirScanMouseClickMode
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanMouseClickMode;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanMouseClickMode = value;
                    switch (value)
                    {
                        case 0:
                            MouseControl.TriggerClick = ClickTriggerEnum.OnDefault;
                            break;
                        case 1:
                            MouseControl.TriggerClick = ClickTriggerEnum.OnEnter;
                            break;
                        case 2:
                            MouseControl.TriggerClick = ClickTriggerEnum.OnLeave;
                            break;
                    }
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanMouseDownOnMove
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanMouseDownOnMove;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanMouseDownOnMove = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool MouseIgnoreOutputSize
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_mouseIgnoreOutputSize;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_mouseIgnoreOutputSize = value;
                    MouseControl.IgnoreOutputSize = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public Point AirScanOffset
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanOffset;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanOffset = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public Rectangle AirScanArea
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanArea;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanArea = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public Rectangle AirScanSafeArea
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanSafeArea;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanSafeArea = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int AirScanRangeFar
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanRangeFar;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanRangeFar = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int AirScanRangeNear
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanRangeNear;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanRangeNear = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int AirScanOutputZoom
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanOutputZoom;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanOutputZoom = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public Size AirScanOutputSize
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return new Size(this.m_AirScanOutputWidth, this.m_AirScanOutputHeight);
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanOutputWidth = value.Width;
                    this.m_AirScanOutputHeight = value.Height;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanInvX
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanInvX;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanInvX = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanInvY
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanInvY;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanInvY = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public bool AirScanSwapXY
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanSwapXY;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanSwapXY = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        public Point AirScanPoint1
        {
            get
            {
                return this.m_AirScanPoint1;
            }
        }

        public Point AirScanPoint1Delta
        {
            get
            {
                return this.m_AirScanPoint1Delta;
            }
        }

        public Point AirScanRawPoint1
        {
            get
            {
                return this.m_AirScanRawPoint1;
            }
        }

        public Point AirScanPoint2
        {
            get
            {
                return this.m_AirScanPoint2;
            }
        }

        public int AirScanAngleDelta
        {
            get
            {
                return this.m_AirScanAngleDelta;
            }
        }

        public int AirScanDistanceDelta
        {
            get
            {
                return this.m_AirScanDistanceDelta;
            }
        }

        public Point AirScanRawPoint2
        {
            get
            {
                return this.m_AirScanRawPoint2;
            }
        }

        public int AirScanAngle
        {
            get
            {
                return this.m_AirScanAngle;
            }
        }

        public int AirScanDistance
        {
            get
            {
                return this.m_AirScanDistance;
            }
        }

        public bool AirScanP1Enter
        {
            get
            {
                return this.m_AirScanP1EnterProperty;
            }
        }

        public bool AirScanP1Leave
        {
            get
            {
                return this.m_AirScanP1LeaveProperty;
            }
        }

        public bool AirScanP2Enter
        {
            get
            {
                return this.m_AirScanP2EnterProperty;
            }
        }

        public bool AirScanP2Leave
        {
            get
            {
                return this.m_AirScanP2LeaveProperty;
            }
        }

        public AirScan.ScanVectorXY[] AirScans
        {
            get
            {
                return this.m_Airscans;
            }
        }

        private void DoEvents(int ID, object info)
        {
            switch (ID)
            {
                case 0:
                    this.m_Airscans = (AirScan.ScanVectorXY[])info;
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanChangedEventHandler scanChangedEvent = this.AirScanChangedEvent;
                    if (scanChangedEvent == null)
                        break;
                    scanChangedEvent((object)this, new EventArgs());
                    break;
                case 1:
                    if (!this.m_sendTouchdata)
                        break;
                    object obj1 = NewLateBinding.LateGet(info, (Type)null, "location", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanPoint1 = obj1 != null ? (Point)obj1 : new Point();
                    object obj2 = NewLateBinding.LateGet(info, (Type)null, "rawlocation", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanRawPoint1 = obj2 != null ? (Point)obj2 : new Point();
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanPoint1EnterEventHandler point1EnterEvent = this.AirScanPoint1EnterEvent;
                    if (point1EnterEvent != null)
                        point1EnterEvent((object)this, new EventArgs());
                    this.m_AirScanP1EnterProperty = true;
                    this.m_AirScanP1LeaveProperty = false;
                    break;
                case 2:
                    if (!this.m_sendTouchdata)
                        break;
                    object obj3 = NewLateBinding.LateGet(info, (Type)null, "location", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanPoint1 = obj3 != null ? (Point)obj3 : new Point();
                    object obj4 = NewLateBinding.LateGet(info, (Type)null, "rawlocation", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanRawPoint1 = obj4 != null ? (Point)obj4 : new Point();
                    object obj5 = NewLateBinding.LateGet(info, (Type)null, "locationdelta", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanPoint1Delta = obj5 != null ? (Point)obj5 : new Point();
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanPoint1MoveEventHandler scanPoint1MoveEvent = this.AirScanPoint1MoveEvent;
                    if (scanPoint1MoveEvent != null)
                        scanPoint1MoveEvent((object)this, new EventArgs());
                    this.m_AirScanP1EnterProperty = true;
                    this.m_AirScanP1LeaveProperty = false;
                    break;
                case 3:
                    if (!this.m_sendTouchdata)
                        break;
                    this.m_AirScanPoint1Delta = new Point(0, 0);
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanPoint1LeaveEventHandler point1LeaveEvent = this.AirScanPoint1LeaveEvent;
                    if (point1LeaveEvent != null)
                        point1LeaveEvent((object)this, new EventArgs());
                    this.m_AirScanP1EnterProperty = false;
                    this.m_AirScanP1LeaveProperty = true;
                    this.m_AirScanP2LeaveProperty = true;
                    break;
                case 4:
                    if (!this.m_sendTouchdata)
                        break;
                    object obj6 = NewLateBinding.LateGet(info, (Type)null, "location", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanPoint2 = obj6 != null ? (Point)obj6 : new Point();
                    object obj7 = NewLateBinding.LateGet(info, (Type)null, "rawlocation", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanRawPoint2 = obj7 != null ? (Point)obj7 : new Point();
                    this.m_AirScanDistance = Conversions.ToInteger(NewLateBinding.LateGet(info, (Type)null, "distance", new object[0], (string[])null, (Type[])null, (bool[])null));
                    this.m_AirScanAngle = Conversions.ToInteger(NewLateBinding.LateGet(info, (Type)null, "angle", new object[0], (string[])null, (Type[])null, (bool[])null));
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanPoint2EnterEventHandler point2EnterEvent = this.AirScanPoint2EnterEvent;
                    if (point2EnterEvent != null)
                        point2EnterEvent((object)this, new EventArgs());
                    this.m_AirScanP2EnterProperty = true;
                    this.m_AirScanP2LeaveProperty = false;
                    break;
                case 5:
                    if (!this.m_sendTouchdata)
                        break;
                    object obj8 = NewLateBinding.LateGet(info, (Type)null, "location", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanPoint2 = obj8 != null ? (Point)obj8 : new Point();
                    object obj9 = NewLateBinding.LateGet(info, (Type)null, "rawlocation", new object[0], (string[])null, (Type[])null, (bool[])null);
                    this.m_AirScanRawPoint2 = obj9 != null ? (Point)obj9 : new Point();
                    this.m_AirScanDistance = Conversions.ToInteger(NewLateBinding.LateGet(info, (Type)null, "distance", new object[0], (string[])null, (Type[])null, (bool[])null));
                    this.m_AirScanDistanceDelta = Conversions.ToInteger(NewLateBinding.LateGet(info, (Type)null, "distanceDelta", new object[0], (string[])null, (Type[])null, (bool[])null));
                    this.m_AirScanAngle = Conversions.ToInteger(NewLateBinding.LateGet(info, (Type)null, "angle", new object[0], (string[])null, (Type[])null, (bool[])null));
                    this.m_AirScanAngleDelta = Conversions.ToInteger(NewLateBinding.LateGet(info, (Type)null, "angleDelta", new object[0], (string[])null, (Type[])null, (bool[])null));
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanPoint2MoveEventHandler scanPoint2MoveEvent = this.AirScanPoint2MoveEvent;
                    if (scanPoint2MoveEvent != null)
                        scanPoint2MoveEvent((object)this, new EventArgs());
                    this.m_AirScanP2EnterProperty = true;
                    this.m_AirScanP2LeaveProperty = false;
                    break;
                case 6:
                    if (!this.m_sendTouchdata)
                        break;
                    this.m_AirScanDistanceDelta = 0;
                    this.m_AirScanAngleDelta = 0;
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanPoint2LeaveEventHandler point2LeaveEvent = this.AirScanPoint2LeaveEvent;
                    if (point2LeaveEvent != null)
                        point2LeaveEvent((object)this, new EventArgs());
                    this.m_AirScanP2EnterProperty = false;
                    this.m_AirScanP2LeaveProperty = true;
                    break;
                case 11:
                    if (!this.m_sendTouchdata)
                        break;
                    // ISSUE: reference to a compiler-generated field
                    AirScan.PointEnterEventHandler pointEnterEvent = this.PointEnterEvent;
                    if (pointEnterEvent == null)
                        break;
                    pointEnterEvent(this.ID, Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 0
                    }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 1
                    }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 2
                    }, (string[])null)), 0, 0);
                    break;
                case 12:
                    if (!this.m_sendTouchdata)
                        break;
                    // ISSUE: reference to a compiler-generated field
                    AirScan.PointMoveEventHandler pointMoveEvent = this.PointMoveEvent;
                    if (pointMoveEvent != null)
                        pointMoveEvent(this.ID, Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                        {
              (object) 0
                        }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                        {
              (object) 1
                        }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                        {
              (object) 2
                        }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                        {
              (object) 3
                        }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                        {
              (object) 4
                        }, (string[])null)), 0, 0);
                    this.CalibrateP1X = Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 5
                    }, (string[])null));
                    this.CalibrateP1Y = Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 6
                    }, (string[])null));
                    break;
                case 13:
                    if (!this.m_sendTouchdata)
                        break;
                    // ISSUE: reference to a compiler-generated field
                    AirScan.PointLeaveEventHandler pointLeaveEvent = this.PointLeaveEvent;
                    if (pointLeaveEvent == null)
                        break;
                    pointLeaveEvent(this.ID, Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 0
                    }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 1
                    }, (string[])null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 2
                    }, (string[])null)), 0, 0);
                    break;
                case 14:
                    // ISSUE: reference to a compiler-generated field
                    AirScan.AirScanDisconnectedEventHandler disconnectedEvent = this.AirScanDisconnectedEvent;
                    if (disconnectedEvent == null)
                        break;
                    disconnectedEvent();
                    break;
                case 15:
                    this.CurrentActivePointCount = Conversions.ToInteger(NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 0
                    }, (string[])null));
                    break;
                case 16:
                    if (!this.m_sendTouchdata)
                        break;
                    Collection pointcol = (Collection)NewLateBinding.LateIndexGet(info, new object[1]
                    {
            (object) 0
                    }, (string[])null);
                    this.SendTuioTouches(ref pointcol);
                    break;
            }
        }

        public event AirScan.PointEnterEventHandler PointEnter;

        public event AirScan.PointMoveEventHandler PointMove;

        public event AirScan.PointLeaveEventHandler PointLeave;

        public event AirScan.AirScanDisconnectedEventHandler AirScanDisconnected;

        public void PointInvoker(int Id, int[] info)
        {
            try
            {
                Gui.Context.Invoke((Action)(() => this.IDDelegate(Id, (object)info)));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ClxException.Throw(ex);
                ProjectData.ClearProjectError();
            }
        }

        public void PointInvokerCol(int Id, object[] info)
        {
            try
            {
                Gui.Context.Invoke((Action)(() => this.IDDelegate(Id, (object)info)));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ClxException.Throw(ex);
                ProjectData.ClearProjectError();
            }
        }

        [JsonProperty]
        public bool ReceiveMode
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_receivemode;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_receivemode = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        private void m_ReceiveMessages()
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(this.IP, this.m_AirScanPort);
            }
            catch (SocketException ex)
            {
                ProjectData.SetProjectError((Exception)ex);
                ClxException.Throw((Exception)ex);
                tcpClient.Close();
                this.m_isconnected = false;
                ProjectData.ClearProjectError();
                return;
            }
            int[] msg = new int[1059];
            this.SigProcP1X.Alpha_Gain = this.SigProcDamping;
            this.SigProcP1X.Beta_Gain = this.SigProcDamping / 2.0;
            this.SigProcP1Y.Alpha_Gain = this.SigProcDamping;
            this.SigProcP1Y.Beta_Gain = this.SigProcDamping / 2.0;
            this.SigProcP2X.Alpha_Gain = this.SigProcDamping;
            this.SigProcP2X.Beta_Gain = this.SigProcDamping / 2.0;
            this.SigProcP2Y.Alpha_Gain = this.SigProcDamping;
            this.SigProcP2Y.Beta_Gain = this.SigProcDamping / 2.0;
            SigProcX sigProcP1X = this.SigProcP1X;
            bool flag1 = true;
            ref bool local1 = ref flag1;
            double x1 = 0.0;
            ref double local2 = ref this.m_AlphaP1X;
            ref double local3 = ref this.m_BetaP1X;
            sigProcP1X.alpha_beta(ref local1, x1, ref local2, ref local3);
            SigProcX sigProcP1Y = this.SigProcP1Y;
            bool flag2 = true;
            ref bool local4 = ref flag2;
            double x2 = 0.0;
            ref double local5 = ref this.m_AlphaP1X;
            ref double local6 = ref this.m_BetaP1Y;
            sigProcP1Y.alpha_beta(ref local4, x2, ref local5, ref local6);
            SigProcX sigProcP2X = this.SigProcP2X;
            bool flag3 = true;
            ref bool local7 = ref flag3;
            double x3 = 0.0;
            ref double local8 = ref this.m_AlphaP2X;
            ref double local9 = ref this.m_BetaP2X;
            sigProcP2X.alpha_beta(ref local7, x3, ref local8, ref local9);
            SigProcX sigProcP2Y = this.SigProcP2Y;
            bool flag4 = true;
            ref bool local10 = ref flag4;
            double x4 = 0.0;
            ref double local11 = ref this.m_AlphaP2X;
            ref double local12 = ref this.m_BetaP2Y;
            sigProcP2Y.alpha_beta(ref local10, x4, ref local11, ref local12);
            while (this.m_isconnected)
            {
                try
                {
                    tcpClient.GetStream().Read(this.rbytes, 0, this.rbytes.Length);
                    if (this.rbytes[0] == (byte)0 & this.rbytes[1] == (byte)0 & this.rbytes[2] == (byte)35 & this.rbytes[14] == (byte)1 & this.rbytes[15] == (byte)0 & this.rbytes[16] == (byte)1 & this.rbytes[17] == (byte)2)
                    {
                        int num1 = 0;
                        bool flag5 = false;
                        int num2 = checked(this.rbytes.Length - 1);
                        int index1 = 19;
                        while (index1 <= num2)
                        {
                            if (num1 != 2 & !flag5)
                            {
                                this.procbytes[index1] = this.rbytes[index1];
                            }
                            else
                            {
                                flag5 = false;
                                num1 = 0;
                            }
                            if (this.rbytes[index1] == (byte)0)
                                checked { ++num1; }
                            else
                                num1 = 0;
                            if (num1 == 2)
                            {
                                flag5 = true;
                                num1 = 0;
                            }
                            checked { ++index1; }
                        }
                        int index2 = 0;
                        do
                        {
                            msg[index2] = checked(256 * (int)this.procbytes[2 * index2 + 19] + (int)this.procbytes[2 * index2 + 1 + 19]);
                            checked { ++index2; }
                        }
                        while (index2 <= 528);
                        object sync = this.m_sync;
                        ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                        bool lockTaken = false;
                        try
                        {
                            Monitor.Enter(sync, ref lockTaken);
                            this.t_receivemode = this.ReceiveMode;
                        }
                        finally
                        {
                            if (lockTaken)
                                Monitor.Exit(sync);
                        }
                        if (!this.t_receivemode)
                            this.m_UpdateMessage(msg);
                        else
                            this.m_UpdateMultiPointMessage(msg);
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ClxException.Throw(ex);
                    this.PointInvoker(14, new int[3] { 0, 0, 0 });
                    tcpClient?.Close();
                    ProjectData.ClearProjectError();
                    return;
                }
            }
            tcpClient.Close();
        }

        [JsonProperty]
        public int MaxPointCount
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_MaxPointCount;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                this.m_MaxPointCount = value;
                if (this.m_Tracker == null)
                    return;
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_Tracker.PointCount = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        public int NearRange
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_NearRange;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                this.t_NearRange = value;
            }
        }

        public int FarRange
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_FarRange;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_FarRange = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int StartRay
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_StartRay;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_StartRay = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int StopRay
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_StopRay;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_StopRay = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int StartX
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_StartX;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_StartX = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int StartY
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_StartY;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_StartY = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int RangeWidth
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_RWidth;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_RWidth = value;
                    PointerEventRouter.Range.X = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int RangeHeight
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_RHeight;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_RHeight = value;
                    PointerEventRouter.Range.Y = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int PointIDOffset
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_PointIDOffset;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_PointIDOffset = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public List<PointF> RegionOfInterest
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_AirScanROI;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_AirScanROI = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        public bool CalcScanOutline
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_CalcScanOutline;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_CalcScanOutline = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int PointValidationCount
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_PointValidationCount;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_PointValidationCount = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int PointInvalidationCount
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_PointInvalidationCount;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_PointInvalidationCount = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public int TrimCount
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.t_TrimCount;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.t_TrimCount = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public double DevicePosX
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_DevicePosX;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_DevicePosX = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public double DevicePosY
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_DevicePosY;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_DevicePosY = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        [JsonProperty]
        public double DeviceOrientation
        {
            get
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    return this.m_DeviceOrientation;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
            set
            {
                object sync = this.m_sync;
                ObjectFlowControl.CheckForSyncLockOnValueType(sync);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(sync, ref lockTaken);
                    this.m_DeviceOrientation = value;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(sync);
                }
            }
        }

        private void m_UpdateMultiPointMessage(int[] msg)
        {
            object sync = this.m_sync;
            ObjectFlowControl.CheckForSyncLockOnValueType(sync);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(sync, ref lockTaken);
                this.t_CalcOutline = this.m_CalcScanOutline;
                this.t_Prediction = this.m_Prediction;
                this.t_UseMotionPrediction = this.m_UseMotionPrediction;
                this.t_MotionPredictionFactor = this.m_PredictionFactor;
                this.t_MaxDelta = this.m_MaxDelta;
                this.t_SigProcDamping = this.SigProcDamping;
                this.t_NearRange = this.NearRange;
                this.t_FarRange = this.FarRange;
                this.t_StartRay = this.StartRay;
                this.t_StopRay = this.StopRay;
                this.t_PointValidationCount = this.PointValidationCount;
                this.t_PointInvalidationCount = this.PointInvalidationCount;
                this.t_AirScanArea = this.AirScanArea;
                this.t_AirScanOffset = this.m_AirScanOffset;
                this.t_AirScanSafeArea = this.AirScanSafeArea;
                this.t_AirScanOutputResolution = this.AirScanOutputSize;
                this.t_Swap = this.AirScanSwapXY;
                this.t_InvX = this.AirScanInvX;
                this.t_InvY = this.AirScanInvY;
                this.t_StartX = this.m_StartX;
                this.t_StartY = this.m_StartY;
                this.t_Rwidth = this.m_RWidth;
                this.t_RHeight = this.m_RHeight;
                this.t_PointIDOffset = this.m_PointIDOffset;
                if (this.m_AirScanROI.Count > 0)
                {
                    this.t_AirScanROI = new PointF[checked(this.m_AirScanROI.Count - 1 + 1)];
                    int num = checked(this.m_AirScanROI.Count - 1);
                    int index = 0;
                    while (index <= num)
                    {
                        this.t_AirScanROI[index] = new PointF(this.m_AirScanROI[index].X, this.m_AirScanROI[index].Y);
                        checked { ++index; }
                    }
                }
                if (this.m_AirScanROI.Count == 0)
                    this.t_AirScanROI = (PointF[])null;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(sync);
            }
            this.m_NewPointCollection.Clear();
            if (this.RayCheckCollection.Count > 0)
                this.RayCheckCollection.Clear();
            this.PointValidationIndex = 0;
            this.PointInvalidationIndex = 0;
            this.t_IgnoreRays = false;
            this.PointValid = false;
            this.t_newpointindex = 1;
            int Ray = 0;
            do
            {
                if (this.t_CalcOutline)
                {
                    if (Ray >= this.t_StartRay & Ray <= this.t_StopRay)
                        this.ScanAngleToPoint(ref this.m_vector[Ray], Ray, msg[checked(Ray + 14)], this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                    else
                        this.ScanAngleToPoint(ref this.m_vector[Ray], Ray, 0, this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                }
                if (Ray >= this.t_StartRay & Ray <= this.t_StopRay)
                {
                    if (this.t_IgnoreRays & this.PointInvalidationIndex >= this.PointInvalidationCount)
                    {
                        this.PointInvalidationIndex = 0;
                        this.t_IgnoreRays = false;
                        this.PointValid = false;
                        this.PointValidationIndex = 0;
                    }
                    // ISSUE: variable of a reference type
                    int&local1;
                    // ISSUE: explicit reference operation
                    int num1 = checked(^ (local1 = ref this.PointInvalidationIndex) + 1);
                    local1 = num1;
                    this.ScanAngleToPoint(ref this.t_Checkpoint, checked(14 + Ray), msg[checked(14 + Ray)], this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                    this.m_PointInZone = this.t_AirScanROI == null ? this.t_Checkpoint.X > (double)this.t_AirScanSafeArea.X & this.t_Checkpoint.X < (double)checked(this.t_AirScanSafeArea.X + this.t_AirScanSafeArea.Width) & this.t_Checkpoint.Y < (double)this.t_AirScanSafeArea.Y & this.t_Checkpoint.Y > (double)checked(this.t_AirScanSafeArea.Y - this.t_AirScanSafeArea.Height) : Math_Helper.PointInPolygon(this.t_AirScanROI, this.t_Checkpoint.X, this.t_Checkpoint.Y);
                    if (this.m_PointInZone)
                    {
                        if (!this.t_IgnoreRays)
                        {
                            if (this.PointValidationIndex == 0)
                                this.StartedRay = Ray;
                            this.RayCheckCollection.Add((object)msg[checked(14 + Ray)], (string)null, (object)null, (object)null);
                            if (this.PointValidationIndex >= this.PointValidationCount)
                                this.PointValid = true;
                            // ISSUE: variable of a reference type
                            int&local2;
                            // ISSUE: explicit reference operation
                            int num2 = checked(^ (local2 = ref this.PointValidationIndex) + 1);
                            local2 = num2;
                        }
                    }
                    else if (this.PointValid)
                    {
                        this.StoppedRay = checked(Ray - 1);
                        this.t_IgnoreRays = true;
                        this.PointInvalidationIndex = 0;
                        this.CenterRay = checked((int)Math.Round(unchecked((double)this.StartedRay + (double)checked(this.StoppedRay - this.StartedRay) / 2.0)));
                        this.AverageDistance = 0.0;
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        if (this.RayCheckCollection.Count > 4)
                        {
                            this.RayCheckCollection.Remove(1);
                            this.RayCheckCollection.Remove(this.RayCheckCollection.Count);
                        }
                        int count = this.RayCheckCollection.Count;
                        int index = 1;
                        while (index <= count)
                        {
                            // ISSUE: variable of a reference type
                            double&local2;
                            // ISSUE: explicit reference operation
                            double num2 = Conversions.ToDouble(Operators.AddObject((object) ^ (local2 = ref this.AverageDistance), this.RayCheckCollection[index]));
                            local2 = num2;
                            this.t_FarPoint = (double)this.t_NearRange;
                            this.t_NearPoint = (double)this.t_FarRange;
                            this.ScanAngleToPoint(ref this.t_CalcPoint, checked(14 + this.StartedRay + index - 1), Conversions.ToInteger(this.RayCheckCollection[index]), this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                            if (this.t_CalcPoint.Y > this.t_FarPoint)
                                this.t_FarPoint = this.t_CalcPoint.Y;
                            if (this.t_CalcPoint.Y < this.t_NearPoint)
                                this.t_NearPoint = this.t_CalcPoint.Y;
                            checked { ++index; }
                        }
                        // ISSUE: variable of a reference type
                        double&local3;
                        // ISSUE: explicit reference operation
                        double num3 = ^ (local3 = ref this.AverageDistance) / (double)this.RayCheckCollection.Count;
                        local3 = num3;
                        this.RayCheckCollection.Clear();
                        this.t_NewPoint.Active = true;
                        this.ScanAngleToPoint(ref this.t_NewPoint, this.CenterRay, checked((int)Math.Round(this.AverageDistance)), this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                        AirScanTrackingPoint2D scanTrackingPoint2D = new AirScanTrackingPoint2D();
                        scanTrackingPoint2D.ID = this.t_newpointindex;
                        scanTrackingPoint2D.Active = true;
                        scanTrackingPoint2D.CenterX = this.t_NewPoint.X;
                        scanTrackingPoint2D.CenterY = this.t_NewPoint.Y;
                        this.ScanAngleToPoint(ref this.t_startpoint, checked(14 + this.StartedRay), msg[checked(14 + this.StartedRay)], this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                        this.ScanAngleToPoint(ref this.t_stoppoint, checked(13 + this.StoppedRay), msg[checked(13 + this.StoppedRay)], this.m_DeviceOrientation, this.m_DevicePosX, this.m_DevicePosY);
                        scanTrackingPoint2D.Width = this.t_stoppoint.X - this.t_startpoint.X;
                        scanTrackingPoint2D.Height = this.t_FarPoint - this.t_NearPoint;
                        this.m_NewPointCollection.Add((object)scanTrackingPoint2D, this.t_newpointindex.ToString(), (object)null, (object)null);
                        // ISSUE: variable of a reference type
                        int&local4;
                        // ISSUE: explicit reference operation
                        int num4 = checked(^ (local4 = ref this.t_newpointindex) + 1);
                        local4 = num4;
                        this.PointValid = false;
                    }
                    else
                    {
                        this.PointValid = false;
                        this.PointValidationIndex = 0;
                        this.RayCheckCollection.Clear();
                    }
                }
                checked { ++Ray; }
            }
            while (Ray <= 499);
            AirScanPointTracker2D tracker = this.m_Tracker;
            AirScan airScan = this;
            ref AirScan local = ref airScan;
            Collection newPointCollection = this.m_NewPointCollection;
            double tSigProcDamping = this.t_SigProcDamping;
            double tPrediction = this.t_Prediction;
            int tTrimCount = this.t_TrimCount;
            int tMaxDelta = this.t_MaxDelta;
            Size outputResolution = this.t_AirScanOutputResolution;
            Rectangle tAirScanArea = this.t_AirScanArea;
            Point tAirScanOffset = this.t_AirScanOffset;
            int num5 = this.t_Swap ? 1 : 0;
            int num6 = this.t_InvX ? 1 : 0;
            int num7 = this.t_InvY ? 1 : 0;
            int tStartX = this.t_StartX;
            int tStartY = this.t_StartY;
            int tRwidth = this.t_Rwidth;
            int tRheight = this.t_RHeight;
            int tPointIdOffset = this.t_PointIDOffset;
            int num8 = this.t_UseMotionPrediction ? 1 : 0;
            double predictionFactor = this.t_MotionPredictionFactor;
            tracker.EvaluatePoints(ref local, newPointCollection, tSigProcDamping, tPrediction, tTrimCount, tMaxDelta, outputResolution, tAirScanArea, tAirScanOffset, num5 != 0, num6 != 0, num7 != 0, tStartX, tStartY, tRwidth, tRheight, tPointIdOffset, num8 != 0, predictionFactor);
            if (!this.t_CalcOutline)
                return;
            Gui.Context.Invoke((Action)(() => this.IDDelegate(0, (object)this.m_vector)));
        }

        private void m_UpdateMessage(int[] msg)
        {
            this.m_PointOne.Clear();
            this.m_PointTwo.Clear();
            this.m_pointOneWrite = false;
            this.m_pointTwoWrite = false;
            this.m_pointOneDone = false;
            this.m_pointTwoDone = false;
            this.SigProcP1X.Alpha_Gain = this.SigProcDamping;
            this.SigProcP1X.Beta_Gain = this.SigProcDamping / 2.0;
            this.SigProcP1Y.Alpha_Gain = this.SigProcDamping;
            this.SigProcP1Y.Beta_Gain = this.SigProcDamping / 2.0;
            this.SigProcP2X.Alpha_Gain = this.SigProcDamping;
            this.SigProcP2X.Beta_Gain = this.SigProcDamping / 2.0;
            this.SigProcP2Y.Alpha_Gain = this.SigProcDamping;
            this.SigProcP2Y.Beta_Gain = this.SigProcDamping / 2.0;
            this.m_AirScanPoint1Active = false;
            this.m_AirScanPoint2Active = false;
            int index1 = 0;
            do
            {
                if (index1 < 250)
                {
                    this.m_DegAngle = (double)index1 * 0.36;
                    this.m_RadAngle = this.m_DegAngle / (180.0 / Math.PI);
                    this.m_vector[index1].X = (double)msg[checked(14 + index1)] * Math.Cos(this.m_RadAngle);
                    this.m_vector[index1].Y = (double)checked(-msg[14 + index1]) * Math.Sin(this.m_RadAngle);
                    this.m_vector[index1].ScanAngle = this.m_DegAngle;
                    this.m_vector[index1].ScanDistance = (double)msg[checked(14 + index1)];
                }
                if (index1 == 250)
                {
                    this.m_vector[index1].X = 0.0;
                    this.m_vector[index1].Y = (double)checked(-msg[14 + index1]);
                    this.m_vector[index1].ScanAngle = 90.0;
                    this.m_vector[index1].ScanDistance = (double)msg[checked(14 + index1)];
                }
                if (index1 > 250)
                {
                    this.m_DegAngle = 90.0 - Math.Abs(90.0 - (double)index1 * 0.36);
                    this.m_RadAngle = this.m_DegAngle / (180.0 / Math.PI);
                    this.m_vector[index1].X = (double)checked(-msg[14 + index1]) * Math.Cos(this.m_RadAngle);
                    this.m_vector[index1].Y = (double)checked(-msg[14 + index1]) * Math.Sin(this.m_RadAngle);
                    this.m_vector[index1].ScanAngle = this.m_DegAngle;
                    this.m_vector[index1].ScanDistance = (double)msg[checked(14 + index1)];
                }
                checked { ++index1; }
            }
            while (index1 <= 499);
            int index2 = 0;
            do
            {
                if (this.m_vector[index2].X > (double)this.m_AirScanArea.X & this.m_vector[index2].X < (double)checked(this.m_AirScanArea.X + this.m_AirScanArea.Width))
                {
                    if (this.m_vector[index2].Y < (double)this.m_AirScanArea.Y & this.m_vector[index2].Y > (double)checked(this.m_AirScanArea.Y - this.m_AirScanArea.Height))
                    {
                        if (!this.m_pointOneDone)
                        {
                            if (this.m_pointOneWrite)
                            {
                                this.m_PointOne.Add((object)this.m_vector[index2], (string)null, (object)null, (object)null);
                                this.m_AirScanPoint1inUse = true;
                            }
                            else
                            {
                                this.m_pointOneWrite = true;
                                this.m_PointOne.Add((object)this.m_vector[index2], (string)null, (object)null, (object)null);
                                this.m_AirScanPoint1Enter = !this.m_AirScanPoint1inUse;
                                this.m_AirScanPoint1Leave = false;
                                this.m_AirScanPoint1Active = true;
                                this.m_AirScanPoint1inUse = true;
                            }
                        }
                    }
                    else if (this.m_pointOneWrite)
                    {
                        this.m_pointOneWrite = false;
                        this.m_pointOneDone = true;
                    }
                }
                else if (this.m_pointOneWrite)
                {
                    this.m_pointOneWrite = false;
                    this.m_pointOneDone = true;
                }
                double scanDistance = this.m_vector[index2].ScanDistance;
                if (scanDistance > (double)this.m_AirScanRangeFar)
                {
                    if (!this.m_pointOneDone && this.m_pointOneWrite)
                    {
                        this.m_pointOneWrite = false;
                        this.m_pointOneDone = true;
                    }
                }
                else if (scanDistance < (double)this.m_AirScanRangeNear && !this.m_pointOneDone && this.m_pointOneWrite)
                {
                    this.m_pointOneWrite = false;
                    this.m_pointOneDone = true;
                }
                checked { ++index2; }
            }
            while (index2 <= 499);
            if (!this.m_AirScanPoint1Active & this.m_AirScanPoint1inUse)
            {
                this.m_AirScanPoint1inUse = false;
                this.m_AirScanPoint1Leave = true;
                Gui.Context.Invoke((Action)(() => this.IDDelegate(3, (object)0)));
                this.m_AirScanPoint1DeltaLast = new Point(0, 0);
                this.m_AirScanPoint2Active = false;
                this.m_AirScanPoint2inUse = false;
                this.m_AirScanPoint2Enter = false;
                Gui.Context.Invoke((Action)(() => this.IDDelegate(6, (object)0)));
                this.m_AirScanPoint2DeltaLast = new Point(0, 0);
                Gui.Context.Invoke((Action)(() => this.IDDelegate(0, (object)this.m_vector)));
            }
            double num1 = 0.0;
            double num2 = 0.0;
            if (this.m_PointOne != null)
            {
                int count = this.m_PointOne.Count;
                try
                {
                    foreach (object obj in this.m_PointOne)
                    {
                        AirScan.ScanVectorXY scanVectorXy = obj != null ? (AirScan.ScanVectorXY)obj : new AirScan.ScanVectorXY();
                        num1 += scanVectorXy.X;
                        num2 += scanVectorXy.Y;
                    }
                }
                finally
                {
                    IEnumerator enumerator;
                    if (enumerator is IDisposable)
                        (enumerator as IDisposable).Dispose();
                }
                if (count > this.m_AirScanPointCount)
                {
                    double a1 = num1 / (double)count;
                    double a2 = num2 / (double)count;
                    this.pointOneX = (a1 - (double)this.m_AirScanArea.X) * ((double)this.m_AirScanOutputWidth / (double)this.m_AirScanArea.Width);
                    this.pointOneY = (a2 - (double)this.m_AirScanArea.Y) * ((double)this.m_AirScanOutputHeight / (double)this.m_AirScanArea.Height);
                    if (this.m_AirScanPoint1Enter)
                    {
                        this.m_AirScanPoint1Enter = false;
                        SigProcX sigProcP1X = this.SigProcP1X;
                        bool flag1 = true;
                        ref bool local1 = ref flag1;
                        double pointOneX1 = this.pointOneX;
                        ref double local2 = ref this.m_AlphaP1X;
                        ref double local3 = ref this.m_BetaP1X;
                        sigProcP1X.alpha_beta(ref local1, pointOneX1, ref local2, ref local3);
                        SigProcX sigProcP1Y = this.SigProcP1Y;
                        bool flag2 = true;
                        ref bool local4 = ref flag2;
                        double pointOneY = this.pointOneY;
                        ref double local5 = ref this.m_AlphaP1Y;
                        ref double local6 = ref this.m_BetaP1Y;
                        sigProcP1Y.alpha_beta(ref local4, pointOneY, ref local5, ref local6);
                        if (this.AirScanInvX)
                        {
                            this.pointOneX = (double)this.AirScanOutputSize.Width - this.pointOneX;
                            this.m_AlphaP1X = (double)this.AirScanOutputSize.Width - this.m_AlphaP1X;
                        }
                        if (this.AirScanInvY)
                        {
                            double num3 = -1.0;
                            Size airScanOutputSize = this.AirScanOutputSize;
                            double num4 = (double)airScanOutputSize.Height + this.pointOneY;
                            this.pointOneY = num3 * num4;
                            double num5 = -1.0;
                            airScanOutputSize = this.AirScanOutputSize;
                            double num6 = (double)airScanOutputSize.Height + this.m_AlphaP1Y;
                            this.m_AlphaP1Y = num5 * num6;
                        }
                        if (this.AirScanSwapXY)
                        {
                            double pointOneX2 = this.pointOneX;
                            this.pointOneX = -1.0 * this.pointOneY;
                            this.pointOneY = -1.0 * pointOneX2;
                            int num3 = checked((int)Math.Round(this.m_AlphaP1X));
                            this.m_AlphaP1X = (double)checked(-1 * (int)Math.Round(this.m_AlphaP1Y));
                            this.m_AlphaP1Y = (double)checked(-1 * num3);
                        }
                        this.m_Point1Info.Location = new Point(checked((int)Math.Round(this.pointOneX)), checked(-(int)Math.Round(this.pointOneY)));
                        this.m_Point1Info.RawLocation = new Point(checked((int)Math.Round(a1)), checked((int)Math.Round(a2)));
                        Gui.Context.Invoke((Action)(() => this.IDDelegate(1, (object)this.m_Point1Info)));
                        this.m_AirScanPoint1DeltaLast = new Point(checked((int)Math.Round(this.pointOneX)), checked(-(int)Math.Round(this.pointOneY)));
                    }
                    else
                    {
                        SigProcX sigProcP1X = this.SigProcP1X;
                        bool flag1 = false;
                        ref bool local1 = ref flag1;
                        double pointOneX1 = this.pointOneX;
                        ref double local2 = ref this.m_AlphaP1X;
                        ref double local3 = ref this.m_BetaP1X;
                        sigProcP1X.alpha_beta(ref local1, pointOneX1, ref local2, ref local3);
                        SigProcX sigProcP1Y = this.SigProcP1Y;
                        bool flag2 = false;
                        ref bool local4 = ref flag2;
                        double pointOneY = this.pointOneY;
                        ref double local5 = ref this.m_AlphaP1Y;
                        ref double local6 = ref this.m_BetaP1Y;
                        sigProcP1Y.alpha_beta(ref local4, pointOneY, ref local5, ref local6);
                        if (this.AirScanInvX)
                        {
                            this.pointOneX = (double)this.AirScanOutputSize.Width - this.pointOneX;
                            this.m_AlphaP1X = (double)this.AirScanOutputSize.Width - this.m_AlphaP1X;
                        }
                        if (this.AirScanInvY)
                        {
                            double num3 = -1.0;
                            Size airScanOutputSize = this.AirScanOutputSize;
                            double num4 = (double)airScanOutputSize.Height + this.pointOneY;
                            this.pointOneY = num3 * num4;
                            double num5 = -1.0;
                            airScanOutputSize = this.AirScanOutputSize;
                            double num6 = (double)airScanOutputSize.Height + this.m_AlphaP1Y;
                            this.m_AlphaP1Y = num5 * num6;
                        }
                        if (this.AirScanSwapXY)
                        {
                            double pointOneX2 = this.pointOneX;
                            this.pointOneX = -1.0 * this.pointOneY;
                            this.pointOneY = -1.0 * pointOneX2;
                            int num3 = checked((int)Math.Round(this.m_AlphaP1X));
                            this.m_AlphaP1X = (double)checked(-1 * (int)Math.Round(this.m_AlphaP1Y));
                            this.m_AlphaP1Y = (double)checked(-1 * num3);
                        }
                        this.m_Point1Info.LocationDelta = new Point(checked(-1 * this.m_AirScanPoint1DeltaLast.X - (int)Math.Round(this.m_AlphaP1X)), checked(-1 * this.m_AirScanPoint1DeltaLast.Y + (int)Math.Round(this.m_AlphaP1Y)));
                        this.m_Point1Info.Location = new Point(checked((int)Math.Round(this.m_AlphaP1X)), checked(-(int)Math.Round(this.m_AlphaP1Y)));
                        this.m_Point1Info.RawLocation = new Point(checked((int)Math.Round(a1)), checked((int)Math.Round(a2)));
                        Gui.Context.Invoke((Action)(() => this.IDDelegate(2, (object)this.m_Point1Info)));
                    }
                }
            }
            int index3 = 499;
            do
            {
                if (this.m_vector[index3].X > (double)this.m_AirScanArea.X & this.m_vector[index3].X < (double)checked(this.m_AirScanArea.X + this.m_AirScanArea.Width))
                {
                    if (this.m_vector[index3].Y < (double)this.m_AirScanArea.Y & this.m_vector[index3].Y > (double)checked(this.m_AirScanArea.Y - this.m_AirScanArea.Height))
                    {
                        if (!this.m_pointTwoDone)
                        {
                            if (this.m_pointTwoWrite)
                            {
                                this.m_PointTwo.Add((object)this.m_vector[index3], (string)null, (object)null, (object)null);
                                this.m_AirScanPoint2inUse = true;
                            }
                            else
                            {
                                this.m_pointTwoWrite = true;
                                this.m_PointTwo.Add((object)this.m_vector[index3], (string)null, (object)null, (object)null);
                                this.m_AirScanPoint2inUse = true;
                            }
                        }
                    }
                    else if (this.m_pointTwoWrite)
                    {
                        this.m_pointTwoWrite = false;
                        this.m_pointTwoDone = true;
                    }
                }
                else if (this.m_pointTwoWrite)
                {
                    this.m_pointTwoWrite = false;
                    this.m_pointTwoDone = true;
                }
                double scanDistance = this.m_vector[index3].ScanDistance;
                if (scanDistance > (double)this.m_AirScanRangeFar)
                {
                    if (!this.m_pointTwoDone && this.m_pointTwoWrite)
                    {
                        this.m_pointTwoWrite = false;
                        this.m_pointTwoDone = true;
                    }
                }
                else if (scanDistance < (double)this.m_AirScanRangeNear && !this.m_pointTwoDone && this.m_pointTwoWrite)
                {
                    this.m_pointTwoWrite = false;
                    this.m_pointTwoDone = true;
                }
                checked { index3 += -1; }
            }
            while (index3 >= 0);
            double num7 = 0.0;
            double num8 = 0.0;
            if (this.m_PointTwo != null)
            {
                int count1 = this.m_PointTwo.Count;
                try
                {
                    foreach (object obj in this.m_PointTwo)
                    {
                        AirScan.ScanVectorXY scanVectorXy = obj != null ? (AirScan.ScanVectorXY)obj : new AirScan.ScanVectorXY();
                        num7 += scanVectorXy.X;
                        num8 += scanVectorXy.Y;
                    }
                }
                finally
                {
                    IEnumerator enumerator;
                    if (enumerator is IDisposable)
                        (enumerator as IDisposable).Dispose();
                }
                if (count1 > this.m_AirScanPointCount)
                {
                    double a1 = num7 / (double)count1;
                    double a2 = num8 / (double)count1;
                    this.pointTwoX = (a1 - (double)this.m_AirScanArea.X) * ((double)this.m_AirScanOutputWidth / (double)this.m_AirScanArea.Width);
                    this.pointTwoY = (a2 - (double)this.m_AirScanArea.Y) * ((double)this.m_AirScanOutputHeight / (double)this.m_AirScanArea.Height);
                    bool flag1;
                    Size airScanOutputSize;
                    if (!this.m_AirScanPoint2Enter)
                    {
                        SigProcX sigProcP2X = this.SigProcP2X;
                        bool flag2 = true;
                        ref bool local1 = ref flag2;
                        double pointTwoX1 = this.pointTwoX;
                        ref double local2 = ref this.m_AlphaP2X;
                        ref double local3 = ref this.m_BetaP2X;
                        sigProcP2X.alpha_beta(ref local1, pointTwoX1, ref local2, ref local3);
                        SigProcX sigProcP2Y = this.SigProcP2Y;
                        flag1 = true;
                        ref bool local4 = ref flag1;
                        double pointTwoY = this.pointTwoY;
                        ref double local5 = ref this.m_AlphaP2Y;
                        ref double local6 = ref this.m_BetaP2Y;
                        sigProcP2Y.alpha_beta(ref local4, pointTwoY, ref local5, ref local6);
                        if (this.AirScanInvX)
                        {
                            this.pointTwoX = (double)this.AirScanOutputSize.Width - this.pointTwoX;
                            this.m_AlphaP2X = (double)this.AirScanOutputSize.Width - this.m_AlphaP2X;
                        }
                        if (this.AirScanInvY)
                        {
                            double num3 = -1.0;
                            airScanOutputSize = this.AirScanOutputSize;
                            double num4 = (double)airScanOutputSize.Height + this.pointTwoY;
                            this.pointTwoY = num3 * num4;
                            double num5 = -1.0;
                            airScanOutputSize = this.AirScanOutputSize;
                            double num6 = (double)airScanOutputSize.Height + this.m_AlphaP2Y;
                            this.m_AlphaP2Y = num5 * num6;
                        }
                        if (this.AirScanSwapXY)
                        {
                            double pointTwoX2 = this.pointTwoX;
                            this.pointTwoX = -1.0 * this.pointTwoY;
                            this.pointTwoY = -1.0 * pointTwoX2;
                            int num3 = checked((int)Math.Round(this.m_AlphaP2X));
                            this.m_AlphaP2X = (double)checked(-1 * (int)Math.Round(this.m_AlphaP2Y));
                            this.m_AlphaP2Y = (double)checked(-1 * num3);
                        }
                        this.m_Point2Info.Location = new Point(checked((int)Math.Round(this.pointTwoX)), checked(-(int)Math.Round(this.pointTwoY)));
                        this.m_Point2Info.RawLocation = new Point(checked((int)Math.Round(a1)), checked((int)Math.Round(a2)));
                        this.m_Point2Info.Distance = checked((int)Math.Round(Math.Round(this.m_PointDistance, 0)));
                        this.m_Point2Info.Angle = checked((int)Math.Round(Math.Round(this.m_PointAngle, 0)));
                        if (this.m_Point2Info.RawLocation.X < checked(this.m_Point1Info.RawLocation.X - this.m_AirScanPointThreshold))
                        {
                            Gui.Context.Invoke((Action)(() => this.IDDelegate(4, (object)this.m_Point2Info)));
                            this.m_AirScanPoint2Enter = true;
                            if (!this.m_AirScanPoint2inUse)
                                this.m_AirScanPoint2inUse = true;
                            this.m_AirScanPoint2Active = true;
                            double num3 = 0.0;
                            double num4 = 0.0;
                            if (this.m_PointOne != null)
                            {
                                int count2 = this.m_PointOne.Count;
                                try
                                {
                                    foreach (object obj in this.m_PointOne)
                                    {
                                        AirScan.ScanVectorXY scanVectorXy = obj != null ? (AirScan.ScanVectorXY)obj : new AirScan.ScanVectorXY();
                                        num3 += scanVectorXy.X;
                                        num4 += scanVectorXy.Y;
                                    }
                                }
                                finally
                                {
                                    IEnumerator enumerator;
                                    if (enumerator is IDisposable)
                                        (enumerator as IDisposable).Dispose();
                                }
                                if (count2 > 0)
                                {
                                    double a3 = num3 / (double)count2;
                                    double a4 = num4 / (double)count2;
                                    this.pointOneX = (a3 - (double)this.m_AirScanArea.X) * ((double)this.m_AirScanOutputWidth / (double)this.m_AirScanArea.Width);
                                    this.pointOneY = (a4 - (double)this.m_AirScanArea.Y) * ((double)this.m_AirScanOutputHeight / (double)this.m_AirScanArea.Height);
                                    SigProcX sigProcP1X = this.SigProcP1X;
                                    bool flag3 = true;
                                    ref bool local7 = ref flag3;
                                    double pointOneX1 = this.pointOneX;
                                    ref double local8 = ref this.m_AlphaP1X;
                                    ref double local9 = ref this.m_BetaP1X;
                                    sigProcP1X.alpha_beta(ref local7, pointOneX1, ref local8, ref local9);
                                    SigProcX sigProcP1Y = this.SigProcP1Y;
                                    bool flag4 = true;
                                    ref bool local10 = ref flag4;
                                    double pointOneY = this.pointOneY;
                                    ref double local11 = ref this.m_AlphaP1Y;
                                    ref double local12 = ref this.m_BetaP1Y;
                                    sigProcP1Y.alpha_beta(ref local10, pointOneY, ref local11, ref local12);
                                    if (this.AirScanInvX)
                                    {
                                        this.pointOneX = (double)this.AirScanOutputSize.Width - this.pointOneX;
                                        this.m_AlphaP1X = (double)this.AirScanOutputSize.Width - this.m_AlphaP1X;
                                    }
                                    if (this.AirScanInvY)
                                    {
                                        double num5 = -1.0;
                                        airScanOutputSize = this.AirScanOutputSize;
                                        double num6 = (double)airScanOutputSize.Height + this.pointOneY;
                                        this.pointOneY = num5 * num6;
                                        double num9 = -1.0;
                                        airScanOutputSize = this.AirScanOutputSize;
                                        double num10 = (double)airScanOutputSize.Height + this.m_AlphaP1Y;
                                        this.m_AlphaP1Y = num9 * num10;
                                    }
                                    if (this.AirScanSwapXY)
                                    {
                                        double pointOneX2 = this.pointOneX;
                                        this.pointOneX = -1.0 * this.pointOneY;
                                        this.pointOneY = -1.0 * pointOneX2;
                                        int num5 = checked((int)Math.Round(this.m_AlphaP1X));
                                        this.m_AlphaP1X = (double)checked(-1 * (int)Math.Round(this.m_AlphaP1Y));
                                        this.m_AlphaP1Y = (double)checked(-1 * num5);
                                    }
                                    this.m_Point1Info.Location = new Point(checked((int)Math.Round(this.pointOneX)), checked(-(int)Math.Round(this.pointOneY)));
                                    this.m_Point1Info.RawLocation = new Point(checked((int)Math.Round(a3)), checked((int)Math.Round(a4)));
                                    Gui.Context.Invoke((Action)(() => this.IDDelegate(1, (object)this.m_Point1Info)));
                                    this.m_AirScanPoint1DeltaLast = new Point(checked((int)Math.Round(this.pointOneX)), checked(-(int)Math.Round(this.pointOneY)));
                                }
                            }
                        }
                        this.PointDistanceAngle(new Point(checked((int)Math.Round(this.m_AlphaP1X)), checked((int)Math.Round(this.m_AlphaP1Y))), new Point(checked((int)Math.Round(this.pointTwoX)), checked((int)Math.Round(this.pointTwoY))));
                        this.m_AirScanDistanceDeltaLast = checked((int)Math.Round(Math.Round(this.m_PointDistance, 0)));
                        this.m_AirScanAngleDeltaLast = checked((int)Math.Round(Math.Round(this.m_PointAngle, 0)));
                        this.m_AirScanPoint2DeltaLast = new Point(checked((int)Math.Round(this.pointTwoX)), checked(-(int)Math.Round(this.pointTwoY)));
                    }
                    if (this.m_AirScanPoint2Enter)
                    {
                        SigProcX sigProcP2X = this.SigProcP2X;
                        flag1 = false;
                        ref bool local1 = ref flag1;
                        double pointTwoX1 = this.pointTwoX;
                        ref double local2 = ref this.m_AlphaP2X;
                        ref double local3 = ref this.m_BetaP2X;
                        sigProcP2X.alpha_beta(ref local1, pointTwoX1, ref local2, ref local3);
                        SigProcX sigProcP2Y = this.SigProcP2Y;
                        flag1 = false;
                        ref bool local4 = ref flag1;
                        double pointTwoY = this.pointTwoY;
                        ref double local5 = ref this.m_AlphaP2Y;
                        ref double local6 = ref this.m_BetaP2Y;
                        sigProcP2Y.alpha_beta(ref local4, pointTwoY, ref local5, ref local6);
                        if (this.AirScanInvX)
                        {
                            airScanOutputSize = this.AirScanOutputSize;
                            this.pointTwoX = (double)airScanOutputSize.Width - this.pointTwoX;
                            airScanOutputSize = this.AirScanOutputSize;
                            this.m_AlphaP2X = (double)airScanOutputSize.Width - this.m_AlphaP2X;
                        }
                        if (this.AirScanInvY)
                        {
                            double num3 = -1.0;
                            airScanOutputSize = this.AirScanOutputSize;
                            double num4 = (double)airScanOutputSize.Height + this.pointTwoY;
                            this.pointTwoY = num3 * num4;
                            double num5 = -1.0;
                            airScanOutputSize = this.AirScanOutputSize;
                            double num6 = (double)airScanOutputSize.Height + this.m_AlphaP2Y;
                            this.m_AlphaP2Y = num5 * num6;
                        }
                        if (this.AirScanSwapXY)
                        {
                            double pointTwoX2 = this.pointTwoX;
                            this.pointTwoX = -1.0 * this.pointTwoY;
                            this.pointTwoY = -1.0 * pointTwoX2;
                            int num3 = checked((int)Math.Round(this.m_AlphaP2X));
                            this.m_AlphaP2X = (double)checked(-1 * (int)Math.Round(this.m_AlphaP2Y));
                            this.m_AlphaP2Y = (double)checked(-1 * num3);
                        }
                        this.PointDistanceAngle(new Point(checked((int)Math.Round(this.m_AlphaP1X)), checked((int)Math.Round(this.m_AlphaP1Y))), new Point(checked((int)Math.Round(this.m_AlphaP2X)), checked((int)Math.Round(this.m_AlphaP2Y))));
                        this.m_Point2Info.LocationDelta = new Point(checked(-1 * this.m_AirScanPoint2DeltaLast.X - (int)Math.Round(this.m_AlphaP2X)), checked(-1 * this.m_AirScanPoint2DeltaLast.Y + (int)Math.Round(this.m_AlphaP2Y)));
                        this.m_Point2Info.Location = new Point(checked((int)Math.Round(this.m_AlphaP2X)), checked(-(int)Math.Round(this.m_AlphaP2Y)));
                        this.m_Point2Info.RawLocation = new Point(checked((int)Math.Round(a1)), checked((int)Math.Round(a2)));
                        this.m_Point2Info.Distance = checked((int)Math.Round(Math.Round(this.m_PointDistance, 0)));
                        this.m_Point2Info.Angle = checked((int)Math.Round(Math.Round(this.m_PointAngle, 0)));
                        this.m_Point2Info.DistanceDelta = checked((int)Math.Round(unchecked(-1.0 * (double)this.m_AirScanDistanceDeltaLast - Math.Round(this.m_PointDistance, 0))));
                        this.m_Point2Info.AngleDelta = checked((int)Math.Round(unchecked((double)this.m_AirScanAngleDeltaLast - Math.Round(this.m_PointAngle, 0))));
                        if (this.m_Point2Info.RawLocation.X < checked(this.m_Point1Info.RawLocation.X - this.m_AirScanPointThreshold))
                        {
                            Gui.Context.Invoke((Action)(() => this.IDDelegate(5, (object)this.m_Point2Info)));
                            this.m_AirScanPoint2Active = true;
                        }
                        else
                        {
                            this.m_AirScanPoint2Active = false;
                            this.m_AirScanPoint2Enter = false;
                        }
                    }
                }
            }
            if (!this.m_AirScanPoint2Active & this.m_AirScanPoint2inUse)
            {
                this.m_AirScanPoint2inUse = false;
                Gui.Context.Invoke((Action)(() => this.IDDelegate(6, (object)0)));
                this.m_AirScanPoint2DeltaLast = new Point(0, 0);
                this.m_AirScanPoint2Enter = false;
            }
            Gui.Context.Invoke((Action)(() => this.IDDelegate(0, (object)this.m_vector)));
        }

        private void PointDistanceAngle(Point PointA, Point PointB)
        {
            Point point1;
            Point point2;
            if (PointB.X < PointA.X)
            {
                point1 = PointB;
                point2 = PointA;
            }
            else
            {
                point1 = PointA;
                point2 = PointB;
            }
            double x1 = (double)Math.Abs(checked(point1.Y - point2.Y));
            double x2 = (double)Math.Abs(checked(point2.X - point1.X));
            double y = 2.0;
            double num = Math.Sqrt(Math.Pow(x1, y) + Math.Pow(x2, 2.0));
            if (num != 0.0)
                this.m_PointAngle = 90.0 - Math.Asin(x2 / num) * (180.0 / Math.PI);
            if (point1.Y > point2.Y)
                this.m_PointAngle = -1.0 * this.m_PointAngle;
            this.m_PointDistance = num;
            if (this.m_PointDistance >= 10.0)
                return;
            this.m_PointDistance = 0.0;
            this.m_PointAngle = 0.0;
        }

        private void ScanAngleToPoint(ref AirScan.ScanVectorXY InVector, int Ray, int Distance, double AngleOffset = 0.0, double PosOffsetX = 0.0, double PosOffsetY = 0.0)
        {
            this.m_DegAngle = (double)Ray * 0.36 + AngleOffset;
            this.m_RadAngle = this.m_DegAngle / (180.0 / Math.PI);
            InVector.X = (double)Distance * Math.Cos(this.m_RadAngle) + PosOffsetX;
            InVector.Y = (double)checked(-Distance) * Math.Sin(this.m_RadAngle) + PosOffsetY;
            InVector.ScanAngle = this.m_DegAngle;
            InVector.ScanDistance = (double)Distance;
        }

        private void SendTuioTouches(ref Collection pointcol)
        {
            OSCBundle oscBundle = new OSCBundle();
            OSCMessage oscMessage1 = new OSCMessage("/tuio/2Dcur");
            oscMessage1.Append((object)"fseq");
            oscMessage1.Append((object)this.iFrame);
            oscBundle.Append((object)oscMessage1);
            OSCMessage oscMessage2 = new OSCMessage("/tuio/2Dcur");
            oscMessage2.Append((object)"alive");
            try
            {
                foreach (AirScanTrackingPoint2DDamped trackingPoint2Ddamped in pointcol)
                {
                    if (trackingPoint2Ddamped.Active)
                        oscMessage2.Append((object)trackingPoint2Ddamped.ID);
                }
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            oscBundle.Append((object)oscMessage2);
            try
            {
                foreach (AirScanTrackingPoint2DDamped trackingPoint2Ddamped in pointcol)
                {
                    if (trackingPoint2Ddamped.Active)
                    {
                        OSCMessage oscMessage3 = new OSCMessage("/tuio/2Dcur");
                        oscMessage3.Append((object)"set");
                        oscMessage3.Append((object)trackingPoint2Ddamped.ID);
                        OSCMessage oscMessage4 = oscMessage3;
                        double centerXpixel = (double)trackingPoint2Ddamped.CenterXPixel;
                        Size airScanOutputSize = this.AirScanOutputSize;
                        double width = (double)airScanOutputSize.Width;
                        // ISSUE: variable of a boxed type
                        __Boxed<float> local1 = (ValueType)(float)(centerXpixel / width);
                        oscMessage4.Append((object)local1);
                        OSCMessage oscMessage5 = oscMessage3;
                        double centerYpixel = (double)trackingPoint2Ddamped.CenterYPixel;
                        airScanOutputSize = this.AirScanOutputSize;
                        double height = (double)airScanOutputSize.Height;
                        // ISSUE: variable of a boxed type
                        __Boxed<float> local2 = (ValueType)(float)(centerYpixel / height);
                        oscMessage5.Append((object)local2);
                        oscMessage3.Append((object)0.0f);
                        oscMessage3.Append((object)0.0f);
                        oscMessage3.Append((object)0.0f);
                        oscMessage3.Append((object)0.5f);
                        oscMessage3.Append((object)0.5f);
                        oscBundle.Append((object)oscMessage3);
                        oscMessage2.Append((object)trackingPoint2Ddamped.ID);
                    }
                }
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            PB_GUI_Legacy.TUIOTransmitter.Send((OSCPacket)oscBundle);
            if (this.iFrame == int.MaxValue)
            {
                this.iFrame = 0;
            }
            else
            {
                // ISSUE: variable of a reference type
                int&local;
                // ISSUE: explicit reference operation
                int num = checked(^ (local = ref this.iFrame) + 1);
                local = num;
            }
        }

        private delegate void DoEventsSub(int ID, object Info);

        public struct ScanVectorXY
        {
            public bool Active;
            public double X;
            public double Y;
            public double ScanAngle;
            public double ScanDistance;
        }

        private struct Point1Info
        {
            public Point LocationDelta;
            public Point Location;
            public Point RawLocation;
        }

        private struct Point2Info
        {
            public Point LocationDelta;
            public Point Location;
            public Point RawLocation;
            public int Angle;
            public int AngleDelta;
            public int Distance;
            public int DistanceDelta;
        }

        public delegate void AirScanChangedEventHandler(object sender, EventArgs e);

        public delegate void AirScanPoint1EnterEventHandler(object sender, EventArgs e);

        public delegate void AirScanPoint1MoveEventHandler(object sender, EventArgs e);

        public delegate void AirScanPoint1LeaveEventHandler(object sender, EventArgs e);

        public delegate void AirScanPoint2EnterEventHandler(object sender, EventArgs e);

        public delegate void AirScanPoint2MoveEventHandler(object sender, EventArgs e);

        public delegate void AirScanPoint2LeaveEventHandler(object sender, EventArgs e);

        public delegate void PointEnterEventHandler(int senderID, int ID, int PositionX, int PositionY, int w, int h);

        public delegate void PointMoveEventHandler(int senderID, int ID, int PositionX, int PositionY, int DeltaX, int deltaY, int w, int h);

        public delegate void PointLeaveEventHandler(int senderID, int ID, int PositionX, int PositionY, int w, int h);

        public delegate void AirScanDisconnectedEventHandler();
    }
}
