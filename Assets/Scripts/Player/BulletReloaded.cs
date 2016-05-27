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

	void OnTriggerEnter(Collider c) {
		if (c.CompareTag("Enemy"))
		{
			Shoot ();
		}
	}

	private void Shoot() {
		Vector3 shootPosition = transform.position;
		//		shootPosition.z += 3f;
		float xDir = 1;
		for (int i = quantityOfShoots; i > 0; i--) {
			Debug.Log ("Multiplicar");
			GameObject go = (GameObject)Instantiate (prefab, shootPosition, Quaternion.identity);
			Rigidbody rb = go.GetComponent<Rigidbody> ();
			SimpleBulletLife bl = go.GetComponent<SimpleBulletLife>();
			Vector3 dir = Vector3.right;
			dir.x *= xDir;
			rb.AddForce (dir * shootForce);	
			bl.direction = dir;
			xDir = -1;
		}
	}


}
