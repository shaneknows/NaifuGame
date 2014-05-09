using UnityEngine;
using System.Collections;

public class GroundController : Parallaxed {
	public override void Initialize()
	{
		power = .05f;
		direction = new Vector3(-1, 0, 0);
	}
}
