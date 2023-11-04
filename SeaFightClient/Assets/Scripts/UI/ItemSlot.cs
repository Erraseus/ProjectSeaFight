using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Data
    public PlayerInventory PlayerInventory { get; set; }
    public bool IsFull { get; private set; }

    // Slot
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _quantityText;
    [SerializeField] private GameObject _selectShader;

    // Description
    private Image _descriptionIcon;
    private TMP_Text _descriptionName;
    private TMP_Text _descriptionText;

    
    [SerializeField] private bool _thisItemSelected;

    private CraftingMaterialSO _item;
    private int _quantity;

    private void Start()
    {
        _descriptionIcon = GameObject.Find("DescriptionIcon").GetComponent<Image>();
        _descriptionName = GameObject.Find("DescriptionName").GetComponent<TMP_Text>();
        _descriptionText = GameObject.Find("DescriptionText").GetComponent<TMP_Text>();
    }
    public void AddItem(CraftingMaterialSO item, int quantity)
    {
        this._item = item;
        this._quantity = quantity;
        IsFull = true;

        _icon.sprite = item.Icon;
        _quantityText.text = quantity.ToString();
        _quantityText.enabled = true;   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!IsFull)
            {
                PlayerInventory.DeselectAllSlots();
            }
            if (IsFull)
            {
                SelectSlot();
            }
            
        }
    }

    private void SelectSlot()
    {
        
        PlayerInventory.DeselectAllSlots();
        _selectShader.SetActive(true);
        _thisItemSelected = true;

        _descriptionIcon.sprite = _item.Icon;
        _descriptionName.text = _item.Name;
        _descriptionText.text = _item.Description;
    }
    
    public void DeselectSlot()
    {
        _selectShader.SetActive(false);
        _thisItemSelected = false;
    }
}