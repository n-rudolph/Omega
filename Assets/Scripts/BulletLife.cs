using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {
    [SerializeField]
    private float lifeTime = 5f;

	// Update is called once per frame
	void Update () {
        if (lifeTime > 0) {
            lifeTime = lifeTime - 1 * Time.deltaTime;
        }
        if (lifeTime <= 0) {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Defense") {
            Destroy(transform.gameObject);
        }
    }
}
