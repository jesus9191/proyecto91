using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaControl : MonoBehaviour
{


    PlayerMovement player;
    public GameObject tiendaMenu;
    public GameObject tienda;
    public GameObject bullet;

    public Button buttonrifle;
    public Button buttonshotgun;
    public GameObject fuentedesonido;

    public Text textscore;


    public float coins = 0;
    public Text textCoins;
 
    float cdNoDamage;
    float currrentNoDamageCD;
    float CDbullet;
  
    public int score = 0;
    SpriteRenderer spriteRenderer;
    public GameObject[] weapon;
    public int currentAmmo = 10;
    public Text TextAmmo;
    public AudioClip buy;
    public AudioClip reload;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        textscore.text = "SCORE: " + score;
        textCoins.text = "$$: " + coins;
        TextAmmo.text = "// " + currentAmmo;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }


 
            public void buyrifle ()
    {

        if (player.coins >= 2000)
        {
            GameObject fuenteACambiar = Instantiate(fuentedesonido, this.transform.position, Quaternion.identity);
            fuenteACambiar.GetComponent<AudioSource>().clip = reload;
            fuenteACambiar.GetComponent<AudioSource>().Play();
            player.ControlCoins(-2000);
            player.rifleUnlocked = true;
            buttonrifle.interactable = false;
        }
    }
    
    
    public void buyshogun ()
    {
        if (player.coins >= 1000)
        {
            GameObject fuenteACambiar = Instantiate(fuentedesonido, this.transform.position, Quaternion.identity);
            fuenteACambiar.GetComponent<AudioSource>().clip = reload;
            fuenteACambiar.GetComponent<AudioSource>().Play();
            player.ControlCoins(-1000);
            player.rifleUnlocked = true;
            buttonshotgun.interactable = false;
        }

    }

    public void buyammo()

    {
        if (player.coins >= 500)
        {
            GameObject fuenteACambiar = Instantiate(fuentedesonido, this.transform.position, Quaternion.identity);
            fuenteACambiar.GetComponent<AudioSource>().clip = buy;
            fuenteACambiar.GetComponent<AudioSource>().Play();
            player.ControlCoins(-500);
            player.ControlAmmo(20);
        }

                }



}
