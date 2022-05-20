using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.right * 7.5f * Time.deltaTime);
    }
}
