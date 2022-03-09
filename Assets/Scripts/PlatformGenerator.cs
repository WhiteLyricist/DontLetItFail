using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _platformPrefab;

    private GameObject _platformFloor;
    private GameObject _platformRoof;

    private int _count = 10;

    private float _y = 4;

    public static Action<Transform> Scale = delegate { };

    void Start()
    {
        for (var i = 1; i <= _count/2; i++) 
        {
            _platformFloor = Instantiate(_platformPrefab) as GameObject;
            _platformRoof = Instantiate(_platformPrefab) as GameObject;

            Scale(_platformFloor.transform);
            Scale(_platformRoof.transform);

            _platformFloor.transform.position = new Vector2(((i - 2) * _platformFloor.GetComponent<ScalePlatform>().MaxSize), -_y);
            _platformRoof.transform.position = new Vector2(((i - 2) * _platformRoof.GetComponent<ScalePlatform>().MaxSize), _y);
        }
    }
}
