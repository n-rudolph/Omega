using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFireController : MonoBehaviour
{

    public List<GameObject> enemies;

    public float shootTimeGapMin;
    public float shootTimeGapMax;
    private float shootTimer;


	// Use this for initialization
	void Start () {
	    enemies= new List<GameObject>();
	    shootTimer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (shootTimer <= 0)
	    {
	        if (enemies.Count > 0)
	        {
	            int index = Random.Range(0, enemies.Count - 1);
	            GameObject enemy = enemies[index];
	            EnemyShoot enemyShoot = enemy.GetComponent<EnemyShoot>();
                enemyShoot.Fire();
	            shootTimer = Random.Range(shootTimeGapMin, shootTimeGapMax);
	        }
	    }
	    if (shootTimer > 0)
	    {
	        shootTimer -= Time.deltaTime;
	    }
	}

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
