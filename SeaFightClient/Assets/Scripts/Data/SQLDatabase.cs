using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SQLDatabase : MonoBehaviour
{
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

    private void Awake()
    {
        
    }
}
