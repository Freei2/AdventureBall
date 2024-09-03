using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI LoseText;

    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        SetScoreText();
        WinText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
    }

    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetScoreText()
    {
        scoreText.text = "Score :" + score.ToString();
        if (score >= 40)
        {
            WinText.gameObject.SetActive(true);
        }
        if (score <= 0)
        {
            LoseText.gameObject.SetActive(true);
        }
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;

            SetScoreText();
        }
        
        if (other.gameObject.CompareTag("MinusPickUp"))
        {
            other.gameObject.SetActive(false);
            score--;

            SetScoreText();
        }
    }
}
