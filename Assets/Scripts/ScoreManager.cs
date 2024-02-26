using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // 追加

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private TextMeshProUGUI scoreLabel;

    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
        scoreLabel.text = "" + score;
    }

    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicをつけること
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "" + score;
    }
}
