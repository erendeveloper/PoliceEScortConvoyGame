using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Horizontal movement of Player's cars
//It gets input from Serve.cs
//Transform gets forwards and horizontalBody get can move horizontally
public class PlayerController : MonoBehaviour
{
    //Access other scripts
    GameManager gameManagerScript;
    Swerve swerveScript;

    private float horizontalSpeed = 3f;
    private float horizontalRoadPosition;//It is where car exists originally
    private const float MaxHorizontalDistance = 0.6f; 
    private Transform horizontalBody; //horizontal movement

    private void Awake()
    {
        gameManagerScript = Camera.main.GetComponent<GameManager>();
        swerveScript = GameObject.FindGameObjectWithTag("Swerve").GetComponent<Swerve>();
        horizontalBody = transform.GetChild(0);
        horizontalRoadPosition = transform.GetChild(0).localPosition.x;
    }

    private void FixedUpdate()
    {
        MoveHorizontally();
    }

    private void MoveHorizontally() //moving horizontalBody locally
    {
        if (Input.GetMouseButton(0))
        {
            //serve input + horizontalBods's original original position
            float distanceX = Mathf.Clamp(swerveScript.PositionX, -MaxHorizontalDistance, MaxHorizontalDistance) + horizontalRoadPosition;
            Vector3 targetPosition = new Vector3(distanceX, horizontalBody.localPosition.y, horizontalBody.localPosition.z);
            horizontalBody.localPosition = Vector3.MoveTowards(horizontalBody.localPosition, targetPosition, Time.deltaTime * horizontalSpeed);

            //fit position on close
            if (Vector3.Distance(horizontalBody.localPosition, targetPosition) < 0.001f)
            {
                horizontalBody.localPosition = targetPosition;
            }
        }          
    }
}
