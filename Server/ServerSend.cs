﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnityNetworkingSystemTCP
{
    class ServerSend //This class is what will be building all of the various packets that will be sent over the network. 
    {
        private static void SendTCPData(int _toClient, Packet _packet) //This method is in charge of preparing the packet to be sent
        {
            _packet.WriteLength(); //Takes the length of the byte list that we want to send and will insert that at the beginning of the packet.
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendTCDDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }
        private static void SendTCDDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }
        }
    }
}