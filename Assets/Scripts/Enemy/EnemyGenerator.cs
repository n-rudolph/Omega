using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    public int amountEnemyWaves1;
    public int amountEnemyWaves2;
    public int amountEnemyWaves3;

    public int amountEnemyPerWaves1;
    public int amountEnemyPerWaves2;
    public int amountEnemyPerWaves3;

    public Vector3 generationPoint;

    public float creationTimeGap1;
    public float creationTimeGap2;
    public float creationTimeGap3;

    public float timeBetweenWaves;

    private int createdEnemiesPerWaves1;
    private int createdEnemiesPerWaves2;
    private int createdEnemiesPerWaves3;

    private float waveGapTimer;
    private float enemyCreationTimer;

    private bool hasWavesLeft1;
    private bool hasWavesLeft2;
    private bool hasWavesLeft3;


    private EnemyFireController enemyFireController;

    void Start()
    {
        hasWavesLeft1 = true;
        hasWavesLeft2 = true;
        hasWavesLeft3 = true;
        createdEnemiesPerWaves1 = amountEnemyPerWaves1;
        createdEnemiesPerWaves2 = amountEnemyPerWaves2;
        createdEnemiesPerWaves3 = amountEnemyPerWaves3;
        enemyCreationTimer = 0;
        enemyFireController = GetComponent<EnemyFireController>();
    }


    // Update is called once per frame
	void Update () {
	   
	    if (waveGapTimer <= 0)
	    {
            
            if (hasWavesLeft1)
	        {
	            hasWavesLeft1 = GenerateEnemy1();
	        }
            
	        if (!hasWavesLeft1 && hasWavesLeft2)
                hasWavesLeft2 = GenerateEnemy2();
            if (!hasWavesLeft1 && !hasWavesLeft2 && hasWavesLeft3)
                hasWavesLeft3 = GenerateEnemy3();
	    }
	    if (waveGapTimer > 0)
	        waveGapTimer -= Time.deltaTime;

	}

    private bool GenerateEnemy1()
    {
        if (enemyCreationTimer <= 0)
        {
            enemyFireController.AddEnemy(GenerateEnemy(enemy1Prefab));
            createdEnemiesPerWaves1 --;
            enemyCreationTimer = creationTimeGap1;
        }
        if (enemyCreationTimer > 0)
            enemyCreationTimer -= Time.deltaTime;

        
        if (createdEnemiesPerWaves1 <= 0)
        {
            amountEnemyWaves1--;
            createdEnemiesPerWaves1 = amountEnemyPerWaves1;
            waveGapTimer = timeBetweenWaves;
        }

        if (amountEnemyWaves1 == 0)
            return false;
        return true;
    }

    private bool GenerateEnemy2()
    {
        if (enemyCreationTimer <= 0)
        {
            enemyFireController.AddEnemy(GenerateEnemy(enemy2Prefab));
            createdEnemiesPerWaves2--;
            enemyCreationTimer = creationTimeGap2;
        }
        
        if (enemyCreationTimer > 0)
        {
            enemyCreationTimer -= Time.deltaTime;
        }

        if (createdEnemiesPerWaves2 == 0)
        {
            amountEnemyWaves2--;
            createdEnemiesPerWaves2 = amountEnemyPerWaves1;
            waveGapTimer = timeBetweenWaves;
        }
        if (amountEnemyWaves2 == 0)
            return false;
        return true;
    }

    private bool GenerateEnemy3()
    {
        if (enemyCreationTimer <= 0)
        {
            enemyFireController.AddEnemy(GenerateEnemy(enemy3Prefab));
            createdEnemiesPerWaves3--;
            enemyCreationTimer = creationTimeGap1;
        }
        if (enemyCreationTimer > 0)
            enemyCreationTimer -= Time.deltaTime;
       
        if (createdEnemiesPerWaves3 == 0)
        {
            amountEnemyWaves3--;
            createdEnemiesPerWaves3 = amountEnemyPerWaves3;
            waveGapTimer = timeBetweenWaves;
        }
        if (amountEnemyWaves3 == 0)
            return false;
        return true;
    }

    public GameObject GenerateEnemy(GameObject prefab)
    {
        return (GameObject)Instantiate(prefab, generationPoint, Quaternion.Euler(90, 180, 0));
    }

    public float GetTotalEnemyAmount()
    {
       return amountEnemyWaves1* amountEnemyPerWaves1 + amountEnemyWaves2 * amountEnemyPerWaves2 + amountEnemyWaves3* amountEnemyWaves3;
    }

	public float TotalEnemies(){
		return amountEnemyWaves1 * amountEnemyPerWaves1 + amountEnemyWaves2 * amountEnemyPerWaves2 + amountEnemyWaves3 * amountEnemyPerWaves3;
	}
}
