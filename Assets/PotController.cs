using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class PotController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;

    private void Update()
    {
        transform.Rotate(0f, 0f, -_rotateSpeed);
    }
}
