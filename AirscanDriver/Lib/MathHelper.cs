using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirscanDriver.Be;

namespace AirscanDriver.Lib
{
    public class MathHelper
    {
        public static bool PointInPolygon(PointF[] poly, double x, double y)
        {
            int i, j, nvert = poly.Length;
            bool c = false;

            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((poly[i].Y >= y) != (poly[j].Y >= y)) &&
                    (x <= (poly[j].X - poly[i].X) * (y - poly[i].Y) / (poly[j].Y - poly[i].Y) + poly[i].X)
                  )
                    c = !c;
            }
            return c;
        }
    }
}
