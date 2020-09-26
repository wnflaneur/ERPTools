using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExcelTools.Src
{
    [XmlRoot]
    public class Param
    {

        [XmlElement]
        public Map[] Maps { get; set; }
    }
    public class Map
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
}
