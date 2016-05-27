using UnityEngine;
using System.Collections;

public class SimpleBulletLife : MonoBehaviour {

	public float life = 10f;
	public float speed= 10f;
	public Vector3 direction;
	public float damage = 30f;

	// Use this for initialization
	void Start ()
	{
		direction.Normalize();      
	}

	// Update is called once per frame
	void Update () {
		if (life <= 0)
		{
			Destroy(this.gameObject);
		}
		transform.Translate(direction * speed * Time.deltaTime, Space.World);
		life -= 1*Time.deltaTime;
	}

	public float Damage
	{
		get { return damage; }
		set { damage = value; }
	}

	
}
