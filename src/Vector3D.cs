using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author/s:
 * Wasabi_Snorter
 * 
 * Changelog:
 * Added getDifference and getDistance
 * Added getters and setters
 * 
 */


namespace Project_Jeden.src
{
    class Vector3D
    {
        //Floating point due to OpenGL
        float x, y, z;

        public Vector3D(float x, float y, float z){
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //How to get from this to other
        public Vector3D getDifference(Vector3D other) {
            return new Vector3D(other.x - this.x, other.y - this.y, other.z - this.z);
        }

        //Get the distance between two vectors
        public float getDistance(Vector3D other) {
            Vector3D difference = this.getDifference(other);
            return (float)Math.Sqrt(difference.x*difference.x + difference.y*difference.y + difference.z*difference.z);
        }

        public void setX(float x) {
            this.x = x;
        }
        public void setY(float y)
        {
            this.y = y;
        }
        public void setZ(float z)
        {
            this.z = z;
        }
        public void setValues(float x, float y, float z) {
            setX(x);
            setY(y);
            setZ(z);
        }

    }
}
