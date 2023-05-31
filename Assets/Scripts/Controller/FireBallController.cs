using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] float speed = 1.5f; // �t�@�C�A�{�[���̃X�s�[�h

    void Update()
    {
        // �i�ݑ�����
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڂ̓G�ɓ��������炨�݂�������
        if (collision.gameObject.tag == "EnemyEye" && this.gameObject.tag == "PlayerFire")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        // �G�̃t�@�C�A�{�[�����v���C���[�ɓ��������ꍇ
        else if(collision.gameObject.name == "Player" && this.gameObject.tag == "EnemyFire")
        {
            // ���Ԃ����炷
            GameDirector.damage = 5f;
            Destroy(gameObject);
        }
    }

    // ��ʊO�ɏo�������
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
