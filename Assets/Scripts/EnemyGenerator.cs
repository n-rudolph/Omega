using UnityEngine;
using System.Collections;
using ADBannerView = UnityEngine.iOS.ADBannerView;

public class EnemyGenerator : MonoBehaviour
{
    public Transform enemyPrefab;

    public Vector3 generationPoint;

    public float waveTime;

    private float timer;

    public int maxWavesAmount;

    public int maxEnemyPerWave;

    private int wavesCreated;

    public float creationTimeGap;

    private float enemyCreationTimer;

    private int enemiesCreated;

    private EnemyFireController enemyFireController;

    void Start()
    {
        wavesCreated = 0;
        timer = 0;
        enemyCreationTimer = 0;
        enemyFireController = GetComponent<EnemyFireController>();
    }


    // Update is called once per frame
	void Update () {
	    if (wavesCreated < maxWavesAmount)
	    {
	        if (timer <= 0)
	        {
	            if (enemyCreationTimer <= 0)
	            {
                    enemyFireController.addEnemy(generateEnemy().gameObject);
	                enemiesCreated += 1;
	                enemyCreationTimer = creationTimeGap;
	            }
	            if (enemiesCreated == maxEnemyPerWave)
	            {
	                timer = waveTime;
                    wavesCreated += 1;
	                enemiesCreated = 0;
	            }
	            if (enemyCreationTimer > 0)
	                enemyCreationTimer -= Time.deltaTime;
	        }
	        if (timer > 0)
	        {
	            timer -= Time.deltaTime;
	        }
	    }

	}

    public Transform generateEnemy()
    {
        Transform t =(Transform)Instantiate(enemyPrefab, generationPoint, Quaternion.identity);
        return t;
    }
}
