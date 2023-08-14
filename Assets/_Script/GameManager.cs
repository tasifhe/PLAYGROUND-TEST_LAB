using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cameraA;
    public Camera cameraB;

    public Material cameraMatA;
    public Material cameraMatB;

    public int renderTextureWidth = 1920;
    public int renderTextureHieght = 1080;
    void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        //cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraA.targetTexture = new RenderTexture(renderTextureWidth, renderTextureHieght, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        //cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraB.targetTexture = new RenderTexture(renderTextureWidth, renderTextureHieght, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }
}
