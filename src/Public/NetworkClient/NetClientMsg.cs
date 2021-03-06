﻿using Lidgren.Network;

namespace NetworkClient
{
    internal class NetClientMsg
    {
        public NetOutgoingMessage Msg { get; set; }

        public NetDeliveryMethod Method { get; set; }

        public NetClientMsg(NetOutgoingMessage msg, NetDeliveryMethod method)
        {
            Msg     = msg;
            Method  = method;
        }
    }
}