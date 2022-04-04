using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    float timer;
    float timerMax;

    private void Update()
    {
        timerMax = 60;
        timer += Time.deltaTime * 1f;
        if(timer >= timerMax)
        {
            SceneManager.LoadScene(1);
        }
    }
}
