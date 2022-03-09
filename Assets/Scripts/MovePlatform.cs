using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlatform : MonoBehaviour
{

    public static Action<Transform> Scale = delegate { }; 

    private float _speed = 3;

    private float _newPositionX = 30f;

    void Update()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Finish")
        {
            Scale(gameObject.transform);
            transform.position = new Vector2(_newPositionX, transform.position.y);
        }
    }

}