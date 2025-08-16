using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlbuttons;

    private void Start()
    {
        int levelAT = PlayerPrefs.GetInt("levelAt", 3);

        for (int i = 0; i < lvlbuttons.Length; i++)
        {
            if (i + 2 > levelAT)
            {
                lvlbuttons[i].interactable = false;
            }
        }
    }
}
