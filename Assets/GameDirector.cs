using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject TimeGage;   // タイムゲージオブジェクト

    float reduce = 0;   // fillAmountを減らす量
    const float TIME_LIMIT = 100f;  // 制限時間の最大値
    float time = TIME_LIMIT;    // 残り時間

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        // 時間を減らす処理(経過時間を制限時間で割る)
        reduce = (time) / TIME_LIMIT;
        TimeGage.GetComponent<Image>().fillAmount = reduce;
    }

}
