using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator_Project
{
    public partial class Form1 : Form
    {

        private Random RandomNumber = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        private bool IsCheckBoxesChecked()
        {
            return (chkLowercase.Checked || chkUppercase.Checked || chkSymbols.Checked || chkNumber.Checked);
        }
        private bool IsTextBoxkEmpty()
        {
            return string.IsNullOrEmpty(txtGeneratedPassword.Text);
        }
        private char GetRandomUpperCaseLttr()
        {
            return Convert.ToChar(RandomNumber.Next(65, 90));
        }
        private char GetRandomLowerCaseLttr()
        {
            return Convert.ToChar(RandomNumber.Next(97, 122));
        }
        private char GetRandomNumbers()
        {
            return Convert.ToChar(RandomNumber.Next(48, 57));
        }
        private char GetRandomSymbols()
        {
            return Convert.ToChar(RandomNumber.Next(33, 47));
        }

        private char GetRandomChar()
        {
            System.Text.StringBuilder Pool = new System.Text.StringBuilder();

            if (chkUppercase.Checked) Pool.Append(GetRandomUpperCaseLttr());
            if (chkLowercase.Checked) Pool.Append(GetRandomLowerCaseLttr());
            if (chkNumber.Checked) Pool.Append(GetRandomNumbers());
            if (chkSymbols.Checked) Pool.Append(GetRandomSymbols());

            return Pool[RandomNumber.Next(Pool.Length)];
        }

        private string GenerateWord()
        {
            string Password = "";

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                Password += GetRandomChar();
            }

            return Password;
        }

        private string GeneratePassword()
        {
            return GenerateWord();
            txtGeneratedPassword.Text = "Mohamed will do it ,don't worry :)";

        }
        private string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rbPassword.Checked = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void IcreaseProgressBar()
        {
            int ProgressBarValue = 0;

            if(rbGUID.Checked)
            {
                ProgressBarValue = 100;
                progressBar1.Value = ProgressBarValue;
                return;
            }

            if (chkUppercase.Checked) ProgressBarValue += 25;
            if (chkLowercase.Checked) ProgressBarValue += 25;
            if (chkNumber.Checked) ProgressBarValue += 25;
            if (chkSymbols.Checked) ProgressBarValue += 25;

            progressBar1.Value = ProgressBarValue;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!IsCheckBoxesChecked() && !rbGUID.Checked)
            {
                MessageBox.Show("Please select at least one character type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsCheckBoxesChecked()|| rbGUID.Checked)
            {
                if (rbPassword.Checked)
                {
                    txtGeneratedPassword.Text = GeneratePassword();
                    IcreaseProgressBar();

                }

                if (rbGUID.Checked)
                {
                    txtGeneratedPassword.Text = GenerateGUID();
                    IcreaseProgressBar();
                }
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxkEmpty())
            {
                txtGeneratedPassword.SelectAll();
                txtGeneratedPassword.Copy();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxkEmpty())
            {
                txtGeneratedPassword.Text = "";
                progressBar1.Value = 0;
            }

        }

        private void txtGeneratedPassword_TextChanged(object sender, EventArgs e)
        {
        }

    }
}