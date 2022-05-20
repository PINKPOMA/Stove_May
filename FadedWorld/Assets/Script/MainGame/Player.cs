using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float baseSpeed = 10f;
    [SerializeField] private float dashSpeed = 2f;
    [Space]
    [SerializeField] private float currentSpeed;
    [Space]
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int grounded;
    [Space]
    [Header("Dead")]
    [SerializeField] private bool isGray;
    [SerializeField] private Text deathNum;
    private float deathCount;
    Rigidbody2D rb;
    private GameObject deadText;
    public GameObject srt;
    public CanvasGroup fade;
    private bool isPain;
    private void Awake()
    {
        deadText = GameObject.Find("Canvas/DeadText");
        isGray = false;
        deathCount = 10;
        grounded = 0;
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
        if (Input.GetKeyDown(KeyCode.Space) && grounded < 2)
        {
            grounded += 1;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0,jumpForce * 100));
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

        if (isPain)
        {
            
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * currentSpeed / 2 * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * currentSpeed / 2 * Time.deltaTime);
        }
        else
        {
            
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }

        if (transform.position.y < -10)
        {
            Dead();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(grounded);
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = 0;
        }


    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Gray"))
        {
            deathNum.color = new Color(1,0,0,1);
            isGray = true;
        }

        if (col.gameObject.CompareTag("Pain"))
        {
            isPain = true;
            Invoke("NotPain", 3f);
        }
    }

    void NotPain()
    {
        isPain = false;
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
        fade.DOFade(1, 1f);
        srt.GetComponent<SurviveTime>().isDead = true;
        deathNum.color = new Color(1,0,0,0);
    }
}
