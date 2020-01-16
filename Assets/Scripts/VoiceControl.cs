using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
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
        transform.Translate(1, 0, 0);
    }

    // Shoot
    private void Pew()
    {
        transform.Translate(1, 0, 0);
    }

    // Stop
    private void Skrrt()
    {
        transform.Translate(-1, 0, 0);
    }

    // Jump
    private void KaBoom()
    {
        transform.Translate(0, 1, 0);
    }

    // Slide under object
    private void Swoosh()
    {
        transform.Translate(0, -1, 0);
    }

    // Speed Boost
    private void Zoom()
    {
        transform.Translate(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
