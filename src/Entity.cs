using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jeden.src
{
    class Entity : Object
    {
        protected Vector2D pos;

        public Entity(string name) : base(name)
        {
            pos = new Vector2D(0.0f, 0.0f);
        }

        public Vector2D getPosition() {
            return pos;
        }
    }
}
