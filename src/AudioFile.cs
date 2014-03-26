using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using System.IO;

namespace Project_Jeden.src
{
    abstract class AudioFile : Asset
    {

        int bufferHandle;

        int formatChunkSize;
        int audioFormat;
        int numChannels;
        int sampleRate;
        int byteRate;
        int blockAlign;
        int bitsPerSample;

        public AudioFile(string name) : base(name)
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

        public static ALFormat GetSoundFormat(int channels, int bits)
        {
            switch (channels)
            {
                case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default: throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        public byte[] LoadRiffData(Stream stream)
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

                formatChunkSize = reader.ReadInt32();
                audioFormat = reader.ReadInt16();
                numChannels = reader.ReadInt16();
                sampleRate = reader.ReadInt32();
                byteRate = reader.ReadInt32();
                blockAlign = reader.ReadInt16();
                bitsPerSample = reader.ReadInt16();

                string data_signature = new string(reader.ReadChars(4));
                if (data_signature != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                int data_chunk_size = reader.ReadInt32();

                return reader.ReadBytes((int)reader.BaseStream.Length);
            }
        }

        public int FormatChunkSize
        {
            get { return formatChunkSize; }
            set { formatChunkSize = value; }
        }

        public int AudioFormat
        {
            get { return audioFormat; }
        }

        public int NumberOfChannels
        {
            get { return numChannels; }
        }

        public int SampleRate
        {
            get { return sampleRate; }
        }

        public int ByteRate
        {
            get { return byteRate; }
        }

        public int BlockAlign
        {
            get { return blockAlign; }
        }

        public int BitsPerSample
        {
            get { return bitsPerSample; }
        }

        ~AudioFile()
        {
            if (bufferHandle != -1)
                AL.DeleteBuffer(bufferHandle);
        }

    }
}
