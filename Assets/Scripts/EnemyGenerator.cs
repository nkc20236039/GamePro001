using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    float randomMax = 4.5f;                                 // —”¶¬‚ÌX
    float randomMin = -4.5f;                                // —”¶¬‚ÌY
    
    [SerializeField, Range(0.0f, 3.0f)] float span = 1.0f;  // ¢Š«ŠÔŠu
    float delta = 0;                                        // Œo‰ßŠÔ
    const float SUMMON_X = 10;                                     // ¢Š«À•W

    [SerializeField] GameObject Enemy;  // ¢Š«‘ÎÛ

    void Update()
    {
        // span‚ÌŠÔŠu‚ÅPrefab‚ğ¢Š«
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;  // init

            // “G‚ğƒ‰ƒ“ƒ_ƒ€‚É¢Š«
            float px = Random.Range(randomMin, randomMax);
            Instantiate(Enemy, new Vector3(SUMMON_X, px, 0), Quaternion.identity);
        }
    }
}
