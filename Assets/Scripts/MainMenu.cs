using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Jungle2");
    }
    public void ShowCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ShowMenu()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }
}
