using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    float randomMax = 4.5f;                                 // ����������X
    float randomMin = -4.5f;                                // ����������Y
    
    [SerializeField, Range(0.0f, 3.0f)] float span = 1.0f;  // �����Ԋu
    float delta = 0;                                        // �o�ߎ���
    const float SUMMON_X = 10;                                     // �������W

    [SerializeField] GameObject Enemy;  // �����Ώ�

    void Update()
    {
        // span�̊Ԋu��Prefab������
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;  // init

            // �G�������_���ɏ���
            float px = Random.Range(randomMin, randomMax);
            Instantiate(Enemy, new Vector3(SUMMON_X, px, 0), Quaternion.identity);
        }
    }
}
