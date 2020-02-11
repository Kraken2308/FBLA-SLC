using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator myAnimator;
    public CharacterController2D controller;
    public float sprintSpeed = 60f;
    public float runSpeed = 40f;
    public static int playerHealth = 3;
    float horizontalMove = 0f;
    bool jump = false;
    public GameObject fullHeart1;
    public GameObject fullHeart2;
    public GameObject fullHeart3;
    public Rigidbody2D rigidbody;
    public GameObject player;
    public Vector3 moveDirection;
    public PlayerMovement instance;
    public static bool gameOver = false;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * sprintSpeed;
            myAnimator.SetFloat("RunningSpeed", Mathf.Abs(horizontalMove));
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            myAnimator.SetFloat("RunningSpeed", Mathf.Abs(horizontalMove));
        }



        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            myAnimator.SetBool("IsJumping", true);

        }
        if (playerHealth > 3)
        {
            playerHealth = 3;
        }

        else if (playerHealth == 3)
        {
            fullHeart1.SetActive(true);
            fullHeart2.SetActive(true);
            fullHeart3.SetActive(true);
        }
        else if (playerHealth == 2)
        {
            fullHeart1.SetActive(true);
            fullHeart2.SetActive(true);
            fullHeart3.SetActive(false);
        }
        else if (playerHealth == 1)
        {
            fullHeart1.SetActive(true);
            fullHeart2.SetActive(false);
            fullHeart3.SetActive(false);
        }
        else if (playerHealth <= 0)
        {
            fullHeart1.SetActive(false);
            fullHeart2.SetActive(false);
            fullHeart3.SetActive(false);
            Die();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tokens")) {
            Destroy(other.gameObject);

        } else if (other.gameObject.CompareTag("Spikes"))
        {
            playerHealth--;
            moveDirection = rigidbody.transform.position - other.transform.position;

            rigidbody.AddForce(moveDirection.normalized * 600f);

        } else if (other.gameObject.CompareTag("Spring"))
        {
            moveDirection = rigidbody.transform.position - other.transform.position;
            rigidbody.AddForce(moveDirection.normalized * 2000f);
        }

    }

    public void OnLanding()
    {

        myAnimator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

    }
    public void Die()
    {
        myAnimator.SetTrigger("Die");
        gameOver = true;
        StartCoroutine(Wait());

       
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}


