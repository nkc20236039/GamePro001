using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir;                                // ���͕���
    Animator PlayerAnime;                       // �v���C���[�̃A�j���[�V����

    [SerializeField] GameObject Director;
    [SerializeField] GameObject fireBallPrefab; // �t�@�C�A�{�[���̃v���n�u
    
    [SerializeField] float speed = 1f;          // �ړ����x
    [SerializeField] float fireBallSpan = 3;    // ���������Ă���Ƃ��Ɏˏo�����Ԋu
    float hitDamage = 10f;                      // �G�ɓ����������̃_���[�W
    float time;

    // �ړ�����
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

        // �t�@�C�A�{�[�����΂�
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

        // �����Ă��Ȃ����̃N�[���_�E��
        else if (time < fireBallSpan)
        {
            time += 0.01f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyEye")
        {
            // ���Ԃ����炷
            Director.GetComponent<GameDirector>().damage = hitDamage;

            // ���������G���폜
            Destroy(collision.gameObject);
        }
    }
}
