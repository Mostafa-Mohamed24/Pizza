using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pizza
{
    public partial class Order : Form
    {

        public Order()
        {
            InitializeComponent();
        }

        float GetSelecedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);

            else if (rbMeduim.Checked)
                return Convert.ToSingle(rbMeduim.Tag);

            else 
                return Convert.ToSingle(rbLarge.Tag);

        }
        float GetToppingPrice()
        {
            float ToppingPrice = 0;

            if (chkChees.Checked)
                ToppingPrice += Convert.ToSingle(chkChees.Tag);

            if (chkGreenPeppers.Checked)
                ToppingPrice += Convert.ToSingle(chkGreenPeppers.Tag);

            if (chkMushrooms.Checked)
                ToppingPrice += Convert.ToSingle(chkMushrooms.Tag);

            if (chkOlives.Checked)
                ToppingPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkOnion.Checked)
                ToppingPrice += Convert.ToSingle(chkOnion.Tag);

            if (chkTomatoes.Checked)
                ToppingPrice += Convert.ToSingle(chkTomatoes.Tag);

            return ToppingPrice;
        }

        float GetSelectedCrustTypePrice()
        {
            if (rbThinkCrust.Checked)
                return Convert.ToSingle(rbThinkCrust.Tag);
            else
                return Convert.ToSingle(rbThinCrust.Tag);

        }

        float ClaculateTotalPrice()
        {
            return GetSelecedSizePrice() + GetSelectedCrustTypePrice() + GetToppingPrice();
        }

        void UpdateTotalPrice()
        {
            lbPrice.Text = "$" +  ClaculateTotalPrice().ToString();
        }
        string UpdateSize ()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
                return "Small";


            else if(rbMeduim.Checked)
                return "Meduim";


            else 
                return "Large";

        }

        string UpdateCrust ()
        {
            UpdateTotalPrice();

            if(rbThinCrust.Checked)
                return "Thin Crust";


            else
                return "Think Crust";

        }

        string UpdateWhereToEatLabel ()
        {
            if(rbEatIn.Checked)
                return "Eat In ";

            else 
                return "Take Out";

        }

        string UpdateTopping()
        {
            UpdateTotalPrice();

            string sTopping = "";

            if (chkChees.Checked)
                sTopping +=   ", Chees";

            if (chkGreenPeppers.Checked)
                sTopping += ", Green Peppers";

            if (chkMushrooms.Checked)
                sTopping += ", Mushrooms";

            if (chkOlives.Checked)
                sTopping += ", Olives";

            if (chkOnion.Checked)
                sTopping += ", Onion";

            if (chkTomatoes.Checked)
                sTopping += ", Tomatoes";

            if(sTopping.StartsWith(","))
            {
                sTopping = sTopping.Substring(1, sTopping.Length - 1).Trim();
            }

            if (string.IsNullOrEmpty(sTopping))
                return "No Toppings.";
            else 
                return sTopping;

        }

        void Reset ()
        {
            rbSmall.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;

            chkChees.Checked = false;
            chkGreenPeppers.Checked = false;
            chkOlives.Checked = false;
            chkMushrooms.Checked = false;
            chkOnion.Checked = false;
            chkTomatoes.Checked = false;
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = UpdateSize();
        }
        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text =  UpdateCrust();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text = UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = UpdateWhereToEatLabel();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = UpdateWhereToEatLabel();
        }
        
        
        private void chkChees_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = UpdateTopping();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = UpdateTopping();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = UpdateTopping();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = UpdateTopping();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = UpdateTopping();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = UpdateTopping();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            Form fm = new Checkout(UpdateSize(),UpdateTopping(),UpdateCrust(),UpdateWhereToEatLabel(),ClaculateTotalPrice());

            fm.ShowDialog();
            Reset();
            //this.Close();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            rbSmall.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;
            lbToppings.Text = UpdateTopping();
        }
    }
}
