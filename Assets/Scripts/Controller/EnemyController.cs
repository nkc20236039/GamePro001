using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator BlinkAnime;

    [SerializeField] GameObject EnemyFire;

    [SerializeField] float speed = 0.1f;
    float Blinktime = 0;
    [SerializeField] float MinBlink = 1f;
    [SerializeField] float MaxBlink = 8f;

    void Start()
    {
        BlinkAnime = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        Blinktime -= Time.deltaTime;
        // ランダムに瞬き、攻撃する
        if (Blinktime < 0)
        {
            BlinkAnime.SetTrigger("blink");
            Instantiate(EnemyFire, transform.position, Quaternion.identity);
        }
    }

    // 画面外に出たら消す
    // Scene画面からも外れている場合のみ
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // 瞬きアニメーションが終わっていたら
    void Blink()
    {
        Blinktime = Random.Range(MinBlink, MaxBlink);
    }
}
