using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashCodeService;
using System.Text;

namespace CRC32.Tests
{
    [TestClass]
    public class TestHashCodeService
    {
        [TestMethod]
        public void TestBytes()
        {
            IHashCodeService crc32 = new HashCodeService.CRC32();
            var result = crc32.GetHashCode(new byte[] { 0x10,0x10,0x10,0x10}).ToString("X8");
            Assert.AreEqual("3A0E29C6", result);
        }

        [TestMethod]
        public void TestString()
        {
            IHashCodeService crc32 = new HashCodeService.CRC32();
            var result = crc32.GetHashCode(Encoding.ASCII.GetBytes("123456789")).ToString("X8");
            Assert.AreEqual("CBF43926", result);
        }
    }
}
