using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{

    public GameObject knife;
    private float minX = -2.7f; // umieszczenie noży na osi X aby było je widać 
    private float maxX = 2.7f;
      

     void Start() {
        StartCoroutine(StartSpawning());

     }
     

   IEnumerator StartSpawning() {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f)); // czas w którym czekamy na nowy nóż
            knife = ObjectPooler.SharedInstance.GetPooledObject();
            if (knife != null)
            {
                float x = Random.Range(minX, maxX);
                knife.transform.position = new Vector2(x, transform.position.y);// y oznacza pozycje Spawnera czyli u nas 5.82
                knife.SetActive(true);

          
            }
        }
    }
}
