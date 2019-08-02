using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaganer : MonoBehaviour
{
     public static EventMaganer current;
     public delegate void TimerAction();
     public static event TimerAction timers;
     public static int timer;

    public void Awake()
    {
        current = this;
    }

    public void Start()
    {
        Time.timeScale = 1f; 
        StartCoroutine(CountTime());
        timer = 0; 
    }

    public IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer++;
            OnTimers();

        }
    }

    public void OnTimers()
    {
        if (timers != null) {
            timers();
        }

    }
}
