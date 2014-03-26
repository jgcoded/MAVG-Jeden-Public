using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using csogg;
using csvorbis;
using OggDecoder;

namespace Project_Jeden.src
{
    class OggFile : AudioFile
    {

        public OggFile(string fileName) : base(fileName) 
        {
            path = fileName;
            Load();
        }

        public override bool Load()
        {
            ALError e;

            OggDecodeStream stream = new OggDecodeStream(File.Open(path, FileMode.Open));

            byte[] audioData = LoadRiffData(stream);
            
            AL.BufferData(base.GetDataHandle, 
                GetSoundFormat(base.NumberOfChannels, base.BitsPerSample), 
                audioData, 
                audioData.Length, 
                base.SampleRate);

            if ((e = AL.GetError()) != ALError.NoError)
            {
                Console.WriteLine("There was an error loading file: " + path +
                    " ; " + AL.GetErrorString(e));

                return false;
            }

            stream.Dispose();

            return true;
        }

        public override bool LoadAsync()
        {
            return false;
        }

    }
}
