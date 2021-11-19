using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Life of Player's cars
public class Life : MonoBehaviour
{
    //Access Game Manager
    GameManager gameManagerScript;

    [SerializeField]
    private float life = 2f;

    private void Awake()
    {
        gameManagerScript = Camera.main.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            life--;
            if (life == 0)
            {
                if (this.gameObject.CompareTag("MainCar"))
                {
                    gameManagerScript.Die();
                }          
                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            gameManagerScript.PassLevel();
        }
        
    }
}
