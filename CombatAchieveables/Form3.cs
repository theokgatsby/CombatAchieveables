using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatAchieveables
{
    public partial class Form3 : Form
    {

        public Form3(string v1, string v2, string v3, string v4)
        {
            InitializeComponent();
            label5.Text = v1;
            label6.Text = v2;
            label7.Text = v3;
            richTextBox1.Text = v4;
        }
    }
}
