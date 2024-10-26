using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            // Kiểm tra ID có phải là chuỗi 10 ký tự số hay không
            if (tbId.Text.Length != 10 || !tbId.Text.All(char.IsDigit))
            {
                MessageBox.Show("ID phải là chuỗi 10 ký tự số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tên không chứa số và không được để trống
            if (string.IsNullOrWhiteSpace(tbName.Text) || tbName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Tên không được chứa số và không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tuổi phải là số
            if (!int.TryParse(tbAge.Text, out _))
            {
                MessageBox.Show("Tuổi phải là số nguyên.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Tất cả các kiểm tra đều thành công
            return true;
        }
        private void btAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);

            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu DataGridView có ít nhất 1 dòng (không tính dòng trống cuối cùng)
            if (dgvEmployee.Rows.Count > 1 || (dgvEmployee.AllowUserToAddRows == false && dgvEmployee.Rows.Count > 0))
            {
                // Lấy chỉ số dòng hiện tại
                int idx = dgvEmployee.CurrentCell.RowIndex;

                // Xóa dòng tại chỉ số đã chọn
                dgvEmployee.Rows.RemoveAt(idx);
            }
            else
            {
                // Thông báo lỗi nếu không có dòng nào để xóa
                MessageBox.Show("Không có dữ liệu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
            {
                // Đảm bảo rằng dòng không phải là dòng trống cuối cùng
                if (dgvEmployee.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    tbId.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                    tbName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                    tbAge.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ckGender.Checked = dgvEmployee.Rows[e.RowIndex].Cells[3].Value != null && (bool)dgvEmployee.Rows[e.RowIndex].Cells[3].Value;
                }
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ckGender_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows[idx].Cells[0].Value = tbId.Text;
                dgvEmployee.Rows[idx].Cells[1].Value = tbName.Text;
                dgvEmployee.Rows[idx].Cells[2].Value = tbAge.Text;
                dgvEmployee.Rows[idx].Cells[3].Value = ckGender.Checked;
            }  
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            dgvEmployee.RowEnter += dgvEmployee_RowEnter;


        }
    }
}
