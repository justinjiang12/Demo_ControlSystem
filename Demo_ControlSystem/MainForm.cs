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

namespace Demo_ControlSystem
{
    public partial class MainForm : Form
    {
        private System_Control SYSCONTROL = new System_Control();

        public MainForm()
        {
            InitializeComponent();
        }

    }
}
