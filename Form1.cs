namespace BankingSystemApp
{
    public partial class Form1 : Form
    {
        //properties
        public static UserManager userManager = new UserManager();
        const string BankUsersFile = @"C:\Users\Yashashwini\Desktop\BankUsers.csv";

        public Form1()
        {
            InitializeComponent();
        }
        //calls the Authenicate_User method
        private void btn_Login_Click(object sender, EventArgs e)
        {
            userManager.Authenicate_User(txt_Username.Text, txt_Password.Text);
        }
        private void UserManager_Successful_Login(object sender, EventArgs e)
        {
            // method ro intiate the frmMain on successful login ;

            MessageBox.Show("Successful Login", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmMain frmMain = new FrmMain();
            frmMain.Show();

        }
        //when form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            userManager.Successful_Login += UserManager_Successful_Login;
            userManager.Unsuccessful_Login += UserManager_Unsuccessful_Login;
            userManager.BankUserFileReadOK += UserManager_BankUserFileReadOK;
            userManager.BankUserFileError += UserManager_BankUserFileError;
            userManager.BankUserOpenFileError += UserManager_BankUserOpenFileError;
            userManager.GetBankUsersFromFile(BankUsersFile);
        }
        private void UserManager_Unsuccessful_Login(object sender, EventArgs e)
        {
            // Message box to display the success;
            MessageBox.Show("Login Failed. Please try again with correct username and password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void UserManager_BankUserFileError(object? sender, EventArgs e)
        {
            // Message box to display the error
            MessageBox.Show("Bank User file error.Check logs for more deatils.\nApplication will end", "File warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
        private void UserManager_BankUserOpenFileError(object? sender, EventArgs e)
        {
            //Message to close the file
            MessageBox.Show("Bank User file is Open.\n Please close the CSV file to continue saving details", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void UserManager_BankUserFileReadOK(object? sender, EventArgs e)
        {
            // the file has been successfully read and we can authenicate users
            btn_Login.Enabled = true;

        }
    }
}