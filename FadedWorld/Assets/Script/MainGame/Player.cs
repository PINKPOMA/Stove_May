using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float dashSpeed = 2f;
    [Space]
    [SerializeField] private float currentSpeed;
    [Space]
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool grounded;
    [Space]
    [Header("Dead")]
    [SerializeField] private bool isGray;
    [SerializeField] private Text deathNum;
    private float deathCount;
    Rigidbody2D rb;
    private GameObject deadText;
    private void Awake()
    {
        deadText = GameObject.Find("Canvas/DeadText");
        isGray = false;
        deathCount = 10;
        grounded = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        InGrayZone();
        Bar();
    }

    void Bar()
    {
        deathNum.text = String.Format("{0:N2}", deathCount);
        deadText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(transform.up * jumpForce * 100);
        }
    }

    void InGrayZone()
    {
        if (isGray)
        {
            deathCount -= Time.deltaTime;
            if (deathCount <= 0)
            {
                Dead();
            }
        }
    }
    private void Move()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? baseSpeed * dashSpeed : baseSpeed;
        
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(grounded);
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }


    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Gray"))
        {
            deathNum.color = new Color(1,0,0,1);
            isGray = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gray"))
        {
            deathNum.color = new Color(1,0,0,0);
            isGray = false;
        }
    }

    void Dead()
    {
        deathNum.color = new Color(1,0,0,0);
        SceneManager.LoadScene(2);
    }
}
