using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject pauseMenu;
    public GameObject circletimer;
    public Image CircleImg;
    private float timeAmt = 3;
    private float time;
    public static bool TimerIsActiv;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        circletimer.SetActive(false);
        time = timeAmt;
    }
    private void Update()
    {
        if(time > 0 && TimerIsActiv == true)
        {
            circletimer.SetActive(true);
            time -= Time.deltaTime;
            CircleImg.fillAmount = time / timeAmt ;
        }else if(time <= 0)
        {
            TimerIsActiv = false;
            circletimer.SetActive(false);
            GamePanel.SetActive(true);
        }
    }

    public void ShowpauseMenu()
    {
        pauseMenu.SetActive(true);
        GamePanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void DontshowpauseMenu()
    {
        TimerIsActiv = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
