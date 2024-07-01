using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystemApp
{
    public partial class FrmMain : Form
    {
        //property
        BankUser current_User = new BankUser();
        public FrmMain()
        {
            InitializeComponent();
        }

        //when form loads
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //lbl_First_Name.Text = Form1.userManager.Current_BankUser.First_Name;
            current_User = Form1.userManager.Current_BankUser;
            Display_Current_BankUser_Details();
            Listen_For_Events();
        }
        //method to display the details of current user
        private void Display_Current_BankUser_Details()
        {


            lbl_First_Name.Text = current_User.First_Name;
            lbl_Last_Name.Text = current_User.Last_Name;
            lbl_UserName.Text = current_User.user_Name;
            lbl_Password.Text = current_User.password;
            lbl_Account_No.Text = current_User.Account_No;
            lbl_Credit_Balance.Text = $"{current_User.Credit_Balance:F2}"; // formatted to two places of deciminal

            

        }

        private void Listen_For_Events()
        {
            // Subsribe to these events
            current_User.Transaction_Completed += CurrentUser_Transaction_Completed;
            current_User.Insufficient_Funds += CurrentUser_Insufficient_Funds;
            current_User.Transaction_Error += CurrentUser_Transaction_Error;
            current_User.Transaction_Limit_Amount += CurrentUser_Transaction_Limit_Amount;

            Form1.userManager.BankUserFileWriteOK += UserManager_BankUserFileWriteOK;
        }


        private void CurrentUser_Transaction_Error(object? sender, EventArgs e)
        {
            MessageBox.Show("Processing Error has occurred", "Transaction not processed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_Amount.Text = "";
        }

        private void CurrentUser_Insufficient_Funds(object? sender, EventArgs e)
        {
            MessageBox.Show("Insufficient fund to complete request", "Transaction not processed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_Amount.Text = "";
        }
        private void CurrentUser_Transaction_Limit_Amount(object? sender, EventArgs e)
        {
            MessageBox.Show("Trsanction Amount is limited to 500 \n Please enter amount less than or equal 500", "Transaction not processed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_Amount.Text = "";
        }

        private void UserManager_BankUserFileWriteOK(object? sender, EventArgs e)
        {
           
            btn_SaveToFile.Enabled = false;
        }
        private void CurrentUser_Transaction_Completed(object? sender, EventArgs e)
        {
            MessageBox.Show("Transaction request is completed successfully", "Transaction  processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_Amount.Text = "";
            Display_Current_BankUser_Details();
            btn_SaveToFile.Enabled = true;
        }

        // calls the withdrawal amount method
        private void btn_Withdrawal_Click(object sender, EventArgs e)
        {
            current_User.Withdrawal_Amount(txt_Amount.Text);
        }

        //on click calls UpdateBankUsersFile
        private void btn_SaveToFile_Click(object sender, EventArgs e)
        {
            DialogResult reply;
            reply = MessageBox.Show("Do you want to save the updated balance to file?", "Confirm Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                if (Form1.userManager.UpdateBankUsersFile())
                {
                    MessageBox.Show("Updated balance saved to file", "Request successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Updated balance not saved to file", "Not Saved ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // calls the deposit amount method
        private void btn_Deposit_Click(object sender, EventArgs e)
        {
            current_User.Deposit_Amount(txt_Amount.Text);
        }
    }
}
