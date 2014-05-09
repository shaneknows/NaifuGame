using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class GameController:MonoBehaviour {
	public float nextSpawn = 0.0f;
	float spawnTime = .6f;

	public void InitiateGame(){
		if(Time.time >= nextSpawn)
		{
			var difficulty = Globals.Instance.Score;
			if(difficulty == 0)
				difficulty = 1;
			if(difficulty >= 10)
				difficulty = 10;
			nextSpawn = spawnTime + Time.time;
			Spawn();
		}
	}

	void Spawn()
	{
		var obstacle = Globals.Instance.Obstacles[Random.Range(0, 3)];
		obstacle.transform.position = new Vector2(Globals.Instance.RightX, obstacle.transform.position.y);
		
		Instantiate(obstacle);
	}
}
