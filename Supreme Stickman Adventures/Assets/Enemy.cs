using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float speed;

     private Rigidbody2D rb;
     private Collision2D radius;
     public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        radius = GetComponent<Collision2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
