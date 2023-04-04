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
    public partial class Form2 : Form
    {
        Form1 tu;
        public Form2(Form1 formy)
        {
            InitializeComponent();
            tu = formy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Task t in Form1.TaskList) {
                if (t.GetPointWorth() == "1") {
                    t.SetStatus("2");
                }
            }

            tu.UpdateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Task t in Form1.TaskList)
            {
                if (t.GetPointWorth() == "2")
                {
                    t.SetStatus("2");
                }
            }

            tu.UpdateTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Task t in Form1.TaskList)
            {
                if (t.GetPointWorth() == "3")
                {
                    t.SetStatus("2");
                }
            }

            tu.UpdateTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Task t in Form1.TaskList)
            {
                if (t.GetPointWorth() == "4")
                {
                    t.SetStatus("2");
                }
            }

            tu.UpdateTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Task t in Form1.TaskList)
            {
                if (t.GetPointWorth() == "5")
                {
                    t.SetStatus("2");
                }
            }

            tu.UpdateTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Task t in Form1.TaskList)
            {
                if (t.GetPointWorth() == "6")
                {
                    t.SetStatus("2");
                }
            }

            tu.UpdateTable();
        }

        private void btnMegaDelete_Click(object sender, EventArgs e)
        {
            switch (btnMegaDelete.Tag)
            {
                case "1": btnMegaDelete.Text = "are you sure?"; btnMegaDelete.Tag = "2"; break;
                case "2": btnMegaDelete.Text = "like... actually?"; btnMegaDelete.Tag = "3"; break;
                case "3":
                    foreach (Task t in Form1.TaskList)
                    {
                        t.SetStatus("0");
                    }
                    tu.GenerateTable();
                    btnMegaDelete.Text = "do not push";
                    btnMegaDelete.Tag = "1";
                    break;
            }

            tu.UpdateTable();
        }
    }
}