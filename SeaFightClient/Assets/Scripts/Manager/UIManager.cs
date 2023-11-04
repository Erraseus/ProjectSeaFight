using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
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
    private void Awake()
    {
        Singleton = this;
    }
    #endregion

    // Declare Menu | [SerializeField] private GameObject _menuName
    // Add _menuName to the _menuList in the InitializeMenu() function
    // Call your menu in Update | ToggleMenuByKey(KeyCode.x, _menuName)
    
    // ToDo
    // Implementing function ToggleMenuByEnter()
    // Implementing function ToggleMenuByExit()


    [Header("Game Start Menu")]
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _loginMenu;
    [SerializeField] private GameObject _registerMenu;

    [Header("Ingame Menu")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _inventoryMenu;
    [SerializeField] private GameObject _equipmentMenu;

    [Header("HUD")]
    [SerializeField] private GameObject _drivemodeHUD;
    [SerializeField] private GameObject _mapmodeHUD;

    private List<GameObject> _menuList = new List<GameObject>();

    private bool _allMenusHidden;
    public bool HasLoggedIn
    {
        get { return hasLoggedIn; }
        set { hasLoggedIn = value; }
    }
    private bool hasLoggedIn;

    private void Start()
    {
        InitializeMenus();
        StartGameMenu();
    }

    private void Update()
    {
        if (!hasLoggedIn) return;
        if (hasLoggedIn && (_loginMenu.activeInHierarchy || _registerMenu.activeInHierarchy))
        {
            _loginMenu.SetActive(false);
            _registerMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !_allMenusHidden)
            HideAllMenuScreens();

        if (Input.GetKeyDown(KeyCode.Escape) && _allMenusHidden)
            ToggleMainMenu();

        ToggleMenuByKey(_inventoryMenu, KeyCode.I);
        ToggleMenuByKey(_equipmentMenu, KeyCode.K);
    }

    private void InitializeMenus()
    {
        //Game Start Menu
        _menuList.Add(_startMenu);
        _menuList.Add(_loginMenu);
        _menuList.Add(_registerMenu);
        //In Game Menu
        _menuList.Add(_mainMenu);
        _menuList.Add(_inventoryMenu);
        _menuList.Add(_equipmentMenu);
        //HUD
        _menuList.Add(_mapmodeHUD);
        _menuList.Add(_drivemodeHUD);
    }

    private void StartGameMenu()
    {
        hasLoggedIn = false;
        HideAllMenuScreens();

        if (_startMenu != null)
            _startMenu.SetActive(true);
    }
    public void RestartGameMenu()
    {
        //TODO: Save current Position and Player data into database before Reload
        SceneManager.LoadScene(0);
    }

    private void HideAllMenuScreens()
    {
        foreach (var menu in _menuList)
            menu.SetActive(false);

        _allMenusHidden = true;
    }

    private void ToggleMainMenu()
    {
        if (!_mainMenu.activeInHierarchy)
            _mainMenu.SetActive(true);
        else if (_mainMenu.activeInHierarchy)
            _mainMenu.SetActive(false);
    }

    private void ToggleMenuByKey(GameObject menu, KeyCode key)
    {
        if (Input.GetKeyDown(key) && !menu.activeInHierarchy && !_mainMenu.activeInHierarchy)
        {
            menu.SetActive(true);
            _allMenusHidden = false;
        }
        else if (Input.GetKeyDown(key) && menu.activeInHierarchy && !_mainMenu.activeInHierarchy)
        {
            menu.SetActive(false);
            _allMenusHidden = false;
        }
    }




    // TODO: Need better way for instantiating menu slots
    public void OpenInventoryMenu()
    {
        _inventoryMenu.SetActive(true);
    }
    public void CloseInventoryMenu()
    {
        _inventoryMenu.SetActive(false);
    }
    // TODO: End



    /* MARKET CODE FUKTIONIERT ZURZEIT NICHT
    
    public static GameObject Market;
    
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

    */
}