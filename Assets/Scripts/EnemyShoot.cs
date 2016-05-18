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
                fireTimer -= Time.deltaTime;
            }
            if (fireTimer <= 0)
	        {
	            Fire();
	            fireTimer = enableGunTime;
                fire = false;
            }
	        
	    }
	}

    public void Fire()
    {
        GameObject go = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 180, 0));
        BulletLife bulletLife = go.GetComponent<BulletLife>();
        bulletLife.SetTarget(new Vector3(0, GetComponent<EnemyMovement>().Height, 0));

    }

    public void EnableFire()
    {
        fire = true;
    }
}
