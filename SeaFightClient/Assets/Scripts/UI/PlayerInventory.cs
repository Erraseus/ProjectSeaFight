using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private string _itemSlotsName;
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] private ItemSlot[] _itemSlots;
    [SerializeField] private CraftingMaterialSO[] _craftingMaterialSlots;
    [SerializeField] private int[] _quantity;
    public int Gold { get; private set; }
    private int _maxGold;


    private void Start()
    {
        InitializeInventorySlots();
    }
    
    private void InitializeInventorySlots()
    {
        UIManager.Singleton.ToggleInventoryMenu();
        Transform slots = GameObject.Find(_itemSlotsName).GetComponent<Transform>();
        UIManager.Singleton.ToggleInventoryMenu();
        for (int i = 0; i < _itemSlots.Length; i++)
        {
            GameObject itemSlot = Instantiate(_itemSlotPrefab, Vector3.zero, Quaternion.identity);
            _itemSlots[i] = itemSlot.GetComponent<ItemSlot>();
            itemSlot.transform.SetParent(slots);
        }
    }

    public int AddGold(int ammount)
    {
        int goldOverMax = 0;
        if (Gold == _maxGold) return ammount;
        Gold += ammount;

        if (Gold > _maxGold)
        {
            Debug.LogWarning($"Max Gold reached!");
            goldOverMax = Gold - _maxGold;
            Debug.LogWarning($"Returning {goldOverMax} Gold into Collectable!");
            Gold = _maxGold;
        }
        else
        {
            Debug.Log($"{ammount} Gold earned!");
            goldOverMax = 0;
        }
        Debug.Log($"Current Gold = {Gold}");

        return goldOverMax;
    }

    public void AddCraftingMaterial(CraftingMaterialSO craftingMaterial, int quantity)
    {
        for (int i = 0; i < _craftingMaterialSlots.Length; i++)
        {
            if (_craftingMaterialSlots[i] == null || _craftingMaterialSlots[i].Id == craftingMaterial.Id)
            {
                _craftingMaterialSlots[i] = craftingMaterial;
                _quantity[i] += quantity;
                _itemSlots[i].UpdateItemSlot(craftingMaterial, quantity);

                return;
            }
        }
    }
}