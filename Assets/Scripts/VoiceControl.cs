﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{

    //public float Thrust = 1.0f;
    public GameObject Bullet;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public PlayerRunningScript Running;
    [Header("Player Settings")]
    public float Speed = 5;
    public float Jump = 5;
    public float dashDistance = 5;
    public float SlowDuration = 4;
    public float SlowSpeed = 1;
    public float SlideDistance = 3;
    public float SlideSpeed = 4;
    public float ShootIntervel = 3;

    private Rigidbody2D PlayerBody;

    
    private bool _IsPlayerGrounded = true;
    private bool _IsPlayerSlow = false;
    private bool _IsPlayerReadyToPunch = false;
    private bool _IsPlayerSliding = false;
    private bool _IsPlayerReadyToShoot = true;
    private float _InitialSpeed;
    private float _PlayerCurrentX;
    private GameObject[] _BulletSpawned;
    private GameObject _BoxToDestory;
    // Start is called before the first frame update
    void Start()
    {
        Running.SetSpeed(Speed);
        PlayerBody = GetComponent<Rigidbody2D>();
         
        // "Smash"
        actions.Add("smash", Smash);
        actions.Add("snatch", Smash);

        // "KaBoom"
        actions.Add("boom", KaBoom);
        actions.Add("kaboom", KaBoom);
        
        // "Boing"
        /* actions.Add("boing", Boing);
         actions.Add("boy", Boing);
         actions.Add("bong", Boing);
         actions.Add("oi", Boing);
         actions.Add("Boeing", Boing);
         actions.Add("bring", Boing);
         actions.Add("bling", Boing);
         actions.Add("wing", Boing);
         actions.Add("coin", Boing);
         actions.Add("boring", Boing);
         actions.Add("ring", Boing); */

        // "Pew-Pew"
        actions.Add("pew", Pew);
        actions.Add("pew pew", Pew);
        actions.Add("q", Pew);
        actions.Add("Puma", Pew);
        actions.Add("Q", Pew);
        actions.Add("QQ", Pew);
        actions.Add("cute", Pew);
        actions.Add("cute cute", Pew);
        actions.Add("Pikachu", Pew);
        actions.Add("pill", Pew);

        // "Zoom"
        actions.Add("zoom", Zoom);
        actions.Add("Zen", Zoom);
        actions.Add("resume", Zoom);

        // "Pow"
        /*actions.Add("Powell", Pow);
        actions.Add("pow", Pow);
        actions.Add("Bow", Pow);
        actions.Add("how", Pow);
        actions.Add("wow", Pow);
        actions.Add("Paul", Pow);*/

        // "Zap"
        actions.Add("zap", Zap);
        actions.Add("zep", Zap);
        actions.Add("Zach", Zap); // ?

        // "Skrrt"
        actions.Add("skirt", Skrrt);
        actions.Add("skrt", Skrrt);
        actions.Add("shirt", Skrrt);

        // "Swoosh"
        actions.Add("swoosh", Swoosh);
        actions.Add("swish", Swoosh);
        actions.Add("toosh", Swoosh);
        actions.Add("switch", Swoosh);
        actions.Add("search", Swoosh);
        actions.Add("sushi", Swoosh);

        actions.Add("forward", Forward);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }


    // This is where we set the action that happens when this word is said
    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }

    // Magic Power
    private void Zap()
    {
        transform.Translate(1, 0, 0);
    }

    // Punch
    private void Smash()
    {
        //play player animation here.
        if (_IsPlayerReadyToPunch == true)
        {
            //destroy the object here
            Destroy(_BoxToDestory);
            _BoxToDestory = null;
            _IsPlayerReadyToPunch = false;
        }
    }

    // Shoot
    private void Pew()
    {
        if (_IsPlayerReadyToShoot == true)
        {
            var temp = Instantiate(Bullet,PlayerBody.transform.position,Quaternion.identity);
         
        }
    }

    // Stop
    private void Skrrt()
    {
        if (_IsPlayerSlow == false)
        {
            Running.SetSpeed(SlowSpeed);
            _IsPlayerSlow = true;
            StartCoroutine("CalculateTime");
        }
    }

    // Jump
    private void KaBoom()
    {
        Debug.Log(_IsPlayerGrounded);
        if (_IsPlayerGrounded)
        {
            
            PlayerBody.AddForce(Vector3.up * Jump, ForceMode2D.Impulse);
            _IsPlayerGrounded = false;
        }
    }

    // Slide under object
    private void Swoosh()
    {
        if (_IsPlayerSliding==false)
        {
            Running.SetSpeed(Speed+ SlideSpeed);
            _PlayerCurrentX = PlayerBody.transform.position.x;
            _IsPlayerSliding = true;
        }
    }

    // Speed Boost
    private void Zoom()
    {
        PlayerBody.transform.position += new Vector3(dashDistance, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Ground")
        {
           
            _IsPlayerGrounded = true;
        }
        if (collision.gameObject.tag == "Box")
        {
            
            _BoxToDestory = collision.gameObject;
            _IsPlayerReadyToPunch = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        if (_IsPlayerSliding == true && ((_PlayerCurrentX+SlideDistance)-PlayerBody.transform.position.x)<0.0)
        {
            _IsPlayerSliding = false;
            Running.SetSpeed(Speed);
        }
    }

    IEnumerator CalculateTime()
    {
       
            yield return new WaitForSecondsRealtime(SlowDuration);
            Running.SetSpeed(Speed);
            _IsPlayerSlow = false;
        
    }
    IEnumerator ShootTimer()
    {
        yield return new WaitForSecondsRealtime(ShootIntervel);
        _IsPlayerReadyToShoot = true;
    }
}
