using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HashCodeService
{
    public class CRC32 : IHashCodeService
    {
        private uint _poly;
        private uint _init;
        private uint[] _table;

        public CRC32()
        {
            _poly = 0xEDB88320;
            _init = 0xFFFFFFFF;
            GenerateTable();
        }

        public CRC32(uint poly, uint init)
        {
            _poly = poly;
            _init = init;
            GenerateTable();
        }

        public uint GetHashCode(object data)
        {
            if (data == null)
                return new uint();

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, data);
                return GetHashCode(ms.ToArray(), _init);
            }
        }

        public uint GetHashCode(byte[] data)
        {
            return GetHashCode(data, _init);
        }

        public uint GetFileHashCode(string filePath)
        {
            byte[] buffer = new byte[256];
            uint reg = _init;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                int readLength = 0;
                bool firstIteration = true;
                do
                {
                    readLength = fs.Read(buffer, 0, buffer.Length);
                    reg = GetHashCode(buffer, firstIteration ? reg : reg ^ 0xFFFFFFFF);
                    firstIteration = false;
                }
                while (readLength == buffer.Length);
            }

            return reg;
        }

        private uint GetHashCode(byte[] data, uint register)
        {
            uint reg = register;
            foreach (byte b in data)
                reg = (reg >> 8) ^ _table[(reg & 0xFF) ^ b];
            return reg ^ 0xFFFFFFFF;
        }

        private void GenerateTable()
        {
            _table = new uint[256];

            for (uint i = 0; i < _table.Length; i++)
            {
                uint tmp = i;
                for (int j = 0; j < 8; j++)
                    if ((tmp & 1) == 1)
                        tmp = (tmp >> 1) ^ _poly;
                    else
                        tmp >>= 1;
                _table[i] = tmp;
            }
        }
    }
}