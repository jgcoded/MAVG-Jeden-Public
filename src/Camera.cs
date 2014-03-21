using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author/s:
 * 
 * 
 * 
 * 
 * Changelog:
 * 
 * 
 */

namespace Project_Jeden.src
{
    class Camera
    {

        Vector3D position;
        
        //These would usually be 3D values but we should only be dealing with 2 axis (X and Y) when scaling and rotating
        float rotation;
        float scale;

        public Camera() {
            position = new Vector3D(0, 0, 0);
            rotation = 0;
            scale = 0;
        }

        //public void setTarget(Entity e){}
        //public void shake(float intensity){}

        public void setPosition(float x, float y, float z){
            this.position.setValues(x, y, z);
        }
        public Vector3D getPosition() {
            return this.position;
        }

    }
}
