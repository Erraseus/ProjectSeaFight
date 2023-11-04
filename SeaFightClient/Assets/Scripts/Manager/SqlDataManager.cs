using UnityEngine;

public class SqlDataManager : MonoBehaviour
{
    #region Singleton
    private static SqlDataManager _singleton;
    public static SqlDataManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(SqlDataManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
    }
    #endregion
    // Data from SqlDatabase
    public int SqlGoldAmmount { get; private set; }
    public int[] SqlInventorySlot { get; private set; }
    public int[] SqlItemId { get; private set; }
    public int[] SqlItemQuantity { get; private set; }


}