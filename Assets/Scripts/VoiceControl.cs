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
        actions.Add("pew", Boing);
        actions.Add("pew pew", Boing);
        actions.Add("Q", Boing);
        actions.Add("QQ", Boing);
        actions.Add("cute", Boing);
        actions.Add("cute cute", Boing);
        actions.Add("pikachu", Boing);

        // "Zoom"
        actions.Add("zoom", Zoom);

        // "Pow"
        actions.Add("Powell", Zoom);
        actions.Add("pow", Zoom);
        actions.Add("Bow", Zoom);
        actions.Add("how", Zoom);

        // "Zap"
        actions.Add("zap", Zoom);
        actions.Add("zep", Zoom);

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

    private void Forward()
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
