using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanceurRayon.Math;

namespace TestMath
{
    [TestClass]
    public class UnitTestMath
    {
        [TestMethod]
        public void TestVec3()
        {
            Vec3 v1 = new Vec3();
            Vec3 v2 = new Vec3(1, 1, 1);
            Vec3 v3 = new Vec3(0.5, 0.5, 0.5);
            Vec3 v4 = new Vec3(2, 3, 4);
            
            Vec3 res1;
            double res2;

            res1 = v2.add(v2);

            if (res1.X != 2 && res1.Y != 2 && res1.Z != 2)
                Assert.Fail();

            try
            {
                v2.add((Vec3) null);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

            res1 = v2.sub(v2);

            if (res1.X != 0 && res1.Y != 0 && res1.Z != 0)
                Assert.Fail();

            try
            {
                v2.sub(null);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

            res1 = v2.mul(3);

            if (res1.X != 3 && res1.Y != 3 && res1.Z != 3)
                Assert.Fail();

            res2 = v2.dot(v2);

            Assert.AreEqual<double>(3, res2);

            res1 = v2.cross(v2);

            if (res1.X != 0 && res1.Y != 0 && res1.Z != 0)
                Assert.Fail();

            res1 = v2.cross(v4);

            if (res1.X != 1 && res1.Y != -2 && res1.Z != 1)
                Assert.Fail();

            try
            {
                v2.cross(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {

            }
            catch (NullReferenceException)
            {
                Assert.Fail();
            }

            Assert.AreEqual<double>(System.Math.Sqrt(29), v4.length());

            res1 = v4.norm();
            Assert.AreEqual<double>(1, res1.length());
        }

        [TestMethod]
        public void TestColor()
        {
            Color c1 = new Color(), c2 = new Color(1, 1, 1), c3 = new Color(0.5, 0.5, 0.5), res;

            res = c1.add(c2);

            if (res.R != 1 && res.G != 1 && res.B != 1)
                Assert.Fail();

            res = c2.add(c2);

            if (res.R != 1 && res.G != 1 && res.B != 1)
                Assert.Fail();

            try
            {
                c1.add(null);
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {

            }

            res = c2.mul(0.3);

            if (res.R != 0.3 && res.G != 0.3 && res.B != 0.3)
                Assert.Fail();

            res = c2.times(c3);

            if (res.R != 0.5 && res.G != 0.5 && res.B != 0.5)
                Assert.Fail();
        }

        [TestMethod]
        public void TestPoint()
        {
            Point p1 = new Point(), p2 = new Point(1, 1, 1), res;
            Vec3 v = new Vec3(1, 1, 1), v_res;

            res = p1.add(v);

            if (res.X != 1 && res.Y != 1 && res.Z != 1)
                Assert.Fail();

            v_res = p2.sub(p1);

            if (v_res.X != 1 && v_res.Y != 1 && v_res.Z != 1)
                Assert.Fail();
        }
       

    }
}
