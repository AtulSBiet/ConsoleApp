using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ModifyConstFile
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(args[0], File.ReadAllText(args[0]).Replace("DB_HOST = \"app42prod.cfdywzjrm34y.us-west-2.rds.amazonaws.com\"", "DB_HOST = \"182.73.181.76\""));
            File.WriteAllText(args[0], File.ReadAllText(args[0]).Replace("DB_PASSWORD = \"App42RootUser\"", "DB_PASSWORD = \"\""));
            File.WriteAllText(args[0], File.ReadAllText(args[0]).Replace("SKIP_LOOKUP = false", "SKIP_LOOKUP = true"));
        }
    }
}
