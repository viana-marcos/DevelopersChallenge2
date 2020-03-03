

using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebApplication1
{
    public class UploadService
    {
        public List<Transaction> GetTransactions(Microsoft.AspNetCore.Http.IFormFileCollection files )
        {
            var transactionsList = new List<Transaction>();
            //var transactionRepository = new TransactionRepository();

            if (files.Count > 0)
            {
                foreach (var file in files)
                {

                    if (file.Length > 0) 
                    {
                        XmlDocument doc = new XmlDocument();


                        FileStream fileStream = new FileStream(file.FileName, FileMode.Create);
                        file.CopyTo(fileStream);


                        if (fileStream.Position > 0)
                        {
                            fileStream.Position = 0;
                        }

                        doc.Load(fileStream);

                        XmlNodeList elementBankTranList = doc.GetElementsByTagName("BANKTRANLIST");
                        XmlNodeList elementTrans = doc.GetElementsByTagName("STMTTRN");
                        string xmlStringBankTranList = XElement.Parse(elementBankTranList.Item(0).OuterXml).ToString();
                        var transactions = new List<Transaction>();

                        XmlRootAttribute xRootTrans = new XmlRootAttribute();
                        xRootTrans.ElementName = "STMTTRN";
                        xRootTrans.IsNullable = true;
                        XmlSerializer serializadorTrans = new XmlSerializer(typeof(Transaction), xRootTrans);

                        foreach (XmlNode node in elementTrans)
                        {
                            string xmlStringtTrans = XElement.Parse(node.OuterXml).ToString();
                            StringReader stringReaderTrans = new StringReader(xmlStringtTrans);
                            var transaction = (Transaction)serializadorTrans.Deserialize(stringReaderTrans);
                            bool exists = transactionsList.Exists(x => x.dtposted.Equals(transaction.dtposted));
                            stringReaderTrans.Close();
                            if (!exists)
                                transactions.Add(transaction);
                        }

                        foreach (var t in transactions)
                        {
                            transactionsList.Add(t);
                        }

                        transactions.Clear();
                        fileStream.Close();
                    }
                    

                }
            }

            
            return transactionsList;
        }       


    }
}
