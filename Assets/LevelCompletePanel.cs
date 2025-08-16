using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePanel : MonoBehaviour
{
    public Text levelTime;
    public Text levelTimedifference;
    public Text Levelnr;
    public Text highscore;

    string Levelname;
    private float recorddifference;
    // Start is called before the first frame update
    void Start()
    {
        LevelString();
        Levelnr.text = string.Format("{0} Completed",Levelname);
        levelTime.text = TimerGamePanel.finishTime.ToString("F3");
       if (PlayerPrefs.GetFloat(Levelname) <= TimerGamePanel.finishTime)
       {
            PlayerPrefs.SetFloat(Levelname, TimerGamePanel.finishTime);
            Debug.Log("Timersafed");
       }
        highscore.text = string.Format("Highscore {0}", PlayerPrefs.GetFloat(Levelname));
        recorddifference = PlayerPrefs.GetFloat(Levelname) - TimerGamePanel.finishTime;
        levelTimedifference.text = recorddifference.ToString("F3");
    }

    private void LevelString()
    {
        int lvlnr = TimerGamePanel.lastSceneLoad - 3;
        switch (lvlnr)
        {
            case 0:
                Levelname = "Level 1";
                break;
            case 1:
                Levelname = "Level 2";
                break;
            case 2:
                Levelname = "Level 3";
                break;
            case 3:
                Levelname = "Level 4";
                break;
            case 4:
                Levelname = "Level 5";
                break;
            case 5:
                Levelname = "Level 6";
                break;
            case 6:
                Levelname = "Level 7";
                break;


        }
    }
}
