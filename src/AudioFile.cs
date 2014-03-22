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

        byte[] data;
        int handle;

        public AudioFile()
        {
            handle = AL.GenBuffer();
            Console.WriteLine(handle);
        }

        // The following is taken directly from the OpenTK reference
        public bool Load()
        {
            int channels, bits_per_sample, sample_rate;
            ALError e;

            data = LoadWave(File.Open(path, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
            
            var sound_format =
                channels == 1 && bits_per_sample == 8 ? ALFormat.Mono8 :
                channels == 1 && bits_per_sample == 16 ? ALFormat.Mono16 :
                channels == 2 && bits_per_sample == 8 ? ALFormat.Stereo8 :
                channels == 2 && bits_per_sample == 16 ? ALFormat.Stereo16 :
                (ALFormat)0; // unknown
            
            AL.BufferData(handle, sound_format, data, data.Length, sample_rate);
            if ((e = AL.GetError()) != ALError.NoError)
            {
                Console.WriteLine("There was an error loading file: " + path + " ; " + AL.GetErrorString(e));
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
            get { return handle; }
        }

        /* I'm not what audio format the sound department has
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
            if (handle != -1)
                AL.DeleteBuffer(handle);
        }

    }
}
