using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMonster : MonoBehaviour{

	private MonsterInformation minionMonster;
	public MonsterInformation miniMonster
	{
		get
		{
			return minionMonster;
		}
	}

	[SerializeField] DrawBar drawBar;

	// Use this for initialization


	void Start () {

		minionMonster = new MonsterInformation();
		minionMonster.basecharacterinformation = new BaseCharacterInformation();

		minionMonster.basecharacterinformation.SetHP(10);
		minionMonster.basecharacterinformation.SetDamage(2);
		
		minionMonster.basecharacterinformation.SetPostion(new Vector3(Random.Range(-2.5f,2.5f), 1.5f, Random.Range(-2.5f, 2.5f)));
		transform.position = minionMonster.basecharacterinformation.GetPostion();

		drawBar = GameObject.Find("Canvas").GetComponent<DrawBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Bullet")
		{
			minionMonster.basecharacterinformation.SubtractionHP(1);
			if (minionMonster.basecharacterinformation.IsDie())
			{
				Destroy(drawBar.GetMHeadUpPosition());
				Destroy(drawBar.GetMonsterHPber());
				Destroy(gameObject);

			}

		}
	}
}
