﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio.OpenAL;

namespace Project_Jeden.src
{
    class AudioSource
    {
        int sourceHandle;

        public AudioSource()
        {
            ALError e;

            sourceHandle = AL.GenSource();
            
            if ((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("AL Error: AudioSource handle - " + 
                    AL.GetErrorString(e));
        }

        public void AttachAudio(AudioFile file)
        {
            AL.GetError();
            ALError e;
            
            AL.Source(sourceHandle, ALSourcei.Buffer, file.GetDataHandle);

            if((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("Error attaching audio to source: " + 
                    file.path + "; " + AL.GetErrorString(e));
        }

        public bool Play()
        {
            AL.GetError();
            AL.SourcePlay(sourceHandle);
            
            ALError e;
            if ((e = AL.GetError()) != ALError.NoError)
            {
                Console.WriteLine("AL Error: error playing source: " + 
                    AL.GetErrorString(e));
                return false;
            }

            return true;
        }

        public bool Stop()
        {
            AL.GetError();
            AL.SourceStop(sourceHandle);

            if (AL.GetError() != ALError.NoError)
            {
                Console.WriteLine("AL Error: error playing source");
                return false;
            }

            return true;
        }

        public bool IsPlaying 
        {
            get 
            { 
                int state;
                AL.GetSource(sourceHandle, ALGetSourcei.SourceState, out state);
                return (ALSourceState)state == ALSourceState.Playing;

            }
        }

        public int GetSourceHandle { get { return sourceHandle; } }

        public void SetPosition(float x, float y, float z)
        {
            AL.Source(sourceHandle, ALSource3f.Position, x, y, z);
        }

        ~AudioSource()
        {
            AL.DeleteSource(sourceHandle);
        }

    }
}
