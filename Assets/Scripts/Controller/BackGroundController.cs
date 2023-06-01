using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private Vector3 targetPos = new Vector3(-8.75f, 0f, 0f);
    private Vector3 startPos;
    private float totalTime = 100f;
    private float delta = 0f;
    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        delta += Time.deltaTime;
        float t = delta / totalTime;

        // 座標を補間してオブジェクト移動
        transform.position = Vector3.Lerp(startPos, targetPos, t);
    }
}
