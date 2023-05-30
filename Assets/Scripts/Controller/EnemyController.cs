using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator BlinkAnime;

    [SerializeField] GameObject EnemyFire;

    [SerializeField] float speed = 0.1f;
    float Blinktime = 0;
    [SerializeField] float MinBlink = 1f;
    [SerializeField] float MaxBlink = 8f;

    void Start()
    {
        BlinkAnime = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        Blinktime -= Time.deltaTime;
        // �����_���ɏu���A�U������
        if (Blinktime < 0)
        {
            BlinkAnime.SetTrigger("blink");
            Instantiate(EnemyFire, transform.position, Quaternion.identity);
        }
    }

    // ��ʊO�ɏo�������
    // Scene��ʂ�����O��Ă���ꍇ�̂�
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // �u���A�j���[�V�������I����Ă�����
    void Blink()
    {
        Blinktime = Random.Range(MinBlink, MaxBlink);
    }
}
