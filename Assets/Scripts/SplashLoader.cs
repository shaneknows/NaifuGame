using UnityEngine;
using System.Collections;

public class SplashLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("BeginGame", 2);
	}

	void BeginGame()
	{
		Application.LoadLevel("Game");
	}
}
