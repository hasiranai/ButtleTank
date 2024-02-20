using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    public AudioClip getSound;

    public GameObject effectPrefab;

    private ShotShell ss;

    private int reward = 5;   // 弾数をいくつ回復させるかは自由に設定

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find()の復習
            ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();

            // ここの意味をおさえよう！（重要ポイント）
            // メソッド経由で変数の値を変更する
            // ShotShellスクリプトの中に記載されている「AddShellメソッド」を呼び出す
            // rewardで設定した数値分だけ弾数が回復する
            ss.AddShell(reward);

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
