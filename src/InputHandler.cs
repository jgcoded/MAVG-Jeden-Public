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

        Dictionary<KeyboardKeyEventArgs, ControlCode> keyMap;

        public void onKeyPress(KeyboardKeyEventArgs key) { 
        
        }
        
        public void onKeyRelease(KeyboardKeyEventArgs key) {
        
        }

    }

    enum ControlCode
    {

        ATTACK, DOWN, JUMP, LEFT, RIGHT, UP

    }
}
