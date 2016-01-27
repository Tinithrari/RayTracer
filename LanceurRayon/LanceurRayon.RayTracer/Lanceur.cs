using LanceurRayon.Math;
using LanceurRayon.Renderer;

namespace LanceurRayon.RayTracer
{
    public class Lanceur
    {
        private Scene   _scene;
        private Repere _repere;
        
        public Lanceur(Scene _scene)
        {
            Vec3 tmpU, tmpV, tmpW, inter;

            this._scene = _scene;

            inter = _scene.Camera.LookFrom.sub(_scene.Camera.LookAt);
            tmpW = inter.mul( (1 / inter.length()) );

            inter = _scene.Camera.UP.sub(tmpW);
            tmpU = inter.mul(1 / inter.length());

            inter = tmpU.cross(tmpW);
            tmpV = inter.mul(1 / inter.length());

            _repere = new Repere(tmpU, tmpV, tmpW);
        }
    }
}
