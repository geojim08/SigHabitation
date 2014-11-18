using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigHabitation
{
    public class Point
    {
        public Point(Double x, Double y)
        {
            this.X = x;
            this.Y = y;
        }


        private Double x;
        public Double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private Double y;
        public Double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
