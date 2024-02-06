using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手のTagにShellという名前が書いてあったならば(条件)
        if (other.CompareTag("Shell"))
        {
            // このスクリプトがついているオブジェクトを破壊する(thisは省略が可能)
            Destroy(this.gameObject);

            // ぶつかってきたオブジェクトを破壊する
            // otherがどこに繋がっているか考えてみよう
            Destroy(other.gameObject);
        }
    }
}