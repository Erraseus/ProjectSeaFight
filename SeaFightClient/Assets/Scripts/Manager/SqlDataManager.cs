using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SqlDataManager : MonoBehaviour
{
    #region Singleton
    private static SqlDataManager _singleton;
    public static SqlDataManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(SqlDataManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
    }
    #endregion

    [Header("Player Data")]
    public int id;
    public new string name;
    [Space]
    [Header("Ship Data")]
    public int shipLevel;
    public List<int> cannonSlots = new List<int>();
    public List<int> sailSlots = new List<int>();
    public List<int> crewSlots = new List<int>();
    public List<int> inventorySlots = new List<int>();
}