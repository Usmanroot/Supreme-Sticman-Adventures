using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float speed;
     public Transform player;
     private Rigidbody2D rb;
     private CircleCollider2D radius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player")
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision2D) {
        if(collision2D.gameObject.tag == "Player")
        {
            
        }
    }
}
