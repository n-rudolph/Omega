using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{
    public float life;
	

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
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
