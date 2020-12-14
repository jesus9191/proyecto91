using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public GameObject tiendaMenu;
	public GameObject tienda;
	public GameObject bullet;

	public Button buttonrifle;
	public Button buttonshotgun;
	public int score = 0;
	public float coins = 0;
	public Text textCoins;

	public Text textscore;
	public int currentAmmo = 10;
	public Text TextAmmo;
	public bool rifleUnlocked = false;
	public bool shotgunUnlocked = false;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	//bool dashAxis = false;

	// Update is called once per frame
	void Update()
	{


		if (tiendaMenu.activeSelf == false)
		{

			if (Vector3.Distance(this.transform.position, tienda.transform.position) < 2 && Input.GetKeyDown(KeyCode.T))

			{

				tiendaMenu.SetActive(true);

			}
			if (Input.GetKeyDown(KeyCode.Q))

			{
				ControlCoins(1000);

			}
		}
		{

			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (Input.GetKeyDown(KeyCode.Z))
			{
				jump = true;
			}

			if (Input.GetKeyDown(KeyCode.C))
			{
				dash = true;
			}

			/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
			{
				if (dashAxis == false)
				{
					dashAxis = true;
					dash = true;
				}
			}
			else
			{
				dashAxis = false;
			}
			*/

		}
	}
		public void OnFall()
		{
			animator.SetBool("IsJumping", true);
		}

		public void OnLanding()
		{
			animator.SetBool("IsJumping", false);
		}

		void FixedUpdate()
		{
			// Move our character
			controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
			jump = false;
			dash = false;
		}

		public void SumScore(int scoreToSum)
		{
			score = score + scoreToSum;
			textscore.text = "SCORE: " + score;
		}

		public void ControlCoins(int CoinsToWin)
		{
			coins += CoinsToWin;

			textCoins.text = "$$: " + coins;
		}
		public void ControlAmmo(int AmmoGiven)
		{
			currentAmmo += AmmoGiven;

			TextAmmo.text = "// " + currentAmmo;
		}
	
}

