using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour

{
    public CharacterController2D player;

    public ProgressBar Pb;
    [Header("Title Setting")]
    public string Title;
    public Color TitleColor;
    public Font TitleFont;
    public int TitleFontSize = 10;

    [Header("Bar Setting")]
    public Color BarColor;
    public Color BarBackGroundColor;
    public Sprite BarBackGroundSprite;
    [Range(0, 1)]
    public float Alert = 0.2f;
    public Color BarAlertColor;

    [Header("Sound Alert")]
    public AudioClip sound;
    public bool repeat = false;
    public float RepeatRate = 1f;

    private Image bar, barBackground;
    private float nextPlay;
    private AudioSource audiosource;
    private Text txtTitle;
    private float barValue;
    bool currenlyOnAlert;
    public float BarValue
    {
        get { return barValue; }

        set
        {
            value = Mathf.Clamp(value, 0, 100);
            barValue = value;
            UpdateValue(barValue);
            
        }
    }

        

    private void Awake()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
        barBackground = GetComponent<Image>();
        txtTitle = transform.Find("Text").GetComponent<Text>();
        barBackground = transform.Find("BarBackground").GetComponent<Image>();
        audiosource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        
        txtTitle.text = Title;
        txtTitle.color = TitleColor;
        txtTitle.font = TitleFont;
        txtTitle.fontSize = TitleFontSize;

        bar.color = BarColor;
        barBackground.color = BarBackGroundColor; 
        barBackground.sprite = BarBackGroundSprite;

       

    }

    void UpdateValue(float val)
    {
        bar.fillAmount = val;
        txtTitle.text = Title + " " + Mathf.RoundToInt( val*100) + "%";

        if (Alert >= val && currenlyOnAlert ==false)
        {
            bar.color = BarAlertColor;
            audiosource.clip = sound;
            audiosource.Play();
            currenlyOnAlert = true;
        }
        else if (Alert < val)
        {
            bar.color = BarColor;
            currenlyOnAlert = false;
        }

    }


    private void Update()
    {
                  
            UpdateValue(player.life/player.maxlife);


        
    }

}
