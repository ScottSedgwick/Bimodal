using NUnit.Framework;
using System;
using UpdateId;

namespace UpdateIdTests
{
    [TestFixture]
    public class BimodalUpdateIdTests
    {
        [TestCase((uint) 0x52618A12, "1H<8L:1")]
        [TestCase((uint) 0xE5E5A048, "FM=MN70")]
        [TestCase((uint) 0xF58CB344, "6EGKO10")]
        [TestCase((uint) 0x79E9F952, ":I>?K:0")]
        [TestCase((uint) 0x9E467A86, "=658C03")]
        public void TestUpdateId(UInt32 ownId, string expected)
        {
            var id = BimodalId.Update(ownId);
            var actual = BimodalId.ToStr(id);
            Assert.AreEqual(expected, actual);
        }
    }
}
