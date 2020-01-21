using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{

    //public float Thrust = 1.0f;
    public GameObject Bullet;
    public GameObject[] UIPrefabs;

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
    public float UIDuration = 3;
    public float UIMoveSpeed = 3;

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
    private int _UIID;
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

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
       // StringBuilder builder = new StringBuilder();
       // builder.AppendFormat("{0} ({1}){2}", speech.text, speech.confidence, Environment.NewLine);
       // builder.AppendFormat("\tTimestamp: {0}{1}", speech.phraseStartTime, Environment.NewLine);
       // builder.AppendFormat("\tDuration: {0} seconds{1}", speech.phraseDuration.TotalSeconds, Environment.NewLine);
       // Debug.Log(builder.ToString());

    }


    // This is where we set the action that happens when this word is said

    // Magic Power
    private void Zap()
    {
        _UIID = 4;
        transform.Translate(1, 0, 0);
    }

    // Punch
    private void Smash()
    {
        _UIID = 3;
        //play player animation here.
        if (_IsPlayerReadyToPunch == true)
        {
            Instantiate(UIPrefabs[_UIID], new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y + 5, 0), Quaternion.identity);
            //destroy the object here
            Destroy(_BoxToDestory);
            _BoxToDestory = null;
            _IsPlayerReadyToPunch = false;
        }
    }

    // Shoot
    private void Pew()
    {
        _UIID = 1;
        if (_IsPlayerReadyToShoot == true)
        {
            Instantiate(UIPrefabs[_UIID], new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y + 5, 0), Quaternion.identity);
            var temp = Instantiate(Bullet,PlayerBody.transform.position,Quaternion.identity);
         
        }
    }

    // Stop
    private void Skrrt()
    {
        _UIID = 2;
        if (_IsPlayerSlow == false)
        {
            Instantiate(UIPrefabs[_UIID], new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y + 5, 0), Quaternion.identity);
            Running.SetSpeed(SlowSpeed);
            _IsPlayerSlow = true;
            StartCoroutine("CalculateTime");
        }
    }

    // Jump
    private void KaBoom()
    {
        _UIID = 0;
        // Debug.Log(_IsPlayerGrounded);
        if (_IsPlayerGrounded)
        {
            Instantiate(UIPrefabs[_UIID], new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y + 5, 0), Quaternion.identity);
            PlayerBody.AddForce(Vector3.up * Jump, ForceMode2D.Impulse);
            _IsPlayerGrounded = false;
        }
    }

    // Slide under object
    private void Swoosh()
    {
        _UIID = 6;
        if (_IsPlayerSliding==false)
        {
            Instantiate(UIPrefabs[_UIID], new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y+5,0), Quaternion.identity);
            Running.SetSpeed(Speed+ SlideSpeed);
            _PlayerCurrentX = PlayerBody.transform.position.x;
            _IsPlayerSliding = true;
        }
    }

    // Speed Boost
    private void Zoom()
    {
        _UIID = 5;
        Instantiate(UIPrefabs[_UIID], new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y + 5, 0), Quaternion.identity);
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
    public float GetUIDuration()
    {
        return UIDuration;
    }
    public float GetUIMoveSpeed()
    {
        return UIMoveSpeed;
    }
}
