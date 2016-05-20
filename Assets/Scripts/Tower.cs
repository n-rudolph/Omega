using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private float shootForce;
	private float shootTime;
	public int life;
	private const int damage = 1;
	public float[] shootDirections;

	// Use this for initialization
	void Start () {
		shootTime = 5f;
		InvokeRepeating ("shoot", shootTime, shootTime);	
	}

	// Update is called once per frame
	void Update (){

	}

	void OnCollisionEnter (Collision c)
	{
		if (c.collider.CompareTag ("Bullet")) {
			if (life - damage == 0) {
				Destroy (this.gameObject);
			} else {
				life -= damage;
				Debug.Log ("Life: " + life);
			}
		}
	}

	private void shoot () {
		Vector3 position = transform.position;
		for (int i = 0; i < shootDirections.Length; i++) {
			float shootDirection = shootDirections [i];
			Vector3 shootPosition = transform.position;
			shootPosition.y = shootDirection;
			shootPosition.z += 3f;
			GameObject go = (GameObject)Instantiate (prefab, shootPosition, Quaternion.Euler (Vector3.forward));
			Rigidbody rb = go.GetComponent<Rigidbody> ();
			rb.AddForce (Vector3.forward * shootForce);
		}
	}
}
