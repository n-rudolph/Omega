using UnityEngine;
using System.Collections;

public class LookAtCenter : MonoBehaviour
{
    private float height;
	private SpaceMovement sm;
	// Use this for initialization
	void Start ()
	{
	    height = 0;
	    sm = GetComponent<SpaceMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	    transform.LookAt(new Vector3(0,height,0));
	    height = sm.CurrentHeight;
	}
}
