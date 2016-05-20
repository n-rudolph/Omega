using UnityEngine;
using System.Collections;

public class GameOverCtrl : MonoBehaviour
{

    public ScoreController scoreController;

    private bool gameOn = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameOver(bool gameWon)
    {
        if (gameOn)
        {
            EndAnimation();
            gameOn = false;
        }

    }

    private void EndAnimation()
    {
        

    }
}
