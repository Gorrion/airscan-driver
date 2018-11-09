using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirscanDriver.Be
{
    public struct ScanPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct ScanRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct ScanVectorXY
    {
        public bool Active;
        public double X { get; set; }
        public double Y { get; set; }
        public double ScanAngle { get; set; }
        public double ScanDistance { get; set; }
    }

    public struct Point2Info
    {
        public ScanPoint LocationDelta { get; set; }
        public ScanPoint Location { get; set; }
        public ScanPoint RawLocation { get; set; }
        public int Angle { get; set; }
        public int AngleDelta { get; set; }
        public int Distance { get; set; }
        public int DistanceDelta { get; set; }
    }

    public struct AirScanTrackingPoint2D
    {

        public string Index { get; set; }
        public int ID { get; set; }
        public bool Active { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class AirScanOptions
    {
        public bool CalcOutline { get; set; }
        public double Prediction { get; set; }
        public bool UseMotionPrediction { get; set; }
        public double MotionPredictionFactor { get; set; }
        public int MaxDelta { get; set; }
        public double SigProcDamping { get; set; } = 0.1;
        public int FarRange { get; set; } = 300;
        public int NearRange { get; set; } = 300;

        public int StartRay { get; set; } = 0;
        public int StopRay { get; set; } = 499;

        public int PointValidationCount { get; set; } = 2;
        public int PointInvalidationCount { get; set; } = 5;
        public ScanPoint AirScanOffset { get; set; }
        public ScanPoint AirScanOutputResolution { get; set; }
        public bool Swap { get; set; }
        public bool InvX { get; set; }
        public bool InvY { get; set; }

        public int StartX { get; set; }
        public int StartY { get; set; }
        public double Rwidth { get; set; }
        public double Rheight { get; set; }
        public int PointIDOffset { get; set; }

        public double NearPoint { get; set; } = 65000.0;
        public double FarPoint { get; set; } = 0.0;

        public double DeviceOrientation { get; set; }

        public ScanVectorXY Startpoint { get; set; } = new ScanVectorXY();
        public ScanVectorXY Stoppoint { get; set; } = new ScanVectorXY();
        public ScanVectorXY NewPoint { get; set; } = new ScanVectorXY();
        public ScanVectorXY CalcPoint { get; set; } = new ScanVectorXY();
        public ScanVectorXY Checkpoint { get; set; } = new ScanVectorXY();

        public ScanRectangle AirScanArea { get; set; } = new ScanRectangle
        {
            X = -600,
            Y = -600,
            Width = 1200,
            Height = 800
        };

        public ScanRectangle AirScanSafeArea { get; set; } = new ScanRectangle
        {
            X = -650,
            Y = -650,
            Width = 1300,
            Height = 900
        };

        public int AirScanRangeNear { get; set; } = 100;
        public int AirScanRangeFar { get; set; } = 1750;
        public int AirScanOutputZoom { get; set; } = 10;

        public bool AirScanInvX { get; set; } = false;
        public bool AirScanEnableMouse { get; set; } = false;
        public bool AirScanEnableMouseClick { get; set; } = false;

        public int AirScanPointThreshold { get; set; } = 50;
        public int AirScanPointCount { get; set; } = 0;
        public double DevicePosX { get; set; }
        public double DevicePosY { get; set; }
    }
}