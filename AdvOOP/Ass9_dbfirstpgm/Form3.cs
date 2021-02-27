using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass9
{
    public partial class Form3 : Form
    {
        public SortedList<string, double> productPriceList = new SortedList<string, double>();
        double totalPrice = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach(KeyValuePair<string,double> p in productPriceList)
            {
                totalPrice += p.Value;
                string price = p.Value.ToString("c");
                string listItem = p.Key + " (" + price + ")";
                lstProductSelected.Items.Add(listItem);
                lblTotalPrice.Text = totalPrice.ToString("c");
            }
        }
    }
}
