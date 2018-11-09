using AirscanDriver.Lib;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirscanDriver.Be
{
    public delegate void TouchHandler(AirScanTrackingPoint2D[] ev);

    public class MyAirscan
    {
        public event TouchHandler OnRecivePoint;

        private AirScanOptions _options;
        // private bool m_sendTouchdata = true;
        private bool m_isconnected = false;
        private string IP = null;
        private Thread m_AirScanThreadReceive;
        private int m_AirScanPort = 9008;
        private MySigProcX SigProcP1X = new MySigProcX();
        private MySigProcX SigProcP2Y = new MySigProcX();
        private double SigProcDamping = 0.1;
        private double m_AlphaP1X;
        private double m_AlphaP2X;
        private double m_BetaP1X;
        private double m_BetaP1Y;
        private MySigProcX SigProcP1Y = new MySigProcX();
        private MySigProcX SigProcP2X = new MySigProcX();
        private double m_BetaP2X;
        private double m_BetaP2Y;
        private object m_sync = RuntimeHelpers.GetObjectValue(new object());
        private byte[] rbytes = new byte[1201];
        private byte[] procbytes = new byte[1201];
        private List<PointF> m_AirScanROI = new List<PointF>();
        private PointF[] t_AirScanROI;
        // private Collection<object> m_NewPointCollection = new Collection<object>();
        // private Collection<object> RayCheckCollection = new Collection<object>();

        private bool t_receivemode = true;
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

        public MyAirscan(AirScanOptions options)
        {
            _options = options ?? new AirScanOptions();
        }

        public void AirScanConnect(string iIP)
        {
            //this.m_sendTouchdata = true;
            this.IP = iIP;
            try
            {
                this.m_AirScanThreadReceive = new Thread(new ThreadStart(this.m_ReceiveMessages));
                this.m_AirScanThreadReceive.Start();
                this.m_isconnected = true;
               
            }
            catch (Exception ex)
            {
                //ProjectData.SetProjectError(ex);
                //ClxException.Throw("AirScan.AirScanConnect", (object)ex);
                //ProjectData.ClearProjectError();
            }
        }

        private void m_ReceiveMessages()
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                Console.WriteLine($"Try to connect by params: IP {this.IP}");

                tcpClient.Connect(this.IP, this.m_AirScanPort);

                Console.WriteLine($"Connected....");
             //   Console.ReadLine();
            }
            catch (SocketException ex)
            {

                Console.WriteLine($"Error connected....");

                //ProjectData.SetProjectError((Exception)ex);
                //ClxException.Throw((Exception)ex);
                tcpClient.Close();
                this.m_isconnected = false;
                //  ProjectData.ClearProjectError();
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
            MySigProcX sigProcP1X = this.SigProcP1X;
            bool flag1 = true;
            ref bool local1 = ref flag1;
            double x1 = 0.0;
            ref double local2 = ref this.m_AlphaP1X;
            ref double local3 = ref this.m_BetaP1X;
            sigProcP1X.alpha_beta(ref local1, x1, ref local2, ref local3);
            MySigProcX sigProcP1Y = this.SigProcP1Y;
            bool flag2 = true;
            ref bool local4 = ref flag2;
            double x2 = 0.0;
            ref double local5 = ref this.m_AlphaP1X;
            ref double local6 = ref this.m_BetaP1Y;
            sigProcP1Y.alpha_beta(ref local4, x2, ref local5, ref local6);
            MySigProcX sigProcP2X = this.SigProcP2X;
            bool flag3 = true;
            ref bool local7 = ref flag3;
            double x3 = 0.0;
            ref double local8 = ref this.m_AlphaP2X;
            ref double local9 = ref this.m_BetaP2X;
            sigProcP2X.alpha_beta(ref local7, x3, ref local8, ref local9);
            MySigProcX sigProcP2Y = this.SigProcP2Y;
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
                        //if (!this.t_receivemode)
                        //    this.m_UpdateMessage(msg);
                        //else
                        this.m_UpdateMultiPointMessage(msg);
                    }
                }
                catch (Exception ex)
                {
                    //ProjectData.SetProjectError(ex);
                    //ClxException.Throw(ex);
                    //this.PointInvoker(14, new int[3] { 0, 0, 0 });
                    tcpClient?.Close();
                    //ProjectData.ClearProjectError();
                    return;
                }
            }
            tcpClient.Close();
        }

        /////////////Обработка сообщений
        private ScanVectorXY[] m_vector;

        private ScanVectorXY ScanAngleToPoint(int Ray, int Distance, double AngleOffset = 0.0, double PosOffsetX = 0.0, double PosOffsetY = 0.0)
        {
            var m_DegAngle = (double)Ray * 0.36 + AngleOffset;
            var m_RadAngle = m_DegAngle / (180.0 / Math.PI);

            var InVector = new ScanVectorXY();
            InVector.X = (double)Distance * Math.Cos(m_RadAngle) + PosOffsetX;
            InVector.Y = (double)checked(-Distance) * Math.Sin(m_RadAngle) + PosOffsetY;
            InVector.ScanAngle = m_DegAngle;
            InVector.ScanDistance = (double)Distance;

            return InVector;
        }

        private void m_UpdateMultiPointMessage(int[] msg)
        {
            object sync = this.m_sync;
            ObjectFlowControl.CheckForSyncLockOnValueType(sync);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(sync, ref lockTaken);

                if (this.m_AirScanROI.Count > 0)
                {
                    this.t_AirScanROI = new PointF[this.m_AirScanROI.Count - 1 + 1];
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

            try
            {
                var m_NewPointCollection = new List<AirScanTrackingPoint2D>();
                var RayCheckCollection = new List<int>();
                // this.m_NewPointCollection.Clear();
                //if (this.RayCheckCollection.Count > 0)
                //    this.RayCheckCollection.Clear();

                var PointValidationIndex = 0;
                var PointInvalidationIndex = 0;
                var t_IgnoreRays = false;
                var PointValid = false;
                var t_newpointindex = 1;

                int StartedRay = 0;
                int Ray = 0;
                var CenterRay = 0;

                double t_FarPoint = 0;
                double t_NearPoint = 0;

                ScanVectorXY t_CalcPoint;

                do
                {
                    if (_options.CalcOutline)
                    {
                        this.m_vector[Ray] = (Ray >= _options.StartRay & Ray <= _options.StopRay) ?
                            this.ScanAngleToPoint(Ray, msg[checked(Ray + 14)], _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY) :
                            this.ScanAngleToPoint(Ray, 0, _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY);
                    }

                    if (Ray >= _options.StartRay & Ray <= _options.StopRay)
                    {
                        if (t_IgnoreRays & PointInvalidationIndex >= _options.PointInvalidationCount)
                        {
                            PointInvalidationIndex = 0;
                            t_IgnoreRays = false;
                            PointValid = false;
                            PointValidationIndex = 0;
                        }

                        Interlocked.Increment(ref PointInvalidationIndex);

                        var t_Checkpoint = this.ScanAngleToPoint(14 + Ray, msg[14 + Ray], _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY);
                        var m_PointInZone = this.t_AirScanROI == null ? t_Checkpoint.X > (double)_options.AirScanSafeArea.X & t_Checkpoint.X <
                            (double)(_options.AirScanSafeArea.X + _options.AirScanSafeArea.Width) & _options.Checkpoint.Y < (double)_options.AirScanSafeArea.Y & t_Checkpoint.Y >
                            (double)(_options.AirScanSafeArea.Y - _options.AirScanSafeArea.Height) : MathHelper.PointInPolygon(this.t_AirScanROI, t_Checkpoint.X, t_Checkpoint.Y);

                        if (m_PointInZone)
                        {
                            if (!t_IgnoreRays)
                            {
                                if (PointValidationIndex == 0)
                                    StartedRay = Ray;

                                RayCheckCollection.Add(msg[14 + Ray]);
                                if (PointValidationIndex >= _options.PointValidationCount)
                                    PointValid = true;

                                Interlocked.Increment(ref PointValidationIndex);
                            }
                        }
                        else if (PointValid)
                        {
                            var StoppedRay = checked(Ray - 1);
                            t_IgnoreRays = true;
                            PointInvalidationIndex = 0;
                            CenterRay = (int)Math.Round((double)StartedRay + (double)(StoppedRay - StartedRay) / 2.0);
                            var AverageDistance = 0.0;

                            while (RayCheckCollection.Count > 4)
                            {
                                RayCheckCollection.Remove(1);
                                RayCheckCollection.Remove(RayCheckCollection.Count);
                            }

                            int count = RayCheckCollection.Count;

                            //  ref double reference2 = 0;
                            for (int j = 1; j <= count; j++)
                            {
                                /* ref double averageDistance = ref AverageDistance;
                                 reference2 = ref averageDistance;*/

                                AverageDistance = Conversions.ToDouble(Operators.AddObject(AverageDistance, RayCheckCollection[j]));

                                t_FarPoint = _options.NearRange;
                                t_NearPoint = _options.FarRange;
                                t_CalcPoint = ScanAngleToPoint(14 + StartedRay + j - 1, Conversions.ToInteger(RayCheckCollection[j]), _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY);

                                if (t_CalcPoint.Y > t_FarPoint)
                                {
                                    t_FarPoint = t_CalcPoint.Y;
                                }
                                if (t_CalcPoint.Y < t_NearPoint)
                                {
                                    t_NearPoint = t_CalcPoint.Y;
                                }
                            }

                            AverageDistance = AverageDistance / (double)RayCheckCollection.Count;

                            RayCheckCollection.Clear();
                            var t_NewPoint = this.ScanAngleToPoint(CenterRay, (int)Math.Round(AverageDistance), _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY);
                            t_NewPoint.Active = true;

                            AirScanTrackingPoint2D scanTrackingPoint2D = new AirScanTrackingPoint2D()
                            {
                                Index = t_newpointindex.ToString(),
                                ID = t_newpointindex,
                                Active = true,
                                CenterX = t_NewPoint.X,
                                CenterY = t_NewPoint.Y,
                            };

                            var t_startpoint = this.ScanAngleToPoint(14 + StartedRay, msg[14 + StartedRay], _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY);
                            var t_stoppoint = this.ScanAngleToPoint(13 + StoppedRay, msg[13 + StoppedRay], _options.DeviceOrientation, _options.DevicePosX, _options.DevicePosY);

                            scanTrackingPoint2D.Width = t_stoppoint.X - t_startpoint.X;
                            scanTrackingPoint2D.Height = t_FarPoint - t_NearPoint;

                            m_NewPointCollection.Add(scanTrackingPoint2D);

                            Interlocked.Increment(ref t_newpointindex);
                            PointValid = false;
                        }
                        else
                        {
                            PointValid = false;
                            PointValidationIndex = 0;
                            RayCheckCollection.Clear();
                        }
                    }
                    checked { ++Ray; }
                }
                while (Ray <= 499);

                //AirScanPointTracker2D tracker = this.m_Tracker;
                //AirScan airScan = this;
                //ref AirScan local = ref airScan;
                //Collection newPointCollection = this.m_NewPointCollection;
                //double tSigProcDamping = this.t_SigProcDamping;
                //int tTrimCount = this.t_TrimCount;
                //int tMaxDelta = this.t_MaxDelta;
                //Size outputResolution = this.t_AirScanOutputResolution;
                //Rectangle tAirScanArea = this.t_AirScanArea;
                //Point tAirScanOffset = this.t_AirScanOffset;

                //int num5 = this.t_Swap ? 1 : 0;
                //int num6 = this.t_InvX ? 1 : 0;
                //int num7 = this.t_InvY ? 1 : 0;
                //int tStartX = this.t_StartX;
                //int tStartY = this.t_StartY;
                //int tRwidth = this.t_Rwidth;
                //int tRheight = this.t_RHeight;
                //int tPointIdOffset = this.t_PointIDOffset;
                //double predictionFactor = this.t_MotionPredictionFactor;

                //tracker.EvaluatePoints(ref local, newPointCollection, tSigProcDamping, _options.Prediction,
                //    tTrimCount, tMaxDelta, outputResolution, tAirScanArea, tAirScanOffset, num5 != 0, num6 != 0, num7 != 0, tStartX,
                //    tStartY, tRwidth, tRheight, tPointIdOffset, _options.UseMotionPrediction, predictionFactor);

                if (!_options.CalcOutline)
                    return;

                Task.Factory.StartNew(() => OnRecivePoint?.Invoke(m_NewPointCollection.ToArray()));

                //Gui.Context.Invoke((Action)(() => this.IDDelegate(0, (object)this.m_vector)));
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
