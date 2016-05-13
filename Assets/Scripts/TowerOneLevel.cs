using UnityEngine;
using System.Collections;

public class TowerOneLevel : MonoBehaviour {
	public int life;
	private const int damage = 10;
	// Use this for initialization
	void Start () {
		life = 100;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.forward, out hit)) {
//			print ("Found an object - distance: " + hit.distance);
//			print ("Shoot");
		}
	}

	void OnCollisionEnter(Collision c) {
		if (c.collider.CompareTag("Bullet")) {
			if (life - damage == 0) {
				Destroy (this.gameObject);
			} else {
				life -= damage;
				Debug.Log("Life: " + life);
			}
		}
	}
}
