using UnityEngine;
using System.Collections;

public class BulletReloaded : MonoBehaviour {
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private float shootForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 shootPosition = transform.position;
//		shootPosition.z += 3f;
		for (int i = 0; i < 2; i++) {
//			GameObject go = (GameObject)Instantiate (prefab, shootPosition, Quaternion.Euler (Vector3.forward));
//			Rigidbody rb = go.GetComponent<Rigidbody> ();
//			rb.AddForce (Vector3.forward * shootForce);	
		}

	}


}
