using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }

        //Method for loading the form, Which also calls other methods to display values
        //when the form loads. 
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPriceDisplay();
            CreditCardType();
            CardExpiryMonths();
            CardExpiryYears();
            CardIssuingBank();        
        }

        //Declaring variables used by CalcPurchaseTotal(), IsMandatoryInputTrue() methods.
        int i_Shoes, i_Jackets, i_Gloves, i_Beanies, i_Sweaters, i_Scarfs;

        //Declaring variables used by LoadPriceDisplay(), CalcPurchaseTotal() methods
        double d_PriceShoes = (150.95);
        double d_PriceJackets = (250.50);
        double d_PriceGloves = (99.95);
        double d_PriceBeanies = (45.50);
        double d_PriceSweaters = (120.95);
        double d_PriceScarfs = (39.50);

        ////Declaring variables used by CalcPurchaseTotal(), ValueToEnableDisablePayment(),
        //SummaryDetails() methods.
        double d_TotalShoes, d_TotalJackets, d_TotalGloves, d_TotalBeanies,
               d_TotalSweaters, d_TotalScarfs, d_TotalPurchase;

        //Method for displaying product prices when form loads.
        //This Method called by, Form1_Load(object sender, EventArgs e) method      
        private void LoadPriceDisplay()
        {
            lblPriceShoes.Text = d_PriceShoes.ToString("#.00");
            lblPriceJackets.Text = d_PriceJackets.ToString("#.00");
            lblPriceGloves.Text = d_PriceGloves.ToString("#.00");
            lblPriceBeanies.Text = d_PriceBeanies.ToString("#.00");
            lblPriceSweaters.Text = d_PriceSweaters.ToString("#.00");
            lblPriceScarfs.Text = d_PriceScarfs.ToString("#.00");
        }
        
        //Event to enable product quantity textbox only if product checkbox is checked,
        //and also null any input if product checkbox is unchecked.
        private void chkProduct_TextEnabled(object sender, EventArgs e)
        {
            if (chkShoes.Checked == true) { txtQuantityShoes.Enabled = true; }
            else { txtQuantityShoes.Enabled = false; }
            if (chkShoes.Checked == false) { txtQuantityShoes.Text = null; }

            if (chkJackets.Checked == true) { txtQuantityJackets.Enabled = true; }
            else { txtQuantityJackets.Enabled = false; }
            if (chkJackets.Checked == false) { txtQuantityJackets.Text = null; }

            if (chkGloves.Checked == true) { txtQuantityGloves.Enabled = true; }
            else { txtQuantityGloves.Enabled = false; }
            if (chkGloves.Checked == false) { txtQuantityGloves.Text = null; }

            if (chkBeanies.Checked == true) { txtQuantityBeanies.Enabled = true; }
            else { txtQuantityBeanies.Enabled = false; }
            if (chkBeanies.Checked == false) { txtQuantityBeanies.Text = null; }

            if (chkSweaters.Checked == true) { txtQuantitySweaters.Enabled = true; }
            else { txtQuantitySweaters.Enabled = false; }
            if (chkSweaters.Checked == false) { txtQuantitySweaters.Text = null; }

            if (chkScarfs.Checked == true) { txtQuantityScarfs.Enabled = true; }
            else { txtQuantityScarfs.Enabled = false; }
            if (chkScarfs.Checked == false) { txtQuantityScarfs.Text = null; }
        }

        //Method that instantly displays sum of user product selections taken from CalcPurchaseTotal() method.
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            lblTotalAmount.Text = CalcPurchaseTotal().ToString("#.00");
        }

        //Method to calculate total purchase amount.
        private double CalcPurchaseTotal()
        {
            //using this block of TryParse code as a validation, so user input of product quantitys
            //will only register numbers
            int.TryParse(txtQuantityShoes.Text, out i_Shoes);
            int.TryParse(txtQuantityJackets.Text, out i_Jackets);
            int.TryParse(txtQuantityGloves.Text, out i_Gloves);
            int.TryParse(txtQuantityBeanies.Text, out i_Beanies);
            int.TryParse(txtQuantitySweaters.Text, out i_Sweaters);
            int.TryParse(txtQuantityScarfs.Text, out i_Scarfs);

            if (chkShoes.Checked) { d_TotalShoes = i_Shoes * d_PriceShoes; }
            else { d_TotalShoes = 0; } 
            
            if (chkJackets.Checked) { d_TotalJackets = i_Jackets * d_PriceJackets; }
            else { d_TotalJackets = 0; }
            
            if (chkGloves.Checked) { d_TotalGloves = i_Gloves * d_PriceGloves; }
            else { d_TotalGloves = 0; }
            
            if (chkBeanies.Checked) { d_TotalBeanies = i_Beanies * d_PriceBeanies; }
            else { d_TotalBeanies = 0; }
            
            if (chkSweaters.Checked) { d_TotalSweaters = i_Sweaters * d_PriceSweaters; }
            else { d_TotalSweaters = 0; }

            if (chkScarfs.Checked) { d_TotalScarfs = i_Scarfs * d_PriceScarfs; }
            else { d_TotalScarfs = 0; }

            d_TotalPurchase = (d_TotalShoes + d_TotalJackets + d_TotalGloves +
                d_TotalBeanies + d_TotalSweaters + d_TotalScarfs);

            return d_TotalPurchase;
        }
        
        //Event to enable credit card input fields only if credit card payment type is selected,
        //and null any input if payment type is changed
        private void rbCreditCard_grpCreditCard(object sender, EventArgs e)
        {
            if (rbCreditCard.Checked == true) { txtNameOnCard.Enabled = true; }
            else { txtNameOnCard.Enabled = false; }
            if (rbCreditCard.Checked == false) { txtNameOnCard.Text = null; }

            if (rbCreditCard.Checked == true) { cboCardType.Enabled = true; }
            else { cboCardType.Enabled = false; }
            if (rbCreditCard.Checked == false) { cboCardType.Text = null; }

            if (rbCreditCard.Checked == true) { txtCardNumber.Enabled = true; }
            else { txtCardNumber.Enabled = false; }
            if (rbCreditCard.Checked == false) { txtCardNumber.Text = null; }

            if (rbCreditCard.Checked == true) { cboExpiryMonth.Enabled = true; }
            else { cboExpiryMonth.Enabled = false; }
            if (rbCreditCard.Checked == false) { cboExpiryMonth.Text = null; }

            if (rbCreditCard.Checked == true) { cboExpiryYear.Enabled = true; }
            else { cboExpiryYear.Enabled = false; }
            if (rbCreditCard.Checked == false) { cboExpiryYear.Text = null; }

            if (rbCreditCard.Checked == true) { cboIssuingBank.Enabled = true; }
            else { cboIssuingBank.Enabled = false; }
            if (rbCreditCard.Checked == false) { cboIssuingBank.Text = null; }

            if (rbCreditCard.Checked == true) { lblName.Enabled = true; }
            else { lblName.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblType.Enabled = true; }
            else { lblType.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblNumber.Enabled = true; }
            else { lblNumber.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblExpiry.Enabled = true; }
            else { lblExpiry.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblBank.Enabled = true; }
            else { lblBank.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblS1.Enabled = true; }
            else { lblS1.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblS2.Enabled = true; }
            else { lblS2.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblS3.Enabled = true; }
            else { lblS3.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblS4.Enabled = true; }
            else { lblS4.Enabled = false; }
            if (rbCreditCard.Checked == true) { lblS5.Enabled = true; }
            else { lblS5.Enabled = false; }
        }

        //Method For enabling/disabling credit card and cash Payment type options,
        //depending on the total purchase amount
        private void ValueToEnableDisablePayment(object sender, EventArgs e)
        {
            if (d_TotalPurchase <= 1500.00) { rbCash.Enabled = true; }
            else { rbCash.Enabled = false; }

            if (d_TotalPurchase < 50.00) { rbCreditCard.Enabled = false; }
            else { rbCreditCard.Enabled = true; }        }

        //Method to declare array variables and values of credit card types.
        private void CreditCardType()
        {
            string[] as_CardType = { "", "Visa", "MasterCard", "Diners Club", "American Express" };

            this.cboCardType.DropDownStyle = ComboBoxStyle.DropDownList;

            cboCardType.DataSource = as_CardType;
        }

        //Method to declare array variables and values of credit card expiry months.
        private void CardExpiryMonths()
        {
            string[] as_ExpiryMonths = { "", "January", "Febuary", "March", "April", "May", "June",
                                        "July", "August", "September", "October", "November", "December" };

            this.cboExpiryMonth.DropDownStyle = ComboBoxStyle.DropDownList;

            cboExpiryMonth.DataSource = as_ExpiryMonths;
        }

        //Method to declare variables and values for credit card expiry years.
        private void CardExpiryYears()
        {
            int year = DateTime.Now.Year;
            for (int i = year; i <= year + 10; i++)
            {
                cboExpiryYear.Items.Add(i.ToString());
            }

            this.cboExpiryYear.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Method to declare Array variables and values for issuing bank.
        private void CardIssuingBank()
        {
            string[] as_IssuingBank = { "", "New Zealand", "Overseas" };

            this.cboIssuingBank.DropDownStyle = ComboBoxStyle.DropDownList;

            cboIssuingBank.DataSource = as_IssuingBank;
        }

        //Method for declaring customer detail inputs as string types, 
        public void getCustomerDetails()
        {
            string s_FirstName, s_LastName, s_Address, s_Suburb, s_City, s_Country;

            s_FirstName = txtFirstName.ToString();
            s_LastName = txtLastName.ToString();
            s_Address = txtAddress.ToString();
            s_Suburb = txtSuburb.ToString();
            s_City = txtCity.ToString();
            s_Country = txtCountry.ToString();
        }
        
        //Method for checking all Mandatory user input has been entered, and user input error checks.
        //returns true if all mandatory input is entered.
        private Boolean IsMandatoryInputTrue()
        {
            StringBuilder s_Message = new StringBuilder();

            if (txtFirstName.TextLength < 1) { s_Message.Append("First name must be entered!\n"); }

            if (txtLastName.TextLength < 1) { s_Message.Append("Last name must be entered!\n"); }

            if (chkShoes.Checked == false && chkJackets.Checked == false &&
                chkGloves.Checked == false && chkBeanies.Checked == false &&
                chkSweaters.Checked == false && chkScarfs.Checked == false)
            { s_Message.Append("At least 1 product must be entered!\n"); }

            if (chkShoes.Checked && txtQuantityShoes.TextLength < 1 || 
                chkJackets.Checked && txtQuantityJackets.TextLength < 1 ||
                chkGloves.Checked && txtQuantityGloves.TextLength < 1 || 
                chkBeanies.Checked && txtQuantityBeanies.TextLength < 1 ||
                chkSweaters.Checked && txtQuantitySweaters.TextLength < 1 || 
                chkScarfs.Checked && txtQuantityScarfs.TextLength < 1)
            { s_Message.Append("Quantity for selected products must be entered!\n"); }

            if (txtQuantityShoes.Enabled && !int.TryParse(txtQuantityShoes.Text, out i_Shoes) ||
                txtQuantityJackets.Enabled && !int.TryParse(txtQuantityJackets.Text, out i_Jackets) ||
                txtQuantityGloves.Enabled && !int.TryParse(txtQuantityGloves.Text, out i_Gloves) ||
                txtQuantityBeanies.Enabled && !int.TryParse(txtQuantityBeanies.Text, out i_Beanies) ||
                txtQuantitySweaters.Enabled && !int.TryParse(txtQuantitySweaters.Text, out i_Sweaters) ||
                txtQuantityScarfs.Enabled && !int.TryParse(txtQuantityScarfs.Text, out i_Scarfs))
            { s_Message.Append("Product Quantity can only contain whole numbers!\n"); }
           
            if (txtNameOnCard.Enabled == true && txtNameOnCard.TextLength < 1)
            { s_Message.Append("Name on card must be entered!\n"); }

            if (cboCardType.Enabled == true && cboCardType.SelectedIndex < 1)
            { s_Message.Append("Credit card type must be selected!\n"); }

            double d_CardNumber;
            if (txtCardNumber.Enabled && txtCardNumber.TextLength < 1) 
            { s_Message.Append("Credit card number must be entered!\n"); }
            if (txtCardNumber.Enabled && !double.TryParse(txtCardNumber.Text, out d_CardNumber))
            { s_Message.Append("Credit card number can only contain numbers!\n"); }
           
            if (cboExpiryMonth.Enabled == true && cboExpiryMonth.SelectedIndex < 1)
            { s_Message.Append("Credit card expiry month must be selected!\n"); }

            if (cboExpiryYear.Enabled == true && cboExpiryYear.SelectedIndex < 1)
            { s_Message.Append("Credit card expiry year must be selected!\n"); }

            if (cboIssuingBank.Enabled == true && cboIssuingBank.SelectedIndex < 1)
            { s_Message.Append("Credit card issuing bank must be selected!\n"); }

            if (rbCash.Checked == false && rbCreditCard.Checked == false && rbBankTransfer.Checked == false)
            { s_Message.Append("A payment type must be selected!\n"); }

            if (s_Message.Length > 0)
            {
                MessageBox.Show(s_Message.ToString(), "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    
        //Method to display all input information when summary button clicked.
        private void SummaryDetails()
        {
            StringBuilder s_Summary = new StringBuilder();

            s_Summary.Append("CUSTOMER DETAILS");
            s_Summary.Append("\nFirst name: \t\t" + txtFirstName.Text);
            s_Summary.Append("\nLast name: \t\t" + txtLastName.Text);
            if (txtAddress.TextLength > 0)
            { s_Summary.Append("\nAddress: \t\t\t" + txtAddress.Text); }

            if (txtSuburb.TextLength > 0)
            { s_Summary.Append("\nSuburb: \t\t\t" + txtSuburb.Text); }

            if (txtCity.TextLength > 0)
            { s_Summary.Append("\nCity: \t\t\t" + txtCity.Text); }

            if (txtCountry.TextLength > 0)
            { s_Summary.Append("\nCountry: \t\t\t" + txtCountry.Text); }
           
            s_Summary.Append("\n\nPURCHASE DETAILS");

            if (chkShoes.Checked == true)
            { s_Summary.Append("\nPairs of Shoes: \t\t" + txtQuantityShoes.Text); }
            if (chkShoes.Checked == true)
            { s_Summary.Append("\nShoes Total: \t\t$" + d_TotalShoes.ToString("#.00")); }

            if (chkJackets.Checked == true)
            { s_Summary.Append("\nNumber of Jackets: \t\t" + txtQuantityJackets.Text); }
            if (chkJackets.Checked == true)
            { s_Summary.Append("\nJacket Total: \t\t$" + d_TotalJackets.ToString("#.00")); }

            if (chkGloves.Checked == true)
            { s_Summary.Append("\nPairs of Gloves: \t\t" + txtQuantityGloves.Text); }
            if (chkGloves.Checked == true)
            { s_Summary.Append("\nGloves Total: \t\t$" + d_TotalGloves.ToString("#.00")); }

            if (chkBeanies.Checked == true)
            { s_Summary.Append("\nNumber of beanies: \t\t" + txtQuantityBeanies.Text); }
            if (chkBeanies.Checked == true)
            { s_Summary.Append("\nBeanies Total: \t\t$" + d_TotalBeanies.ToString("#.00")); }

            if (chkSweaters.Checked == true)
            { s_Summary.Append("\nNumber of sweaters:\t\t" + txtQuantitySweaters.Text); }
            if (chkSweaters.Checked == true)
            { s_Summary.Append("\nSweaters Total: \t\t$" + d_TotalSweaters.ToString("#.00")); }

            if (chkScarfs.Checked == true)
            { s_Summary.Append("\nNumber of scarfs: \t\t" + txtQuantityScarfs.Text); }
            if (chkScarfs.Checked == true)
            { s_Summary.Append("\nScarves Total \t\t$" + d_TotalScarfs.ToString("#.00")); }

             s_Summary.Append("\n\nTOTAL COST: \t\t$" + d_TotalPurchase.ToString("#.00"));

            s_Summary.Append("\n\nPAYMENT TYPE");

            if (rbCash.Checked == true) { s_Summary.Append("\nPayment: \t\t\t Cash"); }
            if (rbCreditCard.Checked == true) { s_Summary.Append("\nPayment: \t\t\t Credit card"); }
            if (rbBankTransfer.Checked == true) { s_Summary.Append("\nPayment: \t\t\t Bank transfer"); }

            if (rbCreditCard.Checked == true)
            { s_Summary.Append("\n\nCREDIT CARD DETAILS"); }

            if (txtNameOnCard.Enabled == true)
            { s_Summary.Append("\nName On Card: \t\t" + txtNameOnCard.Text); }

            if (cboCardType.Enabled == true)
            { s_Summary.Append("\nCard Type: \t\t" + cboCardType.SelectedValue); }

            if (txtCardNumber.Enabled == true)
            { s_Summary.Append("\nCard Number: \t\t" + txtCardNumber.Text); }

            if (cboExpiryMonth.Enabled == true)
            { s_Summary.Append("\nExpiry Month: \t\t" + cboExpiryMonth.SelectedValue); }

            if (cboExpiryYear.Enabled == true)
            { s_Summary.Append("\nExpiry Year: \t\t" + cboExpiryYear.SelectedItem); }

            if (cboIssuingBank.Enabled == true)
            { s_Summary.Append("\nIssuing Bank: \t\t" + cboIssuingBank.SelectedValue); }
          
            MessageBox.Show(s_Summary.ToString(), "Summary of Purchases", 
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
       
        //Method for the summary button click
        private void btnShowSummary_Click(object sender, EventArgs e)
        {
            if (IsMandatoryInputTrue()) { SummaryDetails(); }
        }
        
        //Method to reset form when rest button is clicked.
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control Reset in grpCustomer.Controls)
            {
                if (Reset is TextBox)
                {
                    TextBox txtBox = (TextBox)Reset;
                    txtBox.Text = null;
                }
            }

            foreach (Control Reset in grpProduct.Controls)
            {
                if (Reset is TextBox)
                {
                    TextBox txtBox = (TextBox)Reset;
                    txtBox.Text = null;
                }

                if (Reset is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)Reset;
                    checkBox.Checked = false;
                }
            }

            foreach (Control Reset in grpCreditCard.Controls)
            {
                if (Reset is TextBox)
                {
                    TextBox txtBox = (TextBox)Reset;
                    txtBox.Text = null;
                }

                if (Reset is ComboBox)
                {
                    ComboBox cboBox = (ComboBox)Reset;
                    cboBox.SelectedItem = null;
                }
            }

            foreach (Control Reset in grpPayment.Controls)
            {
                if (Reset is RadioButton)
                {
                    RadioButton rbButton = (RadioButton)Reset;
                    rbButton.Checked = false;
                }

                if (Reset is ComboBox)
                {
                    ComboBox cboBox = (ComboBox)Reset;
                    cboBox.SelectedItem = null;
                }
            }
        }

    }
}
