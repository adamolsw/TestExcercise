using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetExercise.Models
{
    public class Sentences
    {
        [XmlElement("word")]
        public List<string> word { get; set; }
    }
}