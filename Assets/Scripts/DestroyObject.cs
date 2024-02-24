using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject effectPrefab2;  // 2種類目のエフェクトを入れるための箱

    public int objectHP;

    public GameObject itemPrefab;

    // このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手のTagにShellという名前が書いてあったならば(条件)
        if (other.CompareTag("Shell"))
        {
            // オブジェクトのHPを１ずつ減少させる
            objectHP -= 1;

            // もしもHPが0よりも大きい場合には(条件)
            if (objectHP > 0)
            {
                Destroy(other.gameObject);

                // 改良/ otherを追加する
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
            }
            else  // そうでない場合(HPが0以下になった場合)には(条件)
            {
                Destroy(other.gameObject);

                // もう１種類のエフェクトを発生させる
                // otherを追加
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 0.2f);

                Destroy(this.gameObject);

                // （ポイント）pos.y + 0.6fのコードでアイテムの出現場所の「高さ」を調整しています
                Vector3 pos = transform.position;
                Instantiate(itemPrefab, new Vector3(pos.x, pos.y + 0.8f, pos.z), Quaternion.identity);
            }

            // このスクリプトがついているオブジェクトを破壊する(thisは省略が可能)
           // Destroy(this.gameObject);

            // ぶつかってきたオブジェクトを破壊する
            // otherがどこに繋がっているか考えてみよう
          //  Destroy(other.gameObject);

            // エフェクトを実体化する
          //  GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            // エフェクトを2秒後に消す
          //  Destroy(effect, 2.0f);
        }
    }

    private void Instantiate(GameObject itemPrefab, Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
