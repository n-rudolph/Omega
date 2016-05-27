using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    private GameObject prefab;

    public GameObject commonBullet;
	public GameObject bulletReloaded;
	public SoundController soundCtrl;

	private bool laserActivated;

    [SerializeField]
    private float reloadTime;

    private float reloadTimer = 0f;

    private float laserTimer = 0 ;

	
	// Update is called once per frame
	void Update () {
        if (laserTimer > 0)
            laserTimer -= Time.deltaTime;
        if (laserTimer <= 0)
        {
            prefab = commonBullet;
            laserActivated = false;
        }
        if (laserActivated) {
			prefab = bulletReloaded;
		}
        if (Input.GetMouseButtonDown(0) || Input.GetAxis("Fire1")>0) {
            if (reloadTimer <= 0) {
				soundCtrl.PlaySoundEffect (SoundEnum.SHOOT);
                Instantiate(prefab, transform.position, transform.rotation);
                reloadTimer = reloadTime;
            }
        }
        if (reloadTimer > 0) {
            reloadTimer -= Time.deltaTime;
        }

	}

    public void ActivateLaser()
    {
        laserActivated = true;
        laserTimer = 5f;
    }
}
