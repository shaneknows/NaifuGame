using UnityEngine;
using System.Collections;

public class Parallaxed : MonoBehaviour {
	protected float power = 0;
	protected Vector3 direction;
	protected bool hasAppeared;

	// Use this for initialization
	protected virtual void Start () {
		hasAppeared = false;
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void FixedUpdate() {
		if(renderer.isVisible)
		{
			hasAppeared = true;
		}
		else if(hasAppeared && !renderer.isVisible && gameObject != null)
			Parallax();
	}

	public virtual void Initialize() 
	{
		direction = new Vector3(0, 0, 0);
	}

	public virtual void Move()
	{
		var speed = power * (Time.deltaTime+1);
		transform.Translate(new Vector3(speed * direction.x, speed * direction.y, speed * direction.z));
	}

	private void Parallax()
	{
		gameObject.transform.position = new Vector3(Globals.Instance.RightX + (gameObject.renderer.bounds.size.x/2) , gameObject.transform.position.y, 0);
	}
}
