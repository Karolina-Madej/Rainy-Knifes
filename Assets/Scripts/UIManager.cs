using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timerText;


    public void Start()
    {
        EventMaganer.timers += TimeCounter;
    }

    void TimeCounter() {

            timerText.text = "Time: " + EventMaganer.timer;

    }

}
