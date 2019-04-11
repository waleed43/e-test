using System;

using Xamarin.Forms;

using System.IO;
using ETests.Droid;
using ETests.Model;
using SQLite;
using System.Diagnostics;

[assembly: Dependency(typeof(SqliteService))]
namespace ETests.Droid
{
    public class SqliteService : ISQLite
    {

        public SqliteService() { }

        #region ISQLite implementation	
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "etests.db";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Debug.WriteLine("path", path);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename))) {

                    using(var binaryWriter=new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                } ; // RESOURCE NAME ###

                // create a write stream
               
            }

            
            var conn = new SQLiteAsyncConnection(path);

            // Return the database connection 
            return conn;
        }
        #endregion

        ///

        /// helper method to get the database out of /raw/ and into the user filesystem
        /// &lt;/summary&gt;

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }


    }
}