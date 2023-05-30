using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireController : MonoBehaviour
{
    [SerializeField] float speed = -1.5f; // ファイアボールのスピード

    [SerializeField] GameObject Director;       // ディレクターオブジェクト

    void Update()
    {
        // 進み続ける
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーに当たったらダメージを与える
        if (collision.gameObject.name == "Player")
        {
            Director.GetComponent<GameDirector>().damage = 5f;
            Destroy(gameObject);
        }
    }

    // 画面外に出たら消す
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
