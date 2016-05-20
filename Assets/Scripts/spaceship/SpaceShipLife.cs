using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceShipLife : MonoBehaviour {
	private int score;
	private int lifes;
	private const int startLife = 3;
	private const int damage = 1;
	public bool shieldActivate;
    public GameOverCtrl goCtrl;

    public Text lifeText;

	public AudioClip deathClip;
	private AudioSource playerAudio;

	void Awake() {
		playerAudio = GetComponent <AudioSource> ();
		lifes = startLife;
	}

	void OnCollisionEnter(Collision c) {
		string tag = c.collider.tag;
		switch(tag){
		case "Bullet":
			hurt ();
            Destroy(c.collider.gameObject);
			break;
		case "Shield":
			GetComponent<Shield> ().use ();
			shieldActivate = true;
				break;
		case "Arm1": 
			break;
		default:
			break;
		}
	}

	private void hurt(){
		if (!shieldActivate) {
			if (lifes - damage <= 0) {
				death ();
			} else {
				lifes -= damage;
			    lifeText.text = "Lives: " + lifes;
				//playerAudio.Play ();
			}
		} else {

			GetComponent<Shield> ().hurt();
		}
	}

	private void death() {
		//playerAudio.clip = deathClip;
		//playerAudio.Play ();
        goCtrl.GameOver(false);
		//Destroy (this.gameObject);
	}

}
