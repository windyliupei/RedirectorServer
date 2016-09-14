using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class EncryptionKeys
    {
        public int EncryptionKeyId { get; set; }
        public string MacId { get; set; }
        public byte[] EncryptionKey { get; set; }
    }
}
