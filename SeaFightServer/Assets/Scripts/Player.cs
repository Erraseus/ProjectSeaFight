using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Riptide;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine.Networking;
using UnityEditor.PackageManager;
using System;

public class Player : MonoBehaviour
{
    public static Dictionary<ushort, Player> list = new Dictionary<ushort, Player>();

    public ushort Id { get; private set; }
    public string Username { get; private set; }


    private void OnDestroy()
    {
        list.Remove(Id);
    }



    public static void Spawn(ushort id, string username, int ship)
    {
        foreach (Player otherPlayer in list.Values)
            otherPlayer.SendSpawned(id, ship);
        Player player = Instantiate(GameLogic.Singleton.PlayerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<Player>();
        player.name = $"Player {id} ({(string.IsNullOrEmpty(username) ? "Guest" : username)})";
        player.Id = id;
        player.Username = string.IsNullOrEmpty(username) ? $"Guest {id}" : username;

        player.SendSpawned(ship);
        list.Add(id, player);
    }

    private void MovePlayer(ushort id, Vector3 position)
    {
        Debug.Log(id + ") X:" + position.x + "   Y:" + position.y + "    Z:" + position.z);
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ServerToClientId.playerMove);
        message.AddUShort(id);
        message.AddVector3(position);
        NetworkManager.Singleton.Server.SendToAll(message);
        
        gameObject.GetComponent<NavMeshAgent>().destination = position;
    }

    [MessageHandler((ushort)ClientToServerId.Login)]
    private static void Login(ushort fromClientId, Message message)
    {
        string type = message.GetString();
        string name = message.GetString();
        string email = message.GetString();
        string password = message.GetString();
        Debug.Log("Type: " + type);
        if (type == "Login")
        {
            Player playerInstance = new GameObject().AddComponent<Player>();
            playerInstance.StartCoroutine(SendLoginData(name, password, fromClientId));
        }
        else
        {
            Player playerInstance = new GameObject().AddComponent<Player>();
            playerInstance.StartCoroutine(SendRegistrationData(name, password, email, fromClientId));
        }

        
    }

    [MessageHandler((ushort)ClientToServerId.MovePosition)]
    private static void MovePlayer(ushort fromClientId, Message message)
    {
        if (list.TryGetValue(fromClientId, out Player player))
            player.MovePlayer(fromClientId, message.GetVector3());

    }

    private void SendSpawned(ushort toClientId, int ship)
    {
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ServerToClientId.playerSpawned);
        message.AddUShort(Id);
        message.AddString(Username);
        message.AddVector3(transform.position);
        message.AddInt(ship);
        NetworkManager.Singleton.Server.Send(message, toClientId);
    }

    private void SendSpawned(int ship)
    {
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ServerToClientId.playerSpawned);
        message.AddUShort(Id);
        message.AddString(Username);
        message.AddVector3(transform.position);
        message.AddInt(ship);
        NetworkManager.Singleton.Server.SendToAll(message);
    }




    private static IEnumerator SendRegistrationData(string name, string password, string email, ushort toClientID)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);
        form.AddField("email", email);
        string result;
        using (UnityWebRequest www = UnityWebRequest.Post("http://piratetest.mygamesonline.org/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                result = www.error;
            }
            else
            {
                result = www.downloadHandler.text;
            }
        }

        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ServerToClientId.startInformations);
        message.AddString(result);
        NetworkManager.Singleton.Server.Send(message, toClientID);

        if (result.Trim() == "1")
        {
            Spawn(toClientID, name, 0);
        }
    }

    private static IEnumerator SendLoginData(string name, string password, ushort ClientID)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);
        string result = "";
        using (UnityWebRequest www = UnityWebRequest.Post("http://piratetest.mygamesonline.org/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                result = www.error;
            }
            else
            {
                result = www.downloadHandler.text;
            }
        }
        Message message = Message.Create(MessageSendMode.Reliable, (ushort)ServerToClientId.startInformations);
        message.AddString(result);
        NetworkManager.Singleton.Server.Send(message, ClientID);

        if (result.Split(";")[0].Trim() == "1")
        {
            Spawn(ClientID,name, Int32.Parse(result.Split(";")[1]));
        }
    }

}
