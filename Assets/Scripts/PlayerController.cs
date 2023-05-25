using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir;    // ���͕���
    Animator PlayerAnime;  // �v���C���[�̃A�j���[�V����
    [SerializeField]    float speed = 0.5f; // �ړ����x
    // �ړ�����
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

        // ���͕����擾
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        // �ړ������ɂ���ăv���C���[�A�j���[�V�����̌X����ύX
        PlayerAnime.SetFloat("Turn", dir.y);

        // �ړ��ʂ�ݒ�
        pos += dir.normalized * speed;

        // �͈͓����ړ�
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
