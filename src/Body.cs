using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jeden.src
{
    class Body : Entity
    {
        Vector2D vel;
        Vector2D acc;

        public Body() : base("Body")
        {
            base.pos = new Vector2D(0, 0);
            vel = new Vector2D(0, 0);
            acc = new Vector2D(0, 0);
        }

        public Vector2D GetPosition()
        {
            return new Vector2D(pos.x, pos.y);
        }

        public Vector2D GetVelocity()
        {
            return new Vector2D(vel.x, vel.y);
        }

        public Vector2D GetAcceleration()
        {
            return new Vector2D(acc.x, acc.y);
        }
    }
}
