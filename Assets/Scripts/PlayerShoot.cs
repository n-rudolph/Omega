using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private double reloadTime = 0f;

	
	// Update is called once per frame
	void Update () {
    
        if (Input.GetMouseButtonDown(0)) {
            if (reloadTime <= 0)
            {
                GameObject bullet = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                //rb.AddForce(Vector3.forward * 5f);
                reloadTime = 5f;
            }
        }
        if (reloadTime > 0) {
            reloadTime = reloadTime - 1 * Time.deltaTime;
        }
        
	}
}
