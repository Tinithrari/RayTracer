namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe représentant une caméra,décrit par là ou elle regarde ,la direction ,l'angle de vision et l'inclinaison.
    /// </summary>
    public class Camera {

        /// <summary>
        /// Direction où regarde la caméra.
        /// </summary>
        public Point LookAt { get; private set; }
        
        /// <summary>
        /// Vecteur décrivant la positon de la caméra.
        /// </summary>
        public Point LookFrom { get; private set; }
        
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
        /// <param name="LookAt">Direction où regarde la caméra.</param>
        /// <param name="LookFrom">Vecteur décrivant la positon de la caméra.</param>
        /// <param name="Up">Inclinaison de la caméra.</param>
        /// <param name="Fov">Angle d'inclinaison.</param>
        public Camera(Point LookAt, Point LookFrom, Vec3 Up, double Fov)
        {
                this.LookAt = LookAt;
                this.LookFrom = LookFrom;
                this.Up = Up;
                this.Fov = Fov;
            }

        } 
     }

