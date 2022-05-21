using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public SurviveTime sr;
    private void Update()
    {
        var srt = sr.gameObject.GetComponent<SurviveTime>();
        if (srt.surviveTime > 60)
        {
            transform.Translate(Vector3.right * 9f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * 7f * Time.deltaTime);
        }
    }
}
