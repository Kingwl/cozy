﻿using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CozyKxlol.Network.Msg
{
    public struct Msg_AccountLoginRsp : MsgBase
    {
        public int Id { get { return MsgId.AccountLoginRsp; } }

        public Boolean suc { get; set; }
        public String detail { get; set; }

        public void W(NetOutgoingMessage om)
        {
            om.Write(suc);
            om.Write(detail);
        }

        public void R(NetIncomingMessage im)
        {
            suc     = im.ReadBoolean();
            detail  = im.ReadString();
        }
    }
}
