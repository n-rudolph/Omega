using UnityEngine;
using System.Collections;

public class EnemyLookAtCenter : MonoBehaviour {

    private float height;

    private EnemyMovement em;
    // Use this for initialization
    void Start()
    {
        height = 0;
        em = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(0, height, 0));
        height = em.Height;
    }
}
