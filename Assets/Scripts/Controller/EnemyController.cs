using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // �G���ړ�������X�N���v�g
    [SerializeField] float speed = 0.1f;

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }

    // ��ʊO�ɏo�������
    // Scene��ʂ�����O��Ă���ꍇ�̂�
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
