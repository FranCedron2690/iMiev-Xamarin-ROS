using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

using RosSharp.RosBridgeClient;

namespace Xam_Imiev.UWP
{
    public class Node_Publisher : Publisher<RosSharp.RosBridgeClient.Messages.Standard.Float64>
    {
        public string FrameId = "Unity";

        RosSharp.RosBridgeClient.Messages.Standard.Float64 message;

        public Node_Publisher(RosSocket rossocket_recib)
        {
            Topic = "/fran/numero";
            RosSocket = rossocket_recib;
            base.Start();
            //InitializeGameObject();
            InitializeMessage();
        }

        /*private void Update()
        {
            UpdateMessage();
        }*/

        /*private void InitializeGameObject()
        {
            //JoyAxisReaders = GetComponents<JoyAxisReader>();
            //JoyButtonReaders = GetComponents<JoyButtonReader>();
        }*/

        private void InitializeMessage()
        {
            message = new RosSharp.RosBridgeClient.Messages.Standard.Float64();
            message.data = 4;

            UpdateMessage();
        }

        private void UpdateMessage()
        {
            //message.header.Update();

            for (int i = 0; i < 100; i++)
                message.data = i;

            Publish(message);
        }
    }
}
