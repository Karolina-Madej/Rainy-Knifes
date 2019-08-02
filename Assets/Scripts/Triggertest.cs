using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour
{
    public bool enter;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (enter)
        {
            other.gameObject.SetActive(false);
            Destroy(other);
        }

    }
}