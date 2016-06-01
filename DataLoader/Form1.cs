using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Entities;

namespace DataLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VList<VwLeadGet> vlgs = DataRepository.VwLeadGetProvider.GetAll();
        }
    }
}
