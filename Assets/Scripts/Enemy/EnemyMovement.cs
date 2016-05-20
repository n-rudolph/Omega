using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour {


    private float angle = 0;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float radiusJump;
    [SerializeField]
    private float height;
    [SerializeField]
    private float heightJump;

    private bool left;
    private bool right;
    private bool forward;

    private double x;
    private double z;

    private float currentHeight;
    private float currentRadius;

    public GameOverCtrl goCtrl;

    // Update is called once per frame
    void Update () {
        if (!forward)
        {
            float angleRadians = angle * Mathf.PI / 180;
            x = 0 + Mathf.Sin(angleRadians) * radius;
            z = 0 + Mathf.Cos(angleRadians) * radius;
            if (angle >= 180)
            {
                right = false;
                left = true;
                MoveForward();
            }
            if (angle <= 0)
            {
                right = true;
                left = false;
                MoveForward();
            }
            if (right)
            {
                angle = (angle + 15 * Time.deltaTime);
            }
            if (left)
            {
                angle = angle - 15 * Time.deltaTime;
            }
            
            transform.position = new Vector3((float)x, height, (float)z);
        } else {
            bool heightBool = false;
            bool radiusBool = false;
            height += heightJump * Time.deltaTime;
            radius -= radiusJump * Time.deltaTime;

            z = 0 + Mathf.Cos(angle * Mathf.PI / 180) * radius;

            transform.position = new Vector3((float)x, height, (float)z);
            
            if (currentRadius - radiusJump >= radius){
                radiusBool = true;
            }
            if (currentHeight + heightJump <= height) {
                heightBool = true;
            }
            if (heightBool && radiusBool) {
                forward = false;
            }
        }
        if (radius<=10)
            goCtrl.GameOver(false);

    }

    void MoveForward() {
        forward = true;
        currentHeight = height;
        currentRadius = radius;
    }

    public float Height
    {
        get { return height; }
        set { height = value; }
    }
}
