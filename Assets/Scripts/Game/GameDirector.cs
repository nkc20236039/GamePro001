using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject TimeGage;   // タイムゲージオブジェクト
    [SerializeField] GameObject advance;    // タイムゲージオブジェクト

    const float TIME_LIMIT = 100f;          // 制限時間の最大値
    float time = TIME_LIMIT;                // 残り時間
    public static float damage;                    // 当たった時に減らされる時間ダメージ
    float MperS = 0;                        // 60m/sの計算

    void Update()
    {
        // 進んだ距離
        MperS++;
        advance.GetComponent<TextMeshProUGUI>().text = MperS.ToString("000000") + "km";

        // カウントダウンとダメージを受けたときのロスをタイムゲージに表示
        time -= Time.deltaTime + damage;
        damage = 0;
        TimeGage.GetComponent<Image>().fillAmount = time / TIME_LIMIT;

        if (TimeGage.GetComponent<Image>().fillAmount <= 0)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
