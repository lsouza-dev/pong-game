using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecondPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float yOffset;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;
    [SerializeField] private bool isMultiplayer;

    [SerializeField] private Transform transformBall;


    [SerializeField] private float yLerp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float optimizedVelocity =  speed * Time.deltaTime;

        
        


        if (isMultiplayer)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * optimizedVelocity);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector2.down * optimizedVelocity);
            }

            if (Input.GetKey(KeyCode.Return))
            {
                isMultiplayer = false;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, transformBall.position.y,yLerp));

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                isMultiplayer = true;
            }
        }

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -yOffset, yOffset));
    }
}
