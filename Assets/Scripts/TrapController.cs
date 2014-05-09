using UnityEngine;
using System.Collections;

public class TrapController : EnemyControllerScript {
	Animator anim;
	
	// Use this for initialization
	public override void Start () {
		hasAppeared = false;
		speed = 0f;
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.tag == "Player")
		{
			anim.SetBool("Collision", true);
			audio.Play();
		}
	}

	void Stop()
	{
		power= 0;
	}
}
