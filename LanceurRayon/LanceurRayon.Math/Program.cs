using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    class Program
    {
        public static void Main(String[] args){
        Mat4 m = new Mat4(new Vec4(1,2,3,4),
                          new Vec4(5,6,7,8),
                          new Vec4(9,10,11,12),
                          new Vec4(13,14,15,16)
                          );

        Console.WriteLine( m.Determinant());
            Console.ReadKey();
    }
}
}
