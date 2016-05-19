using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	public float speed = 90f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, transform.forward, Time.deltaTime * speed);
	}
}
