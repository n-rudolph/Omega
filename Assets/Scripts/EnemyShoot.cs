using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public float enableGunTime;

    private float fireTimer;

    private bool fire;

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start ()
	{
	    fireTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (fire)
	    {
            if (fireTimer > 0)
            {
                fire = false;
                fireTimer -= Time.deltaTime;
            }
            if (fireTimer <= 0)
	        {
	            Fire();
	            fireTimer = enableGunTime;
	        }
	        
	    }
	}

    public void Fire()
    {
        Rigidbody bullet = (Rigidbody)Instantiate(bulletPrefab, transform.parent.transform.position, Quaternion.identity);
        bullet.AddForce(new Vector3(0, 0, 1)*10);
    }

    public void EnableFire()
    {
        fire = true;
    }
}
