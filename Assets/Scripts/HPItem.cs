using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public GameObject effectPrefab;

    public AudioClip getSound;

    private TankHealth th;

    public int reward = 3;  // いくつ回復させるかは自由！

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find()メソッドの使い方をマスターすること
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            // ここの意味をしっかり復習すること
            // AddHP()メソッドを呼び出して「引数」にrewardを与えている
            th.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
}
