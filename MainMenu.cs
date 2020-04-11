using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] _allPanels;
    //[SerializeField] private int _sceneIndex;

    public void StartGame()
    {
        SceneManager.LoadScene((int)Scenes.HintScene);
    }

    public void ShowMenu(GameObject menu)
    {
        foreach (var panel in _allPanels)
        {
            if (panel != menu)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
