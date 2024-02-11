using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderX : MonoBehaviour
{
    private GameObject target;

    private float dis;

    void Start()
    {
        // Find () ・・・＞ゲーム画面上で「名前」でオブジェクトを取得する
        target = GameObject.Find("Tank");
    }

    void Update()
    {
        // targetとなるオブジェクトが存在する時だけ実行(条件)
        if (target)
        {
            // ２点間(今回は「自分」と「ターゲット」の位置)の距離を取得する(ポイント)
            dis = Vector3.Distance(transform.position, target.transform.position);

            if (dis < 5)
            {
                // LookAt() ・・・＞指定した方向にオブジェクトの向きを回転させることができる
                transform.LookAt(target.transform);
            }
        }
    }
}
