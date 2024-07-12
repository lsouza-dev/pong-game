using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xOffset;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 dir;
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform target;
    [SerializeField] private float speedRotation;
    [SerializeField] private float maxSpeed;
    [SerializeField] private AudioClip collisionSound;
    private float posX;

    private float time;
    // Start is called before the first frame update


    void Start()
    {
        int direction = UnityEngine.Random.Range(0, 4);
        
        switch (direction)
        {
            // -x = esquerda | +x =  direita // -y = baixo | +y = cima
          
            case 0:
                dir = new Vector2(-speed,speed); 
                break;
            case 1:
                dir = new Vector2(speed, speed);
                break;
            case 2:
                dir = new Vector2(-speed, -speed);
                break;
            case 3:
                dir = new Vector2(speed, -speed);
                break;
        }

        rb.velocity = dir;
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;

        if (posX >= xOffset || posX <= -xOffset)
        {
            RestarGame();
        }

        transform.eulerAngles += new Vector3(0, 0, speedRotation);

        rb.velocity  = Vector3.ClampMagnitude(rb.velocity,maxSpeed);
    }

    private void RestarGame()
    {
        time += Time.deltaTime;
        int seconds = Convert.ToInt32(time % 60);

        if (time >= 1)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(collisionSound,Camera.main.transform.position);
    }
}
