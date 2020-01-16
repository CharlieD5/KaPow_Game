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
        // "Boing"
        actions.Add("boing", Boing);
        actions.Add("boy", Boing);
        actions.Add("bong", Boing);
        actions.Add("oi", Boing);
        actions.Add("boeing", Boing);

        // "Pew-Pew"
        actions.Add("pew", Pew);
        actions.Add("pew pew", Pew);
        actions.Add("Q", Pew);
        actions.Add("QQ", Pew);
        actions.Add("cute", Pew);
        actions.Add("cute cute", Pew);
        actions.Add("pikachu", Pew);

        // "Zoom"
        actions.Add("zoom", Zoom);

        // "Pow"
        actions.Add("Powell", Pow);
        actions.Add("pow", Pow);
        actions.Add("Bow", Pow);
        actions.Add("how", Pow);

        // "Zap"
        actions.Add("zap", Zap);
        actions.Add("zep", Zap);

        // "Skrrt"
        actions.Add("skirt", Skrrt);
        actions.Add("shirt", Skrrt);

        // "Swoosh"
        actions.Add("swoosh", Swoosh);
        actions.Add("swish", Swoosh);
        actions.Add("toosh", Swoosh);
        actions.Add("switch", Swoosh);
        actions.Add("search", Swoosh);


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
        transform.Translate(-1, 0, 0);
    }

    private void Boing()
    {
        transform.Translate(0, 1, 0);
    }

    private void Swoosh()
    {
        transform.Translate(0, -1, 0);
    }

    private void Zoom()
    {
        transform.Translate(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
