using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystemApp
{
    public class UserManager
    {
        //properties
        private List<BankUser> bankUsers = new List<BankUser>();
        private string BankUserFileName = "";
        public BankUser Current_BankUser { get; set; }

        private void Get_BankUsers()
        {
            //change from using csv file    
            BankUser bankUser = new BankUser();
            bankUser.user_Name = "Thom";
            bankUser.password = "1234";
            bankUser.First_Name = "Thom";
            bankUser.Last_Name = "tim";
            bankUser.Account_No = "123456";
            bankUser.Credit_Balance = 700.00;

            bankUsers.Add(bankUser);
            
        }
        //class constructor
        public UserManager()
        {
            this.Get_BankUsers();
        }
        //method to authenticate user
        public void Authenicate_User(string userName, string password)
        {
            bool IsSusccesful = false;

            foreach(BankUser bankUser in bankUsers)
            {
                if (bankUser.user_Name.ToLower() == userName.ToLower())
                {
                    
                    IsSusccesful = (bankUser.password == password);
                }

                if (IsSusccesful)
                {
                    Current_BankUser=bankUser;
                    break;
                }
            }
            // raise events to indicate successful log in or unsuccessful log in attempt
            if (IsSusccesful)
            {
                // successful log in
                OnSuccessful_Login();
            }
            else
            {
                OnUnsuccessful_Logout();
            }

        }
        //events raised
        public event EventHandler? Successful_Login;
        public event EventHandler? Unsuccessful_Login;
        public event EventHandler? BankUserFileError;
        public event EventHandler? BankUserFileReadOK;
        public event EventHandler? BankUserFileWriteOK;
        public event EventHandler? BankUserOpenFileError;

        //methods to invoke events
        public void OnSuccessful_Login()
        {
            Successful_Login?.Invoke(this, EventArgs.Empty);

        }
        public void OnUnsuccessful_Logout()
        {
            Unsuccessful_Login?.Invoke(this, EventArgs.Empty);
        }
        public void OnBankUserFileError()
        {
            BankUserFileError?.Invoke(this, EventArgs.Empty);
        }

        public void OnBankUserFileReadOK()
        {
            BankUserFileReadOK?.Invoke(this, EventArgs.Empty);
        }
        public void OnBankUserOpenFileError()
        {
            BankUserOpenFileError?.Invoke(this, EventArgs.Empty);
        }

        public void OnMobileUserFileWriteOK()
        {
            BankUserFileWriteOK?.Invoke(this, EventArgs.Empty);
        }

        //method to save the updates details to csv file
        public bool UpdateBankUsersFile()
        {
            bool isSucssessful = false;
            string fileName = BankUserFileName;
            try
            {
                // logic to write the update current user details
                using (StreamWriter fileWriter = new(fileName))
                {
                    fileWriter.WriteLine("FirstName,LastName,UserName,Password,AccountNumber,CreditBalance");

                    foreach (BankUser bankUser in bankUsers)
                    {
                        fileWriter.WriteLine($"{bankUser.First_Name},{bankUser.Last_Name}," +
                            $"{bankUser.user_Name},{bankUser.password}," +
                            $"{bankUser.Account_No},{bankUser.Credit_Balance}");
                    }
                }
                // write the header
                isSucssessful = true;
                OnMobileUserFileWriteOK();  // raise the event
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(" find "))
                {
                    //Message to show error in path or to open file
                    MessageBox.Show($"Error saving Updated information to {fileName} \n {ex.Message}", "Fatel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OnBankUserFileError();
                }
                else
                {
                    //Message to show file is open
                    MessageBox.Show($"Error saving Updated information to {fileName} \n {ex.Message}", "Fatel Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OnBankUserOpenFileError();

                }
                
            }

            return isSucssessful;
        }
        //method to get the user from the file
        public bool GetBankUsersFromFile(string fileName)
        {
            bool isSuccessful = false;
            bankUsers.Clear();
            try
            {
                string[] dataLines = File.ReadAllLines(fileName);

                // Process form Line #1 - to skip header
                for (int i = 1; i < dataLines.Length; i++)
                {
                    string[] dataFields = dataLines[i].Split(",");
                    BankUser bankUser = new BankUser();
                    bankUser.First_Name = dataFields[0];
                    bankUser.Last_Name = dataFields[1];
                    bankUser.user_Name = dataFields[2];
                    bankUser.password = dataFields[3];
                    bankUser.Account_No = dataFields[4];
                    bankUser.Credit_Balance = Convert.ToDouble(dataFields[5]);
                    bankUsers.Add(bankUser);
                }
                isSuccessful = true;
                BankUserFileName = fileName;  // keep local copy of fileName
                OnBankUserFileReadOK();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Reading {fileName} \n {ex.Message}", "Fatel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnBankUserFileError();
            }

            return isSuccessful;
        }




    }
}
