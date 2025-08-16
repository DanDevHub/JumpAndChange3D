using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject SettingPanel;
    public GameObject PlaySelection;
    public GameObject LevelSelection;

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.SetActive(false);
        PlaySelection.SetActive(false);
        LevelSelection.SetActive(false);
    }

    public void OpenSettings()
    {
        MenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void BacktoMenu()
    {
        MenuPanel.SetActive(true);
        SettingPanel.SetActive(false);
        PlaySelection.SetActive(false);
    }
    
    public void OpenPlaySelection()
    {
        MenuPanel.SetActive(false);
        LevelSelection.SetActive(false);
        PlaySelection.SetActive(true);
    }

    public void OpenLevelSelection()
    {
        PlaySelection.SetActive(false);
        LevelSelection.SetActive(true);
    }
}
