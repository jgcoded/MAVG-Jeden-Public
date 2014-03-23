using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio.OpenAL;
using OpenTK.Audio;

namespace Project_Jeden.src
{
    class Environment : IDisposable
    {

        AudioContext audioContext;
        private static Environment env = new Environment();

        /* Listener properties */
        Vector2D listenerPosition;
        Vector2D listenerVelocity;

        private Environment() 
        {
            audioContext = new AudioContext();

            listenerPosition = listenerVelocity = new Vector2D();
        }
        
        // AudioContexts are per process and not per thread
        public static Environment Instance()
        {
                if (env == null)
                    env = new Environment();
                
                return env;
        }

        public void UseAudioContext()
        {
            audioContext.MakeCurrent();
        }

        public Vector2D ListenerPosition
        {
            get
            {
                return listenerPosition;
            }
            set
            {
                listenerPosition = value;
                AL.Listener(ALListener3f.Position, listenerPosition.x, listenerPosition.y, 0);
            }
        }

        public Vector2D ListenerVelocity
        {
            get
            {
                return listenerVelocity;
            }
            set
            {
                listenerVelocity = value;
                AL.Listener(ALListener3f.Velocity, listenerVelocity.x, listenerVelocity.y, 0);
            }
        }

        public void Dispose()
        {
            if(audioContext != null)
                audioContext.Dispose();
        }
    }
}
