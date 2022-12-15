﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data.Exporting
{
    public class ExportManager
    {
        public static readonly string DataDir = Path.GetTempPath();

        public static string CreateExportDirectory(string directory, string subDirName)
        {
            if (directory is null) return null;

            var path = Path.Join(directory, "export", subDirName);
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }

            Directory.CreateDirectory(path);
            return path;
        }
    }
}
