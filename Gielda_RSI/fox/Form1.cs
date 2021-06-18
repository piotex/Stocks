using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gecko;
using Gecko.WebIDL;

namespace fox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Xpcom.Initialize("Firefox");

            List<string> links = new fox.MyCode.GetAllCompanies().Get("dd");
            List<string> record = new List<string>();
            foreach (var link in links)
            {
                string lin = "https://www.biznesradar.pl/" + link;
                record = new MyCode.GetPTV().Get(lin);

                textBox1.Text += lin + "   ";
                foreach (var item in record)
                {
                    textBox1.Text += item + "___";
                }
                textBox1.Text += "\r\n";
            }
        }

    }
}
