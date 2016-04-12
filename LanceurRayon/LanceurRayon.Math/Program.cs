using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    public class Program
    {

        public static void Main(String[] args) {

            Vec4 v1 = new Vec4(5, 14, 1, 34);
            Mat4 m1= new Mat4(new Vec4(1,2,3,4),
                                  new Vec4(1, 2, 37, 4),
                                  new Vec4(17, 2, 36, 4),
                                  new Vec4(1, 52, 3, 47)),
                
                 m2=new Mat4(new Vec4(1, 2, 43, 4),
                             new Vec4(1, 22, 3, 4),
                             new Vec4(1, 2, 73, 43),
                             new Vec4(16, 2, 13, 4));

            Console.Out.WriteLine("B*A \n\n"+m1.LeftMatrixProduct(m2));
            Console.Out.WriteLine("A*B \n\n" + m1.RightMatrixProduct(m2));

            Console.Out.WriteLine("A*B \n\n" + m2.LeftMatrixProduct(m1));
            Console.Out.WriteLine("B*A \n\n" + m2.RightMatrixProduct(m1));

            Console.Out.WriteLine("A t \n\n" + m1.transpose());
            Console.Out.WriteLine("B t \n\n" + m1.transpose());

            Console.Out.WriteLine("A - B \n\n" + m1.sub(m2));
            Console.Out.WriteLine("B -A \n\n" + m2.sub(m1));


            Console.Out.WriteLine("A + B \n\n" + m1.add(m2));
            Console.Out.WriteLine("B + A \n\n" + m2.add(m1));

            Console.Out.WriteLine("3*A\n\n" + m1.Scalaire(3));

            Console.Out.WriteLine("Det(A) \n\n" + m1.Determinant());
            Console.Out.WriteLine("A -1 \n\n" + m1.Inverse());
            Console.Out.WriteLine(" B-1 \n\n" + m2.Inverse());

        


        }
    }
}
