using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private GameObject _Player;
    public float CameraSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(_Player.transform.position.x + 3, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
        
        if ((transform.position.x - _Player.transform.position.x) > 18.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
