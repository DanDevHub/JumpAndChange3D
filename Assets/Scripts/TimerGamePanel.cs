using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerGamePanel : MonoBehaviour
{
    public static int nextSceneLoad;
    public static int lastSceneLoad;
    public float timeStart;
    public Text timerbox;
    public static float finishTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        lastSceneLoad = SceneManager.GetActiveScene().buildIndex;
        timerbox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (ColorCheck.playerdead == false)
        {
            timeStart += Time.deltaTime;
            timerbox.text = timeStart.ToString("F2");
        }
        lvlcomplete();
        //PlayerPrefs.SetFloat("TimeScore", timeStart);
    }

    private void lvlcomplete()
    {
        //Move to LevelCompleteScene
        if(ColorCheck.endp == true)
        {
            finishTime = timeStart;
            Debug.Log(finishTime);
            SceneManager.LoadScene("LevelComplete");
            ColorCheck.endp = false;
            //Setting Int for index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }

    }
}
