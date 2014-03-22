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

        AudioContext context;
        private static Environment env = new Environment();

        private Environment() 
        {
            context = new AudioContext();
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
            context.MakeCurrent();
        }

        // this is the position from where sounds are heard from
        // in this case, the character's position
        public void SetListenerPosition(float x, float y, float z)
        {
            /* This AL property will be set many times as the
             * character's position changes. Error checking should
             * be done in debug builds only
             * */
            AL.Listener(ALListener3f.Position, x, y, z);
        }

        public void Dispose()
        {
            if(context != null)
                context.Dispose();
        }
    }
}
