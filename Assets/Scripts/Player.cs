using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	protected Animator anim;
	public GameObject collided_with;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		CheckCollisions();
	}

	// Update is called once per frame
	void Update () {
		if(Globals.Instance.Phase == 1)
		{
			CheckInputs();
		}
		UpdatePlayerActions();
	}

	#region virtual members
	protected virtual void Kill(){
		ClearAnimations();
		Globals.Instance.Phase = 0;
		Destroy(transform.gameObject);
	}

	protected virtual void ClearAnimations(){}
	protected virtual void CheckCollisions(){}
	protected virtual void CheckInputs(){}
	protected virtual void UpdatePlayerActions(){}
	#endregion
}
