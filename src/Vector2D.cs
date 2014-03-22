using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Jeden.src
{
    class Vector2D
    {
        public float x, y;

        public Vector2D()
        {
            x = 0.0f;
            y = 0.0f;
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D operator +(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.x + right.x, left.y + right.y);
        }

        public static Vector2D operator -(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.x - right.x, left.y - right.y);
        }

        public static float Dot(Vector2D left, Vector2D right)
        {
            return (left.x * right.x) + (left.y * right.y);
        }

        public static float Cross(Vector2D left, Vector2D right)
        {
            return (left.x * right.y) - (left.y * right.x);
        }
    }
}
