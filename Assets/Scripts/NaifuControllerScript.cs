using UnityEngine;
using System.Collections;

public class NaifuControllerScript : Player {
	public AudioSource die;
	public AudioSource slash;
	public AudioSource jump;

	float slashTime = .3f;
	float lastSlash;
	
	float slideTime = .3f;
	float lastSlide;
	
	float jumpTime = .3f;
	float lastJump;
	
	float deathTime = .7f;

	#region Actions
	protected override void CheckCollisions(){
		if(collided_with != null)
		{
			switch(collided_with.tag)
			{
			case "Enemy":
				if(!anim.GetBool("Slash"))
					anim.SetBool("Die", true);
				break;
			case "TopObstacle":
				if(!anim.GetBool("Slide"))
					anim.SetBool("Die", true);
				break;
			case "BottomObstacle":
				if(!anim.GetBool("Jump"))
					anim.SetBool("Die", true);
				break;
			}
		}
	}

	protected override void CheckInputs(){
		if(Globals.Instance.Up)
		{
			if(NoCurrentAnimations())
			{
				ClearAnimations();
				jump.Play();
				anim.SetBool("Jump", true);
				lastJump = Time.time;
			}
		}
		if(Time.time - lastJump >= jumpTime)
		{
			anim.SetBool("Jump", false);
		}
		if(Globals.Instance.Tap)
		{
			if(NoCurrentAnimations())
			{
				ClearAnimations();
				anim.SetBool("Slash", true);
				slash.Play();
				lastSlash = Time.time;
			}
		}
		if(Time.time - lastSlash >= slashTime)
		{
			anim.SetBool("Slash", false);
		}
		if(Globals.Instance.Down)
		{
			if(NoCurrentAnimations())
			{
				ClearAnimations();
				anim.SetBool("Slide", true);
				lastSlide = Time.time;
			}
		}
		if(Time.time - lastSlide >= slideTime)
		{
			anim.SetBool("Slide", false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		if(collision.name != "Ground")
			collided_with = collision.gameObject;
	}
	
	void OnTriggerExit2D(Collider2D collision){
		if(anim.GetBool("Die"))
		{
			die.Play();
			Invoke ("Kill", deathTime);
		}
		else if(collision.tag != "Ground")
		{
			collided_with = null;
			Globals.Instance.Score++;
		}
	}
	
	protected override void UpdatePlayerActions()
	{
		Globals.Instance.PlayerActions["Jumping"] = anim.GetBool("Jump");
		Globals.Instance.PlayerActions["Sliding"] = anim.GetBool("Slide");
		Globals.Instance.PlayerActions["Slashing"] = anim.GetBool("Slash");
		Globals.Instance.PlayerActions["Dying"] = anim.GetBool("Die");
	}
	
	protected override void ClearAnimations()
	{
		anim.SetBool("Die", false);
		anim.SetBool("Jump", false);
		anim.SetBool("Slash", false);
		anim.SetBool("Slide", false);
	}
	
	bool NoCurrentAnimations()
	{
		return (!anim.GetBool("Slash") || lastSlash >= slashTime-.1f) && !anim.GetBool("Jump") 
			&& (!anim.GetBool("Slide") || lastSlide >= slideTime-.1f) && !anim.GetBool("Die");
	}
	#endregion
}
