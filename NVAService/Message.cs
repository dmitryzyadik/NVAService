using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NVAService
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();

            this.label1.Text = Program.getHostName();
            this.Location = new Point(Screen.GetWorkingArea(this).Right - this.Width, Screen.GetWorkingArea(this).Bottom - this.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageHelper.SendMessage(label1.Text, richTextBox1.Text,DateTime.Now);
            richTextBox1.Clear();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.HostMessage' table. You can move, or remove it, as needed.
            this.hostMessageTableAdapter.Fill(this.dataSet1.HostMessage, label1.Text);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.hostMessageTableAdapter.Fill(this.dataSet1.HostMessage, label1.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.hostMessageTableAdapter.FillBy(this.dataSet1.HostMessage, label1.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
