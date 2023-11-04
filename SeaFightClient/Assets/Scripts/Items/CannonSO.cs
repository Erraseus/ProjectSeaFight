using UnityEngine;

[CreateAssetMenu(menuName = "Components/Cannon", fileName = "NewCannon")]
public class CannonSO : ScriptableObject, IItem
{
    [Header("General Information")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField][TextArea(minLines: 4, maxLines: 4)] private string _description;
    [Space]
    [Header("Specific Information")]
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    [SerializeField] private float _reloadTime;
    [Space]
    [SerializeField][Range(0f, 100f)] private float _hitchance;
    [SerializeField][Range(0f, 100f)] private float _critchance;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public string Description { get { return _name; } }
    public int Damage { get { return _damage; } }
    public float Range { get { return _range; } }
    public float ReloadTime { get { return _reloadTime; } }
    public float Hitchance { get { return _hitchance; } }
    public float Critchance { get { return _critchance; } }
}