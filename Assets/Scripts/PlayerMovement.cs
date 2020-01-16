using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public GameObject CharacterToMove;  //Assign Player Character in Editor
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public float Thrust = 1.0f;
    public Rigidbody PlayerBody;





    void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();

        // "Boing" - Jump
        actions.Add("boing", Boing);
        actions.Add("boy", Boing);
        actions.Add("bong", Boing);
        actions.Add("oi", Boing);
        actions.Add("boeing", Boing);

        // "Pew-Pew" - Shoot
        actions.Add("pew", Pew);
        actions.Add("pew pew", Pew);
        actions.Add("Q", Pew);
        actions.Add("QQ", Pew);
        actions.Add("cute", Pew);
        actions.Add("cute cute", Pew);
        actions.Add("pikachu", Pew);

        // "Zoom" - Speed Up
        actions.Add("zoom", Zoom);

        // "Pow" - Punch
        actions.Add("Powell", Pow);
        actions.Add("pow", Pow);
        actions.Add("Bow", Pow);
        actions.Add("how", Pow);

        // "Zap" - Lightning Bolt
        actions.Add("zap", Zap);
        actions.Add("zep", Zap);

        // "Skrrt" - Slow Down
        actions.Add("skirt", Skrrt);
        actions.Add("shirt", Skrrt);

        // "Swoosh" - Duck
        actions.Add("swoosh", Swoosh);
        actions.Add("swish", Swoosh);
        actions.Add("toosh", Swoosh);
        actions.Add("switch", Swoosh);
        actions.Add("search", Swoosh);

    }

    //Detected Actions will be Executed Here
    private void Zap()
    {
        transform.Translate(1, 0, 0);
    }

    private void Pow()
    {
        transform.Translate(1, 0, 0);
    }

    private void Pew()
    {
        transform.Translate(1, 0, 0);
    }

    private void Skrrt()
    {
        PlayerBody.AddForce(-Thrust, 0.0f, 0.0f, ForceMode.Force);
    }

    private void Boing()
    {
        PlayerBody.AddForce(0.0f, Thrust, 0.0f, ForceMode.Force);
    }

    private void Swoosh()
    {
        transform.Translate(0, -1, 0);
    }

    private void Zoom()
    {
        PlayerBody.AddForce(Thrust, 0.0f, 0.0f, ForceMode.Force);
    }


}
