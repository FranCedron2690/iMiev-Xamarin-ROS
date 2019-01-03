using System;
using System.Collections.Generic;
using System.Text;

using RosSharp.RosBridgeClient;

namespace Xam_Imiev.UWP
{
    public abstract class Publisher<T> where T : Message
    {
        public string Topic;
        private string publicationId;
        public RosSocket RosSocket;

        protected virtual void Start()
        {
            publicationId = RosSocket.Advertise<T>(Topic);
        }

        protected void Publish(T message)
        {
            RosSocket.Publish(publicationId, message);
        }
    }
}
