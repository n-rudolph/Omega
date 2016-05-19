using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public class SpaceMovement : MonoBehaviour {
    public float speed = 1.0F;
    private static Vector3 min = new Vector3(1, 0, 0);
	private const float jumpHeight = 5;
	private const float maxHeight = 15;
	private float height = 0f;

    private float shipAngle;
    private float x;
    private float z;

    private bool movingUp = false;
    private bool movingDown = false;
    private bool notMoving = true;

    private float targetHeight;
    private float currentHeight;
    
	// Use this for initialization
	void Start ()
	{
	    shipAngle = 90;
	    targetHeight = 0;
	    currentHeight = height;
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 horizontal = moveHorizontally();
	    Vector3 vertical= new Vector3(0, height, 0);

	    if (notMoving)
	    {
	        if (Input.GetKeyDown("joystick button 1"))
	        {
	            if (SetTargetHeight(1f))
	            {
	                movingUp = true;
	                movingDown = false;
	                notMoving = false;
	            }
	            //vertical = moveVertically(1f);
            }
	        if (Input.GetKeyDown("joystick button 0"))
	        {
	            if (SetTargetHeight(-1f))
	            {
	                movingDown = true;
	                movingUp = false;
	                notMoving = false;
	            }
	            //vertical = moveVertically(-1f);
	        }
	    }
	    if (movingUp)
	    {
            vertical = moveV(1f);
	        if (height == vertical.y)
	        {
	            notMoving = true;
	            movingUp = false;
	        }
	    }
        if (movingDown)
        {
            vertical = moveV(-1f);
            if (height == vertical.y)
            {
                notMoving = true;
                movingDown = false;
            }
        }
        transform.position = horizontal + vertical;
	}

    private bool SetTargetHeight(float direction)
    {
        targetHeight = height;
        if (direction < 0)
        {
            if (height == 0)
                return false;
            height -= 5;
            targetHeight = height;
            return true;
        }
        else
        {
            if (height == 15)
                return false;
            height += 5;
            targetHeight = height;
            return true;
        }
        
    }

    //Calculate horizontal translation
    private Vector3 moveHorizontally()
    {
        float hDir = Input.GetAxis("Horizontal");
        //get next position depending on the angle
        float angleRadians = shipAngle * Mathf.PI / 180;
        x = 0 + Mathf.Sin(angleRadians) * 10;
        z = 0 + Mathf.Cos(angleRadians) * 10;

        //check if player is in the limit of the circunsference
        if (shipAngle <= 1f && hDir < 0f)
        {
            return new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (shipAngle >= 179f && hDir > 0f)
        {
            return new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (hDir > 0)
        {
            shipAngle = (shipAngle + speed * Time.deltaTime);
        }
        else if (hDir < 0)
        {
            shipAngle = (shipAngle - speed * Time.deltaTime);
        }
        return new Vector3((float) x, 0, (float) z);
    }

	private Vector3 moveVertically(float direction) {
		float jump = direction * jumpHeight;
		float tmp = height + jump;
		if (tmp < 0f || tmp > maxHeight) 
			return new Vector3(0, height, 0);
		height = tmp;
	    return new Vector3(0, jump, 0);
		//transform.Translate (0, jump, 0);
	}

    //calculate vertical translation
    private Vector3 moveV(float direction)
    {
        if (Mathf.Abs(currentHeight - targetHeight) < 0.1)
            return new Vector3(0,targetHeight, 0);
        currentHeight += direction * Time.deltaTime;
        return new Vector3(0, currentHeight, 0);
    }

    public float Height
    {
        get { return height; }
        set { height = value; }
    }
    public float CurrentHeight
    {
        get { return currentHeight; }
        set { currentHeight = value; }
    }
}
