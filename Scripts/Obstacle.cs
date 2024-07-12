using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;
    [SerializeField] private float posY;
    [SerializeField] private float yOffset;
    [SerializeField] private bool descendo = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= yOffset)
        {
            descendo = true;
        }
        else if (transform.position.y <= -yOffset)
        {
            descendo = false;
        }

        if (descendo)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
