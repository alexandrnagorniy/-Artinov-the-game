using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    Rigidbody2D rb;
    public Transform cameraTransform;
    public float movement = 0f;
    public int tubeCol=0;
    public GameObject menu, next, resume, restart;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (cameraTransform.position.y - transform.position.y > 4)
        {
            gameObject.SetActive(false);
            menu.SetActive(true);
            restart.SetActive(true);
        }
        if (tubeCol >= 10)
        {
            menu.SetActive(true);
            next.SetActive(true);
            gameObject.SetActive(false);
        }

    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    
    public void GetTube()
    {
        tubeCol++;
    }

}
