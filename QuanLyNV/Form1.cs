using System.Xml.Linq;

namespace QuanLyNV
{
    public partial class Form1 : Form
    {
        private object tbname;

        public Form1()
        {
            InitializeComponent();
            tbPassWord.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text;
            string password = tbPassWord.Text;

            if (username == "tintin" && password == "1234567890")
            {

                Form2 fr01 = new Form2();
                fr01.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
