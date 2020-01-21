using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float distance;
    public Vector3 pos;
    public Transform player;
    private int scoreString;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        distance = Vector3.Distance(player.position, pos);
    }

    // Update is called once per frame
    void Update()
    {
        score();
    }

    void score()
    {
        distance = Vector3.Distance(player.position, pos) / 4;
        scoreString = (int)distance;
        Debug.Log(scoreString);
    }
}
