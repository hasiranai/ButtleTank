using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public AudioClip sound;

    public void OnStartButtonClicked()
    {
        StartCoroutine(GoToMain());
    }

    // ＊コルーチン(「実行・・・＞待機・・・＞実行」の仕組みを作れる)
    private IEnumerator GoToMain()
    {
        // 音を発生させる(実行１)
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

        // 1.5秒待つ(待機)
        yield return new WaitForSeconds(1.5f);

        // Mainシーンに移行する(実行２)
        SceneManager.LoadScene("Main");
    }
}
