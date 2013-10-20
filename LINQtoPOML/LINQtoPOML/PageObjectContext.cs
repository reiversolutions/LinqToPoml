using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LINQtoPOML.Internal.Parsers;

namespace LINQtoPOML
{
    /// <summary>
    /// Context store for poml files
    /// </summary>
    public class PageObjectContext
    {
        /// <summary>
        /// Directory root of poml files
        /// </summary>
        public DirectoryInfo Root { get; set; }

        /// <summary>
        /// Constructor for Page Object Context
        /// </summary>
        /// <param name="path">Path to poml directory</param>
        public PageObjectContext(DirectoryInfo path)
        {
            Root = path;
        }

        /// <summary>
        /// Get all the Page object files
        /// </summary>
        /// <returns>Page object files</returns>
        public List<PageObjectFile> Get()
        {
            List<PageObjectFile> files = new List<PageObjectFile>();

            files = GetData(null);

            return files != null && files.Count > 0 ? files : null;
        }

        /// <summary>
        /// Get a list of page object files filtered by group name
        /// </summary>
        /// <param name="group">Page group name</param>
        /// <returns>Page object files</returns>
        public List<PageObjectFile> Get(string group)
        {
            List<PageObjectFile> files = new List<PageObjectFile>();

            files = GetData(group);

            return files != null && files.Count > 0 ? files : null;
        }

        #region private methods
        private List<PageObjectFile> GetData(string group)
        {
            List<PageObjectFile> files = new List<PageObjectFile>();

            files = ParseDirectory(Root, group);

            return files.Count > 0 ? files : null;
        }

        private List<PageObjectFile> ParseDirectory(DirectoryInfo info, string group)
        {
            List<PageObjectFile> files = new List<PageObjectFile>();
            if (info.Exists)
            {
                AbstractPageObjectParser parser = new PageObjectParser();

                // Parse each file in current directory
                foreach (FileInfo file in info.GetFiles())
                {
                    Pages page = parser.ParseFile(file);

                    if (page != null)
                    {
                        // Filter by group name
                        if (group == null || page.Name == group)
                        {
                            files.Add(new PageObjectFile()
                            {
                                FileInfo = file,
                                Data = page
                            });
                        }
                    }
                }

                // Parse each subdirectory using recursion.
                foreach (DirectoryInfo subDirectory in info.GetDirectories())
                {
                    files.AddRange(ParseDirectory(subDirectory, group));
                }
            }

            return files;
        }
        #endregion
    }
}