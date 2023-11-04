using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [Header("Drop Settings")]
    [SerializeField] private List<CraftingMaterialSO> possibleItems;
    [Header("Items in Container")]
    [SerializeField] private int minItems;
    [SerializeField] private int maxItems;
    [Header("Stack")]
    [SerializeField] private int minStackSize;
    [SerializeField] private int maxStackSize;
    [Space]
    [SerializeField] private int gold;

    private int calculatedItems;
    [SerializeField] private List<CraftingMaterialSO> itemsInCollectable = new List<CraftingMaterialSO>();
    [SerializeField] private List<int> calculatedStackSize;
    private int calculatedGold;

    private void Start()
    {
        CalculateCollectable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory playerInventory = other.gameObject.GetComponentInParent<PlayerInventory>();
            for (int i = 0; i < itemsInCollectable.Count; i++)
            {
                playerInventory.AddItem(itemsInCollectable[i], calculatedStackSize[i]);
            }
            Destroy(gameObject);
        }
    }

    private void CalculateCollectable()
    {
        calculatedStackSize = new List<int>();

        calculatedGold = 0;
        itemsInCollectable.Clear();
        calculatedItems = 0;
        calculatedStackSize.Clear();

        int calculateMinGold = gold * 90 / 100;
        int caluclateMaxGold = gold * 110 / 100;
        calculatedGold = Random.Range(calculateMinGold, caluclateMaxGold + 1);

        calculatedItems = Random.Range(minItems, maxItems + 1);

        for (int i = 0; i < calculatedItems; i++)
        {
            int randomItem = Random.Range(0, possibleItems.Count);
            int randomStackSize = Random.Range(minStackSize, maxStackSize + 1);

            if (maxItems > possibleItems.Count)
            {
                Debug.LogError("value of maxItems too high (OutOfRangeException)");
                return;
            }

            if (itemsInCollectable.Contains(possibleItems[randomItem]))
            {
                Debug.LogWarning("Double Item catched, Recalculating!");
                i--;
            }
            else
            {
                itemsInCollectable.Add(possibleItems[randomItem]);
                calculatedStackSize.Add(randomStackSize);
            }

        }
    }
}