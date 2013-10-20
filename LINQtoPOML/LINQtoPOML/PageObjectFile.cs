using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LINQtoPOML
{
    /// <summary>
    /// Page object file 
    /// </summary>
    public class PageObjectFile
    {
        /// <summary>
        /// File information
        /// </summary>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// Page object data
        /// </summary>
        public Pages Data { get; set; }
    }
}
