using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // 追加

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;
    public GameObject shellPrefab;
    public AudioClip shotSound;

    public TextMeshProUGUI shellLabel;

    private float interval = 0.75f;

    private float timer = 0;

    private int shotCount;

    // 弾数の最大値の設定(最大値は自由)
    private int shotMaxCount = 20;

    private AudioSource audioS;   // 発射音

    private void Start()  // 「S」は大文字を確認！
    {
        shotCount = shotMaxCount;

        shellLabel.text = "" + shotCount;

        // 発射音
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        // タイマーの時間を動かす
        timer += Time.deltaTime;

        // もしもSpaceキーを押したならば(条件)
        // 「Space」の部分を変更することで他のキーにすることができる(ポイント)
        // 条件追加　「&&」の意味を復習しよう
        // 条件(&& shotCount > 0)の追加
        if (Input.GetKeyDown(KeyCode.Space) && timer > interval && shotCount > 0)
        {
            // *追加
            shotCount -= 1;

            // *追加
            shellLabel.text = "" + shotCount;

            // タイマーの時間を０に戻す
            timer = 0.0f;

            // 砲弾のプレハブを実体化(インスタンス化)する
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            // 砲弾についているRigidbodyコンポーネントにアクセスする
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // forward（青軸＝Z軸）の方向に力を加える
            shellRb.AddForce(transform.forward * shotSpeed);

            // 発射した砲弾を3秒後に破壊する
            // (重要な考え方)不要になった砲弾はメモリー上から削除すること
            Destroy(shell, 3.0f);

            // 発射音
            audioS.volume = 0.3f;
            audioS.PlayOneShot(shotSound);

            // 砲弾の発射音を出す(使用しないのでコメントアウト)
            //AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    // 残弾数を回復させるメソッド
    // このメソッドは外部からアクセスできるように「public」をつける（重要）
    // このメソッドをShellItemスクリプトから呼び出す
    public void AddShell(int amount)
    {
        // shotCountをamount分だけ回復させる
        shotCount += amount;

        // ただし、最大値を超えないようにする
        if (shotCount > shotMaxCount)
        {
            shotCount = shotMaxCount;
        }

        // 回復をUIに反映させる
        shellLabel.text = "" + shotCount;
    }
}
