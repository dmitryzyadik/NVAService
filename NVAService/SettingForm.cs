using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NVAService
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            this.label5.Text = Program.getHostName();
            this.Location = new Point(Screen.GetWorkingArea(this).Right - this.Width, Screen.GetWorkingArea(this).Bottom - this.Height);

            Setting s = SettingHelper.LoadSetting(label5.Text);

            FIOtextBox.Text = s.FIO;
            TitleTextBox.Text = s.TITLE;
            ORGtextBox.Text = s.ORG;
            PhoneTextBox.Text = s.PHONE;
            
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingHelper.SaveSetting(label5.Text, FIOtextBox.Text.Trim(), TitleTextBox.Text.Trim(), ORGtextBox.Text.Trim(), PhoneTextBox.Text.Trim());
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
