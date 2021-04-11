using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practice.Model;

namespace Practice
{
    public partial class Menu : Form
    {
        // 前画面の値を取得
        public UserDataModel Model { get; set; }

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            LabelUserName.Text = Model.UserName; 

        }
    }
}
