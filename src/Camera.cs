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

        const float TWEEN_AMOUNT = 0.8f;

        Vector3D position;
        Vector2D target;

        //These would usually be 3D values but we should only be dealing with 2 axis (X and Y) when scaling and rotating
        float rotation; //Radians
        float scale; // 0.5 would make an image half as small, 2 would make an image twice as big

        public Camera() {
            position = new Vector3D(0, 0, 0);
            rotation = 0;
            scale = 1;
        }

        public void onUpdate() {
            if (target != null) {
                Vector2D current = new Vector2D(position.getX(), position.getY());
                Vector2D difference = target - current;
               
                this.setPosition(position.getX() + (difference.x*TWEEN_AMOUNT), this.position.getY() + (difference.y*TWEEN_AMOUNT), this.position.getZ());
            }
        }

        public void setTarget(Vector2D target) {
            this.target = target;
        }
        public void setTarget(Entity e){
            this.setTarget(e.getPosition());
        }
        //public void shake(float intensity){}

        public void setPosition(float x, float y, float z){
            this.position.setValues(x, y, z);
        }
        public Vector3D getPosition() {
            return this.position;
        }

        public float getScale() {
            return scale;
        }
        public void setScale(float scale) {
            this.scale = scale;
        }

        public float getRotation() {
            return this.rotation;
        }
        public void setRotation(float rot) {
            this.rotation = rot;
        }

    }
}
