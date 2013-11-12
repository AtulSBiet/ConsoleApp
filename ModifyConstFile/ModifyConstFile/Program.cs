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
            String domainFilePath = @"C:\Automation\AppWarp\src\com\shephertz\app42\server\domain\Constants.java";
            File.WriteAllText(args[0], File.ReadAllText(args[0]).Replace("DB_HOST = \"app42prod.cfdywzjrm34y.us-west-2.rds.amazonaws.com\"", "DB_HOST = \"192.168.1.13\""));
            File.WriteAllText(args[0], File.ReadAllText(args[0]).Replace("DB_PASSWORD = \"App42RootUser\"", "DB_PASSWORD = \"\""));
            File.WriteAllText(args[0], File.ReadAllText(args[0]).Replace("SKIP_LOOKUP = false", "SKIP_LOOKUP = true"));
            File.WriteAllText(domainFilePath, File.ReadAllText(domainFilePath).Replace("CLEAN_UP_TIME_MILLISECONDS = 3600000", "CLEAN_UP_TIME_MILLISECONDS = 60000"));
        }
    }
}
