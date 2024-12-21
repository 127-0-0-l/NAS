namespace HashCodeService
{
    public interface IHashCodeService
    {
        uint GetHashCode(object data);
        uint GetHashCode(byte[] data);
        uint GetFileHashCode(string filePath);
    }
}
