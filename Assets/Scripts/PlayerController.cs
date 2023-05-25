using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir;    // 入力方向
    Animator PlayerAnime;  // プレイヤーのアニメーション
    [SerializeField]    float speed = 0.5f; // 移動速度
    // 移動制限
    [SerializeField]    Vector2 rangeMax = new Vector2(10.0f, 5.0f);
    [SerializeField]    Vector2 rangeMin = new Vector2(-10.0f, -5.0f);

    Vector3 pos;

    void Start()
    {
        PlayerAnime = GetComponent<Animator>();
    }

    void Update()
    {
        /*__INIT__*/
        dir = Vector3.zero;
        pos = transform.position;

        // 入力方向取得
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        // 移動方向によってプレイヤーアニメーションの傾きを変更
        PlayerAnime.SetFloat("Turn", dir.y);

        // 移動量を設定
        pos += dir.normalized * speed;

        // 範囲内を移動
        pos.x = Mathf.Clamp(pos.x, rangeMin.x, rangeMax.x);
        pos.y = Mathf.Clamp(pos.y, rangeMin.y, rangeMax.y);

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyEye")
        {
            Destroy(collision.gameObject);
        }
    }
}
