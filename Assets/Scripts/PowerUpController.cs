using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour
{

    public GameObject torret1Prefab;
    public GameObject torret2Prefab;

    public Shield shieldScript;
    public PlayerShoot playerShoot;

    public MeshRenderer shieldIndicator;
    public MeshRenderer cannonIndicator;
    public MeshRenderer torret1Indicator;
    public MeshRenderer torret2Indicator;

	public SoundController soundCtrl;

    private bool shield= false;
    private bool cannon=false;
    private bool torret1=false;
    private bool torret2=false;

    private GameObject shieldGO;
	// Use this for initialization
	void Start ()
	{
	    shieldIndicator.enabled = shield;
	    cannonIndicator.enabled = cannon;
	    torret1Indicator.enabled = torret1;
	    torret2Indicator.enabled = torret2;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetAxis("PowerUp") > 0)
	    {
	        if (shield)
	        {
	            shieldScript.use();
				soundCtrl.PlaySoundEffect (SoundEnum.SHIELD);
	            shield = false;
	        }
	        if (cannon)
	        {
                playerShoot.ActivateLaser();
	            cannon = false;
	        }
	        if (torret1)
	        {
	            GenerateTorret(TorretEnum.STANDARD);
	            torret1 = false;
	        }
	        if (torret2)
	        {
	            GenerateTorret(TorretEnum.RELOADED);
	            torret2 = false;
	        }
	    }
        shieldIndicator.enabled = shield;
        cannonIndicator.enabled = cannon;
        torret1Indicator.enabled = torret1;
        torret2Indicator.enabled = torret2;
    }

    private void GenerateTorret(TorretEnum torretEnum)
    {
        float angleInterval = 180 / 45;
        float row = Random.Range(0, 3);
        float col = Random.Range(0, 44);
        float anglePosition = angleInterval * col + angleInterval * (col + 1) - angleInterval * col;
        float radAngle = anglePosition * Mathf.PI / 180;
        float x = 0 + Mathf.Sin(radAngle) * 30;
        float z = 0 + Mathf.Cos(radAngle) * 30;
        float y = row * 5;

        if (torretEnum.Equals(TorretEnum.STANDARD))
        {
            Instantiate(torret1Prefab, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (torretEnum.Equals(TorretEnum.RELOADED))
        {
            Instantiate(torret2Prefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }

    public void ActivateShield()
    {
        shield = true;
		soundCtrl.PlaySoundEffect (SoundEnum.POWERUP);
    }

    public void ActivateCannon()
    {
        cannon = true;
		soundCtrl.PlaySoundEffect (SoundEnum.POWERUP);
    }

    public void ActivateTorret1()
    {
        torret1 = true;
		soundCtrl.PlaySoundEffect (SoundEnum.POWERUP);
    }

    public void ActivateTorret2()
    {
        torret2 = true;
		soundCtrl.PlaySoundEffect (SoundEnum.POWERUP);
    }
    public enum TorretEnum
    {
        STANDARD, RELOADED
    }
}
