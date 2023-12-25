using UnityEngine;

// 日本語対応
public class Item : MonoBehaviour
{
    public ItemStatus Status => _myStatus;

    [SerializeField] private ItemStatus _myStatus = ItemStatus.None;
    [SerializeField] private Sprite _water = null;
    [SerializeField] private Sprite _rice = null;
    [SerializeField] private Sprite _meltedRice = null;

    private SpriteRenderer _myRenderer = null;

    private void OnValidate()
    {
        if (!TryGetComponent(out _myRenderer)) return;

        SetSprite();
    }

    private void Start()
    {
        if (_myRenderer == null && !TryGetComponent(out _myRenderer))
            throw new System.NullReferenceException("SpriteRenderer is not found");

        SetSprite();
    }

    public void Initialize(ItemStatus status)
    {
        _myStatus = status;
    }

    private void SetSprite()
    {
        _myRenderer.sprite = _myStatus switch
        {
            ItemStatus.Water => _water,
            ItemStatus.Rice => _rice,
            ItemStatus.MeltedRice => _meltedRice,
            _ => null,
        };
    }
}

public enum ItemStatus
{
    None = -1,
    Water = 0,
    Rice = 1,
    MeltedRice = 2,
}