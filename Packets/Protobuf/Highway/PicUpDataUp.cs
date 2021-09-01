﻿// ReSharper disable SuggestBaseTypeForParameterInConstructor

namespace Konata.Core.Packets.Protobuf.Highway
{
    public class PicUpDataUp : PicUp
    {
        public const string Command = "PicUp.DataUp";

        public PicUpDataUp(uint peerUin, int sequence, byte[] ticket,
            int fileSize, byte[] fileMD5, int chunkOffset, int chunkSize, byte[] chunkMD5)
            : base(Command, 2, peerUin, sequence)
        {
            AddTree("12", w =>
            {
                // File size
                w.AddLeafVar("10", fileSize);

                // Chunk offset
                w.AddLeafVar("18", chunkOffset);

                // Chunk size
                w.AddLeafVar("20", chunkSize);

                // Service ticket
                w.AddLeafBytes("32", ticket);

                // Chunk md5
                w.AddLeafBytes("42", chunkMD5);

                // File md5
                w.AddLeafBytes("4A", fileMD5);
            });
        }

        public PicUpDataUp(uint peerUin, int sequence, byte[] ticket,
            int fileSize, byte[] fileMD5, int chunkOffset, int chunkSize,
            byte[] chunkMD5, GroupPttUpRequest request)
            : base("PicUp.DataUp", 29, peerUin, sequence)
        {
            AddTree("12", w =>
            {
                // File size
                w.AddLeafVar("10", fileSize);

                // Chunk offset
                w.AddLeafVar("18", chunkOffset);

                // Chunk size
                w.AddLeafVar("20", chunkSize);

                // Service ticket
                w.AddLeafBytes("32", ticket);

                // Chunk md5
                w.AddLeafBytes("42", chunkMD5);

                // File md5
                w.AddLeafBytes("4A", fileMD5);
            });

            AddTree("1A", request);
        }
    }
}
