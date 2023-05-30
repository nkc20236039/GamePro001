using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    void Update()
    {
        // 左クリックかスペースキーかコントローラー0で開始
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
