using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup fain;
    void Start()
    {
        fain.DOFade(0, 1f);
    }
}
