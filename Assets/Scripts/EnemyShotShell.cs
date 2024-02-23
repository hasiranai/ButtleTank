using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;

    public GameObject enemyShellPrefab;

    public AudioClip shotSound;

    public int interval;

    private int count;

    private float stopTimer = 5.0f;  // 何秒間停止させるかは自由

    void Update()
    {
        count += 1;

        stopTimer -= Time.deltaTime;

        // ここの意味を考えてみよう
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        // 「%」と「==」の意味を考えよう(ポイント)
        // 条件の追加
        if (count % 100 == 0 && stopTimer <= 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向(青軸方向)・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);
        }
    }

    // 敵の攻撃を停止させるメソッド
    // （復習）このメソッドは外部からアクセスできるように「public」をつける（重要）
    // （復習）このメソッドをStopAttackItemスクリプトを呼び出す
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;
    }
}
