using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    void Update()
    {
        // ���N���b�N���X�y�[�X�L�[���R���g���[���[0�ŊJ�n
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
