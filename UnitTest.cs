using CSVParse.Classes;
using CSVParse.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSVParseTest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Test case with record having no value for Price Multiplier in the Algo Params column
        /// Checks if the all records have read successfully
        /// </summary>
        [TestMethod]
        public void TestMethod_NoPriceMultiplierValue()
        {
            int rowCount = 0;
            CSVParser parse = new CSVParser();
            List<OutputCSVModel> lst = parse.Read(@"C:\Users\Fenil\source\repos\CSVParse\Files\DataExtractor_Example_Input_NoContractSize.csv", "DataExtractor_Example_Input_NoContractSize.csv", ref rowCount);
            Assert.IsFalse(lst.Count == rowCount); //Number of records in the source file would not be same as the records in the file to be written because of no value for Price Multiplier in the Algo Params column in one of the record.
        }

        /// <summary>
        /// Test case with correct data -- Ideal case
        /// Checks if the all records have read successfully
        /// </summary>
        [TestMethod]
        public void TestMethod_Ideal()
        {
            int rowCount = 0;
            CSVParser parse = new CSVParser();
            List<OutputCSVModel> lst = parse.Read(@"C:\Users\Fenil\source\repos\CSVParse\Files\DataExtractor_Example_Input.csv", "DataExtractor_Example_Input.csv", ref rowCount);
            Assert.IsTrue(lst.Count > 0 && lst.Count == rowCount);//Number of records in the source file should be >0 and same as the records in the file to be written.
        }

        /// <summary>
        /// Test case for file which are not CSV
        /// Checks if the all records have read successfully
        /// </summary>
        [TestMethod]
        public void TestMethod_WrongExtension()
        {
            int rowCount = 0;
            CSVParser parse = new CSVParser();
            List<OutputCSVModel> lst = parse.Read(@"C:\Users\Fenil\source\repos\CSVParse\Files\DataExtractor.docx", "DataExtractor.docx", ref rowCount);
            Assert.IsFalse(lst.Count > 0); //Number of records in the list would be 0 as the file is a word document.
        }

        /// <summary>
        /// Test case with missing ISIN column in the CSV file
        /// Checks if the all records have read successfully
        /// </summary>
        [TestMethod]
        public void TestMethod_MissingColumn()
        {
            int rowCount = 0;
            CSVParser parse = new CSVParser();
            List<OutputCSVModel> lst = parse.Read(@"C:\Users\Fenil\source\repos\CSVParse\Files\DataExtractor_Example_Input_NoISIN.csv", "DataExtractor_Example_Input_NoISIN.csv", ref rowCount);
            Assert.IsFalse(lst.Count == rowCount); //Number of records in the source file would not be same as the records in the file to be written as ISIN column is missing.
        }
    }
}
