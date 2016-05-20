using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCtrl : MonoBehaviour
{

    public ScoreController scoreController;

    public Text finishText;
    public RectTransform panel;

    private bool gameOn = true;

    public void GameOver(bool gameWon)
    {
        if (gameOn)
        {
            panel.gameObject.SetActive(true);
            finishText.gameObject.SetActive(true);
            if (gameWon)
            {
                finishText.text = "You Won!! \n\n Score : " + scoreController.GetScore();
            }
            else
            {
                finishText.text = "Game Over!!";
            }
            
            gameOn = false;
        }

    }

}
