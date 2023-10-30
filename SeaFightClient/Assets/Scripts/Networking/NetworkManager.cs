using Riptide;
using Riptide.Utils;
using System;
using System.Net;
using UnityEngine;





public enum ServerToClientId : ushort
{
    playerSpawned,
    playerMove,
    handel,
    startInformations,
    NPCSpawn,
}

public enum ClientToServerId : ushort
{
    MovePosition,
    Login,
}




public class NetworkManager : MonoBehaviour
{

    private static NetworkManager _singleton;
    public static NetworkManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(NetworkManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
        
    }


    public Client Client { get; private set; }

    [SerializeField] private string ip;
    [SerializeField] private ushort port;
    public MainMenu mainMenu;

    private void Start()
    {
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
        Client = new Client();
        Client.Connected += DidConnect;
        Client.ConnectionFailed += FailedToConnect;
        Client.Disconnected += DidDisconnect;
    }


    private void FixedUpdate()
    {
        Client.Update();
    }

    private void OnApplicationQuit()
    {
        Client.Disconnect();
    }

    public void Connect()
    {
        Client.Connect(ip + ":" + port);
    }

    private void DidConnect(object sender, EventArgs e)
    {
        mainMenu.open_login();
    }

    private void FailedToConnect(object sender, EventArgs e)
    {
        mainMenu.connectRetry();
    }

    private void DidDisconnect(object sender, EventArgs e)
    {
        mainMenu.connectRetry();
    }

}

