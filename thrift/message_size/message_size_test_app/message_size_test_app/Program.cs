using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace message_size_test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Transaction t = new Transaction();
            t.Items = new List<Item>();
            for(int x =0; x < 50; x++)
            {
                t.Items.Add(new Item()
                {
                    Field1 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG", Field2 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field3 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG", Field4 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field5 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG", Field6 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field7 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG", Field8 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field9 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field10 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field11 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field12 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field13 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field14 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field15 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field16 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field17 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field18 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field19 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                    Field20 = "ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG_ABCDEFG",
                });
            }

            var stream = new MemoryStream();
            TProtocol tProtocol = new TBinaryProtocol(new TStreamTransport(stream, stream));

            t.Write(tProtocol);

            byte[] content = stream.ToArray();


            var stream1 = new MemoryStream(content);
            TProtocol tProtocol1 = new TBinaryProtocol(new TStreamTransport(stream1, stream1));

            Transaction t1 = new Transaction();
            t1.Read(tProtocol1);
        }
    }
}
