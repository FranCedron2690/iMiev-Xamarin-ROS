using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RosSharp.RosBridgeClient;

namespace Xam_Imiev.UWP
{
    public class Node_Subscriber : Subscriber<RosSharp.RosBridgeClient.Messages.Standard.Int16>
    {
        int number_message = 0;
        private bool isMessageReceived;

        public Node_Subscriber(RosSocket rosSocket_recib)
        {
            Topic = "/imu/alignment";
            TimeStep = 0;
            rosSocket = rosSocket_recib;
            base.Start();
        }

        public void Recibir_Mensaje()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(RosSharp.RosBridgeClient.Messages.Standard.Int16 message)
        {
            number_message = message.data;

            Console.WriteLine(number_message);

            isMessageReceived = true;
        }
        private void ProcessMessage()
        {
            Console.WriteLine(number_message);
        }

        /*private Vector3 GetPosition(RosSharp.RosBridgeClient.Messages.Navigation.Odometry message)
        {
            return new Vector3(
                message.pose.pose.position.x,
                message.pose.pose.position.y,
                message.pose.pose.position.z);
        }

        private Quaternion GetRotation(RosSharp.RosBridgeClient.Messages.Navigation.Odometry message)
        {
            return new Quaternion(
                message.pose.pose.orientation.x,
                message.pose.pose.orientation.y,
                message.pose.pose.orientation.z,
                message.pose.pose.orientation.w);
        }*/
    }
}
