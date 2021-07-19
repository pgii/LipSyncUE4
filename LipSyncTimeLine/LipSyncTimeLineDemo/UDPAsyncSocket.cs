using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LipSyncTimeLineDemo
{
    public class UdpAsyncSocket
    {
        public Socket UdpSocket;
        private readonly List<EndPoint> _clientList = new List<EndPoint>();
        private readonly byte[] _byteData = new byte[1024];

        private static readonly ManualResetEvent SendDone = new ManualResetEvent(false);

        public void StartClient(string address, int port)
        {
            UdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UdpSocket.Connect(IPAddress.Parse(address), port);
            EndPoint newClientEp = new IPEndPoint(IPAddress.Any, 0);
            UdpSocket.BeginReceiveFrom(_byteData, 0, _byteData.Length, SocketFlags.None, ref newClientEp, DoReceiveFrom, newClientEp);
        }

        private void DoReceiveFrom(IAsyncResult iar)
        {
            try
            {
                EndPoint clientEp = new IPEndPoint(IPAddress.Any, 0);
                try
                {
                    int dataLen = UdpSocket.EndReceiveFrom(iar, ref clientEp);
                    byte[] data = new byte[dataLen];
                    Array.Copy(_byteData, data, dataLen);

                    EndPoint newClientEp = new IPEndPoint(IPAddress.Any, 0);
                    UdpSocket.BeginReceiveFrom(_byteData, 0, _byteData.Length, SocketFlags.None, ref newClientEp, DoReceiveFrom, newClientEp);

                    if (!_clientList.Any(client => client.Equals(clientEp)))
                        _clientList.Add(clientEp);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            catch (ObjectDisposedException dex)
            {
                Debug.WriteLine(dex.Message);
            }
        }

        public void Send(string message)
        {
            if (UdpSocket != null && UdpSocket.IsBound && UdpSocket.Connected)
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                UdpSocket.BeginSend(data, 0, data.Length, 0, SendCallback, UdpSocket);
                SendDone.WaitOne();
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
                SendDone.Set();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}