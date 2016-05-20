using UnityEngine;
using System.Collections;

public class PlayerBulletLife : MonoBehaviour
{
    public float life = 10f;
    public float speed= 10f;
    private Vector3 direction;
    public float damage = 30f;

	// Use this for initialization
	void Start ()
	{
	    direction = new Vector3(transform.position.x, 0, transform.position.z);
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
