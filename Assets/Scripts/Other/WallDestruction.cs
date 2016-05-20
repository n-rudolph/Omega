using UnityEngine;
using System.Collections;

public class WallDestruction : MonoBehaviour {

    void OnCollisionEnter(Collision c) {
        if (c.collider.CompareTag("Bullet")) {
            //Debug.Log("bullet hit");
            Destroy(c.gameObject);
            Destroy(this.gameObject);
        }
        if (c.collider.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
