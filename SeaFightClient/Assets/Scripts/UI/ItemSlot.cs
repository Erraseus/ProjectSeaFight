using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class ItemSlot : MonoBehaviour
{
    [Header("Item Icon")]
    [SerializeField] private Image _background;
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite[] _itemBackground;
    [Header("Item Quantity")]
    [SerializeField] private GameObject _quantityTextField;
    [SerializeField] private TMP_Text _quantityText;
    [Space]
    [SerializeField] private GameObject _selectShader;
    
    public void UpdateItemSlot(IInventoryItem item, int quantity)
    {
        _background.sprite = _itemBackground[(int)item.Rarity];
        _icon.sprite = item.Icon;

        _quantityText.text = quantity.ToString();

        if (quantity > 0) _quantityTextField.SetActive(true);
        else _quantityTextField.SetActive(false);
    }
}