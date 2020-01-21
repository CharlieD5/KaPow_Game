using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
