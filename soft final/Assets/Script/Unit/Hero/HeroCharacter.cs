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
	[SerializeField] private bool isCollision;
	[SerializeField] private float time;
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
		heroInformation.baseCharacterInformation.anim = GameObject.Find("Soldier").GetComponent<Animator>();
		heroInformation.rigidbody = GetComponent<Rigidbody>();

}

	// Update is called once per frame
	void Update () {

		
		heroInformation.Move(player);
		player.Rotate(Vector3.up * Time.deltaTime * heroInformation.RotSpeed * Input.GetAxis("Mouse X"));
		//player.Rotate(Vector3.left * Time.deltaTime * heroInformation.RotSpeed * Input.GetAxis("Mouse Y"));

		heroInformation.baseCharacterInformation.SetPostion((player.transform.position));

		if (heroInformation.baseCharacterInformation.GetPostion().y <= 1f)
		{
			jumpState = HeroInformation.JumpState.OneJump;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			heroInformation.Jump(ref jumpState, heroInformation.GetJumpSpeed());
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "monster")
		{
			if (!isCollision)
			{
				heroInformation.baseCharacterInformation.SubtractionHP(
					collision.transform.GetComponent<MinionMonster>().miniMonster.basecharacterinformation.GetDamae());
				Debug.Log(heroInformation.baseCharacterInformation.GetHP());

				for (int i = 0; i < drawBar.GetSliderHListHPber().Count; i++)
				{
					if (heroInformation.baseCharacterInformation.IsDie(i))
					{
						Destroy(drawBar.GetHHeadUpPosition(i));
						Destroy(drawBar.GetHeroHPber(i));
						Destroy(gameObject);

						drawBar.RemoveHeroList(i);
					}
				}
				isCollision = true;
			}



		}
	}

	private void OnCollisionExit(Collision collision)
	{
		isCollision = false;
		time = 0;
	}

	private void OnCollisionStay(Collision collision)
	{


		if (isCollision)
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

				for (int i = 0; i < drawBar.GetSliderHListHPber().Count; i++)
				{
					if (heroInformation.baseCharacterInformation.IsDie(i))
					{
						Destroy(drawBar.GetHHeadUpPosition(i));
						Destroy(drawBar.GetHeroHPber(i));
						Destroy(gameObject);

						drawBar.RemoveHeroList(i);
					}
				}
			}
		}
	}
}
