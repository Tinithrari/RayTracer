using LanceurRayon.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Lanceur
{
    public class Intersection
    {
        public double? T { get; private set; }
        public VisualEntity Obj { get; private set; }

        public Intersection(double? t, VisualEntity obj)
        {
            T = t;
            Obj = obj;
        }
    }
}
