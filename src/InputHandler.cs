using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;


/*
 * Author/s:
 * 
 * 
 * 
 * Changelog:
 * 
 * 
 */


namespace Project_Jeden.src
{
    class InputHandler
    {

        Dictionary<ControlCode, Key> keyMap = new Dictionary<ControlCode,Key>();
        private bool ATTACK = false;
        private bool DOWN = false;
        private bool JUMP = false;
        private bool LEFT = false;
        private bool RIGHT = false;
        private bool UP = false;

        public InputHandler() {
            keyMap.Add(ControlCode.ATTACK, Key.Z);
            keyMap.Add(ControlCode.DOWN, Key.Down);
            keyMap.Add(ControlCode.JUMP, Key.X);
            keyMap.Add(ControlCode.LEFT, Key.Left);
            keyMap.Add(ControlCode.RIGHT, Key.Right);
            keyMap.Add(ControlCode.UP, Key.Up);
        }

        public bool getAttack() {
            return ATTACK;
        }

        public bool getDown() {
            return DOWN;
        }

        public bool getJump() {
            return JUMP;
        }

        public bool getLeft() {
            return LEFT;
        }

        public bool getRight() {
            return RIGHT;
        }

        public bool getUp() {
            return UP;
        }

        public void display() {
            System.Console.Clear();
            System.Console.WriteLine("ATTACK : " + getAttack());
            System.Console.WriteLine("DOWN   : " + getDown());
            System.Console.WriteLine("JUMP   : " + getJump());
            System.Console.WriteLine("LEFT   : " + getLeft());
            System.Console.WriteLine("RIGHT  : " + getRight());
            System.Console.WriteLine("UP     : " + getUp());
        }

        public void onKeyDown(KeyboardKeyEventArgs key) {

            if (key.Key.Equals(keyMap[ControlCode.ATTACK])) {
                ATTACK = true;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.DOWN]))
            {
                DOWN = true;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.JUMP]))
            {
                JUMP = true;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.LEFT]))
            {
                LEFT = true;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.RIGHT]))
            {
                RIGHT = true;display();
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.UP]))
            {
                UP = true;
                display();
            }

        }
        
        public void onKeyUp(KeyboardKeyEventArgs key) {
            if (key.Key.Equals(keyMap[ControlCode.ATTACK]))
            {
                ATTACK = false;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.DOWN]))
            {
                DOWN = false;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.JUMP]))
            {
                JUMP = false;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.LEFT]))
            {
                LEFT = false;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.RIGHT]))
            {
                RIGHT = false;
                display();
            }
            else if (key.Key.Equals(keyMap[ControlCode.UP]))
            {
                UP = false;
                display();
            }
        }

    }

    enum ControlCode
    {

        ATTACK, DOWN, JUMP, LEFT, RIGHT, UP

    }
}
