using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCus : MonoBehaviour
{
    public Material shadowmat;
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src,dest,shadowmat);
    }
}
