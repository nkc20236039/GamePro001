using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    float randomMax = 4.5f;                                 // Ά¬ΜX
    float randomMin = -4.5f;                                // Ά¬ΜY
    
    [SerializeField, Range(0.0f, 3.0f)] float span = 1.0f;  // ’«Τu
    float delta = 0;                                        // oίΤ
    const float SUMMON_X = 10;                                     // ’«ΐW

    [SerializeField] GameObject Enemy;  // ’«ΞΫ

    void Update()
    {
        // spanΜΤuΕPrefabπ’«
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;  // init

            // Gπ_Ι’«
            float px = Random.Range(randomMin, randomMax);
            Instantiate(Enemy, new Vector3(SUMMON_X, px, 0), Quaternion.identity);
        }
    }
}
