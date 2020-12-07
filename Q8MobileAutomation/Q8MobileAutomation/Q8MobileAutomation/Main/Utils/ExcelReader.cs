using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Q8MobileAutomation.Main.Utils
{
    public class ExcelReader
    {
        private int rowCntr = 0;
        private int colCntr = 0;
        public int rowCount = 0;
        private int colCount = 0;
        private int worksheetCount = 0;
        private string workSheetName = string.Empty;
        private Excel.Application xlApp = null;
        private Excel.Workbook xlWorkBook= null;
        private Excel.Worksheet xlWorkSheet= null;
        private Excel.Range xlrange=null;
        public static DataSet excelDataSet = null;

        //class constructor
        public ExcelReader()
        {
            try
            {
                xlApp = new Excel.Application();
                excelDataSet = new DataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to fetch complete excel data
        /// </summary>
        public void GetCompleteExcelData()
        {
            try
            {
                xlWorkBook = xlApp.Workbooks.Open(Helper.dirPath + @"Test\TestData\AutomationTestData.xlsx");
                worksheetCount = xlWorkBook.Worksheets.Count;
                for (int workSheet = 1; workSheet <= worksheetCount; workSheet++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[workSheet];
                    workSheetName = xlWorkSheet.Name;
                    xlrange = xlWorkSheet.UsedRange;
                    rowCount = xlrange.Rows.Count;
                    colCount = xlrange.Columns.Count;
                    var dt = new DataTable(workSheetName);
                    string[] headers = new string[colCount];

                    for (colCntr = 1; colCntr <= colCount; colCntr++)
                    {
                        headers[colCntr - 1] = Convert.ToString((xlrange.Cells[1, colCntr] as Excel.Range).Value2);
                        dt.Columns.Add(headers[colCntr - 1]);
                    }
                    for (rowCntr = 2; rowCntr <= rowCount; rowCntr++)
                    {
                        var array = new object[colCount];
                        for (colCntr = 1; colCntr <= colCount; colCntr++)
                        {
                            array[colCntr - 1] = Convert.ToString((xlrange.Cells[rowCntr, colCntr] as Excel.Range).Value2);
                        }
                        dt.Rows.Add(array);
                    }
                    excelDataSet.Tables.Add(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to retrive the cell value
        /// </summary>
        /// <param name="WorksheetName"></param>
        /// <param name="ColName"></param>
        /// <returns></returns>
        public string GetValueFromSheet(string WorksheetName, string ColName)
        {
            try
            {
                return excelDataSet.Tables[WorksheetName].Rows[0][ColName].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }
    }
}
