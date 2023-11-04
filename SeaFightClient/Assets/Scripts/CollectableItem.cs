using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    //General Settings
    [Header("Drop Settings")]
    [SerializeField] private List<CraftingMaterialSO> _possibleCraftingMaterials;
    [Header("Items in Container")]
    [SerializeField] private int _minItems;
    [SerializeField] private int _maxItems;
    [Header("Stack Size")]
    [SerializeField] private int _minQuantity;
    [SerializeField] private int _maxQuantity;
    [Space]
    [Header("Average Gold ammount")]
    [SerializeField] private int _averageGold;

    //Calculating
    private int calculatedItems;
    [SerializeField] private List<CraftingMaterialSO> _craftingMaterials;
    [SerializeField] private List<int> _quantity;
    public int _gold;

    private void Start()
    {
        _craftingMaterials = new List<CraftingMaterialSO>();
        _quantity = new List<int>();

        _gold = 0;
        _craftingMaterials.Clear();
        calculatedItems = 0;
        _quantity.Clear();

        int calculateMinGold = _averageGold * 90 / 100;
        int caluclateMaxGold = _averageGold * 110 / 100;
        _gold = Random.Range(calculateMinGold, caluclateMaxGold + 1);

        calculatedItems = Random.Range(_minItems, _maxItems + 1);

        for (int i = 0; i < calculatedItems; i++)
        {
            int randomItem = Random.Range(0, _possibleCraftingMaterials.Count);
            int randomStackSize = Random.Range(_minQuantity, _maxQuantity + 1);

            if (_maxItems > _possibleCraftingMaterials.Count)
            {
                Debug.LogError("value of maxItems too high");
                return;
            }
            if (_craftingMaterials.Contains(_possibleCraftingMaterials[randomItem]))
            {
                i--;
            }
            else
            {
                _craftingMaterials.Add(_possibleCraftingMaterials[randomItem]);
                _quantity.Add(randomStackSize);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory _playerInventory = other.gameObject.GetComponentInParent<PlayerInventory>();

            int goldOverMax = _playerInventory.AddGold(_gold);
            if (goldOverMax > 0) _gold = goldOverMax;
           
            for (int i = 0; i < _craftingMaterials.Count; i++)
            {
                _playerInventory.AddCraftingMaterial(_craftingMaterials[i], _quantity[i]);
            }

            Destroy(gameObject);
            
            //for (int i = 0; i < _itemsInCollectable.Count; i++)
            //{
            //    int leftoverItems = playerInventory.AddItem(_itemsInCollectable[i], calculatedQuantity[i]);
            //    if (leftoverItems > 0)
            //    {
            //        calculatedQuantity[i] = leftoverItems;
            //        i--;
            //    }
            //}
        }
    }
}