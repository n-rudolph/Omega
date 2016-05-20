using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour {
	public float spawnTime = 3f;            // How long between each spawn.
	public float powerUpTimeLife; //Change variable
	public float radious;
	public GameObject[] powerups;
	private float[] jumps = new float[]{0f, 5f ,10f};

	// Use this for initialization
	void Start () {
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);	
		radious = 5f;
		powerUpTimeLife = 2f;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void Spawn () {
		// If the player has no health left...
//		if(playerHealth.currentHealth <= 0f) {
			// ... exit the function.
//			return;
//		}

		// Find a random index between zero and one less than the number of spawn points.
		int powerUpIndex = Random.Range (0, powerups.Length);
		int angle = Random.Range (0, 180);

		Vector3 position = angleToPosition (angle);
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Object powerUp = Instantiate (powerups[powerUpIndex], position, Quaternion.identity);
		Object.Destroy (powerUp, powerUpTimeLife);
	}

	private Vector3 angleToPosition(float deg) {
		float angle = deg * Mathf.Deg2Rad;
//		Debug.Log("Deg: " + angle);
		float x = Mathf.Sin (angle) * radious;
		float z = Mathf.Cos (angle) * radious;
		int yIndex = Random.Range (0, 2);
		float y = jumps [yIndex];
//		Debug.Log ("x,y,z: " + x + ", " + y + ", " + z);
		Debug.Log ("sin(0.5)= " + Mathf.Sin (90*Mathf.Deg2Rad));
		return new Vector3 (x, y, z);
	}
}