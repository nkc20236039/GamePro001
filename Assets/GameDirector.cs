using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject TimeGage;   // �^�C���Q�[�W�I�u�W�F�N�g

    float reduce = 0;   // fillAmount�����炷��
    const float TIME_LIMIT = 100f;  // �������Ԃ̍ő�l
    float time = TIME_LIMIT;    // �c�莞��

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        // ���Ԃ����炷����(�o�ߎ��Ԃ𐧌����ԂŊ���)
        reduce = (time) / TIME_LIMIT;
        TimeGage.GetComponent<Image>().fillAmount = reduce;
    }

}
