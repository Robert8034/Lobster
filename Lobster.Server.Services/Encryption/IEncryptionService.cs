﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Server.Services.Encryption
{
    public interface IEncryptionService
    {
        string GenerateEncryptionKey();
        string Encrypt(string clearText, string EncryptionKey);
        string Decrypt(string cipherText, string EncryptionKey);

    }
}
