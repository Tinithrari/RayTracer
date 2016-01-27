using System;

namespace LanceurRayon.Math
{
    public class Camera{

        private Vec3 lookAt;
        private Vec3 lookFrom;
        private Vec3 up;
        private double fov;



        public Camera(Vec3 lookAt, Vec3 lookFrom, Vec3 up, double fov)
        {

            this.lookAt = lookAt;
            this.lookFrom = lookFrom;
            this.up = up;
            this.fov = fov;
        }


        public Vec3 LookAt
        {
            get
            {
                return lookAt;
            }


        }

        public Vec3 LookFrom
        {
            get
            {
                return lookFrom;
            }

         
        }

        public Vec3 UP
        {
            get
            {
                return up;
            }

          
        }

        public double Fov
        {
            get
            {
                return fov;
            }

        }

      }


    }

