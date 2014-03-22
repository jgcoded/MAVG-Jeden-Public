using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Jeden.src
{
    class PhysicsWorld
    {
        Vector2D gravity;

        public PhysicsWorld()
        {
            gravity = new Vector2D(0, -9.8f);
        }

        public void SetGravity(Vector2D gravity)
        {
            this.gravity = gravity;
        }

        public Vector2D GetGravity()
        {
            return new Vector2D(gravity.x, gravity.y);
        }
    }
}
