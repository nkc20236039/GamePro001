using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject TimeGage;   // �^�C���Q�[�W�I�u�W�F�N�g

    const float TIME_LIMIT = 100f;  // �������Ԃ̍ő�l
    float time = TIME_LIMIT;    // �c�莞��
    public float damage;

    void Update()
    {
        time -= Time.deltaTime + damage;
        damage = 0;

        // �Q�[�W�����炷
        TimeGage.GetComponent<Image>().fillAmount = time / TIME_LIMIT;
    }
}
