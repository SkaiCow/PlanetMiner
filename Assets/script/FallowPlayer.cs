﻿using UnityEngine;
using System.Collections;

public class FallowPlayer : MonoBehaviour {

	public GameObject Player;
	
	// Update is called once per frame
	void Update () 
	{
		
		transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -36.9f);
		
	}
}
