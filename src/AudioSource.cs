using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio.OpenAL;

namespace Project_Jeden.src
{
    class AudioSource
    {
        int sourceHandle;

        /* Sound properties */
        bool loopSound;
        float soundGain;
        float maximumSoundGain;
        Vector2D soundPosition;
        Vector2D soundVelocity;
        Vector2D soundDirection;

        public AudioSource()
        {
            ALError e;

            loopSound = false;
            soundPosition = soundDirection = soundVelocity = new Vector2D();

            sourceHandle = AL.GenSource();
            
            if ((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("AL Error: AudioSource handle - " + 
                    AL.GetErrorString(e));
        }

        public void AttachAudioFile(AudioFile file)
        {
            AL.GetError();
            ALError e;
            
            AL.Source(sourceHandle, ALSourcei.Buffer, file.GetDataHandle);

            if((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("Error attaching audio to source: " + 
                    file.path + "; " + AL.GetErrorString(e));
        }

        public void PlaySound()
        {
            AL.GetError();
            AL.SourcePlay(sourceHandle);
            
            ALError e;
            if ((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("AL Error: error playing source: " + 
                    AL.GetErrorString(e));
        }

        public void StopSound()
        {
            AL.GetError();
            AL.SourceStop(sourceHandle);

            if (AL.GetError() != ALError.NoError)
                Console.WriteLine("AL Error: error playing source");
        }

        public bool IsPlayingSound
        {
            get 
            { 
                int state;
                AL.GetSource(sourceHandle, ALGetSourcei.SourceState, out state);
                return (ALSourceState)state == ALSourceState.Playing;
            }
        }

        public bool LoopSound
        {
            get
            {
                return loopSound;
            }
            set
            {
                loopSound = value;
                AL.Source(sourceHandle, ALSourceb.Looping, loopSound);
            }
        }

        public int GetSourceHandle { get { return sourceHandle; } }

        public Vector2D SoundPosition
        {
            get
            {
                return soundPosition;
            }
            set
            {
                soundPosition = value;

                AL.Source(sourceHandle, 
                    ALSource3f.Position,
                    soundPosition.x,
                    soundPosition.y, 
                    0);
            }
        }

        public Vector2D SoundVelocity
        {
            get
            {
                return soundVelocity;
            }
            set
            {
                soundVelocity = value;

                AL.Source(sourceHandle, 
                    ALSource3f.Velocity, 
                    soundVelocity.x, 
                    soundVelocity.y, 
                    0);
            }
        }

        public Vector2D SoundDirection
        {
            get
            {
                return soundDirection;
            }
            set
            {
                soundDirection = value;

                AL.Source(sourceHandle, 
                    ALSource3f.Direction, 
                    soundDirection.x, 
                    soundDirection.y, 
                    0);
            }
        }

        public float SoundGain
        {
            get
            {
                return soundGain;
            }
            set
            {
                soundGain = value;
                AL.Source(sourceHandle, ALSourcef.Gain, soundGain);
            }
        }

        public float MaximumSoundGain
        {
            get
            {
                return maximumSoundGain;
            }
            set
            {
                maximumSoundGain = value;
                AL.Source(sourceHandle, ALSourcef.MaxGain, maximumSoundGain);
            }
        }

        ~AudioSource()
        {
            AL.DeleteSource(sourceHandle);
        }

    }
}
