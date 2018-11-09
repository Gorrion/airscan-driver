using AirscanDriver.Be;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirscanDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var opt1 = new AirScanOptions
                {
                    AirScanOutputZoom = 17,
                    MotionPredictionFactor = 0.20,
                    SigProcDamping = 0.1,
                    Rwidth = 1920,
                    Rheight = 1080,
                    AirScanArea = new ScanRectangle
                    {
                        X = -1180,
                        Y = -825,
                        Width = 2350,
                        Height = 1260
                    },
                    AirScanSafeArea = new ScanRectangle
                    {
                        Width = 2350,
                        Height = 1260
                    },
                    MaxDelta = 100,
                    AirScanOffset = new ScanPoint { X = 0, Y = 0 },
                    PointInvalidationCount = 8,
                    PointValidationCount = 2,
                };

                var airScan1 = new MyAirscan(opt1);
                airScan1.OnRecivePoint += AirScan1_OnRecivePoint;
                airScan1.AirScanConnect("2.2.1.111");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press key to exit...");
            Console.ReadKey();
        }

        private static void AirScan1_OnRecivePoint(AirScanTrackingPoint2D[] ev)
        {
            Console.WriteLine($"Recive {ev.Length} messages!");

            for (var i = 0; i < ev.Length; i++)
            {
                Console.WriteLine($"Point: centerX - {ev[i].CenterX}, centerY - {ev[i].CenterY}!");
            }
        }
    }
}
