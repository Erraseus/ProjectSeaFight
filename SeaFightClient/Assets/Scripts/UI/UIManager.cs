using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _singleton;
    public static UIManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(UIManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    [SerializeField] public static GameObject Market;

    private void Awake()
    {
        Singleton = this;
        Market = gameObject.transform.Find("Market").gameObject;
    }

    public void ExitMarket()
    {
        Market.gameObject.SetActive(false);
    }



    [MessageHandler((ushort)ServerToClientId.handel)]
    private static void PlayerHandel(Message message)
    {
        Debug.Log(message.GetString());
        Market.gameObject.SetActive(true);
    }




}
