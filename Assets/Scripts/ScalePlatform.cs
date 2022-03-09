using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlatform : MonoBehaviour
{

    private float _minSize = 3;
    private float _maxSize = 10;
    public float MaxSize 
    {
        get => _maxSize;
    }
    private float _size;

    private void Awake()
    {
        MovePlatform.Scale += OnScale;
        PlatformGenerator.Scale += OnScale;
    }

    void OnScale(Transform _transform)
    {
        _size = Random.Range(_minSize, _maxSize);
        _transform.localScale = new Vector2(_size, _transform.localScale.y);
    }
      
    private void OnDestroy()
    {
        MovePlatform.Scale -= OnScale;
        PlatformGenerator.Scale += OnScale;
    }
}
