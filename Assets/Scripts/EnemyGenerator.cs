using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    int randomMax = 5;
    int randomMin = -5;

    [SerializeField, Range(0.0f, 3.0f)] float span = 1.0f; // ¢Š«ŽžŠÔ
    float delta = 0;

    [SerializeField] GameObject Enemy;  // ¢Š«‘ÎÛ

    void Update()
    {
        // span‚ÌŠÔŠu‚ÅPrefab‚ð¢Š«
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;  // init

            GameObject summon = Instantiate(Enemy);
            float px = Random.Range(randomMin, randomMax);

            summon.transform.position = new Vector3(10, px, 0);
        }
    }
}
