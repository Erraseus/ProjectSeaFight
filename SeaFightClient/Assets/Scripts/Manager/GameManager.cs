using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _singleton;
    public static GameManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(GameManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
        Application.runInBackground = true;
    }
    #endregion

    public GameObject ClientPlayerPrefab => _clientPlayerPrefab;
    public GameObject ServerPlayerPrefab => _serverPlayerPrefab;

    [Header("Prefabs")]
    [SerializeField] private GameObject _clientPlayerPrefab;
    [SerializeField] private GameObject _serverPlayerPrefab;
}