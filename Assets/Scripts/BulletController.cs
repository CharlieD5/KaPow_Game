using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 20f;
    private GameObject Player;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        rb.velocity = new Vector2(bulletSpeed, 0);
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
