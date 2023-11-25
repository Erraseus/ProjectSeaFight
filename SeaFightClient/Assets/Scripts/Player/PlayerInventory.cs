using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    [Header("Creating Inventory UI")]
    [SerializeField] private string _itemSlotsName;
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] [Range(1, 40)] private int _maxItemSlots;

    private List<ItemSlot> _itemSlots = new List<ItemSlot>();

    private List<IInventoryItem> _item = new List<IInventoryItem>();
    private List<int> _quantity = new List<int>();

    public int Gold { get; private set; }
    private int _maxGold = 1000000;


    private void Start()
    {
        InitializeInventorySlots();
    }
    
    private void InitializeInventorySlots()
    {
        UIManager.Singleton.ToggleInventoryMenu();
        Transform slots = GameObject.Find(_itemSlotsName).GetComponent<Transform>();
        UIManager.Singleton.ToggleInventoryMenu();
        for (int i = 0; i < _maxItemSlots; i++)
        {
            GameObject itemSlot = Instantiate(_itemSlotPrefab, Vector3.zero, Quaternion.identity);
            _itemSlots.Add(itemSlot.GetComponent<ItemSlot>());
            itemSlot.transform.SetParent(slots);
            _item.Add(null);
            _quantity.Add(0);
        }
    }

    public int AddGold(int ammount)
    {
        int goldOverMax = 0;
        Gold += ammount;
        if (Gold > _maxGold)
        {
            goldOverMax = Gold - _maxGold;
            Gold = _maxGold;
        }
        return goldOverMax;
    }

    public int AddItem(IInventoryItem item, int quantity)
    {
        int remainingQuantity = quantity;
        
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            
            if (_item[i] == null) _item[i] = item;

            if (_item[i].Id == item.Id)
            {
                if (_item[i].StackQuantity < _quantity[i] + remainingQuantity)
                {
                    int addedQuantity;
                    addedQuantity = _item[i].StackQuantity - _quantity[i];
                    _quantity[i] = _quantity[i] + addedQuantity;
                    remainingQuantity = remainingQuantity - addedQuantity;
                
                    _itemSlots[i].UpdateItemSlot(_item[i], _quantity[i]);
                }
                else
                {
                    _quantity[i] = _quantity[i] + remainingQuantity;
                    remainingQuantity = 0;

                    _itemSlots[i].UpdateItemSlot(_item[i], _quantity[i]);

                    return remainingQuantity;
                }
            }
            if (remainingQuantity <= 0)
            {
                remainingQuantity = 0;
                return remainingQuantity;
            }
        }
        Debug.LogWarning("Inventory full"!);
        return remainingQuantity;
    }
}