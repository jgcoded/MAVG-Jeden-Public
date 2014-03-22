using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jeden.src
{
    class Object
    {
        string name;
        Dictionary<string, Object> children;

        public Object(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return new string(name.ToCharArray());
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
