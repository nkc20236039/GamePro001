using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] float speed = 1.5f; // ファイアボールのスピード

    void Update()
    {
        // 進み続ける
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 目の敵に当たったらお互いを消す
        if (collision.gameObject.tag == "EnemyEye" && this.gameObject.tag == "PlayerFire")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        // 敵のファイアボールがプレイヤーに当たった場合
        else if(collision.gameObject.name == "Player" && this.gameObject.tag == "EnemyFire")
        {
            // 時間を減らす
            GameDirector.damage = 5f;
            Destroy(gameObject);
        }
    }

    // 画面外に出たら消す
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
