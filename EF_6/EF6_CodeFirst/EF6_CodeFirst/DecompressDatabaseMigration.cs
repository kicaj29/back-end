using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF6_CodeFirst
{
    public class DecompressDatabaseMigration
    {
        public void CompressModel(String migrationName, string connString, string filePath)
        {
            var content = File.ReadAllText(filePath);
            var xDoc = XDocument.Parse(content);
            byte[] modelBinary = null;

            using (var outStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(outStream, CompressionMode.Compress))
                {
                    xDoc.Save(gzipStream);
                }
                modelBinary = outStream.ToArray();
            }

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var sqlToExecute = "UPDATE [EF6_CodeFirst.BloggingContext].[dbo].[__MigrationHistory] set [Model] = @Model where [MigrationId] = @migrationId";

                var command = new SqlCommand(sqlToExecute, connection);
                command.Parameters.AddWithValue("@Model", modelBinary);
                command.Parameters.AddWithValue("@migrationId", migrationName);
                command.ExecuteNonQuery();       
            }
        }

        public void DecompressModel(String migrationName, string connString)
        {
            var sqlToExecute = String.Format("select model from __MigrationHistory where migrationId like '%{0}'", migrationName);

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(sqlToExecute, connection);

                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("Now Rows to display. Probably migration name is incorrect");
                }

                while (reader.Read())
                {
                    var model = (byte[])reader["model"];
                    var decompressed = Decompress(model);
                    Console.WriteLine(decompressed);
                }
            }
        }

        private XDocument Decompress(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    return XDocument.Load(gzipStream);
                }
            }
        }
    }
}
