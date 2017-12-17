using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : MonoBehaviour
{
	
	[SerializeField] private HeroInformation heroInformation =  new HeroInformation();
	public HeroInformation heroinfo
	{
		get
		{
			return heroInformation;
		}
	}
	[SerializeField] private Transform player;
	[SerializeField] private bool isCol;
	[SerializeField] private float time;
	[SerializeField] private float rotSpeed = 100.0f;
	[SerializeField] private DrawBar drawBar;
	[SerializeField] private HeroInformation.JumpState jumpState;
	// Use this for initialization
	void Start () {
		//heroInformation = Resources.Load("Script/Hero/Heroinformation", typeof(HeroInformation)) as HeroInformation;
		time = 0;
		player = GetComponent<Transform>();
		heroInformation = new HeroInformation();
		heroInformation.baseCharacterInformation = new BaseCharacterInformation();
		heroInformation.SetJumpSpeed(200);
		heroInformation.baseCharacterInformation.SetDamage(5);
		heroInformation.baseCharacterInformation.SetHP(100);
		heroInformation.baseCharacterInformation.SetMoveSpeed(10);
		drawBar = GameObject.Find("Canvas").GetComponent<DrawBar>();
		heroInformation.baseCharacterInformation.anim = GetComponent<Animator>();
		heroInformation.rigidbody = GetComponent<Rigidbody>();
}

	// Update is called once per frame
	void Update () {

		
		heroInformation.Move(player);
		player.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

		//player.Rotate(Vector3.left * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse Y"));

		heroInformation.baseCharacterInformation.SetPostion((player.transform.position));

		if (heroInformation.baseCharacterInformation.GetPostion().y <= 1f)
		{
			jumpState = HeroInformation.JumpState.OneJump;
		}

		if (Input.GetKeyDown(KeyCode.Space))
			heroInformation.Jump(ref jumpState,heroInformation.GetJumpSpeed());
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "monster")
		{
			if (!isCol)
			{
				heroInformation.baseCharacterInformation.SubtractionHP(
					collision.transform.GetComponent<MinionMonster>().miniMonster.basecharacterinformation.GetDamae());
				Debug.Log(heroInformation.baseCharacterInformation.GetHP());
				isCol = true;
			}


			if (heroInformation.baseCharacterInformation.IsDie())
			{
				Destroy(drawBar.GetHHeadUpPosition());
				Destroy(drawBar.GetHeroHPber());
				Destroy(gameObject);
			}
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		isCol = false;
		time = 0;
	}

	private void OnCollisionStay(Collision collision)
	{


		if (isCol)
		{
			Time.fixedDeltaTime = 0.017f;
			time += Time.fixedDeltaTime;
			if (collision.transform.GetComponent<MinionMonster>() != null)
			{
				if (time >= 1)
				{

					heroInformation.baseCharacterInformation.SubtractionHP(
						collision.transform.GetComponent<MinionMonster>().miniMonster.basecharacterinformation.GetDamae());
					Debug.Log(heroInformation.baseCharacterInformation.GetHP());
					time = 0;
				}

				if (heroInformation.baseCharacterInformation.IsDie())
				{
					Destroy(drawBar.GetHHeadUpPosition());
					Destroy(drawBar.GetHeroHPber());
					Destroy(gameObject);

				}
			}
		}
	}
}
