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

        public InputHandler() {
            keyMap.Add(ControlCode.ATTACK, Key.Z);
            keyMap.Add(ControlCode.DOWN, Key.Down);
            keyMap.Add(ControlCode.JUMP, Key.X);
            keyMap.Add(ControlCode.LEFT, Key.Left);
            keyMap.Add(ControlCode.RIGHT, Key.Right);
            keyMap.Add(ControlCode.UP, Key.Up);
        }
        public void onKeyDown(KeyboardKeyEventArgs key) {

            if (key.Key.Equals(keyMap[ControlCode.ATTACK])) {
                System.Console.WriteLine("ATTACK");
            }
            else if (key.Key.Equals(keyMap[ControlCode.DOWN]))
            {
                System.Console.WriteLine("DOWN");
            }
            else if (key.Key.Equals(keyMap[ControlCode.JUMP]))
            {
                System.Console.WriteLine("JUMP");
            }
            else if (key.Key.Equals(keyMap[ControlCode.LEFT]))
            {
                System.Console.WriteLine("LEFT");
            }
            else if (key.Key.Equals(keyMap[ControlCode.RIGHT]))
            {
                System.Console.WriteLine("RIGHT");
            }
            else if (key.Key.Equals(keyMap[ControlCode.UP]))
            {
                System.Console.WriteLine("UP");
            }

        }
        
        public void onKeyUp(KeyboardKeyEventArgs key) {
            if (key.Key.Equals(keyMap[ControlCode.ATTACK]))
            {
                System.Console.WriteLine("-ATTACK");
            }
            else if (key.Key.Equals(keyMap[ControlCode.DOWN]))
            {
                System.Console.WriteLine("-DOWN");
            }
            else if (key.Key.Equals(keyMap[ControlCode.JUMP]))
            {
                System.Console.WriteLine("-JUMP");
            }
            else if (key.Key.Equals(keyMap[ControlCode.LEFT]))
            {
                System.Console.WriteLine("-LEFT");
            }
            else if (key.Key.Equals(keyMap[ControlCode.RIGHT]))
            {
                System.Console.WriteLine("-RIGHT");
            }
            else if (key.Key.Equals(keyMap[ControlCode.UP]))
            {
                System.Console.WriteLine("-UP");
            }
        }

    }

    enum ControlCode
    {

        ATTACK, DOWN, JUMP, LEFT, RIGHT, UP

    }
}
