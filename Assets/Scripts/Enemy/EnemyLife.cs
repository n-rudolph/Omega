using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{
    public float life;
	
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameObject bullet = other.gameObject;
            PlayerBulletLife bl = bullet.GetComponent<PlayerBulletLife>();
            life -= bl.Damage;
            Destroy(bullet);
            if (life <= 0)
                Destroy(this.gameObject);
        }
    }
}
