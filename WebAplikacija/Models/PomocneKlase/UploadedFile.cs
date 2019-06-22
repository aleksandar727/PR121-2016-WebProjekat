using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models.PomocneKlase
{
    public class UploadedFile
    {
        #region Fields
        public string name { get; set; }
        public string localPath { get; set; }
        #endregion


        #region Constructors
        public UploadedFile()
        {
            this.name = "";
            this.localPath = "";
        }
        public UploadedFile(string name, string localPath)
        {
            this.name = name;
            this.localPath = localPath;
        }
        #endregion
    }
}