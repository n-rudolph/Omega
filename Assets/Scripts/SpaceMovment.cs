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

		if (Input.GetKeyDown ("up")) {
			moveVertical (1f);
		} 
		if (Input.GetKeyDown ("down")) {
			moveVertical (-1f);
		} 
		//transform.Translate (0, verticalTranslation, 0);

	}

	private void moveVertical(float direction) {
		float tmp = height + direction * jumpHeight;
		if (tmp <= -jumpHeight && direction < 0)
			return;
		else if (tmp >= maxHeight && direction > 0) 
			return;
		height += direction * jumpHeight;
		Debug.Log ("y: " + height);
		transform.Translate (0, height, 0);
	}
}
