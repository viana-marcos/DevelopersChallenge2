using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApplication1
{
    [XmlRoot("BANKTRANLIST")]
    public class BankTranList

    {
        public BankTranList() { }

        public BankTranList(string _data)
        {
            this.data = _data;
        }

        [XmlElement("DTSTART")]
        public string dtstart { get; set; }
        [XmlElement("DTEND")]
        public string dtend { get; set; }
        public string data { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
