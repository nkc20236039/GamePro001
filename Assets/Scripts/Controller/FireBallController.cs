using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] float speed = 1.5f; // ファイアボールのスピード

    void Update()
    {
        // 進み続ける
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 目の敵に当たったらお互いを消す
        if (collision.gameObject.tag == "EnemyEye")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // 画面外に出たら消す
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
