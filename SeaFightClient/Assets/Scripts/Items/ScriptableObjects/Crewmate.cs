using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Craftable/Crewmate", fileName = "new Crewmate")]
public class Crewmate : ScriptableObject, IItem
{
    #region Properties
    //Item
    public int Id => _id;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Rarities Rarity => _rarity;
    public string Description => _description;
    //Crewmate
    public CrewmateBonus CrewmateBonus => _crewmateBonus;
    public float CrewmateBonusValue => _crewmateBonusValue;
    #endregion

    [Header("Item Settings")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Rarities _rarity;
    [SerializeField][TextArea] private string _description;

    [Header("Crewmate Settings")]
    [SerializeField] private CrewmateBonus _crewmateBonus;
    [SerializeField] private float _crewmateBonusValue;
}