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
    public partial class Form2 : Form
    {
        
        SortedList<string, double> prodPrice = new SortedList<string, double>();

        public Form2()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);

        }


        private void productNameTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            txtProductName.DoDragDrop(txtProductName.Text.ToString(), DragDropEffects.Copy);
        }

        private void lstProductSelected_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstProductSelected_DragDrop(object sender, DragEventArgs e)
        {
            string name = e.Data.GetData(DataFormats.Text).ToString();
            lstProductSelected.Items.Add(name);
            if ((!prodPrice.ContainsKey(name.ToString())) && (name != ""))
            {
                if (double.TryParse(lblUnitPrice.Text, out double pprice))
                {
                    string pname = txtProductName.Text;
                    //double pprice = double.Parse(lblUnitPrice.Text);
                    prodPrice.Add(pname, pprice);
                }

            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            foreach(KeyValuePair<string,double> p in prodPrice)
            {
                f3.productPriceList.Add(p.Key,p.Value);
            }
            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstProductSelected.Items.Clear();
            prodPrice.Clear();
        }
    }
}
