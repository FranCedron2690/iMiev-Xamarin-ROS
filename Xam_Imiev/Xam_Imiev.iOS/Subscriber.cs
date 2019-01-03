using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using RosSharp.RosBridgeClient;

namespace Xam_Imiev.iOS
{
    public abstract class Subscriber<T> where T : Message
    {
        public string Topic;// = "/join_states";
        public float TimeStep;// = 0;
        public RosSocket rosSocket;

        protected virtual void Start()
        {
            rosSocket.Subscribe<T>(Topic, ReceiveMessage, (int)(TimeStep * 1000)); // the rate(in ms in between messages) at which to throttle the topics
        }

        protected abstract void ReceiveMessage(T message);
    }
}
