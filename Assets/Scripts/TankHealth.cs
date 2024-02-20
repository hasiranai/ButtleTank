using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 追加
using TMPro;                        // 追加

public class TankHealth : MonoBehaviour
{
    public GameObject effectPrefab1;

    public GameObject effectPrefab2;

    public int tankHP;

    public TextMeshProUGUI hpLabel;

    private void Start()
    {
        hpLabel.text = "" + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかってきた相手のTagが”EnemyShell”であったならば(条件)
        if (other.CompareTag("EnemyShell"))
        {
            // HPを１ずつ減少させる
            tankHP -= 1;

            hpLabel.text = "" + tankHP;

            // ぶつかってきた相手方(敵の砲弾)を破壊する
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else   // 上の条件が成立しなくなった場合にはこちらを実行する
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // プレーヤーを破壊する
                //Destroy(gameObject);

                // プレーヤーを破壊せずにオフモードにする(ポイント・テクニック)
                // プレーヤーを破壊すると、その時点でメモリー上から消えるので、それ以降のコードが実行されなくなる
                this.gameObject.SetActive(false);

                // 1.5秒後に「GoToGameOver()」メソッドを実行する
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
