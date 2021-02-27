using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass10
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Order_Details' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.Search(this.northwindDataSet.Customers, countryToolStripTextBox.Text, last_two_dogits_of_phoneToolStripTextBox.Text);
                if(last_two_dogits_of_phoneToolStripTextBox.Text.Length < 2)
                {
                    MessageBox.Show("Enter last Two digits of the phone Number. It should be Exactly 2 digits");
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
