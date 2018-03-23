using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_sever_RPS
{
    public partial class Form1 : Form
    {
        byte[] data = new byte[1024];
        IPEndPoint ipep = new IPEndPoint(
                        IPAddress.Parse("127.0.0.1"), 9050);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint sender = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        EndPoint Remote;
        string input;
        public Form1()
        {
            InitializeComponent();
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
            Remote = (EndPoint)sender;
            data = new byte[1024];
        }
        public void kq(string input, string k)
        {
            if (input == "1")
            {
                if (k == "1")
                {
                    txtResult.Text = "Hòa";
                }
                if (k == "2")
                {
                    txtResult.Text = "Thắng";
                }
                if (k == "3")
                {
                    txtResult.Text = "Thua";
                }
            }
            if (input == "2")
            {
                if (k == "1")
                {
                    txtResult.Text = "Thua";
                }
                if (k == "2")
                {
                    txtResult.Text = "Hòa";
                }
                if (k == "3")
                {
                    txtResult.Text = "Thắng";
                }
            }
            if (input == "3")
            {
                if (k == "1")
                {
                    txtResult.Text = "Thắng";
                }
                if (k == "2")
                {
                    txtResult.Text = "Thua";
                }
                if (k == "3")
                {
                    txtResult.Text = "Hòa";
                }
            }
        }
        private void btnPaper_Click(object sender, EventArgs e)
        {
            txtSelect.Text = "Bao";
            input = "2";
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            kq(input, k);
        }
        private void btnScissor_Click(object sender, EventArgs e)
        {
            txtSelect.Text = "Kéo";
            input = "1";
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            kq(input, k);
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            txtSelect.Text = "Búa";
            input = "3";
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            kq(input, k);
        }
    }
}
