using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{
    public float life;

    public ScoreController scoreController;
    public EnemyFireController enemyFireController;
    public float points;

    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        enemyFireController = FindObjectOfType<EnemyFireController>();
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
                enemyFireController.RemoveEnemy(gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
