using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class GameCamera : MonoBehaviour {
	public Transform startButton;
	public Transform character;
	public Transform ground;
	public Transform topObstacle;
	public Transform bottomObstacle;
	public Transform enemy;
	public Transform background;
	public Transform gameTitle;

	public Font font;
	protected bool showScore = false;

	public GameController controller;
	GUIStyle style;
	// Use this for initialization
	void Start () {
		//Setup Score
		style = new GUIStyle();
		style.font = font;
		style.fontSize = 42;

		SetUpGlobals();
		//Create StartButton Object
		Instantiate(startButton.gameObject, new Vector3(startButton.position.x, startButton.position.y), Quaternion.identity);
		//Create Grounds
		Instantiate(ground.gameObject, new Vector3(0, ground.position.y), Quaternion.identity);
		Instantiate(ground.gameObject, new Vector3(Globals.Instance.RightX + (ground.GetComponent<Renderer>().bounds.size.x/2), ground.position.y), Quaternion.identity);

		//Background
		Instantiate(background);
		//Instantiate(character.gameObject, new Vector3(character.position.x, character.position.y), Quaternion.identity);
		Instantiate(character.gameObject, Globals.Instance.CharacterPosition, Quaternion.identity);

		Instantiate(gameTitle);

		controller = transform.gameObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Transition into Playing Phase when start button has been pressed
		if(Globals.Instance.Phase == 1)
		{
			if(!Globals.Instance.PlayerActions["Dying"])//While player is dying stop spawning
			{
				showScore = true;
				controller.InitiateGame();
			}
		}	
		else if(Globals.Instance.Phase == 0 && GameObject.FindGameObjectsWithTag("Button").Length == 0)//Transition back to menu when player dies
		{
			Instantiate(character.gameObject, Globals.Instance.CharacterPosition, Quaternion.identity);
			//Instantiate(character.gameObject, new Vector3(character.position.x, character.position.y), Quaternion.identity);
			Instantiate(startButton.gameObject, new Vector3(startButton.position.x, startButton.position.y), Quaternion.identity);
			DestroyObstacles();
			controller.nextSpawn = 0;
		}
	}

	void DestroyObstacles()
	{
		foreach(var o in GameObject.FindGameObjectsWithTag("TopObstacle"))
			Destroy(o);
		foreach(var o in GameObject.FindGameObjectsWithTag("BottomObstacle"))
			Destroy(o);
		foreach(var o in GameObject.FindGameObjectsWithTag("Enemy"))
			Destroy(o);
	}

	void SetUpGlobals()
	{
		Globals.Instance.LeftX = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
		Globals.Instance.RightX = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;

		Globals.Instance.CharacterPosition = new Vector2(Globals.Instance.LeftX + character.GetComponent<Renderer>().bounds.size.x,
		                                                 character.position.y);

		List<GameObject> obstacles = new List<GameObject>();
		obstacles.Add(topObstacle.gameObject);
		obstacles.Add(bottomObstacle.gameObject);
		obstacles.Add(enemy.gameObject);
		Globals.Instance.Obstacles = obstacles;
		Globals.Instance.Phase = 0;

		Globals.Instance.PlayerActions = new Dictionary<string, bool>()
		{
			{"Jumping", false},
			{"Sliding", false},
			{"Slashing", false},
			{"Dying", false}
		};
		Globals.Instance.ScorePosition = new Vector2(Globals.Instance.RightX - 100, Screen.height - 40);
	}

	void OnGUI() {
		if(showScore)
		{
			GUI.Box(new Rect(Screen.width/2 - 50, 10,
			                 100, 60), (Globals.Instance.Score / 2).ToString(), style);
		}
	}
}
