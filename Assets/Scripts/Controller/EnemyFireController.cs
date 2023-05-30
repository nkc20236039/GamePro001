using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireController : MonoBehaviour
{
    [SerializeField] float speed = -1.5f; // �t�@�C�A�{�[���̃X�s�[�h

    [SerializeField] GameObject Director;       // �f�B���N�^�[�I�u�W�F�N�g

    void Update()
    {
        // �i�ݑ�����
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �v���C���[�ɓ���������_���[�W��^����
        if (collision.gameObject.name == "Player")
        {
            Director.GetComponent<GameDirector>().damage = 5f;
            Destroy(gameObject);
        }
    }

    // ��ʊO�ɏo�������
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
