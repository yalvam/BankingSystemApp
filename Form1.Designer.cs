namespace BankingSystemApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Login = new Button();
            txt_Username = new TextBox();
            txt_Password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.White;
            btn_Login.Enabled = false;
            btn_Login.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Login.Location = new Point(127, 405);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(100, 33);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "&Log In";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(199, 337);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(100, 23);
            txt_Username.TabIndex = 1;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(199, 366);
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '*';
            txt_Password.Size = new Size(100, 23);
            txt_Password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(69, 337);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(69, 366);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            BackgroundImage = Properties.Resources.Bank_new;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(384, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_Password);
            Controls.Add(txt_Username);
            Controls.Add(btn_Login);
            Name = "Form1";
            Text = "Banking System Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private TextBox txt_Username;
        private TextBox txt_Password;
        private Label label1;
        private Label label2;
    }
}