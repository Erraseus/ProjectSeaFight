using System;
using UnityEngine;
using Riptide;
using Riptide.Utils;

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
    #region Singleton
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
    #endregion

    public Client Client { get; private set; }

    [SerializeField] private string ip;
    [SerializeField] private ushort port;
    [SerializeField] private StartMenu _startMenu;

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
        Client.Connect($"{ip}:{port}");
    }

    private void DidConnect(object sender, EventArgs e)
    {
        _startMenu.OpenLogin();
    }

    private void FailedToConnect(object sender, EventArgs e)
    {
        _startMenu.ConnectRetry();
    }

    private void DidDisconnect(object sender, EventArgs e)
    {
        UIManager.Singleton.RestartGame();
    }
}