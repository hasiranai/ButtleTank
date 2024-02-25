using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject effectPrefab2;  // 2種類目のエフェクトを入れるための箱

    public int objectHP;

    public GameObject[] itemPrefabs;   // 配列・・・＞複数のデータを入れることができる箱

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

                // ランダムメソッドの使い方を学習しよう
                // itemNumberが「０〜９９」のいずれかになるように改良する時は「itemPrefabs.Length」の部分を「100」に書き換える
                int itemNumber = UnityEngine.Random.Range(0, itemPrefabs.Length);

                if (itemPrefabs.Length != 0)
                {
                    // （ポイント）pos.y + 0.6fのコードでアイテムの出現場所の「高さ」を調整しています
                    Vector3 pos = transform.position;

                    // itemNumberの数字によって、出るアイテムが変化する（ポイント）
                    Instantiate(itemPrefabs[itemNumber], new Vector3(pos.x, pos.y + 0.8f, pos.z), Quaternion.identity);

                    // StopAttackItemの出現確率・・・＞１０％
                    //if (itemNumber < 10)
                    //{
                    //    Instantiate(itemPrefabs[2], new Vector3(pos.x, pos.y + 0.8f, pos.z), Quaternion.identity);
                    //}

                    // ShellItemの出願確率・・・＞３０％
                    //else if (itemNumber < 40)
                    //{
                    //    Instantiate(itemPrefabs[1], new Vector3(pos.x, pos.y + 0.8f, pos.z), Quaternion.identity);
                    //}
                    // HPItemの出現確率・・・＞３０％
                }
            }
        }
    }
}
