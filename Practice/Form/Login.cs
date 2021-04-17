using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Practice.Controller;
using Practice.Model;

namespace Practice
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        // ログインボタン押下時処理
        private void button1_Click(object sender, EventArgs e)
        {
            // パラメータ作成
            String UserId = TxtUserId.Text;
            String Password = TxtPassword.Text;

            // ログイン確認
            LoginController loginController = new LoginController();
            if (!loginController.Login(UserId, Password))
            {
                MessageBox.Show("ログイン失敗");
            }
        }
    }
}
