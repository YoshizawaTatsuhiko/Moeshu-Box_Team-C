using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class Player : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private int _maxRaycastCount = 5;

    private Vector2 _cameraPos = Vector2.zero;
    private RaycastHit2D[] _hitResults2D = null;

    private void Start()
    {
        _cameraPos = _mainCamera.transform.position;
        _hitResults2D = new RaycastHit2D[_maxRaycastCount];
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            int n = Physics2D.LinecastNonAlloc(_cameraPos, mousePos, _hitResults2D);
            Debug.DrawLine(_cameraPos, mousePos);

            for (int i = 0; i < n; i++)
            {
                if (!_hitResults2D[i].collider.TryGetComponent(out Item item)) continue;
                if (ItemHolder.Instance.Add(item)) Debug.Log($"Add {item.name}");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            DestroyObj();
        }
    }

    private static void DestroyObj()
    {
        if (ItemHolder.Instance.Container.Count > 1)
        {
            while (ItemHolder.Instance.Container.Count > 0)
            {
                var item = ItemHolder.Instance.Container.Dequeue();
                Debug.Log($"Destroy {item.name}");
                Destroy(item.gameObject);
            }
        }
        ItemHolder.Instance.Clear();
    }
}