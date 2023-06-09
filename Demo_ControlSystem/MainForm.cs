﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo_ControlSystem.MainSystem;

namespace Demo_ControlSystem
{
    public partial class MainForm : Form
    {
        internal System_Control SYSCONTROL = new System_Control();


        public MainForm()
        {
            MianForm_Initial();
            InitializeComponent();
        }

        private void MianForm_Initial()
        {
            SYSCONTROL.SYSOnSysLevelChanging += changeLevel;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }


        #region 控制物件管理
        /// <summary>
        /// 按鈕管理巨集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = (string)btn.Tag;
            try
            {

                switch (tag)
                {




                    case "btn_LoginPage":

                        showLoginForm();

                        break;

                    

                    case "btn_Other":

                       
                        break;


                }
            }
            catch (Exception x) { MessageBox.Show(x.ToString(), "systen error!!!"); }
        }
        #endregion


        private void changeLevel(string _state)
        {
            //label1.Text ="Level: "+ SYSCONTROL.LevelState;
            label1.Text = "Level: " + _state;
        }


        private void showLoginForm()
        {
            using (var form = new Forms.LoginForm())
            {
                form.SYSCONTROL = SYSCONTROL;
                form.ShowDialog();
            }
           
        }

    }
}
