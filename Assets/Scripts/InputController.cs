using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	bool up = false;
	bool down = false;
	bool tap = false;

	// Update is called once per frame
	void Update () {
		ClearGlobals();
		//Quit Game
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
		
		//Touch Controls
		if (Input.touchCount > 0)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Began)
				tap = true;
			if(Input.GetTouch(0).phase == TouchPhase.Moved) 
			{
				// Get movement of the finger since last frame
				var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				if(Mathf.Abs(touchDeltaPosition.y) > .9f)
				{
					if(touchDeltaPosition.y > 0)
					{
						up = true;
						tap = false;
						down = false;
					}
					else
					{
						down = true;
						up = false;
						tap = false;
					}
				}
			}
			if(Input.GetTouch(0).deltaTime > .1f || Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				Globals.Instance.Up = up;
				Globals.Instance.Down = down;
				Globals.Instance.Tap = tap;
				ClearLocals();
			}

		}

		//PC Controls
		if(Input.GetKeyDown(KeyCode.S))
			Globals.Instance.Down = true;
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
			Globals.Instance.Tap = true;
		if(Input.GetKeyDown(KeyCode.W))
			Globals.Instance.Up = true;
	}

	void ClearGlobals()
	{
		Globals.Instance.Up = false;
		Globals.Instance.Down = false;
		Globals.Instance.Tap = false;
	}

	void ClearLocals()
	{
		up = false;
		down = false;
		tap = false;
	}
}
