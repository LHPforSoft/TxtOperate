using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxtOperate
{
    public partial class Form1 : Form
    {
        public static string TextRead = "";
        TXTOperate txtOperate = new TXTOperate();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "文本操作";
            btnCreatTxt.Focus();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string returnFile = txtOperate.OpenFile();            //得到当前的文件的路径
            if (returnFile == null)
            {
                return;
            }
            else
            {
                TextRead = txtOperate.ReadText(returnFile);       //读取文件的内容
                Label Lb = new Label();
                Lb.Text = returnFile;                             //显示当前的路径
                Lb.Location = new Point(20, 60);
                Lb.AutoSize = true;
                this.Controls.Add(Lb);
                int length = TextRead.Trim().Split('\n').Length;
                TextBox Tb = new TextBox();
                Tb.Multiline = true;
                Tb.Location = new Point(20, 100);
                int intFontHeight = Tb.Font.Height;
                Tb.Height = intFontHeight * length + 6;
                Tb.Text += TextRead;                             //显示已读取的内容
                Graphics g = Tb.CreateGraphics();
                System.Drawing.SizeF s = g.MeasureString(Tb.Text, Tb.Font);
                Tb.Width = (int)s.Width + 10;
                Tb.TextChanged += new EventHandler(Tb_TextChanged);
                this.Controls.Add(Tb);
            }
        }
        void Tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            TextRead = tb.Text;
        }

        //保存文件  参数为文件的内容
        private void btnSaveTxt_Click(object sender, EventArgs e)
        {
            bool SucOrNo = txtOperate.SaveTxt(TextRead);        //保存文件 返回布尔值 是否保存
            if (SucOrNo == true)
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void btnCreatTxt_Click(object sender, EventArgs e)
        {
            bool SucOrNo = txtOperate.CreatTxt();
            if (SucOrNo == true)
            {
                MessageBox.Show("创建文本成功！");
            }
            else
            {
                MessageBox.Show("创建文本失败！");
            }
        }
    }
}
