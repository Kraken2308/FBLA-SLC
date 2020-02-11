using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack2Controller : MonoBehaviour
{
    public GameObject quizUI;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizUI.SetActive(true);
        }
    }
}
