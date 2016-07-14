using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DevExpress.XtraCharts.Demos.Modules
{
    public static class Utils
    {
        const string path = "DevExpress.XtraCharts.Demos.Images.";

        public static string GetRelativePath(string name)
        {
            name = "Data\\" + name;
            string path = System.Windows.Forms.Application.StartupPath;
            string s = "\\";
            for (int i = 0; i <= 10; i++)
            {
                if (System.IO.File.Exists(path + s + name))
                    return (path + s + name);
                else
                    s += "..\\";
            }
            path = Environment.CurrentDirectory;
            s = "\\";
            for (int i = 0; i <= 10; i++)
            {
                if (System.IO.File.Exists(path + s + name))
                    return (path + s + name);
                else
                    s += "..\\";
            }
            return "";
        }
        public static void SetConnectionString(System.Data.OleDb.OleDbConnection oleDbConnection, string path)
        {
            oleDbConnection.ConnectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False", path);
        }
        public static Image GetImage(string name)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path + name);
            if (stream != null)
                return Image.FromStream(stream);
            return null;
        }
        public static Cursor GetCursor(string name)
        {
            return ResourceImageHelper.CreateCursorFromResources(path + name, Assembly.GetExecutingAssembly());
        }
    }
}
