using UnityEngine;
using System.Collections;

public class DefenseGenerator : MonoBehaviour{
    public int defenseAmount;
    public GameObject defensePrefab;
    public GameObject placeholderPrefab;
    
    private float angleInterval = 180/45;
    private bool[,] defenseMatrix;
	// Use this for initialization
	void Start ()
	{
        angleInterval=180/45;
	    if (defenseAmount > 35)
	        defenseAmount = 35;
	    defenseMatrix = new bool[4,45];
	    GenerateDefense();
	    InstantiateDefense();
	}

    private void GenerateDefense()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < defenseAmount; j++)
            {
                int position;
                do
                {
                    position = GetNextPosition();
                }while(defenseMatrix[i,position]);
                defenseMatrix[i,position] = true;
            }
        }
    }

    private int GetNextPosition()
    {
        return Random.Range(0, 44);
    }

    private void InstantiateDefense()
    {
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 45; j++)
            {
                float anglePosition = angleInterval * j + angleInterval * (j + 1) - angleInterval*j;
                
                float radAngle = anglePosition*Mathf.PI/180;
                float x = 0 + Mathf.Sin(radAngle) * 30;
                float z = 0 + Mathf.Cos(radAngle) * 30;
                float y = i*5;
                if (defenseMatrix[i,j])
                {
                    //Instantiate defense
                    GameObject go = (GameObject)Instantiate(defensePrefab, new Vector3(x,y,z), Quaternion.identity);
                    go.transform.LookAt(new Vector3(0,y,0));
                }
                else
                {
                    //Instantiate placeholder
                    GameObject go = (GameObject)Instantiate(placeholderPrefab, new Vector3(x, y, z), Quaternion.identity);
                    go.transform.LookAt(new Vector3(0, y, 0));
                }
                

            }
        }
    }
}
