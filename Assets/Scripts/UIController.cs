using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public VoiceControl voiceControl;
    private GameObject Player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        voiceControl = Player.GetComponent<VoiceControl>();
        rb.velocity = new Vector2(0, voiceControl.GetUIMoveSpeed());
        Destroy(gameObject, voiceControl.GetUIDuration());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Player.transform.position.x,transform.position.y);
    }
}
