using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio.OpenAL;

namespace Project_Jeden.src
{
    class AudioSource
    {
        int handle;
        
        AudioFile file;

        public AudioSource()
        {
            ALError e;

            handle = AL.GenBuffer();
            
            if ((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("AL Error: AudioSource handle - " + AL.GetErrorString(e));
        }

        public void AttachAudio(AudioFile file)
        {
            AL.GetError();
            ALError e;
            this.file = file;
            
            AL.Source(handle, ALSourcei.Buffer, this.file.GetDataHandle);

            if((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("Error attaching audio to source: " + file.path + "; " + AL.GetErrorString(e));

        }

        public bool Play()
        {
            AL.GetError();
            AL.SourcePlay(handle);
            
            ALError e;
            if ((e = AL.GetError()) != ALError.NoError)
            {
                Console.WriteLine("AL Error: error playing source: " + AL.GetErrorString(e));
                return false;
            }

            return true;
        }

        public bool Stop()
        {
            AL.GetError();
            AL.SourceStop(handle);

            if (AL.GetError() != ALError.NoError)
            {
                Console.WriteLine("AL Error: error playing source");
                return false;
            }

            return true;
        }

        public void SetPosition(float x, float y, float z)
        {
            AL.Source(handle, ALSource3f.Position, x, y, z);
        }

        ~AudioSource()
        {
            AL.DeleteSource(handle);
        }

    }
}
