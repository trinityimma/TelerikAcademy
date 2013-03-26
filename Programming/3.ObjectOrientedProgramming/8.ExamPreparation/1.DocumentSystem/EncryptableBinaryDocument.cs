using System;

abstract class EncryptableBinaryDocument : BinaryDocument, IEncryptable
{
    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        return this.IsEncrypted ? this.ToStringHelper("encrypted") : base.ToString();
    }
}
