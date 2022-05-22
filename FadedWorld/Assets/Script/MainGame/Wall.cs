using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public bool isWark;
    [SerializeField]private Text mv;
    private void Update()
    {
        IsWarkTrue();
        Move();
    }

    void IsWarkTrue()
    {
        if (isWark)
            return;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            mv.DOFade(0, 2f);
            isWark = true;
        }
    }

    void Move()
    {
        if(isWark)
            transform.Translate(Vector3.right * 7.5f * Time.deltaTime);
    }
}
