﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance;

    public GameObject playerPrefab;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 30;

        #if UNITY_EDITOR
        Debug.Log("Build the project to start the server!");
        #else
        Server.Start(50, 26950);
        #endif
    }

    public Player InstantiatePlayer()
    {
        return Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
    }
}