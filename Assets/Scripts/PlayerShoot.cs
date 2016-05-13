using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float shootForce;

    [SerializeField]
    private float reloadTime;

    private float reloadTimer= 0f;

	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            if (reloadTimer <= 0) {
                GameObject go = (GameObject)Instantiate(prefab, transform.position, Quaternion.Euler(Vector3.forward));
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.forward * shootForce);
                reloadTimer = reloadTime;
            }
        }
        if (reloadTimer > 0) {
            reloadTimer -= Time.deltaTime;
        }
        
	}
}
