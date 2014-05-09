using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	Animator anim;
	float timeClicked;
	float clickTransition = .25f;

	void Start () {
		anim = GetComponent<Animator>();
		Camera.main.audio.mute = true;
		Camera.main.audio.Pause();
	}

	void OnMouseDown(){
		Globals.Instance.Score = 0;
		anim.SetBool("Clicked", true);
		Invoke("Begin", clickTransition);
		//timeClicked = Time.time;
	}

	void Begin(){
		//Populate game objects and destroy menu option.
		Globals.Instance.Phase = 1;
		Destroy(gameObject);
		if(GameObject.FindGameObjectsWithTag("Title").Length != 0)
			DestroyObject(GameObject.FindGameObjectsWithTag("Title")[0]);
		Camera.main.audio.mute = false;
		Camera.main.audio.Play();
	}
}
