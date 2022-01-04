using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class SDKLANG : MonoBehaviour
{
    public Text _textLanguage;
    public Text Languages;
    private SDKLANG SDK;
    
    [DllImport("__Internal")] private static extern void ProjectStarted();
    
    // Создание SINGLETON
    private static SDKLANG _instance;
    public static SDKLANG Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SDKLANG>();
            
            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ProjectStarted();
    }



    public void GettingLang(string lang)
    {
        print(lang);
        SetLang(lang);
    }
    
    private void SetLang(string _lang)
    {
        var json = JSON.Parse(_lang);
        string lang = json["browser"]["lang"];
        _textLanguage.text = lang;
        Languages.text = "Error";
        print(lang);
        switch (lang)
        {
            case"ru":
                Languages.text = "Русский";
                break;
            case"en":
                Languages.text = "English";
                break;
        }
    }
}
