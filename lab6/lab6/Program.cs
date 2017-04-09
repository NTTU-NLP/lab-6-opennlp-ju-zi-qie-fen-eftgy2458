using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using opennlp.tools.sentdetect;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"..\..\Data\result.txt");
            StreamReader sr = new StreamReader(@"..\..\Data\data.txt");
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                java.io.InputStream modelIn = new java.io.FileInputStream("en-sent.bin");
                SentenceModel smodel = new SentenceModel(modelIn);
                SentenceDetector detector = new SentenceDetectorME(smodel);
                string[] sents = detector.sentDetect(line);
                foreach (var sent in sents)
                {
                    sw.WriteLine(sent);
                    sw.WriteLine();
                }
                sw.Flush();
            }
            sr.Close();
            sw.Close();
        }
    }
}