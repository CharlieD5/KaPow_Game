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
        actions.Add("forward", Forward);
        actions.Add("boing", Boing);
        actions.Add("down", Down);
        actions.Add("back", Back);
        actions.Add("skirt", Skirt);
        actions.Add("dash", Dash);

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

    private void Dash()
    {
        transform.Translate(5, 0, 0);
    }


    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Boing()
    {
        transform.Translate(0, 1, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }

    private void Skirt()
    {
        transform.Translate(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
