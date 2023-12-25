using System.Collections;
using UnityEngine;

// 日本語対応
public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private float _generateInterval = 1.0f;
    [SerializeField] private int _initialGenerateCount = 45;
    [SerializeField] private Item _item = null;
    [SerializeField] private Transform _target = null;
    [SerializeField] private float _generateAreaRadius = 5.0f;

    private Vector3 _generateCenter = Vector2.zero;

    private void Start()
    {
        _generateCenter = _target ? _target.position : transform.position;

        for (int i = 0; i < _initialGenerateCount; i++)
        {
            Generate(_item);
        }
        StartCoroutine(IntervalGenerateAsync(_generateInterval));
    }

    private IEnumerator IntervalGenerateAsync(float interval)
    {
        for (float t = 0.0f; true; t += Time.deltaTime)
        {
            if (t > interval)
            {
                t = 0.0f;
                Generate(_item);
            }
            yield return null;
        }
    }

    private Item Generate(Item item)
    {
        item.Initialize((ItemStatus)Random.Range(0, 3));
        return Instantiate(item, 
            RandomPosInCircle(_generateCenter, _generateAreaRadius), Quaternion.identity, transform);
    }

    private Vector2 RandomPosInCircle(Vector2 center, float radius)
    {
        return new Vector2(center.x + Random.Range(-radius, radius), center.y + Random.Range(-radius, radius));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_target ? _target.position : transform.position, _generateAreaRadius);
    }
}
