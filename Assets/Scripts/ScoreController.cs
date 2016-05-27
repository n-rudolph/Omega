using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{


    public Text scoreText;
    public PowerUpController puCtrl;
    private float score;

    private float shieldScore = 40f; //40
    private float cannonScore = 50f; //50
    private float torret1Score = 60f; //70
    private float torret2Score = 70f; //80

	// Use this for initialization
	void Start ()
	{
	    scoreText.text = "Score: 0";
   
	}

    public void AddScore(float points)
    {
        score += points;
        scoreText.text = "Score: " + score;

        shieldScore -= points;
        cannonScore -= points;
        torret1Score -= points;
        torret2Score -= points;

        if (shieldScore <= 0)
        {
            puCtrl.ActivateShield();
            shieldScore = 40f;
        }
        if (cannonScore <= 0)
        {
            puCtrl.ActivateCannon();
            cannonScore = 50f;
        }
        if (torret1Score <= 0)
        {
            puCtrl.ActivateTorret1();
            shieldScore = 60f;
        }
        if (torret2Score <= 0)
        {
            puCtrl.ActivateTorret2();
            shieldScore = 70f;
        }
    }

    public float GetScore()
    {
        return score;
    }
}
