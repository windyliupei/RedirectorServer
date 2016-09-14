using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class EncryptionKeys
    {
        public int EncryptionKeyId { get; set; }
        public string MacId { get; set; }
        public byte[] EncryptionKey { get; set; }
    }
}
