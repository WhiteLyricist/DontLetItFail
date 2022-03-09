using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBall : MonoBehaviour
{
    private Touch _touch;

    private float _speed = 5;

    public static Action EndGame = delegate { };

    void Update()
    {

        transform.position = new Vector2(transform.position.x, transform.position.y - _speed * Time.deltaTime);

        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject()) 
        {
            _touch = Input.GetTouch(0);

            var touch = Camera.main.ScreenToWorldPoint(_touch.position);

            if (_touch.phase == TouchPhase.Began) 
            {
                if (touch.y > transform.position.y)
                {
                    _speed = -_speed;
                }
                if (touch.y < transform.position.y)
                {
                    _speed = -_speed;

                }
            }

            if (_speed > 0)
            {
                _speed += 0.01f;
            }
            else 
            {
                _speed -= 0.01f;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _speed = -_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndGame();
        Destroy(gameObject);
    }

}
