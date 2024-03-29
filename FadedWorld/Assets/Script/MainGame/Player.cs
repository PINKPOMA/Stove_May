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
    [SerializeField] private bool isRain;
    [SerializeField] private Text deathNum;
    private float deathCount;
    Rigidbody2D rb;
    private GameObject deadText;
    public CanvasGroup fade;
    private Animator animator;
    private bool isPain;
    private SpriteRenderer rend;
    private void Awake()
    {
        deadText = GameObject.Find("Canvas/DeadText");
        isGray = false;
        deathCount = 10;
        grounded = 0;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        InGrayZone();
        Bar();
        InRainZone();
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
            SoundManager.instance.PlayJumpSound();
            animator.SetBool("IsJump", true);
            animator.SetBool("IsIdle", false);
        }
    }

    void InGrayZone()
    {
        if (isGray)
        {
            deathNum.color = new Color(1,0,0,1);
            deathCount -= Time.deltaTime;
            if (deathCount <= 0)
            {
                Dead();
            }
        }
        else if (!isRain)
        {
            
            deathNum.color = new Color(1,0,0,0);
        }
    }
    void InRainZone()
    {
        if (isRain)
        {
            deathNum.color = new Color(1,0,0,1);
            deathCount -= Time.deltaTime;
            if (deathCount <= 0)
            {
                Dead();
            }
        }        
        else if (!isGray)
        {
            
            deathNum.color = new Color(1,0,0,0);
        }
    }
    private void Move()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? baseSpeed : baseSpeed * dashSpeed;
        float h = Input.GetAxisRaw("Horizontal");

        if (h == 0)
        {
            animator.SetBool("IsIdle", true);
        }

        if (isPain)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJump", false);
            animator.SetFloat("IsRun", 0.5f);

            if (h > 0)
            {
                rend.flipX = false;
                transform.Translate(Vector3.right * h * currentSpeed / 2 * Time.deltaTime);
            }

            else if (h < 0)
            {
                rend.flipX = true;
                transform.Translate(Vector3.right * h * currentSpeed / 2 * Time.deltaTime);
            }
        }
        
        else
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJump", false);
            animator.SetFloat("IsRun", 1f);

            if (h == 0)
            {
                animator.SetBool("IsIdle", true);
            }
            
            if (h > 0)
            {
                rend.flipX = false;
                transform.Translate(Vector3.right * h * currentSpeed * Time.deltaTime);
            }

            else if (h < 0)
            {
                rend.flipX = true;
                transform.Translate(Vector3.right * h * currentSpeed * Time.deltaTime);
            }
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
        if (col.gameObject.CompareTag("Rain"))
        {
            deathNum.color = new Color(1,0,0,1);
            isRain = true;
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
        if (other.gameObject.CompareTag("Rain"))
        {
            deathNum.color = new Color(1,0,0,0);
            isRain = false;
        }
        if (other.gameObject.CompareTag("Item"))
        {
            deathCount += 5;
            if (deathCount > 10)
            {
                deathCount = 10;
            }
            Destroy(other.gameObject);
            SoundManager.instance.PlayClockSound();
        }
    }

    void Dead()
    {
        fade.DOFade(1, 1f);
        var srt = GameObject.FindWithTag("MainTimer").GetComponent<MainTimer>();
        SoundManager.instance.PlayDieSound();
        srt.Dead();
        deathNum.color = new Color(1,0,0,0);
    }
}
