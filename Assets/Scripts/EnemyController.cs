using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 敵を移動させるスクリプト
    [SerializeField] float speed = 0.1f;

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }

    // 画面外に出たら消す
    // Scene画面からも外れている場合のみ
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
