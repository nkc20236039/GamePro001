using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    private TextMeshProUGUI gameOverText;
    private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreObject;

    private float value;
    private float score;
    public static float ScoreResult;


    void Start()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        scoreObject.SetActive(false);
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        if (gameOverText.fontSharedMaterial.GetFloat(ShaderUtilities.ID_FaceDilate) <= 0)
        {
            value += 0.1f;
            gameOverText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, value);
        }
        else if(scoreObject.activeInHierarchy == false)
        {
            scoreObject.SetActive(true);
        }
        else
        {
            if (score <= ScoreResult)
            {
                score++;
                scoreText.text = "Score : " + score.ToString("000000");
            }
            
        }
        
    }
}
