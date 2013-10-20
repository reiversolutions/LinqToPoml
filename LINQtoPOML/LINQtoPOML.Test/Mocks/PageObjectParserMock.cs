using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LINQtoPOML.Test.Mocks
{
    internal class PageObjectParserMock
    {
        internal static readonly DirectoryInfo VALID_pomlDirectory = new DirectoryInfo(@"..\..\..\LINQtoPOML.Test\Mocks\TestFiles");
        internal static readonly FileInfo VALID_GET_pomlFileInfo_1 = new FileInfo(@"..\..\..\LINQtoPOML.Test\Mocks\TestFiles\valid_example_1.poml");
        internal static readonly FileInfo VALID_GET_pomlFileInfo_2 = new FileInfo(@"..\..\..\LINQtoPOML.Test\Mocks\TestFiles\valid_example_2.poml");
        internal static readonly FileInfo VALID_GET_pomlFileInfo_3 = new FileInfo(@"..\..\..\LINQtoPOML.Test\Mocks\TestFiles\valid_example_3.poml");
        internal static readonly FileInfo VALID_READ_pomlFileInfo = new FileInfo(@"..\..\..\LINQtoPOML.Test\Mocks\TestFiles\valid_read.poml");
        internal static readonly FileInfo VALID_SAVE_pomlFileInfo = new FileInfo(@"..\..\..\LINQtoPOML.Test\Mocks\TestFiles\valid_save.poml");
        internal static readonly Pages VALID_pomlFile = new Pages()
        {
            Name = "Website pages",
            ListOfPages = new List<Page>()
            {
                new Page()
                {
                    Name = "Login",
                    ListOfElements = new List<PageElement>()
                    {
                        new PageElement()
                        {
                            Name = "Username",
                            Locator = "username",
                            Selector = "Text",
                            Type = "id"
                        },
                        new PageElement()
                        {
                            Name = "Password",
                            Locator = "#password",
                            Selector = "Text",
                            Type = "css"
                        }
                    }
                }
            }
        };
    }
}