using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pizza
{
    public partial class Checkout : Form
    {


        public Checkout(String PizzaSize , string PizzaTopping,string PizzaCrustType , string WhereToEat , float Price)
        {
            InitializeComponent();

            lbChSize.Text = PizzaSize ;
            lbChTopping.Text = PizzaTopping;
            lbChCrust.Text = PizzaCrustType ;
            lbChWhereToEat.Text = WhereToEat ;
            lbChPrice.Text = "$" + Price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            
            var Result = MessageBox.Show("Are You Sure ? ","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (Result.ToString() == "OK")
            {
                var msgResult = MessageBox.Show("Order Placed Succcessfuly" ,"Done",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                if (msgResult.ToString() == "OK")
                {
                    this.Close();
                }
            }
        }

    }
}
