using Microsoft.SharePoint.Client;
using System;
using System.IO;
using System.Security;
using Excel = Microsoft.Office.Interop.Excel;
using File = Microsoft.SharePoint.Client.File;

namespace SPass
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "raghavendra.jinkala@acuvate.com";
            Console.WriteLine("Enter your password.");
            SecureString password = GetPassword();

            using (var clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Practice0ct12018/RaghuRocks"))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
                List DocumentLibrary = clientContext.Web.Lists.GetByTitle("Documents");
                File file = DocumentLibrary.RootFolder.Files.GetByUrl("sharepointassesmentfile.xlsx");
                clientContext.Load(file);
                try
                {
                    clientContext.ExecuteQuery();
                    Console.WriteLine("loaded file successful");
                    Console.WriteLine(file.Title);
                    Console.WriteLine(file.Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error ", e);
                }
                Console.ReadKey();
            }

            //using (var clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Practice0ct12018/RaghuRocks"))
            //{
            //    clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
            //    List DocumentLibrary = clientContext.Web.Lists.GetByTitle("Documents");
            //    File file = DocumentLibrary.RootFolder.Files.GetByUrl("sharepointassesmentfile.xlsx");
            //    Excel.Application xlApp = new Excel.Application();

            //    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file.ToString(), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //    Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
            //    Excel.Range xlRange = xlWorksheet.UsedRange;

            //    int rowCount = xlRange.Rows.Count;
            //    int colCount = xlRange.Columns.Count;

            //    for (int i = 1; i <= rowCount; i++)
            //    {
            //        for (int j = 1; j <= colCount; j++)
            //        {
            //            clientContext.Load(xlWorksheet.Cells[i, j].ToString());
            //            clientContext.ExecuteQuery();
            //            Console.WriteLine(xlWorksheet.Cells[i, j].ToString());
            //        }
            //    }
            //}


            using (var clientContext = new ClientContext("https://acuvatehyd.sharepoint.com/teams/Practice0ct12018/RaghuRocks"))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
                if (clientContext != null)
                {
                    var list = clientContext.Web.Lists.GetByTitle("Documents");
                    var listItem = list.GetItemById(1);
                    clientContext.Load(list);
                    clientContext.Load(listItem, i => i.File);
                    clientContext.ExecuteQuery();

                    var fileRef = listItem.File.ServerRelativeUrl;
                    var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
                    var fileName = Path.Combine("https://acuvatehyd.sharepoint.com/Practice0ct12018/RaghuRocks/", (string)listItem.File.Name);
                    using (var fileStream = System.IO.File.Create(fileName))
                    {
                        fileInfo.Stream.CopyTo(fileStream);
                    }

                }
            }
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
