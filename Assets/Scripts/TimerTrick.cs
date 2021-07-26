using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;

public class TimerTrick : MonoBehaviour
{
    public float time = 60;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time - Time.deltaTime;
        //float time1 = Mathf.Round(time);
        scoreText.text = "Time: " + Mathf.Round(time);
    }
}
