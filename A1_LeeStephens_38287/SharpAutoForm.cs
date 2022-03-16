/*
 * Car Dealership (Assignment 2)
 * Lee Stephens
 * 1138287
 * 04/01/2021
 * This program calculates the amount due for a new or used car, and will take into account the extra features wanted as well as trade in credit received
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A1_LeeStephens_38287
{
    public partial class SharpAutoForm : Form
    {
        public SharpAutoForm()
        {
            InitializeComponent();
        }
        //Global Variable
        double additionalFeatureCost = 0;


        /*
         * Functions
         */
        // Validates to make sure user input is correct
        private Boolean IsValid()
        {
            if (String.IsNullOrEmpty(txtBasePrice.Text))
            {
                string msgBoxTitle = "Warning: Text Field 'Base Price' left empty";
                string msgBoxMessage = "You must input a value for the base price of the car you want to buy";
                MessageBox.Show(msgBoxMessage, msgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Event Handlers
         */

        //Allowing the user to change the color of the text for base price and amount due
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = txtBasePrice.ForeColor;
            colorDialog.Color = txtAmountDue.ForeColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtBasePrice.ForeColor = colorDialog.Color;
                txtAmountDue.ForeColor = colorDialog.Color;
            }
        }

        //Allows the user to select the font they want to use for Base Price and amount due
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowHelp = true;
            fontDialog.Font = txtBasePrice.Font;
            fontDialog.Font = txtAmountDue.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txtBasePrice.Font = fontDialog.Font;
                txtAmountDue.Font = fontDialog.Font;
            }
        }

        //Message box comes up with project description when "about" button is hit
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msgBoxTitle = "Program Functionality";
            string msgBoxMessage = "This program calculates the amount due for a new or used car, and will take into account the extra features wanted as well as trade in credit received";
            MessageBox.Show(msgBoxMessage, msgBoxTitle);
        }

        // when the boc is checked or unchecked
        private void chkStereoSystem_CheckedChanged(object sender, EventArgs e)
        {
            //when its checked add 425.76 to the variable that holds the cost of all the features
            if (chkStereoSystem.Checked)
            {
                additionalFeatureCost += 425.76;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            } // if the box is unchecked it removes the amount from the variable to holds the total amount
            else
            {
                additionalFeatureCost -= 425.76;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }
        }

        // when the boc is checked or unchecked
        private void chkLeatherInterior_CheckedChanged(object sender, EventArgs e)
        {
            //when its checked add 425.76 to the variable that holds the cost of all the features
            if (chkLeatherInterior.Checked)
            {
                additionalFeatureCost += 987.41;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }// if the box is unchecked it removes the amount from the variable to holds the total amount
            else
            {
                additionalFeatureCost -= 987.41;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }
        }

        // when the boc is checked or unchecked
        private void chkComputerNavigation_CheckedChanged(object sender, EventArgs e)
        {
            //when its checked add 425.76 to the variable that holds the cost of all the features
            if (chkComputerNavigation.Checked) 
            {
                additionalFeatureCost += 1741.23;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }// if the box is unchecked it removes the amount from the variable to holds the total amount
            else
            {
                additionalFeatureCost -= 1741.23;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }
        }

        //If the radio button is checked or unchecked
        private void rdoStandard_CheckedChanged(object sender, EventArgs e)
        {
            // if its checked set the other radio buttons to false
            if (rdoStandard.Checked)
            {
                rdoPearlized.Checked = false;
                rdoCustomizedDetailing.Checked = false;
            }

        }

        //If the radio button is checked or unchecked
        private void rdoPearlized_CheckedChanged(object sender, EventArgs e)
        {
            // if its checked set the other radio buttons to false and set the total of the additinoal features to add 345.72
            if (rdoPearlized.Checked)
            {
                rdoStandard.Checked = false;
                rdoCustomizedDetailing.Checked = false;
                additionalFeatureCost += 345.72;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            } // if its unchecked remove the amount from the additional feature total
            else
            { 
                additionalFeatureCost -= 345.72;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }
        }

        //If the radio button is checked or unchecked
        private void rdoCustomizedDetailing_CheckedChanged(object sender, EventArgs e)
        {
            // if its checked set the other radio buttons to false and set the total of the additinoal features to add 599.99
            if (rdoCustomizedDetailing.Checked)
            {
                rdoStandard.Checked = false;
                rdoPearlized.Checked = false;
                additionalFeatureCost += 599.99;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            } // if its unchecked remove the amount from the additional feature total
            else
            {
                additionalFeatureCost -= 599.99;
                txtAdditionalOptions.Text = additionalFeatureCost.ToString();
            }
        }

        // When the calculate button is clicked it adds up all the totals and outputs them
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                double basePrice = double.Parse(txtBasePrice.Text);
                double tradeIn = double.Parse(txtTradeInAllowance.Text);
                double subtotal = basePrice + additionalFeatureCost;
                double salesTax = subtotal * 0.13;
                double total = subtotal * 1.13;
                double amountDue = total - tradeIn;

                txtSubtotal.Text = subtotal.ToString();
                txtSalesTax.Text = salesTax.ToString();
                txtTotal.Text = total.ToString();
                txtAmountDue.Text = amountDue.ToString();
            }
        }


        // when the btnClear is hit it sets everything back to default including radio buttons and check boxes
        private void btnClear_Click(object sender, EventArgs e)
        {

            txtBasePrice.Text = "";
            txtTradeInAllowance.Text = "0";
            txtTotal.Text = "";
            txtSubtotal.Text = "";
            txtAmountDue.Text = "";
            txtSalesTax.Text = "";
            rdoCustomizedDetailing.Checked = false;
            rdoPearlized.Checked = false;
            rdoStandard.Checked = true;
            chkComputerNavigation.Checked = false;
            chkLeatherInterior.Checked = false;
            chkStereoSystem.Checked = false;
            additionalFeatureCost = 0;
            txtAdditionalOptions.Text = "";
        }


        //Close program
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
