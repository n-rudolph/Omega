using UnityEngine;
using System.Collections;

public class BulletReloaded : MonoBehaviour {
	[SerializeField]
	private GameObject prefabLeft;
	[SerializeField]
	private GameObject prefabRight;
	[SerializeField]
	private float shootForce;
	// Use this for initialization
	private int quantityOfShoots;

	private float damage = 0f;

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

			GameObject go1 = (GameObject)Instantiate (prefabLeft, shootPosition, Quaternion.Euler(Vector3.forward));
			GameObject go2 = (GameObject)Instantiate (prefabRight, shootPosition, Quaternion.Euler(Vector3.forward));
			

	}

	public float Damage
	{
		get { return damage; }
		set { damage = value; }
	}


}
