﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNetworkingSystemTCP;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        // TODO: send welcome received packet
    }
}