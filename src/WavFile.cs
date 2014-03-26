using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace Project_Jeden.src
{
    class WavFile : AudioFile
    {

        public WavFile(string fileName) : base(fileName)
        {
            path = fileName;
            Load();
        }

        public override bool Load()
        {

            ALError e;

            byte[] audioData = base.LoadRiffData(File.Open(path, FileMode.Open));

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

            return true;
        }

        public override bool LoadAsync()
        {
            return false;
        }

    }
}
