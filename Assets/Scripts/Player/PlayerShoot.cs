using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
	private GameObject bulletReloaded;
	private bool laserActivated;

    [SerializeField]
    private float reloadTime;

    private float reloadTimer= 0f;

	
	// Update is called once per frame
	void Update () {
		if (laserActivated) {
			prefab = bulletReloaded;
		}
        if (Input.GetMouseButtonDown(0) || Input.GetAxis("Fire1")>0) {
            if (reloadTimer <= 0) {
                Instantiate(prefab, transform.position, transform.rotation);
                reloadTimer = reloadTime;
            }
        }
        if (reloadTimer > 0) {
            reloadTimer -= Time.deltaTime;
        }
        
	}
}
