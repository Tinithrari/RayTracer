using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    class Mat4
    {
        public Vec4 C1 { get; set;}
        public Vec4 C2 { get; set; }
        public Vec4 C3 { get; set; }
        public Vec4 C4 { get; set; }

        public Mat4(Vec4 C1,Vec4 C2,Vec4 C3,Vec4 C4) {

            this.C1 = C1;
            this.C2 = C2;
            this.C3 = C3;
            this.C4 = C4;

        }

        public Mat4 add(Mat4 m) {

            return new Mat4(this.C1.add(m.C1), this.C2.add(m.C2), this.C3.add(m.C3), this.C4.add(m.C4));
            
        }

        public Mat4 sub(Mat4 m)
        {
            return new Mat4(this.C1.sub(m.C1), this.C2.sub(m.C2), this.C3.sub(m.C3), this.C4.sub(m.C4));
        }

        public Mat4 transpose() {

            return new Mat4(new Vec4(C1.X, C2.X, C3.X, C4.X),
                            new Vec4(C1.Y, C2.Y, C3.Y, C4.Y),
                            new Vec4(C1.Z, C2.Z, C3.Z, C4.Z),
                            new Vec4(C1.T, C2.T, C3.T, C4.T)
                           );
        }


        public Mat4 CreateRotationMatrix(double angle,Vec3 v) {

            double cos_angle= System.Math.Cos(angle), sin_angle=System.Math.Sin(angle),minus_cos_angle=1-cos_angle;

            return new Mat4(new Vec4( cos_angle+(v.X*v.X) * minus_cos_angle, (v.X*v.Y)*minus_cos_angle +(v.Z* sin_angle) , (v.X * v.Z) * minus_cos_angle - (v.Y * sin_angle), 0),
                            new Vec4((v.X * v.Y) * minus_cos_angle - (v.Z* sin_angle) ,cos_angle + (v.Y*v.Y) * minus_cos_angle, ( (v.Y*v.Z) * minus_cos_angle)+ v.X * sin_angle , 0),
                            new Vec4( (v.X*v.Z) * minus_cos_angle + (v.Y*sin_angle), (v.Y * v.Z) * minus_cos_angle - (v.X * sin_angle), cos_angle + ( (v.Z*v.Z)*minus_cos_angle) , 0),
                            new Vec4(0,0,0,1)
                            );
        }


      

       


    }


}
