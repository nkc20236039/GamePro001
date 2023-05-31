using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject TimeGage;   // �^�C���Q�[�W�I�u�W�F�N�g
    [SerializeField] GameObject advance;    // �^�C���Q�[�W�I�u�W�F�N�g

    const float TIME_LIMIT = 100f;          // �������Ԃ̍ő�l
    float time = TIME_LIMIT;                // �c�莞��
    public static float damage;                    // �����������Ɍ��炳��鎞�ԃ_���[�W
    float MperS = 0;                        // 60m/s�̌v�Z

    void Update()
    {
        // �i�񂾋���
        MperS++;
        advance.GetComponent<TextMeshProUGUI>().text = MperS.ToString("000000") + "km";

        // �J�E���g�_�E���ƃ_���[�W���󂯂��Ƃ��̃��X���^�C���Q�[�W�ɕ\��
        time -= Time.deltaTime + damage;
        damage = 0;
        TimeGage.GetComponent<Image>().fillAmount = time / TIME_LIMIT;

        if (TimeGage.GetComponent<Image>().fillAmount <= 0)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
