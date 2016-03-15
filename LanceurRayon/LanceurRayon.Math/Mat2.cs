using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    public class Mat2
    {
        Vec2 C1;
        Vec2 C2;

        public Mat2(){
            this.C1 = new Vec2(0,0);
            this.C2 = new Vec2(0, 0);
        }

        public Mat2(Vec2 C1,Vec2 C2)
        {
            this.C1 = C1;
            this.C2 = C2;
        }


        public Mat2 RightMatrixProduct(Mat2 m) {
            Vec2 vl1, vl2;

            vl1 = new Vec2(m.C1.X, m.C2.X);
            vl2 = new Vec2(m.C1.Y, m.C2.Y);
          

            return new Mat2(
                             new Vec2(vl1.dot(this.C1), vl1.dot(this.C2)),
                             new Vec2(vl2.dot(this.C1), vl2.dot(this.C2))  
                             );
        }


    }
}
