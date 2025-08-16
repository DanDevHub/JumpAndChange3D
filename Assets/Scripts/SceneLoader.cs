using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void backtoMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void loadlvlInfinity()
    {
        SceneManager.LoadScene("InfinityModus");
    }

    public void loadlvl1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void loadlvl2()
    {
        SceneManager.LoadScene("lvl2");
    }
    public void loadlvl3()
    {
        SceneManager.LoadScene("lvl3");
    }
    public void loadlvl4()
    {
        SceneManager.LoadScene("lvl4");
    }
    public void loadlvl5()
    {
        SceneManager.LoadScene("lvl5");
    }
    public void loadlvl6()
    {
        SceneManager.LoadScene("lvl6");
    }
    public void loadlvl7()
    {
        SceneManager.LoadScene("lvl7");
    }
    public void loadnextlevel()
    {
        SceneManager.LoadScene(TimerGamePanel.nextSceneLoad);
    }

    public void loadlastlevel()
    {
        SceneManager.LoadScene(TimerGamePanel.lastSceneLoad);
    }
}
