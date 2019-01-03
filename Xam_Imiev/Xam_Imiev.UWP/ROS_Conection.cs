using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using RosSharp.RosBridgeClient;

namespace Xam_Imiev.UWP
{
    public class ROS_Conection
    {        
        public int Timeout = 10;

        public RosSocket RosSocket { get; private set; }
        public enum Protocols { WebSocketSharp, WebSocketNET, WebSocketUWP };
        public Protocols Protocol;
        public string RosBridgeServerUrl = "ws://10.42.0.1:9090";

        private ManualResetEvent isConnected = new ManualResetEvent(false);

        private void ConnectAndWait()
        {
            RosSocket = ConnectToRos(Protocol, RosBridgeServerUrl, OnConnected, OnClosed);

            if (!isConnected.WaitOne(Timeout * 1000))
                Console.WriteLine("Failed to connect to RosBridge at: " + RosBridgeServerUrl);
        }

        public static RosSocket ConnectToRos(Protocols protocolType, string serverUrl, EventHandler onConnected = null, EventHandler onClosed = null)
        {
            RosSharp.RosBridgeClient.Protocols.IProtocol protocol = GetProtocol(protocolType, serverUrl);
            protocol.OnConnected += onConnected;
            protocol.OnClosed += onClosed;

            return new RosSocket(protocol);
        }

        private static RosSharp.RosBridgeClient.Protocols.IProtocol GetProtocol(Protocols protocol, string rosBridgeServerUrl)
        {

#if WINDOWS_UWP
            return new RosSharp.RosBridgeClient.Protocols.WebSocketUWPProtocol(rosBridgeServerUrl);
#else
            switch (protocol)
            {
                case Protocols.WebSocketNET:
                    return new RosSharp.RosBridgeClient.Protocols.WebSocketNetProtocol(rosBridgeServerUrl);
                case Protocols.WebSocketSharp:
                    return new RosSharp.RosBridgeClient.Protocols.WebSocketSharpProtocol(rosBridgeServerUrl);
                case Protocols.WebSocketUWP:
                    Console.Write("WebSocketUWP only works when deployed to HoloLens, defaulting to WebSocketNetProtocol");
                    return new RosSharp.RosBridgeClient.Protocols.WebSocketNetProtocol(rosBridgeServerUrl);
                default:
                    return null;
            }
#endif
        }

        private void OnConnected(object sender, EventArgs e)
        {
            isConnected.Set();
            Console.WriteLine("Connected to RosBridge: " + RosBridgeServerUrl);
        }

        private void OnClosed(object sender, EventArgs e)
        {
            isConnected.Reset();
            Console.WriteLine("Disconnected from RosBridge: " + RosBridgeServerUrl);
        }

        public void Conectar_a_ROS()
        {
#if WINDOWS_UWP
            ConnectAndWait();
#else
            new Thread(ConnectAndWait).Start();
#endif
        }

        public void Susbscribir_Nodo()
        {
            Node_Subscriber odom_subs = new Node_Subscriber(RosSocket);
        }

        public void Publicar_Nodo()
        {
            Node_Publisher odom_subs = new Node_Publisher(RosSocket);
        }

        public void Desconectar()
        {
            RosSocket.Close();
        }
    }
}
