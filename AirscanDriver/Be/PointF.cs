using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirscanDriver.Be
{
    public struct PointF
    {
        public float X;
        public float Y;

        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{{X={0}, Y={1}}}", (object)this.X, (object)this.Y);
        }
    }
}
