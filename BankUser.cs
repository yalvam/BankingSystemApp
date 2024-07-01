using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystemApp
{
    public class BankUser
    {
        //properties of an bank user
        public string user_Name { get; set; } 
       
        public string password { get; set;}

        public string First_Name { get; set; }
        public string Last_Name { get; set;} 

        public double Credit_Balance { get; set; }
        public string Account_No { get; set; }

        //method for withdrawal amount
        public bool Withdrawal_Amount(string amountEntered)
        {
            bool isSuccessful = false;
            try
            { 
                double amount = Convert.ToDouble(amountEntered);

                // are there sufficent funds for this deduction
                if (this.Credit_Balance >= amount)
                {
                    if (amount > 500)
                    {
                        //limit transaction- more than 500
                        OnLimitAmountTransaction();

                    }
                    else
                    {
                        // proceed with deduction
                        this.Credit_Balance -= amount;
                        isSuccessful = true;
                        OnTransactionCompleted();
                    }
                    
                }
                else
                {
                    // insufficent funds
                    OnInsufficientFunds();  
                }
            }
            catch
            {
                //When error occurs
                OnTransactionError();
            }

            return isSuccessful;
        }
        //method for adding amount
        public bool Deposit_Amount(string amountEntered)
        {
            bool isSuccessful = false;
            try
            {
                double amount = Convert.ToDouble(amountEntered);

               
                if (amount > 500)
                {
                    //limit transaction- more than 500
                    OnLimitAmountTransaction();
                }
                else
                {
                    this.Credit_Balance += amount;
                    isSuccessful = true;
                    OnTransactionCompleted();   
                }
            }
            catch
            {
                // when error Occurrs
                OnTransactionError();
            }

            return isSuccessful;
        }


        //Event that will be raised 
        public event EventHandler Insufficient_Funds; 
        public event EventHandler Transaction_Error; 
        public event EventHandler Transaction_Completed;
        public event EventHandler Transaction_Limit_Amount;

        //methods to invoke events
        public void OnInsufficientFunds()
        {
            Insufficient_Funds?.Invoke(this, EventArgs.Empty);
        }

        public void OnTransactionError()
        {
            Transaction_Error?.Invoke(this, EventArgs.Empty);
        }

        public void OnLimitAmountTransaction()
        {
            Transaction_Limit_Amount?.Invoke(this, EventArgs.Empty);
        }

        public void OnTransactionCompleted()
        {
            Transaction_Completed?.Invoke(this, EventArgs.Empty);
        }

    }
}
