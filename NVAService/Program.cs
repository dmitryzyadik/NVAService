using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace NVAService
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NotifyIcon notifyIcon1 = new NotifyIcon();
            ContextMenu contextMenu1 = new ContextMenu();
            CustomMenuItem menuItem1 = new CustomMenuItem();
            CustomMenuItem menuItem2 = new CustomMenuItem();
            CustomMenuItem menuItem3 = new CustomMenuItem();
            CustomMenuItem menuItem4 = new CustomMenuItem();
            CustomMenuItem menuItem5 = new CustomMenuItem();
            CustomMenuItem menuItem6 = new CustomMenuItem("User: "+System.Security.Principal.WindowsIdentity.GetCurrent().Name);
          //  CustomMenuItem menuItem7 = new CustomMenuItem("Отправить сообщение");






            contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1, menuItem2, menuItem3, menuItem4, menuItem5, menuItem6/*, menuItem7*/ });
            
            // menuItem1.Click += new EventHandler(menuItem1_Click);

            menuItem2.Index = 0;
            menuItem2.Text = "Ваш IP адрес: "+Program.getLocalIPAddress() ;
            menuItem2.Enabled = false;
            menuItem2.Click += MenuItem2_Click;

            menuItem1.Index = 1;
            menuItem1.Text = "Хост: " + Program.getHostName();
            menuItem1.Font = new Font(new FontFamily("Verdana"), 11);
            menuItem1.Enabled = false;

            menuItem3.Index = 2;
            menuItem3.Text = "Тех. помощь: тел. 70-97";
            menuItem3.Font = new Font(new FontFamily("Verdana"), 9);
            
            menuItem3.Enabled = false;

            menuItem4.Index = 3;
            menuItem4.Text = "Сведения";
            menuItem4.Font = new Font(new FontFamily("Verdana"), 9);
            menuItem4.Click += MenuItem4_Click;

            menuItem5.Index = 4;
            menuItem5.Text = "Показать IP";
            menuItem5.Font = new Font(new FontFamily("Verdana"), 9);
            menuItem5.Click += MenuItem5_Click;

            menuItem6.Index = 5;            
            menuItem6.Font = new Font(new FontFamily("Verdana"), 9);

            //menuItem7.Index = 6;
            //menuItem7.Font = new Font(new FontFamily("Verdana"), 9);
            //menuItem7.Click += MenuItem7_Click;


            //notifyIcon1.Icon = new Icon("nva.ico");
            notifyIcon1.Icon = NVAService.Properties.Resources.Drawer;
            notifyIcon1.Text = "Нижневартовсавиа";
            notifyIcon1.ContextMenu = contextMenu1;
            notifyIcon1.Visible = true;
            Application.Run();
            notifyIcon1.Visible = false;
        }

        private static void MenuItem7_Click(object sender, EventArgs e)
        {
            Message ms = new Message();
            ms.Show();
        }

        private static void MenuItem4_Click(object sender, EventArgs e)
        {
            SettingForm sForm = new SettingForm();
            sForm.Show();
        }

        private static void MenuItem5_Click(object sender, EventArgs e)
        {
            Process.Start(@"O:\!Показать IP-адрес\Показать IP-адрес.exe");
        }

        private static void MenuItem2_Click(object sender, EventArgs e)
        {
            SettingForm sForm = new SettingForm();
            sForm.Show();
        }

        //private static void menuItem1_Click(object Sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        public static string getHostName()
        {            
            return Dns.GetHostName(); 
        }

        private static string getLocalIPAddress()
        {
            //string ip;
            //string dns = Program.getHostName();
            //IPHostEntry ipEntry = Dns.GetHostByName(dns);
            //IPAddress[] addr = ipEntry.AddressList;

            //for (int i = 0; i < addr.Length; i++)
            //{
            //    ip = String.Format("IP Address {0}: {1} ", i, addr[i].ToString());
            //}
            //return "";
            string Host = System.Net.Dns.GetHostName();
            string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
            return IP;
        }

    }

    class CustomMenuItem : MenuItem
    {
        private Font _font;
        public Font Font
        {
            get
            {                
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        public CustomMenuItem()
        {
            this.OwnerDraw = true;
            this.Font = new Font(new FontFamily("Verdana"), 14);// SystemFonts.DefaultFont;
        }

        public CustomMenuItem(string text)
            : this()
        {
            this.Text = text;
        }

        // ... Add other constructor overrides as needed

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            // I would've used a Graphics.FromHwnd(this.Handle) here instead,
            // but for some reason I always get an OutOfMemoryException,
            // so I've fallen back to TextRenderer

            var size = TextRenderer.MeasureText(this.Text, this.Font);
            e.ItemWidth = (int)size.Width;
            e.ItemHeight = (int)size.Height;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, e.Bounds);
            //e.Graphics.DrawIcon(NVAService.Properties.Resources.nva,new Rectangle(0,e.Bounds.Y,16,16));

        }
    }
}
