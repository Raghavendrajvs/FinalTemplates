using Microsoft.SharePoint.Client;
using System;
using System.IO;
using System.Security;
using Excel= Microsoft.Office.Interop.Excel;
using File = Microsoft.SharePoint.Client.File;
using DocumentFormat.OpenXml.Packaging;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.Linq;
using Microsoft.Office.Excel.Server.WebServices;

namespace SPass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter User Email :");
            //string username = ;
            string userName = "raghavendra.jinkala@acuvate.com";
            Console.WriteLine("Enter your password.");
            SecureString password = GetPassword();
            string url = "https://acuvatehyd.sharepoint.com/teams/Practice0ct12018/RaghuRocks";
           // bool IsError = true;
            using (var clientContext = new ClientContext(url))
            {
                DataTable dataTable = new DataTable("ExcelDataTable");
                clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
               
                List DocumentLibrary = clientContext.Web.Lists.GetByTitle("Documents");
                File file = DocumentLibrary.RootFolder.Files.GetByUrl("sharepointassesmentfile.xlsx");
                ClientResult<Stream> data = file.OpenBinaryStream();
                clientContext.Load(file);

                try
                {
                    clientContext.ExecuteQuery();
                    Console.WriteLine("loaded file successful");
                    Console.WriteLine(file.Title);
                    Console.WriteLine(file.Name);
             
                  //using (MemoryStream memoryStream = new MemoryStream())
                  //{
                  //  if (data != null)
                  //  {
                  //      data.Value.CopyTo(memoryStream);
                  //      using (SpreadsheetDocument documnet = SpreadsheetDocument.Open(memoryStream, false))
                  //      {
                  //          WorkbookPart workbookpart = documnet.WorkbookPart;
                  //          IEnumerable<Sheet> sheets = documnet.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                  //          string relationshipId = sheets.First().Id.Value;
                  //          WorksheetPart worksheetPart = (WorksheetPart)documnet.WorkbookPart.GetPartById(relationshipId);
                  //          Worksheet workSheet = worksheetPart.Worksheet;
                  //          SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                  //          IEnumerable<Row> rows = sheetData.Descendants<Row>();
                  //          foreach (Cell cell in rows.ElementAt(0))
                  //          {
                  //              string str = GetCellValue(clientContext, documnet, cell);
                  //              dataTable.Columns.Add(str);
                  //          }
                  //          foreach (Row row in rows)
                  //          {
                  //              if (row != null)
                  //              {
                  //                  DataRow dataRow = dataTable.NewRow();
                  //                  for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                  //                  {
                  //                      dataRow[i] = GetCellValue(clientContext, documnet, row.Descendants<Cell>().ElementAt(i));
                  //                        Console.WriteLine(dataRow[i]);
                  //                  }
                  //                  dataTable.Rows.Add(dataRow);
                  //              }
                  //          }
                  //          dataTable.Rows.RemoveAt(0);
                  //      }
                    //}
                 // }
                  
                //UpdateSPList(clientContext, dataTable, fileName);
                //IsError = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error ", e);
                    //IsError = true;

                    //Console.WriteLine(e.Message);

                    //Console.WriteLine("first catch block main");
                }
            Console.ReadKey();


            }

            using (var clientContext = new ClientContext(url))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, password);

                List DocumentLibrary = clientContext.Web.Lists.GetByTitle("Documents");
                File file = DocumentLibrary.RootFolder.Files.GetByUrl("sharepointassesmentfile.xlsx");


                var fileRef = file.ServerRelativeUrl;
                var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
                var fileName = Path.Combine(filePath, (string)file.Name);
                using (var fileStream = System.IO.File.Create(fileName))
                {
                    fileInfo.Stream.CopyTo(fileStream);
                }
            }

            //using (var clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Practice0ct12018/RaghuRocks"))
            //{
            //    clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
            //    List DocumentLibrary = clientContext.Web.Lists.GetByTitle("Documents");
            //    File file = DocumentLibrary.RootFolder.Files.GetByUrl("sharepointassesmentfile.xlsx");
            //    clientContext.Load(file);
            //    clientContext.ExecuteQuery();
            //    var filepath = file.ServerRelativeUrl;
            //    var  fileinfo=File.OpenBinaryDirect(clientContext, filepath);
            //    Console.WriteLine(file.Name);
            //    var fileName = Path.Combine("https://acuvatehyd.sharepoint.com/Practice0ct12018/RaghuRocks/", (string)file.Name);

            //Excel.Application xlApp = new Excel.Application();           
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file.ToString(), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            //int rowCount = xlRange.Rows.Count;
            //int colCount = xlRange.Columns.Count;

            //for (int i = 1; i <= rowCount; i++)
            //{
            //    for (int j = 1; j <= colCount; j++)
            //    {
            //        clientContext.Load(xlWorksheet.Cells[i, j].ToString());
            //        clientContext.ExecuteQuery();
            //        Console.WriteLine(xlWorksheet.Cells[i, j].ToString());
            //    }
            //}
            // }

            //using (var clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Practice0ct12018/RaghuRocks"))
            //{
            //    clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
            //    if (clientContext != null)
            //    {
            //        var list = clientContext.Web.Lists.GetByTitle("Documents");
            //        var listItem = list.GetItemById(1);
            //        clientContext.Load(list);
            //        clientContext.Load(listItem, i => i.File);
            //        clientContext.ExecuteQuery();

            //        var fileRef = listItem.File.ServerRelativeUrl;
            //        var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
            //        var fileName = Path.Combine("https://acuvatehyd.sharepoint.com/Practice0ct12018/RaghuRocks/", (string)listItem.File.Name);
            //        using (var fileStream = System.IO.File.Create(fileName))
            //        {
            //           fileInfo.Stream.CopyTo(fileStream);
            //        }
            //    }
            //}
        }


        //private static void UpdateSPList(ClientContext clientContext, DataTable dataTable, string fileName)
        //{
        //    bool isError = true;
        //    string strErrorMsg = string.Empty;
        //    Int32 count = 0;
        //    const string lstName = "Files";
        //    const string lstColCreatedBy = "create";
        //    const string lstColType = "typeof";
        //    const string lstColSize = "Size";
        //    try
        //    {
        //        List oList = clientContext.Web.Lists.GetByTitle(lstName);
        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            if (count++ == 0)
        //                continue;
        //            string filee = row[0].ToString();
        //            string filename = filee.Split('\\').Last();
        //            System.IO.FileInfo filesize = new System.IO.FileInfo(row[0].ToString());
        //            long size = filesize.Length;
        //            string exten = filesize.Extension;
        //            Type type = filesize.GetType();
        //            if ((size / 1048576.0) > 0 && (size / 1048576.0) < 15)
        //            {
        //                var fileCreationInformation = new FileCreationInformation();
        //                fileCreationInformation.Content = System.IO.File.ReadAllBytes(row[0].ToString());
        //                fileCreationInformation.Url = filename;
        //                Microsoft.SharePoint.Client.File file = oList.RootFolder.Files.Add(fileCreationInformation);
        //                clientContext.Load(file);
        //                var item = file.ListItemAllFields;
        //                item[lstColCreatedBy] = row[1].ToString();
        //                item[lstColType] = exten;
        //                item[lstColSize] = filesize.Length;
        //                item.Update();
        //                clientContext.ExecuteQuery();
        //            }
        //        }
        //        isError = false;
        //    }
        //    catch (Exception e)
        //    {
        //        isError = true;
        //        Console.WriteLine(e.Message);
        //    }

        //}

        private static string GetCellValue(ClientContext clientContext, SpreadsheetDocument document, Cell cell)
        {
            bool isError = true;
            string strErrorMsg = string.Empty;
            string value = string.Empty;
            try
            {
                if (cell != null)
                {
                    SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
                    if (cell.CellValue != null)
                    {
                        value = cell.CellValue.InnerXml;
                        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                        {
                            if (stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)] != null)
                            {
                                isError = false;
                                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                            }
                        }
                        else
                        {
                            isError = false;
                            return value;
                        }
                    }
                }
                isError = false;
                return string.Empty;
            }
            catch (Exception e)
            {
                isError = true;
                strErrorMsg = e.Message;
            }

            return value;
        }

            private static SecureString GetPassword()

        {
            ConsoleKeyInfo info;
            //Get the user's password as a SecureString  
            SecureString securePassword = new SecureString();
            do
            {
                info = Console.ReadKey(true);
                if (info.Key != ConsoleKey.Enter)
                {
                    securePassword.AppendChar(info.KeyChar);
                }
            }
            while (info.Key != ConsoleKey.Enter);
            return securePassword;
        }
    }
}