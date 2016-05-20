using UnityEngine;
using System.Collections;

public class BulletReloaded : MonoBehaviour {
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private float shootForce;
	// Use this for initialization
	private int quantityOfShoots;

	void Start () {
		quantityOfShoots = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision c) {
		if (c.collider.CompareTag("Enemy"))
		{
			shoot ();
		}
	}

	private void shoot() {
		Vector3 shootPosition = transform.position;
		//		shootPosition.z += 3f;
		float xDir = 1;
		for (int i = quantityOfShoots; i > 0; i--) {
			GameObject go = (GameObject)Instantiate (prefab, shootPosition, Quaternion.Euler (Vector3.forward));
			Rigidbody rb = go.GetComponent<Rigidbody> ();
			Vector3 dir = Vector3.left;
			dir.x *= xDir;
			rb.AddForce (dir * shootForce);	
			xDir = -1;
		}
	}


}
