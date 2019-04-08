using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;


namespace SearchTest
{
    class ExcelComms
    {
        private static string[] columnSearchRange = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" }; //full search range that we will use       
        private static int startRow; //find the first row in the list and use it later to get the column headers
        private static int startColumnIndex = 0; //get the index of the first seen object. This will be the first header and tell us where to look later
        private static int maxRowSearchRange = 100; //the maximum amount of rows we will search for across the excel file when looking for data

        public static string startColumn; //assign the letter of the column that is found as the beginning of the data table
        public static int columnCount = 0; //count the amount of columns in the data table
        public static int rowCount = 0; //count the amount of rows in the data table
        public static string[] columnHeaders;
        

        public ExcelComms()
        {
            GetTableFormat(); //grab the headers and also the location of the table within the excel file
        }

        private static void GetTableFormat()
        {
            FileInfo file = new FileInfo(Application.StartupPath + "\\Data.xlsx"); //use the specified file location

            using (ExcelPackage pack = new ExcelPackage(file)) //create an excel package
            {
                ExcelWorkbook wb = pack.Workbook; //assign a workbook
                wb.Protection.LockWindows = false;
                wb.Protection.LockStructure = false;
                ExcelWorksheet ws = pack.Workbook.Worksheets[1]; //use "Sheet1"
                ws.Protection.AllowSelectLockedCells = true;
                
                bool tableFound = false; //use this to know when we have found the table

                for (int columnInt = 1; columnInt < columnSearchRange.Length; columnInt++)
                {
                    if (tableFound) //if we have found the first header, break from outer loop.
                    {
                        tableFound = false;
                        break;
                    }

                    for (int i = 1; i < maxRowSearchRange; i++)
                    {
                        if (ws.Cells[i, columnInt].Value != null)
                        {
                            startColumn = columnSearchRange[columnInt - 1]; //assign the column letter for building in more user controls
                            startRow = i; //record the location of the first row for headers
                            startColumnIndex = columnInt; //record the index of the first column in the excel sheet
                            tableFound = true; //take note that we have now found the table in the sheet
                            break; //we are done here so break back into the outer loop
                        }
                    }
                }

                List<string> headers = new List<string>(); //create a list to hold the header strings while we do not know how many there might be

                for (int i = startColumnIndex; i < columnSearchRange.Length; i++) //loop through the first row
                {
                    if (ws.Cells[startRow, i].Value != null) //when we come to the first null value, we know the table is finished
                    {
                        headers.Add(ws.Cells[startRow, i].Value.ToString()); //add the header to the list of strings
                        columnCount++; //increment a counter and keep track of how many columns we have in the table
                    }
                    else
                    {
                        columnHeaders = new string[columnCount]; //use the counter to specify the size of our header array
                        int counter = 0;
                        foreach (string value in headers)
                        {
                            columnHeaders[counter] = value; //place the header strings into the array
                            counter++;
                        }

                    }
                }

                for (int i = startRow; i < maxRowSearchRange; i++) //get the number of rows in the data table
                {
                    if (ws.Cells[i, startColumnIndex].Value != null)
                        rowCount++;
                    else
                        break;
                }
                
                
            }
        }

        public static Object[,] GetData(string filepath)
        {
            FileInfo file = new FileInfo(Application.StartupPath + "\\Data.xlsx"); //use the specified file location            

            Object[,] dataTable = new Object[rowCount, columnCount]; //create an object array to copy the data from the table

            using (ExcelPackage pack = new ExcelPackage(file)) //create an excel package
            {
                ExcelWorkbook wb = pack.Workbook; //assign a workbook
                wb.Protection.LockWindows = false;
                wb.Protection.LockStructure = false;
                ExcelWorksheet ws = pack.Workbook.Worksheets[1]; //use "Sheet1"
                ws.Protection.AllowSelectLockedCells = true;

                int dataR = 0;
                int dataC = 0;

                for (int i = startRow + 1; i < rowCount + startRow; i++)
                {
                    for (int j = startColumnIndex; j < columnCount + startColumnIndex; j++)
                    {
                        dataTable[dataR, dataC] = ws.Cells[i, j].Value;
                        dataC++;
                    }
                    dataC = 0;
                    dataR++;
                }
                dataR = 0;
            }

            return dataTable;
        }
    }
}
