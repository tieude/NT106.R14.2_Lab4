using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_Lab4.Bai1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim();
            if(string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "http://" + url;
                textBox1.Text = url;
            }

            try
            {
                button1.Enabled = false;
                Cursor = Cursors.WaitCursor;

                richTextBox1.Text = GetHtml(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy dữ liệu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                button1.Enabled = true;
            }
        }

        private string GetHtml(string url)
        {
         
            WebRequest request = WebRequest.Create(url);

            if (request is HttpWebRequest httpRequest)
            {
                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
            }

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            response.Close();
            return responseFromServer;
        }
    }
}
