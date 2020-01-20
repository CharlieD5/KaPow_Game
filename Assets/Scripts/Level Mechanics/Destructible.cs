using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject DestroyedVersion;
    private void OnMouseDown() // Change Function to be called when Player Attacks the Destructible Object
    {
        Instantiate(DestroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
