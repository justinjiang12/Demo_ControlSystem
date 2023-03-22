using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo_ControlSystem.MainSystem;

namespace Demo_ControlSystem.Forms
{
    public partial class LoginForm : Form
    {

        internal System_Control SYSCONTROL { get { return _SYSCONTROL; } set { _SYSCONTROL = value; } } //對外訊號(R/W)
        private System_Control _SYSCONTROL; //對內訊號


        internal LoginForm()
        {
            InitializeComponent();
        }


        private void btn_Login_Click(object sender, EventArgs e)
        {
            setLevel(_SYSCONTROL);
            Hide();
        }

        private void btn_Leave_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void setLevel(System_Control _SYSPermiss)
        {
            try
            {
                if (tex_name.Text == "gust" && tex_password.Text == "") { _SYSPermiss.PERMISS.Permission_Level = PermissionList.Level_0_Guest; }
                if (tex_name.Text == "op" && tex_password.Text == "op") { _SYSPermiss.PERMISS.Permission_Level = PermissionList.Level_1_Operator; }
                if (tex_name.Text == "eng" && tex_password.Text == "eng") { _SYSPermiss.PERMISS.Permission_Level = PermissionList.Level_2_Engineer; }
                if (tex_name.Text == "seng" && tex_password.Text == "seng") { _SYSPermiss.PERMISS.Permission_Level = PermissionList.Level_3_SeniorEngineer; }
                if (tex_name.Text == "mirdc" && tex_password.Text == "102691") { _SYSPermiss.PERMISS.Permission_Level = PermissionList.Level_10_Designer; }


            }
            catch (Exception x) { MessageBox.Show(x.ToString(), "systen error!!!"); }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }
    }
}
