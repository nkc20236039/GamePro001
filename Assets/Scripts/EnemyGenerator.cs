using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    float randomMax = 4.5f;
    float randomMin = -4.5f;

    [SerializeField, Range(0.0f, 3.0f)] float span = 1.0f; // ��������
    float delta = 0;
    float summonX = 9;

    [SerializeField] GameObject Enemy;  // �����Ώ�

    void Update()
    {
        // span�̊Ԋu��Prefab������
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;  // init

            GameObject summon = Instantiate(Enemy);
            float px = Random.Range(randomMin, randomMax);

            summon.transform.position = new Vector3(summonX, px, 0);
        }
    }
}
