using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackController : MonoBehaviour
{
    public bool dialogueDone;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !dialogueDone)
        {
      
            DialogueTrigger.instance.TriggerDialogue();
            StartCoroutine(Wait());
            dialogueDone = true;
        }
    
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);

    }
}