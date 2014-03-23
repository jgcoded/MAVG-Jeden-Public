using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using System.IO;

namespace Project_Jeden.src
{
    class AudioFile : Asset
    {

        int bufferHandle;
        
        public AudioFile()
        {
            ALError e;

            bufferHandle = AL.GenBuffer();

            if ((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("AL Error: AudioSource handle - " +
                    AL.GetErrorString(e));
        }

        public int GetDataHandle
        {
            get { return bufferHandle; }
        }

        ~AudioFile()
        {
            if (bufferHandle != -1)
                AL.DeleteBuffer(bufferHandle);
        }

    }
}
