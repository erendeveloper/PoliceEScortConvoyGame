using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Access other script
    UIController uiControllerScript;

    private bool gamePlay = false;
    public bool GamePlay { get => gamePlay; set => gamePlay = value; }


    private void Awake()
    {
        uiControllerScript = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
    }
    public void PassLevel()
    {
        gamePlay = false;
        uiControllerScript.OpenGameOverText();
        uiControllerScript.OpenRestartButton();
    }
    public void Die()
    {
        gamePlay = false;
        uiControllerScript.OpenRestartButton();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    


}
