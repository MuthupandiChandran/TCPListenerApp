using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPListenerApp
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string addressString = txtAddress.Text;
                int port;
                if (!int.TryParse(txtPort.Text, out port) || port <= 0 || port > 65535)
                {
                    groupBox1.Text += "Invalid port number. Port number must be between 1 and 65535." + Environment.NewLine;
                    return;
                }


                IPAddress ipAddress;
                if (string.IsNullOrWhiteSpace(addressString))
                {
                    groupBox1.Text += "Please enter a valid IP address or host name" + Environment.NewLine;
                    return;
                }
                if (string.Equals(addressString, "localhost", StringComparison.OrdinalIgnoreCase)) //Accept both Lowercase and Uppercase
                {
                    ipAddress = IPAddress.Loopback;
                }
                else
                {

                    if (!IPAddress.TryParse(addressString, out ipAddress))
                    {
                        try
                        {
                            IPAddress[] addresses = Dns.GetHostAddresses(addressString);
                            if (addresses.Length == 0)
                            {
                                groupBox1.Text += "Unable to resolve host name: " + addressString + Environment.NewLine;
                                return;
                            }
                            ipAddress = addresses[0];
                        }
                        catch (Exception)
                        {
                            groupBox1.Text += "Invalid IP address or host name" + Environment.NewLine;
                            return;
                        }
                    }
                }

                tcpListener = new TcpListener(ipAddress, port);
                tcpListener.Start();

                PrintMessage("TCP listener started. Waiting for connections...");

                tcpListener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnected), null);

                btnStart.Enabled = false;
            }
            catch (Exception ex)
            {
                groupBox1.Text += "Error: " + ex.Message + Environment.NewLine;
            }
        }

        private void OnClientConnected(IAsyncResult ar)
        {
            TcpClient client = tcpListener.EndAcceptTcpClient(ar);
            HandleClient(client);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnected), null);
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            PrintMessage("TCP connection established with " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                PrintMessage("Data received: " + data);
            }
            client.Close();
        }

        private void PrintMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(PrintMessage), message);
                return;
            }
            groupBox1.Text += message + Environment.NewLine;
        }
    }
}
