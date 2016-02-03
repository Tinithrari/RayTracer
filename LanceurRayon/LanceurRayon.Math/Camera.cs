namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe représentant une caméra,décrit par là ou elle regarde ,la direction ,l'angle de vision et l'inclinaison.
    /// </summary>
    public class Camera {

        /// <summary>
        /// Direction où regarde la caméra.
        /// </summary>
        public Vec3 LookAt { get; private set; }
        
        /// <summary>
        /// Vecteur décrivant la positon de la caméra.
        /// </summary>
        public Vec3 LookFrom { get; private set; }
        
        /// <summary>
        /// Inclinaison de la caméra.
        /// </summary>
        public Vec3 Up { get; private set; }
        
        /// <summary>
        /// Angle d'inclinaison.
        /// </summary>
        public double Fov { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public Camera(Vec3 LookAt, Vec3 LookFrom, Vec3 Up, double Fov)
        {
                this.LookAt = LookAt;
                this.LookFrom = LookFrom;
                this.Up = Up;
                this.Fov = Fov;
            }

        } 
     }

