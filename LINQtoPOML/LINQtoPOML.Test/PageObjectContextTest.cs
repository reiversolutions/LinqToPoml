using LINQtoPOML;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using LINQtoPOML.Test.Mocks;

namespace LINQtoPOML.Test
{
    /// <summary>
    /// PageObjectContext tests
    ///</summary>
    [TestClass]
    public class PageObjectContextTest
    {
        [TestMethod]
        public void Get_Valid_Test()
        {
            // Assign
            PageObjectContext context = new PageObjectContext(PageObjectParserMock.VALID_pomlDirectory);
            
            // Act
            List<PageObjectFile> result = context.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            Assert.IsTrue(result.Exists(i => i.Data.Name.Contains("Website A")));
            Assert.IsTrue(result.Exists(i => i.Data.Name.Contains("Website B")));
            Assert.IsTrue(result.Exists(i => i.Data.Name.Contains("Website C")));
        }

        [TestMethod]
        public void GetByGroup_Valid_Test()
        {
            // Assign
            PageObjectContext context = new PageObjectContext(PageObjectParserMock.VALID_pomlDirectory);

            // Act
            List<PageObjectFile> result = context.Get("Website A");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(1, result.Count);

            Assert.IsTrue(result.Exists(i => i.Data.Name.Contains("Website A")));
            Assert.IsTrue(result.Exists(i => !i.Data.Name.Contains("Website B")));
            Assert.IsTrue(result.Exists(i => !i.Data.Name.Contains("Website C")));
        }
    }
}