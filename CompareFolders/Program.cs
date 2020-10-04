using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] eFiles = Directory.GetFiles(@"E:\Videos\", "*.*", SearchOption.AllDirectories);
            string[] mybookFiles = Directory.GetFiles(@"\\mybookworld\Public\Videos\", "*.*", SearchOption.AllDirectories);

            List<string> eFileList = new List<string>();
            
            foreach (string str in eFiles)
            {
                if (str.Contains("Thumbs.db")) { continue; }
                eFileList.Add(str.Replace(@"E:\", string.Empty));
            }

            List<string> myBookFileList = new List<string>();
            foreach (string file in mybookFiles)
            {
                if (file.Contains("Thumbs.db")) { continue; }
                string tmp = file.Replace(@"\\mybookworld\Public\", string.Empty);
                myBookFileList.Add(file.Replace(@"\\mybookworld\Public\", string.Empty));
            }

            List<string> eFileListWithNoMyBookFiles = eFileList.Except(myBookFileList).ToList();
            List<string> myBookFilesWithNoeFiles = myBookFileList.Except(eFileList).ToList();

            using (StreamWriter writer = new StreamWriter(@"C:\Users\Nish\Documents\tmp\filediff.txt"))
            {
                writer.WriteLine(@"E:\ drive Files missing in mybook world");
                foreach (string str in eFileListWithNoMyBookFiles)
                {
                    writer.WriteLine(str);
                }
                writer.WriteLine(@"My Book world files missing in E:\ drive");
                foreach (string str in myBookFilesWithNoeFiles)
                {
                    writer.WriteLine(str);
                }
                writer.WriteLine("Done!!!");
            }
        }
    }
}
