using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public IEnumerator RestartGame()
        {
            yield return new WaitForSecondsRealtime(2f);

            UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);// Ponowne naładowane sceny
            
    }


    public void Awake()
    {
        instance = this;
    }

}
