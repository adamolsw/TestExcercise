using NetExercise.Models;
using System.IO;

namespace NetExercise.Repository
{
    public class SaveToCsvFile : ISaveToFile
    {
        public void SaveFile(Text text, string dirPath)
        {

            string applicationPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Output");
            if (!Directory.Exists(applicationPath))
            {
                Directory.CreateDirectory(applicationPath);
            }
            dirPath = Path.Combine(applicationPath, dirPath);

            using (StreamWriter sw = new StreamWriter(dirPath + ".csv"))
            {
                for (int i = 0; i < text.sentence.Count; i++)
                {
                    string textLine = "";
                    foreach (string word in text.sentence[i].word)
                    {
                        textLine = textLine + ", " + word;
                    }
                    sw.WriteLine("Sentence " + (i + 1).ToString() + textLine);
                }
            }
        }
    }
}