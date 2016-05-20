using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public int damage;

	private SpaceShipLife spaceShipLife;
	private bool gunActivated;
	private float duration = 10f;
	private float timeLeft;

	void Awake() {
		enabled = false;
		spaceShipLife = GetComponent<SpaceShipLife> ();
		timeLeft = duration;
	}


	// Update is called once per frame
	void Update () {
		if (gunActivated) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				gunActivated = false;
				timeLeft = duration;
				spaceShipLife.shieldActivate = false;
				Debug.Log ("Inactivated");
			}
		}
	}

	public void use() {
		enabled = true;
		gunActivated = true;
		Debug.Log ("Activated");
		//TODO aumentar el daño del disparo
	}
}
