using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    public GameObject effectPrefab;

    public AudioClip getSound;

    public float speedupRate = 1.2f;
    public float duration = 5.0f;

    private TankMovement tm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find()メソッドの使い方をマスターすること
            tm = GameObject.Find("Tank").GetComponent<TankMovement>();

            // ここの意味をしっかり復習すること
            // AddHP()メソッドを呼び出して「引数」にrewardを与えている
            tm.BoostMoveSpeed(speedupRate, duration);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
}
