using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour {
	public int Score;
	public List<GameObject> Obstacles;
	public GameObject Player;
	public GameObject Ground;
	public GameObject StartButton;
	public int Phase;
	public bool Down;
	public bool Up;
	public bool Tap;
	public float CharacterWidth;
	public Vector2 CharacterPosition;
	/*
	public Vector2 GroundPosition;
	public Vector2 StartButtonPosition;
	public Vector2 TopObstaclePosition;
	public Vector2 BottomObstaclePosition;
	public Vector2 EnemyPosition;
	*/
	public Vector2 ScorePosition;
	public float LeftX;
	public float RightX;

	public Dictionary<string, bool> PlayerActions;

	private static Globals instance = null;
	
	private Globals() {}
	
	public static Globals Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (Globals)FindObjectOfType(typeof(Globals));
				if (instance == null)
				{
					instance = (new GameObject("Globals")).AddComponent<Globals>();
				}
			}
			return instance;
		}
	}
	
	public void Start()
	{
	}
}
