using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine.Entities.Camera;

namespace Engine
{
    public static class MathFunctions
    {
        public static Vector2 ScreenToWorldSpace(Camera cam, Vector2 point)
        {
            Matrix invertedMatrix = Matrix.Invert(cam.Transform);
            return Vector2.Transform(point, invertedMatrix);
        }

        public static float GetEuclideanDistance(Vector2 p1, Vector2 p2)
        {
            float d = (float)Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
            return d;
        }
    }
}
