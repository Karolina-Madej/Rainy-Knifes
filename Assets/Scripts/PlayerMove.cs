using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{


    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float speed = 3f;
     float minX = -2.7f; 
     float maxX = 2.7f;

   // public Text timerText;
    private int timer;



    // Start is called before the first frame update
    void Awake(){
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
   void Start(){
     
    }
    // Update is called once per frame
    void Update(){
        Move();
        PlayerBounds();
    }

    void PlayerBounds() {

        Vector3 posicions = transform.position;
        if(posicions.x > maxX) {
            posicions.x = maxX;
        }
        else if (posicions.x < minX) {
            posicions.x = minX;
        }

        transform.position = posicions;
    }


    void Move(){
        float horizontalInpu = Input.GetAxis("Horizontal"); //Sterowanie graczem (strzałki) w prawo/d 1 w lewo/a -1
        Vector3 oldPlayerPosition = transform.position; // Przechowujemy aktualną pozycje w oldPlayerPosition 
        //Sterowanie graczem
        if (horizontalInpu > 0) {
            oldPlayerPosition.x += speed * Time.deltaTime; // deltaTime różnica pomiędzy klatkami, służy do upłynnienia ruchu
            spriteRenderer.flipX = false; // odwracanie twarzy gracza w kierunku ruchu 
            animator.SetBool("Walk",true); // "Walk" komunikacja z Unity, weź animacje Walk i zamień wartość na true
        }
        else if (horizontalInpu < 0) {
            oldPlayerPosition.x -= speed * Time.deltaTime;
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);
        }
        else if (horizontalInpu == 0){
            animator.SetBool("Walk", false);
        }

        transform.position = oldPlayerPosition;

    }

    void OnTriggerEnter2D(Collider2D targer){

        if(targer.tag == "Knife") {
            Time.timeScale = 0f; //zatrzymanie gry 
            StartCoroutine(GameManager.instance.RestartGame());
        }
    }



   /*IEnumerator CountTimer() {
        EventMaganer.timers += CountTimer;
        yield return new WaitForSeconds(1f);
         timer++;
        // timerText.text = "Time: " + timer;
         StartCoroutine(CountTimer());
     }*/
}
