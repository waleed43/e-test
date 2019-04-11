using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace ETests.Droid
{
    [Activity(Label = "ETests", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = false,ScreenOrientation =ScreenOrientation.Locked, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //var sqliteFilename = "etests.db";

            //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            //var path = Path.Combine(documentsPath, sqliteFilename);

            //Console.WriteLine(path);
            //if (!File.Exists(path))
            //{
            //    using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
            //    {

            //        using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
            //        {
            //            byte[] buffer = new byte[2048];
            //            int length = 0;
            //            while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
            //            {
            //                binaryWriter.Write(buffer, 0, length);
            //            }
            //        }
            //    }; // RESOURCE NAME ###

            //    // create a write stream

            //}

            
            //var conn = new SQLiteConnection(path);




            LoadApplication(new App());
        }
        //void ReadWriteStream(Stream readStream, Stream writeStream)
        //{
        //    int Length = 256;
        //    Byte[] buffer = new Byte[Length];
        //    int bytesRead = readStream.Read(buffer, 0, Length);
        //    // write the required bytes
        //    while (bytesRead >= 0)
        //    {
        //        writeStream.Write(buffer, 0, bytesRead);
        //        bytesRead = readStream.Read(buffer, 0, Length);
        //    }
        //    readStream.Close();
        //    writeStream.Close();
        //}
    }
}