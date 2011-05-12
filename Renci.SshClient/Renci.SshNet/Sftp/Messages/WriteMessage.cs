﻿using System;

namespace Renci.SshNet.Sftp.Messages
{
    internal class WriteMessage : SftpRequestMessage
    {
        public override SftpMessageTypes SftpMessageType
        {
            get { return SftpMessageTypes.Write; }
        }

        public byte[] Handle { get; private set; }

        public UInt64 Offset { get; private set; }

        public byte[] Data { get; private set; }

        public WriteMessage()
        {

        }

        public WriteMessage(uint requestId, byte[] handle, UInt64 offset, byte[] data)
            : base(requestId)
        {
            this.Handle = handle;
            this.Offset = offset;
            this.Data = data;
        }

        protected override void LoadData()
        {
            base.LoadData();
            this.Handle = this.ReadBinaryString();
            this.Offset = this.ReadUInt64();
            this.Data = this.ReadBinaryString();
        }

        protected override void SaveData()
        {
            base.SaveData();
            this.WriteBinaryString(this.Handle);
            this.Write(this.Offset);
            this.WriteBinaryString(this.Data);
        }
    }
}