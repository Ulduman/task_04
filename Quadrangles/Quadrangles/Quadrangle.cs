﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrangles
{
    public class Quadrangle
    {
        public bool TestQuad(params double[] x)
        {

            if (x.Length == 8)
            {
                if ((x[0] == x[2] && x[0] == x[6]) || (x[1] == x[3] && x[1] == x[7]) || (x[0] == x[6] && x[6] == x[4]) || (x[1] == x[7] && x[7] == x[5]) || (x[6] == x[4] && x[4] == x[2]) || (x[7] == x[5] && x[5] == x[3]) || (x[4] == x[2] && x[2] == x[0]) || (x[5] == x[3] && x[3] == x[1]))
                {
                    return false;
                } else {
                    double k1 = (x[1] - x[3]) / (x[0] - x[2]), k2 = (x[3] - x[5]) / (x[2] - x[4]), k3 = (x[5] - x[7]) / (x[4] - x[6]), k4 = (x[7] - x[1]) / (x[6] - x[0]);

                    if (k1 == k2 || k2 == k3 || k3 == k4 || k4 == k1)
                    {
                        return false;
                    }
                    else return true;
                        }

            }else return false;
        }
        
        public double[] ReplaceCoordinates(params double[] x)
        {
                double[] z = (double[])x.Clone();

                double ax = z[0] - z[2], bx = z[0] - z[4], cx = z[0] - z[6], ay = z[1] - z[3], by = z[1] - z[5], cy = z[1] - z[7], cosab = (ax * bx + ay * by) / (Math.Sqrt(Math.Pow(ax, 2) + Math.Pow(ay, 2)) * Math.Sqrt(Math.Pow(bx, 2) + Math.Pow(by, 2)));
                double cosac = (ax * cx + ay * cy) / (Math.Sqrt(Math.Pow(ax, 2) + Math.Pow(ay, 2)) * Math.Sqrt(Math.Pow(cx, 2) + Math.Pow(cy, 2)));
                double cosbc = (cx * bx + cy * by) / (Math.Sqrt(Math.Pow(bx, 2) + Math.Pow(by, 2)) * Math.Sqrt(Math.Pow(cx, 2) + Math.Pow(cy, 2)));

                if (cosab < cosac && cosab < cosbc)
                {
                    return new double[] { z[0], z[1], z[2], z[3], z[6], z[7], z[4], z[5] };
                }
                else if (cosac < cosab && cosac < cosbc)
                {
                    return z;
                }
                else return new double[] { z[0], z[1], z[4], z[5], z[2], z[3], z[6], z[7] };
        }

        public string SpotTypeQuad(params double[] x)
        {
            double[] z = (double[])x.Clone();
            z = ReplaceCoordinates(z);
            bool ans = TestQuad(z);

            if (ans)
            {
                return "0";
            }
            else return "0";
        }

        public double CalcAreaQuad(params double[] x)
        {
            double[] z = ReplaceCoordinates(x);
            bool ans = TestQuad(z);

            if (ans)
            {
                return Math.Abs((z[0] * z[3] - z[1] * z[2] + z[2] * z[5] - z[3] * z[4] + z[4] * z[7] - z[5] * z[6] + z[6] * z[1] - z[7] * z[0]) / 2);
            }
            else return 0;
        }

        public double CalcPerimetrQuad(params double[] x)
        {
            double[] z = (double[])x.Clone();
            z = ReplaceCoordinates(z);
            bool ans = TestQuad(z);

            if (ans)
            {
                double a = Math.Pow((Math.Pow(Math.Abs(z[0] - z[2]), 2) + Math.Pow(Math.Abs(z[1] - z[3]), 2)), 0.5), b = Math.Pow((Math.Pow(Math.Abs(z[2] - z[4]), 2) + Math.Pow(Math.Abs(z[3] - z[5]), 2)), 0.5), c = Math.Pow((Math.Pow(Math.Abs(z[6] - z[4]), 2) + Math.Pow(Math.Abs(z[7] - z[5]), 2)), 0.5), d = Math.Pow((Math.Pow(Math.Abs(z[6] - z[0]), 2) + Math.Pow(Math.Abs(z[7] - z[1]), 2)), 0.5);
                return a + b + c + d;
            }
            else return 0;
        }

       
    }
}
