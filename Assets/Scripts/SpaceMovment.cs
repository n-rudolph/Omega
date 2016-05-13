using UnityEngine;
using System.Collections;

public class SpaceMovment : MonoBehaviour {
    public float speed = 1.0F;
    private static Vector3 min = new Vector3(1, 0, 0);
	private const float jumpHeight = 2;
	private const float maxHeight = 6;
	private float height = 0f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveHorizontally ();

		if (Input.GetKeyDown ("up")) {
			moveVertically (1f);
		} 
		if (Input.GetKeyDown ("down")) {
			moveVertically (-1f);
		} 
	}

	private void moveHorizontally() {
		float horizontalDir = Input.GetAxis("Horizontal");
		float horizontalTranslation = horizontalDir * speed;
		float angle = Vector3.Angle(min, transform.position);

		if (angle <= 1f && horizontalDir > 0f){
			return;
		} else if(angle >= 179f && horizontalDir < 0f) {
			return;
		}
		horizontalTranslation *= Time.deltaTime;
		transform.RotateAround(Vector3.zero, Vector3.up, horizontalTranslation);	
	}

	private void moveVertically(float direction) {
		float jump = direction * jumpHeight;
		float tmp = height + jump;
		if (tmp < 0f || tmp > maxHeight) 
			return;
		height = tmp;
		transform.Translate (0, jump, 0);
	}
}
