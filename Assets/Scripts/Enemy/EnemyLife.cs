using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{
    public float life;
    public ScoreController scoreController;
    public float points;

    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            GameObject bullet = other.gameObject;
            PlayerBulletLife bl = bullet.GetComponent<PlayerBulletLife>();
            life -= bl.Damage;
            Destroy(bullet);
            if (life <= 0)
            {
                scoreController.AddScore(points);
                Destroy(this.gameObject);
            }
        }
    }
}
