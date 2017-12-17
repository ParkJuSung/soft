using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private HeroCharacter hero;
	[SerializeField] private MinionMonster mini;
    // Use this for initialization
    void Start () {
		speed = 1000.0f;
		GetComponent<Rigidbody>().AddForce(transform.forward * speed);
		hero = GameObject.Find("Soldier").GetComponent<HeroCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "monster")
		{
			mini = collision.gameObject.GetComponent<MinionMonster>();
			mini.miniMonster.basecharacterinformation.SubtractionHP(hero.heroinfo.baseCharacterInformation.GetDamae());
			Destroy(gameObject);
		}
	}


}
