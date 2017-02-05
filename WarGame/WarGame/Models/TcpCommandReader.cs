using NLog;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using WarGame.Models.Events;

namespace WarGame.Models
{
    public class TcpCommandReader : ICommandReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public event PushCommand PushCommandEvent;

        /// <summary>
        /// Start tcp listener and receive commands from a tcp client
        /// </summary>
        public void ReadCommands()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    logger.Info("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    string data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.Equals("StopListen<EOF>"))
                        {
                            logger.Trace("Close server listener socket.");
                            listener.Close();
                            return;
                        }
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            handler.Send(Encoding.ASCII.GetBytes(data));
                            //logger.Trace("Text received : {0}", data);
                            PushCommandEvent?.Invoke(this, new PushCommandArgs() { Command = data.Substring(0, data.IndexOf("<")) });
                            //AddCommandToQueue(data.Substring(0, data.IndexOf("<")));
                            //break;
                        }
                    }

                }

            }
            catch (Exception e)
            {
                logger.Error("Error at ReadCommandsFromTCP {0}", e.Message);
            }
        }
    }
}
