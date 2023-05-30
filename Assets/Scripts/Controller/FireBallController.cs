using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] float speed = 1.5f; // �t�@�C�A�{�[���̃X�s�[�h

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime,  0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyEye")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
