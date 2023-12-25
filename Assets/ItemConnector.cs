using UnityEngine;

// 日本語対応
public class ItemConnector : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRend = null;

    private void Update()
    {
        _lineRend.positionCount = ItemHolder.Instance.ItemPositions.Length;
        _lineRend.SetPositions(ItemHolder.Instance.ItemPositions);
    }
}
