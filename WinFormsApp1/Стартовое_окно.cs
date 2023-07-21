using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AssemblyPrice
{
    public partial class Стартовое_окно : Form
    {
        public Стартовое_окно()
        {
            InitializeComponent();
        }
        private void DB_CreateUpdDel_Click(object sender, EventArgs e)
        {
            DB_CreateUpdDel db = new ();
            db.ShowDialog();
        }
        private void CalculatePrice_Click(object sender, EventArgs e)
        {
            CalculatePrice calculatePrice = new ();
            calculatePrice.ShowDialog();
        }
    }
}