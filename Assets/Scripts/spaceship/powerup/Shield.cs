using System;
using UnityEngine;

public class Shield: MonoBehaviour {
	private SpaceShipLife spaceShipLife;
	private int life;

	void Awake() {
		enabled = false;
		spaceShipLife = GetComponent<SpaceShipLife> ();
	}

	// Use this for initialization
	void Start () {
		life = 3;
	}

	// Update is called once per frame
	void Update () {
	}

	public void use() {
		spaceShipLife.shieldActivate = true;
		life = 3;
		Debug.Log ("Activated");
	}

	public void hurt() {
		life--;
		Debug.Log("Shield Life: " + life);
		if (life <= 0) {
			spaceShipLife.shieldActivate = false;
		}
	}


}

