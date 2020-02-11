using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    public QuizUI instance;
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject incorrectScreen;
    public static bool userWin = false;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;

        }
        question1.SetActive(true);
        question2.SetActive(false);
        question3.SetActive(false);
        incorrectScreen.SetActive(false);
    }

    public void incorrectQ1()
    {
        question1.SetActive(false);
        incorrectScreen.SetActive(true);
        StartCoroutine(Wait());
        incorrectScreen.SetActive(false);
        question1.SetActive(true);
    }
    public void correctQ1()
    {
        question1.SetActive(false);
        question2.SetActive(true);
    }
    public void incorrectQ2()
    {
        question2.SetActive(false);
        incorrectScreen.SetActive(true);
        StartCoroutine(Wait());
        incorrectScreen.SetActive(false);
        question2.SetActive(true);
    }
    public void correctQ2()
    {
        question2.SetActive(false);
        question3.SetActive(true);
    }
    public void incorrectQ3()
    {
        question3.SetActive(false);
        incorrectScreen.SetActive(true);
        StartCoroutine(Wait());
        incorrectScreen.SetActive(false);
        question3.SetActive(true);
    }
    public void correctQ3Lvl1()
    {
        SceneManager.LoadScene("Level2");
    }
    public void correctQ3Lvl2()
    {
        SceneManager.LoadScene("Level3");
    }
    public void correctQ3Lvl3()
    {
        SceneManager.LoadScene("Level4");
    }
    public void correctQ3Lvl4()
    {
        userWin = true;
        SceneManager.LoadScene("YouWin");
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
      
    }
}
