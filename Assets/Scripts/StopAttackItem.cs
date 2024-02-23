using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    // 「配列」（プログラミング・ポイント）
    private GameObject[] targets;

    public AudioClip getSound;

    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 「EnemyShotShell」オブジェクトに「EnemyShotShell」タグを設定してください（ポイント）
            targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");

            // 「繰り返し文」（プログラミング・ポイント）
            // 「foreach」の使い方を学習しよう
            foreach (GameObject t in targets)
            {
                // 攻撃停止時間を「3秒」加算する（自由に変更可能）
                t.GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
            }

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
