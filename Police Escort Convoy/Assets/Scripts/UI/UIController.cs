using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Added on Canvas
public class UIController : MonoBehaviour
{
    //Access GameManager
    GameManager gameManagerScript;

    [SerializeField] private Text gameStatueText;
    [SerializeField] private GameObject restartButton;

    private int counterNum = 3;
    private float counterTimeInterval = 1f;

    private void Awake()
    {
        gameManagerScript = Camera.main.GetComponent<GameManager>();
    }
    private void Start()
    {
        StartCoroutine("Counter");
    }
    public void OpenGameOverText()
    {
        gameStatueText.enabled = true;
        gameStatueText.text = "Game Over";
    }
    public void OpenRestartButton()
    {
        restartButton.SetActive(true);
    }

    IEnumerator Counter()
    {
        for(int i=counterNum; i>0; i--)
        {
            gameStatueText.text = i.ToString();
            yield return new WaitForSeconds(counterTimeInterval);
        }
        gameStatueText.text = "";
        gameStatueText.enabled = false;
        gameManagerScript.GamePlay = true;
    }
}
