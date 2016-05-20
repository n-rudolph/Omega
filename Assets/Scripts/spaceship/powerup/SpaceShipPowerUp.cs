using UnityEngine;
using System.Collections;

public class SpaceShipPowerUp : MonoBehaviour {
	private SpaceShipLife spaceShipLife;


	void Awake() {
		enabled = false;
		spaceShipLife = GetComponent<SpaceShipLife> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision c) {
		if (c.collider.CompareTag("Shield")) {
			Shield shield = GetComponent<Shield> ();
			shield.use ();
		}
	}
}
