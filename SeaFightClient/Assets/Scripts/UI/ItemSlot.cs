using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public bool IsFull { get; private set; }
    public CraftingMaterialSO Item { get { return _item; } set { _item = value; } }
    public int Quantity { get { return _quantity; } set { _quantity = value; } }
    
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _quantityTextField;
    [SerializeField] private TMP_Text _quantityText;
    [SerializeField] private GameObject _selectShader;

    [Header("Slot Info")]
    [SerializeField] private CraftingMaterialSO _item;
    [SerializeField] private int _quantity;

    public void UpdateItemSlot(CraftingMaterialSO item, int quantity)
    {
        if (!_quantityTextField.activeInHierarchy) _quantityTextField.SetActive(true);
        _quantity += quantity;
        _icon.sprite = item.Icon;
        _quantityText.text = _quantity.ToString();
        
    }
}