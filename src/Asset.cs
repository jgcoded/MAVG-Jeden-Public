using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jeden.src
{
    class Asset : Object
    {

        public bool Load()
        {
            return false;
        }

        public bool LoadAsync()
        {
            return false;
        }

        public bool loaded { get; set; }

        public string path { get; set; }

    }
}
