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

        byte[] audioData;
        int bufferHandle;
        
        public AudioFile()
        {
            ALError e;

            bufferHandle = AL.GenBuffer();

            if ((e = AL.GetError()) != ALError.NoError)
                Console.WriteLine("AL Error: AudioSource handle - " +
                    AL.GetErrorString(e));
        }

        // The following is taken directly from the OpenTK reference
        public bool Load()
        {
            int channels, bits_per_sample, sample_rate;
            ALError e;

            audioData = LoadWave(File.Open(path, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
            AL.BufferData(bufferHandle, GetSoundFormat(channels, bits_per_sample), audioData, audioData.Length, sample_rate);

            if ((e = AL.GetError()) != ALError.NoError)
            {
                Console.WriteLine("There was an error loading file: " + path +
                    " ; " + AL.GetErrorString(e));

                return false;
            }

            return true;
        }

        public bool LoadAsync()
        {
            return false;
        }

        public int GetDataHandle
        {
            get { return bufferHandle; }
        }

        public static ALFormat GetSoundFormat(int channels, int bits)
        {
            switch (channels)
            {
                case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default: throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        /* I'm not sure what audio format the sound department has
         * agreed to use, so for now, to make my life easier, I'll
         * use the example OpenTK audio format: wav
         * */
        byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (BinaryReader reader = new BinaryReader(stream))
            {
                // RIFF header
                string signature = new string(reader.ReadChars(4));
                if (signature != "RIFF")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                int riff_chunck_size = reader.ReadInt32();

                string format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                // WAVE header
                string format_signature = new string(reader.ReadChars(4));
                if (format_signature != "fmt ")
                    throw new NotSupportedException("Specified wave file is not supported.");

                int format_chunk_size = reader.ReadInt32();
                int audio_format = reader.ReadInt16();
                int num_channels = reader.ReadInt16();
                int sample_rate = reader.ReadInt32();
                int byte_rate = reader.ReadInt32();
                int block_align = reader.ReadInt16();
                int bits_per_sample = reader.ReadInt16();

                string data_signature = new string(reader.ReadChars(4));
                if (data_signature != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                int data_chunk_size = reader.ReadInt32();

                channels = num_channels;
                bits = bits_per_sample;
                rate = sample_rate;

                return reader.ReadBytes((int)reader.BaseStream.Length);
            }   
        }

        ~AudioFile()
        {
            if (bufferHandle != -1)
                AL.DeleteBuffer(bufferHandle);
        }

    }
}
