using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {
	private int score;
	public int lifes = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void updateScore() {
		
	}

	void OnCollisionEnter(Collision c) {
		Debug.Log("Entro");
		if (c.collider.CompareTag("Bullet")) {
			if (lifes - 1 == 0) {
				Destroy (this.gameObject);
			} else {
				lifes--;
				Debug.Log("Life: " + lifes);
			}
		}
	}
}
