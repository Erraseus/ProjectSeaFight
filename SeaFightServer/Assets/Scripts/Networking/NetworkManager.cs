using Riptide;
using Riptide.Utils;
using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Networking;

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

    public Server Server { get; private set; }

    [SerializeField] private ushort port;
    [SerializeField] private ushort maxClientCount;

    public static String SQL_Output;
    public string response;
    private void Awake()
    {
        Singleton = this;
    }


    private void Start()
    {

#if UNITY_EDITOR
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
#else
        System.Console.Title = "Server";
        System.Console.Clear();
        Application.SetStackTraceLogType(UnityEngine.LogType.Log, StackTraceLogType.None);
        RiptideLogger.Initialize(Debug.Log, true);
#endif

        Server = new Server();
        Server.ClientDisconnected += PlayerLeft;
        Server.Start(port, maxClientCount);

    }

    private void FixedUpdate()
    {
        Server.Update();        
    }

    private void OnApplicationQuit()
    {
        Server.Stop();
    }

    private void PlayerLeft(object sender, ServerDisconnectedEventArgs e)
    {
        if (Player.list.TryGetValue(e.Client.Id, out Player player))
            Destroy(player.gameObject);
    }


    public IEnumerator SendSQL(string sqlQuery, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("sql_query", sqlQuery);
        UnityWebRequest request = UnityWebRequest.Post("http://piratetest.mygamesonline.org/sql.php", form);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Fehler beim Senden der SQL-Anfrage: " + request.error);
        }
        else
        {
            string response = request.downloadHandler.text.Trim();
            callback(response);
        }
    }

}
