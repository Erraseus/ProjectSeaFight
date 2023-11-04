using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;

    private Transform _itemParent;
    private PlayerEquipment _playerEquipment;
    private CraftingMaterialSO _item;
    [SerializeField] private List<ItemSlot> _itemSlots;
    

    public int Gold { get; private set; }


    private void Start()
    {
        UIManager.Singleton.OpenInventoryMenu();
        InitializeInventorySlots();
        UIManager.Singleton.CloseInventoryMenu();
        
        
    }
    
    private void InitializeInventorySlots()
    {
        _itemParent = GameObject.Find("Slots").GetComponent<Transform>();
        _playerEquipment = GetComponent<PlayerEquipment>();
        _itemSlots = new List<ItemSlot>();

        for (int i = 0; i < _playerEquipment.inventorySlots; i++)
        {
            
            GameObject icon = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            icon.GetComponent<ItemSlot>().PlayerInventory = GetComponent<PlayerInventory>();
            _itemSlots.Add(icon.GetComponent<ItemSlot>());
            icon.transform.SetParent(_itemParent);
        }
    }

    public void AddGold(int ammount)
    {
        Gold += ammount;
        Debug.Log($"Player got {ammount} gold. Curent gold = {Gold}");
    }
    public void AddItem(CraftingMaterialSO item, int quantity)
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            if (_itemSlots[i] == null)
            {
                _itemSlots[i].AddItem(item, quantity);
                return;
            }
            if (_itemSlots[i].IsFull == false)
            {
                _itemSlots[i].AddItem(item, quantity);
                return;
            }
        }
    }


    public void DeselectAllSlots()
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            _itemSlots[i].DeselectSlot();
        }
    }
}