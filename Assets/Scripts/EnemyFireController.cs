using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFireController : MonoBehaviour
{

    public List<GameObject> enemies;

    public int firingEnemiesAmount;
    private int[] shotIndex;

    public float shootTimeGap;
    private float shootTimer;

	// Use this for initialization
	void Start () {
	    enemies= new List<GameObject>();
        shotIndex= new int[firingEnemiesAmount];
	    shootTimer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (shootTimer <= 0)
	    {
	        int enemiesShoots = firingEnemiesAmount;
	        if (enemies.Count > 0)
	        {
	            if (enemies.Count < firingEnemiesAmount)
	                enemiesShoots = enemies.Count;
	            for (int i = 0; i < enemiesShoots; i++)
	            {
	                while (true)
	                {
	                    int rnd = Random.Range(0, enemies.Count);
	                    if (!Shot(i))
	                    {
	                        GameObject enemy = enemies[i];
	                        EnemyShoot es = enemy.GetComponent<EnemyShoot>();
	                        es.Fire();
	                        break;
	                    }
	                }

	            }
	        }
            shootTimer = shootTimeGap;
        }
	    if (shootTimer > 0)
	    {
	        shootTimer -= Time.deltaTime;
	    }
	}

    private bool Shot(int index)
    {
        bool exists = false;
        for (int i = 0; i < shotIndex.Length; i++)
        {
            if (shotIndex != null)
            {
                if (shotIndex[i] == index)
                {
                    exists = true;
                }
            }
        }
        return exists;
    }

    public void addEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void removeEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
