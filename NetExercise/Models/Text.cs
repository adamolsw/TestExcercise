using System.Collections.Generic;
using System.Xml.Serialization;

namespace NetExercise.Models
{
    [XmlRoot("text")]
    public class Text
    {
        [XmlElement("sentence")]
        public List<Sentences> sentence { get; set; }

        public Text()
        {
            sentence = new List<Sentences>();
        }
    }
}