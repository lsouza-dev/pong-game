using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    //[SerializeField] private int lifes = 3;
    //private float speed;
    //private Rigidbody2D rb;

    [SerializeField] private Vector2 dir;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float yOffset;

    private void Start()
    {
        
    }

    private void Update()
    {
        float optimizedVelocity = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * optimizedVelocity);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * optimizedVelocity);
        }

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -yOffset, yOffset));
        //TimeSpan.FromSeconds();
    }
}