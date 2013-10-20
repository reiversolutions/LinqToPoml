using LINQtoPOML.Internal.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using LINQtoPOML.Test.Mocks;

namespace LINQtoPOML.Test
{
    /// <summary>
    /// PageObjectParser tests
    /// </summary>
    [TestClass]
    public class PageObjectParserTest
    {
        #region Setup / Teardown
        [TestInitialize]
        public void Setup()
        {
            // Removed valid save file
            RemoveSaveFile();
        }

        [TestCleanup]
        public void Teardown()
        {
            // Teardown valid save file
            RemoveSaveFile();
        }

        private void RemoveSaveFile()
        {
            if (File.Exists(PageObjectParserMock.VALID_SAVE_pomlFileInfo.FullName))
            {
                File.Delete(PageObjectParserMock.VALID_SAVE_pomlFileInfo.FullName);
            }
        }
        #endregion

        [TestMethod]
        public void ParseFile_Valid_Test()
        {
            // Assign
            PageObjectParser parser = new PageObjectParser();
            FileInfo file = PageObjectParserMock.VALID_READ_pomlFileInfo;
            Pages expected = PageObjectParserMock.VALID_pomlFile;

            // Act
            Pages result = parser.ParseFile(file);

            // Assert
            Assert.AreEqual(expected.Name, result.Name);
            for (int i = 0; i < expected.ListOfPages.Count; i++)
            {
                Page expectedPage = expected.ListOfPages[i];
                Page resultPage = result.ListOfPages[i];

                Assert.AreEqual(expectedPage.Name, resultPage.Name);
                for (int j = 0; j < expectedPage.ListOfElements.Count; j++)
                {
                    PageElement expectedElement = expectedPage.ListOfElements[j];
                    PageElement resultElement = resultPage.ListOfElements[j];

                    Assert.AreEqual(expectedElement.Name, resultElement.Name);
                    Assert.AreEqual(expectedElement.Locator, resultElement.Locator);
                    Assert.AreEqual(expectedElement.Selector, resultElement.Selector);
                    Assert.AreEqual(expectedElement.Type, resultElement.Type);
                }
            }
        }

        [TestMethod]
        public void SaveObject_Valid_Test()
        {
            // Assign
            PageObjectParser parser = new PageObjectParser();
            FileInfo file = PageObjectParserMock.VALID_SAVE_pomlFileInfo;
            Pages data = PageObjectParserMock.VALID_pomlFile;

            // Act
            bool result = parser.SaveObject(file, data);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(file.FullName));
        }
    }
}