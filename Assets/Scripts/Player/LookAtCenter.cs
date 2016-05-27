using UnityEngine;
using System.Collections;

public class LookAtCenter : MonoBehaviour
{
    private float height;
	private SpaceMovment sm;
	// Use this for initialization
	void Start ()
	{
	    height = 0;

	    
	}
	
	// Update is called once per frame
	void Update () {
	    transform.LookAt(new Vector3(0,height,0));
		height = transform.position.y;
	}
}
