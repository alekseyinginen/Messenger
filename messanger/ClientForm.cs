using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace Messenger
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm
    {
       // EventArgs Event;
       // object Obj;
       // delegate void Button_Click(object Obj, EventArgs Args);
        public static string userName = "Pidor";
        private const string host = "192.168.43.200";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;
        public ClientForm()
        {
            InitializeComponent();
            Chat.Enabled = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
            textMessage.Clear();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            MainChat();
        }
        
        private void MainChat()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                stream = client.GetStream(); // получаем поток

                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // запускаем новый поток для получения данных
                Thread receiveThread1 = new Thread(new ThreadStart(ReceiveMessage));
                //Thread receiveThread2 = new Thread(new ThreadStart(Button1_Click));
                Chat.Text = "Добро пожаловать" + Environment.NewLine; ;//+ userName;
                receiveThread1.Start();
                ConnectButton.Enabled = false;
                //SendMessage();
            }
            catch (Exception ex)
            {
                Chat.Text = ex.Message;
            }
            //finally
            //{
            //    Disconnect();
            //}
        }
        // отправка сообщений
        private void SendMessage()
        {
            string message = textMessage.Text;
            Chat.Text += message + Environment.NewLine;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
        // получение сообщений
        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    Chat.Text += message + Environment.NewLine;//вывод сообщения
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }
                
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
            Close();
        }

        private void Chat_TextChanged(object sender, EventArgs e)
        {

        }


        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                textMessage.Clear();
            }
        }
    }
}
