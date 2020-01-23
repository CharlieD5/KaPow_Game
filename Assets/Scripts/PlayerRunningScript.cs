using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunningScript : MonoBehaviour
{
    private GameObject _Player;
    private Rigidbody2D _PlayerRigidBody;
    private float speed;
    
    private float _Jump = 6f;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _PlayerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         _PlayerRigidBody.transform.position += Vector3.right * speed * Time.deltaTime;



        if (Input.GetKey(KeyCode.Q))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathZone")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void SetSpeed(float ISpeed)
    {
        
        speed = ISpeed;
        
    }
 
}
