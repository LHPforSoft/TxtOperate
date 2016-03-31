using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TxtOperate
{
    class TXTOperate
    {
        private static string FileGet;
        private string saveFile = "";
        private bool SuccessOrNo;
        OpenFileDialog OFD = new OpenFileDialog();
        SaveFileDialog SFD = new SaveFileDialog();

        public TXTOperate()
        {

        }

        public bool CreatTxt()
        {
            SFD.InitialDirectory = Environment.CurrentDirectory;
            SFD.Filter = "数据文件(*.txt)|*.Txt|所有文件|*.*";
            SFD.Title = "新建文本文件";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                saveFile = SFD.FileName;
                if (File.Exists(saveFile))
                {
                    File.Delete(saveFile);
                }
                File.Create(saveFile).Close();

                SuccessOrNo = true;
            }
            else
            {
                SuccessOrNo = false;
            }
            return SuccessOrNo;
        }

        public string OpenFile()
        {
            OFD.InitialDirectory = Environment.CurrentDirectory;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                FileGet = OFD.FileName;
            }
            return FileGet;
        }
        public string ReadText(string file)
        {
            string fs = file;
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            String line;
            line = sr.ReadToEnd();
            sr.Close();
            string s1 = line;//.Trim().Split('\n');
            return s1;

        }

        public bool SaveTxt(string TxtContent)
        {
            SFD.InitialDirectory = Environment.CurrentDirectory;
            SFD.Filter = "数据文件(*.txt)|*.Txt|所有文件|*.*";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                saveFile = SFD.FileName;
                if (File.Exists(saveFile))
                {
                    File.Delete(saveFile);
                }
                FileStream fs = new FileStream(saveFile, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
                //string Name = System.IO.Path.GetFileName(saveFile);
                sw.Flush();
                sw.BaseStream.Seek(0, SeekOrigin.End);
                string[] S = TxtContent.Trim().Split('\n');
                int length = S.Length;
                for (int i = 0; i < length; i++)
                {
                    sw.WriteLine(S[i]);
                }
                sw.Flush();
                sw.Close();
                SuccessOrNo = true;
            }
            else
            {
                SuccessOrNo = false;
            }
            return SuccessOrNo;
        }
    }
}
