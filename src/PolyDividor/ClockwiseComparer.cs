using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace PolyDividor
{
    public class ClockwiseComparer : IComparer
    {
        /*public int Compare(object x, object y)
        {
            var point1 = (PointF)x;
            var point2 = (PointF)y;

            var a1 = Math.Atan2(point1.Y, point1.X);
            var a2 = Math.Atan2(point2.Y, point2.X);

            if (a1 < 0)
                a1 += 2 * Math.PI;

            if (a2 < 0)
                a2 += 2 * Math.PI;

            return a1.CompareTo(a2);
        }*/

        public int Compare(object x, object y)
        {
            var p1 = x as PointF;
            var p2 = y as PointF;
            return Math.Atan2(-p1.Y, -p1.X).CompareTo(Math.Atan2(-p2.Y, -p2.X));
        }

    }
}
