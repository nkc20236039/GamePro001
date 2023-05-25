using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject TimeGage;   // タイムゲージオブジェクト

    const float TIME_LIMIT = 100f;  // 制限時間の最大値
    float time = TIME_LIMIT;    // 残り時間
    public float damage;

    void Update()
    {
        time -= Time.deltaTime + damage;
        damage = 0;

        // ゲージを減らす
        TimeGage.GetComponent<Image>().fillAmount = time / TIME_LIMIT;
    }
}
