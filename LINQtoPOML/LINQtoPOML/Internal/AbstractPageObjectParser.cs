using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LINQtoPOML.Internal.Parsers
{
    internal abstract class AbstractPageObjectParser
    {
        abstract internal Pages ParseFile(FileInfo file);
        abstract internal bool SaveObject(FileInfo file, Pages data);
    }
}