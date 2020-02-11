using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager instance;
    public int hintsShown = 0;
    public int hintCost = -10;
    public GameObject info1;
    public GameObject info2;
    public GameObject info3;
    // Start is called before the first frame update
    void Start()
    {
        hintsShown = 0;

        if (instance = null)
        {
            instance = this;
        }
    }
    public void buyHint()
    {
        if (ScoreManager.score >= 10)
        {
            ScoreManager.instance.ChangeScore(hintCost);
            hintsShown++;
        }
    }
    void FixedUpdate()
    {
        if (hintsShown >= 1)
        {
            info1.SetActive(true);
        }
        else
        {
            info1.SetActive(false);
            info2.SetActive(false);
            info3.SetActive(false);
        }
        if (hintsShown >= 2)
        {
            info1.SetActive(true);
            info2.SetActive(true);
        }
        if (hintsShown >= 3)
        {
            info1.SetActive(true);
            info2.SetActive(true);
            info3.SetActive(true);
        }

    }
}
