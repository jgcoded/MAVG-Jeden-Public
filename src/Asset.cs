using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jeden.src
{
    abstract class Asset : Object
    {
        public Asset(string name) : base(name)
        {
        }

        public virtual bool Load()
        {
            return false;
        }

        public virtual bool LoadAsync()
        {
            return false;
        }

        public bool loaded { get; set; }

        public string path { get; set; }

    }
}
