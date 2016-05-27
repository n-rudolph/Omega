using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCtrl : MonoBehaviour
{

    public ScoreController scoreController;

    public GameObject finishCanvas;
    public GameObject finishText;

    private Canvas canvas;
    private Text text;

	private SoundController soundCtrl;

    void Start()
    {
        canvas = finishCanvas.GetComponent<Canvas>();
        text = finishText.GetComponent<Text>();
		soundCtrl = GetComponent<SoundController> ();
		soundCtrl.PlayBackgroundSound (SoundEnum.BACKGROUND);
    }

    private bool gameOn = true;

    public void GameOver(bool gameWon)
    {
        
        if (gameOn)
        {
            canvas.enabled = true;
            
            if (gameWon)
            {
				soundCtrl.PlayBackgroundSound (SoundEnum.VICTORY);
                text.text = "\nYou Won!! \n\n Score : " + scoreController.GetScore();
            }
            else
            {
				soundCtrl.PlayBackgroundSound (SoundEnum.GAMEOVER);
                text.text = "\nGame Over!! \n\n You Lose";
            }
            gameOn = false;
        }

    }

}
