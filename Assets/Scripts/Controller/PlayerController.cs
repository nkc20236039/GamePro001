using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir;                                // 入力方向
    Animator PlayerAnime;                       // プレイヤーのアニメーション

    [SerializeField] GameObject Director;
    [SerializeField] GameObject fireBallPrefab; // ファイアボールのプレハブ
    
    [SerializeField] float speed = 1f;          // 移動速度
    [SerializeField] float fireBallSpan = 3;    // 長押ししているときに射出される間隔
    float hitDamage = 10f;                      // 敵に当たった時のダメージ
    float time;

    // 移動制限
    [SerializeField] Vector2 rangeMax = new Vector2(10.0f, 5.0f);
    [SerializeField] Vector2 rangeMin = new Vector2(-10.0f, -5.0f);

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

        // ファイアボールを飛ばす
        if (Input.GetButton("Fire1"))
        {
            time += Time.deltaTime;
            if (time > fireBallSpan)
            {
                time = 0;
                GameObject fireBall =  Instantiate(fireBallPrefab);
                fireBall.transform.position = this.transform.position;
            }
        }

        // 撃っていない時のクールダウン
        else if (time < fireBallSpan)
        {
            time += 0.01f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyEye")
        {
            // 時間を減らす
            Director.GetComponent<GameDirector>().damage = hitDamage;

            // 当たった敵を削除
            Destroy(collision.gameObject);
        }
    }
}
