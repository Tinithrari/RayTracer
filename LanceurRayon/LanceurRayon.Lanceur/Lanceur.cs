using LanceurRayon.Math;
using LanceurRayon.Renderer;

namespace LanceurRayon.RayTracer
{
    public class Lanceur
    {

        public Scene Scene { get; private set; }
        public Repere Repere { get; private set; }

        public Lanceur(Scene _scene)
        {
            Vec3 tmpU, tmpV, tmpW, inter;

            this.Scene = _scene;

            inter = _scene.Camera.LookFrom.sub(_scene.Camera.LookAt);
            tmpW = inter.mul( (1 / inter.length()) );

            inter = _scene.Camera.UP.sub(tmpW);
            tmpU = inter.mul(1 / inter.length());

            inter = tmpU.cross(tmpW);
            tmpV = inter.mul(1 / inter.length());

            Repere = new Repere(tmpU, tmpV, tmpW);
        }
    }
}
