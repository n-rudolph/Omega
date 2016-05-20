using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {
    [SerializeField]
    private float lifeTime = 5f;

    private Vector3 target = Vector3.zero;

    public float damage;


    public float speed;
	// Update is called once per frame
	void Update ()
	{
        
        gameObject.transform.LookAt(target);
	    Vector3 direction =target - transform.position;
	    transform.position += direction*Time.deltaTime;
        if (lifeTime > 0) {
            lifeTime = lifeTime - 1 * Time.deltaTime;
        }
        if (lifeTime <= 0) {
            Destroy();
        }
	}


    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
