using UnityEngine;
using System.Collections;

public class EnemyControllerScript : MonoBehaviour {
	protected float power = .25f;
	protected float speed = 0f;
	protected bool hasAppeared;
	// Use this for initialization
	public virtual void Start () {
		hasAppeared = false;
		speed = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Run();
		Attack();
		if(renderer.isVisible)
		{
			hasAppeared = true;
		}
		else if(hasAppeared && !renderer.isVisible && gameObject != null)
		{
			DestroyObject(gameObject);
		}
	}

	public virtual void Run()
	{
		speed = -power * (Time.deltaTime+1);
		transform.Translate(new Vector3(speed, 0, 0));
	}

	public virtual void Attack()
	{
	}
}
