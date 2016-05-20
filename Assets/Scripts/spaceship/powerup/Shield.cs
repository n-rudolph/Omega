using System;
using UnityEngine;

public class Shield: MonoBehaviour {
	private SpaceShipLife spaceShipLife;
	private bool shieldActivated;
	private float duration = 10f;
	private float timeLeft;

	void Awake() {
		enabled = false;
		spaceShipLife = GetComponent<SpaceShipLife> ();
		timeLeft = duration;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (shieldActivated) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				shieldActivated = false;
				timeLeft = duration;
				spaceShipLife.shieldActivate = false;
				Debug.Log ("Inactivated");
			}
		}
	}

	public void use() {
		enabled = true;
		shieldActivated = true;
		spaceShipLife.shieldActivate = true;
		Debug.Log ("Activated");
	}

}

