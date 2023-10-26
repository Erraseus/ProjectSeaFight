using UnityEngine;

[CreateAssetMenu(menuName = "Components/Sail", fileName = "NewSail")]
public class SailSO : ScriptableObject
{
    public int id;
    [Space]
    [Header("General Information")]
    public new string name;
    public Sprite icon;
    [Space]
    [Header("Specific Information")]
    public float speed;
}