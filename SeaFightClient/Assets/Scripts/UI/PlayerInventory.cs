using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Creating Inventory UI")]
    [SerializeField] private string _itemSlotsName;
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] [Range(1, 40)] private int _itemSlotsQuantity;

    private List<ItemSlot> _itemSlots = new List<ItemSlot>();
    private List<CraftingMaterialSO> _craftingMaterialSlots = new List<CraftingMaterialSO>();
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
        for (int i = 0; i < _itemSlotsQuantity; i++)
        {
            GameObject itemSlot = Instantiate(_itemSlotPrefab, Vector3.zero, Quaternion.identity);
            _itemSlots.Add(itemSlot.GetComponent<ItemSlot>());
            itemSlot.transform.SetParent(slots);
            _craftingMaterialSlots.Add(null);
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

    public int AddCraftingMaterial(CraftingMaterialSO craftingMaterial, int quantity)
    {
        int quantityToReturn = quantity;

        for (int i = 0; i < _itemSlotsQuantity; i++)
        {
            if (_craftingMaterialSlots[i] != null && _craftingMaterialSlots[i].Stack >= _quantity[i] + quantity) continue;

            if (_craftingMaterialSlots[i] == null || _craftingMaterialSlots[i].Id == craftingMaterial.Id)
            {
                _craftingMaterialSlots[i] = craftingMaterial;

                if (_craftingMaterialSlots[i].Stack < _quantity[i] + quantity)
                {
                    int quantityToAdd = _craftingMaterialSlots[i].Stack - _quantity[i];

                    _quantity[i] = _quantity[i] + quantityToAdd;

                    quantityToReturn = quantity - quantityToAdd;
                    Debug.LogWarning($"Returned {quantityToReturn} pieces of {_craftingMaterialSlots[i].Name} to Barrel!");
                    _itemSlots[i].UpdateItemSlot(_craftingMaterialSlots[i], _quantity[i]);

                    return quantityToReturn;
                }
                else
                {
                    _quantity[i] = _quantity[i] + quantity;
                    _itemSlots[i].UpdateItemSlot(_craftingMaterialSlots[i], _quantity[i]);
                    quantityToReturn = 0;

                    return quantityToReturn;
                }
            }
        }
        Debug.Log("Inventory is full!");
        return quantityToReturn;
    }
}