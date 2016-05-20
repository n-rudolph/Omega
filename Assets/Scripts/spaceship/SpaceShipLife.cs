using UnityEngine;
using System.Collections;

public class SpaceShipLife : MonoBehaviour {
	private int score;
	private int lifes;
	private const int startLife = 3;
	private const int damage = 1;
	public bool shieldActivate; 

	public AudioClip deathClip;
	private AudioSource playerAudio;

	void Awake() {
		playerAudio = GetComponent <AudioSource> ();
		lifes = startLife;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void updateScore() {
		
	}

	void OnCollisionEnter(Collision c) {
		string tag = c.collider.tag;

		switch(tag){
			case "Bullet":
				if (!shieldActivate) hurt ();
				break;
			case "Shield":
				Shield shield = GetComponent<Shield> ();
				shield.enabled = true;
				shield.use ();
				break;
			case "Arm1": 
				break;
			case "Arm2":
				break;
			default:
				break;
		}
	}

	private void hurt(){
		if (lifes - damage <= 0) {
			death ();
		} else {
			lifes -= damage;
			playerAudio.Play ();
			Debug.Log("Life: " + lifes);
		}
	}

	private void death() {
		playerAudio.clip = deathClip;
		playerAudio.Play ();
		Destroy (this.gameObject);
	}

}
