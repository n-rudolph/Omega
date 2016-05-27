using UnityEngine;
using System.Collections;

public class SimpleBulletLife : MonoBehaviour {

	public float life = 10f;
	public float speed= 20f;
	public Vector3 direction;
	public float damage = 30f;


	// Update is called once per frame
	void Update () {
		if (life <= 0)
		{
			Destroy(this.gameObject);
		}
		transform.Translate(direction * speed * Time.deltaTime, Space.World);
		life -= 1*Time.deltaTime;
		Debug.Log (direction);
	}

	public float Damage
	{
		get { return damage; }
		set { damage = value; }
	}
		

	
}
