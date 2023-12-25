using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public sealed class ItemHolder
{
    public static ItemHolder Instance => _instance ??= new();
    public Queue<Item> Container => _itemContainer;
    public Vector3[] ItemPositions => _itemPositions.ToArray();

    private static ItemHolder _instance = null;
    private Queue<Item> _itemContainer = new Queue<Item>();
    private HashSet<Item> _itemChecker = new HashSet<Item>();
    private Queue<Vector3> _itemPositions = new Queue<Vector3>();

    public bool Add(in Item item)
    {
        if (_itemContainer.Count > 0 &&
            item.Status != _itemContainer.Peek().Status) return false;
        if (!_itemChecker.Add(item)) return false;

        _itemContainer.Enqueue(item);
        _itemPositions.Enqueue(item.transform.position);
        return true;
    }

    public bool HasContains(Item item)
    {
        return _itemChecker.Contains(item);
    }

    public void Clear()
    {
        _itemContainer.Clear();
        _itemChecker.Clear();
        _itemPositions.Clear();
    }
}
