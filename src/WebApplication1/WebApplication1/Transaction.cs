using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApplication1
{
    [XmlRoot("STMTTRN")]    
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [XmlElement("TRNTYPE")]
        public string trntype { get; set; }
        [XmlElement("DTPOSTED")]
        public string dtposted { get; set; }
        [XmlElement("TRNAMT")]
        public decimal trnamt { get; set; }

        [XmlElement("MEMO")]
        public string memo { get; set; }
    }
}
