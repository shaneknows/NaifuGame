using UnityEngine;
using System.Collections;

public class SamuraiController : EnemyControllerScript {
	Animator anim;
	public GameObject collided_with;
	public override void Start () {
		anim = GetComponent<Animator>();
		hasAppeared = false;
		speed = 0f;
	}
	
	// Update is called once per frame
	public override void Attack () {
		if(collided_with != null)
		{
			if(Globals.Instance.PlayerActions["Jumping"])
				anim.SetBool("UpSlash", true);
			else if(!Globals.Instance.PlayerActions["Slashing"])
				anim.SetBool("TowardSlash", true);
			else
				anim.SetBool("Die", true);
		}
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.name != "Ground")
			collided_with = collision.gameObject;
	}
	
	void OnTriggerExit2D(Collider2D collision){
		if(collision.name != "Ground")
		{
			collided_with = null;
		}
	}
}
