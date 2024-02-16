using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera fpsCamera;

    // 初期値は-1
    private int num = -1;

    void Start()
    {
        // FPSカメラのdepthの初期値を「-1」に設定(Mainカメラが「０」なので、最初はMainカメラが優先)
        fpsCamera.depth = num;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Cボタンを押すごとに、numの値が「１」と「−１」に変化する（テクニック）
            num *= -1;

            // depthが「１」の時・・・＞FPSカメラが優先
            // depthが「−１」の時・・・＞Mainカメラが優先
            fpsCamera.depth = num;
        }
    }
}
