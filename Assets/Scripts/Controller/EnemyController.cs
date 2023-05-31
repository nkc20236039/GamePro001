using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator BlinkAnime;

    [SerializeField] GameObject EnemyFire;
    [SerializeField] GameObject Target;

    [SerializeField] float speed = 0.1f;
    float Blinktime = 0;
    [SerializeField] float MinBlink = 0.5f;
    [SerializeField] float MaxBlink = 3f;

    void Start()
    {
        BlinkAnime = GetComponent<Animator>();
        Blinktime = Random.Range(1, 2);
        Target = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        Blinktime -= Time.deltaTime;
        // ランダムに瞬き、攻撃する
        Debug.Log(Blinktime);
        if (Blinktime < 0)
        {
            Blinktime = 1000;
            BlinkAnime.SetTrigger("blink");
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
        Vector3 toDirection = Target.transform.position - this.transform.position;
        Instantiate(EnemyFire, transform.position, Quaternion.FromToRotation(Vector3.up, toDirection));
        Blinktime = Random.Range(MinBlink, MaxBlink);
    }
}
