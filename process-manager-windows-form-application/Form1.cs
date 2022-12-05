using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace process_manager_windows_form_application
{
    public partial class Form1 : Form
    {
        void DisplayProcess()
        {
            // Xóa nội dung cũ của ListBox
            lbOutput.Items.Clear();

            // Tìm danh sách các Process đang chạy.
            Process[] plist = Process.GetProcesses();

            // Hiển thị tên, ID của từng Process
            foreach (Process process in plist)
            {
                lbOutput.Items.Add(process.ProcessName + "," + process.Id);
            }
        }

        public Form1()
        {
            InitializeComponent();
            DisplayProcess();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Tạo form duyệt chọn file khả thi cần chạy.
            OpenFileDialog dlg = new OpenFileDialog();

            // Hiển thị form duyệt chọn file khả thi cần chạy.
            DialogResult ret = dlg.ShowDialog();

            // Kiểm tra quyết định của user, nếu user chọn OK thì ghi nhận tên file.
            if (ret == DialogResult.OK)
                txtPath.Text = dlg.FileName;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Tạo mới đối tượng quản lý Process.
            Process myProcess = new Process();
            try
            {
                // Thiết lập đường dẫn file cần chạy. 
                myProcess.StartInfo.FileName = txtPath.Text;

                // Kích hoạt process
                myProcess.Start();

                // Hiển thị danh sách các process đang chạy.
                DisplayProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Hiển thị lại danh sách các Process đang hiện hành.
            DisplayProcess();
        }
    }
}
