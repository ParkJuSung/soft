using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {
   [SerializeField] private GameObject bullet;
   [SerializeField] private Transform firePos;
   [SerializeField] private HeroCharacter hero;
	// Use this for initialization
	void Start () {
		firePos = GameObject.Find("Soldier/FirePos").transform;
		bullet = Resources.Load("Bullet",typeof(GameObject)) as GameObject ;
		hero = GetComponent<HeroCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePos.position, firePos.rotation);
			hero.heroinfo.baseCharacterInformation.anim.SetBool("IsRun", false);
			hero.heroinfo.baseCharacterInformation.anim.SetBool("IsShoot", true);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			hero.heroinfo.baseCharacterInformation.anim.SetBool("IsShoot", false);
		}

	}


}
