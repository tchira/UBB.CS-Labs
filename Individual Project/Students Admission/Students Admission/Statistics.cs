using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students_Admission
{
    public partial class Statistics : Form
    {   private int[] candStats;

        public Statistics(int[] stats)
        {
            InitializeComponent();
            candStats = stats;
            
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            int yPos = 20;
            for(int i=1;i<11&&candStats[i]!=0;i++){
                Label lbl=new Label();
                lbl.Location = new Point(50, yPos);
                lbl.Width = 200;
                yPos += 30;
                lbl.Text=candStats[i]+" candidates admitted at option "+i;
                this.Controls.Add(lbl);

            }
        }
    }
}
