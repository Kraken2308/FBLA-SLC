using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    public GameObject controlsText;
    

    // Update is called once per frame
    void Update()
    {



    }

    public void startGame()
    {
        SceneManager.LoadScene("Level1");
        ScoreManager.score = 0;
        PlayerMovement.playerHealth = 3;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();

    }

   public void showControls()
    {
        controlsText.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void hideControls()
    {
        controlsText.SetActive(false);
        mainMenu.SetActive(true);

    }
}
