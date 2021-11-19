using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

//Forward movement of cars
//It uses bezier curve
public class VehicleMoveForward : MonoBehaviour
{
    //Access other scripts
    GameManager gameManagerScript;

    [SerializeField]
    private float forwardSpeed;

    //path
    private PathCreator pathCreator;
    private float distanceOnPath = 0;

    private void Awake()
    {
        gameManagerScript = Camera.main.GetComponent<GameManager>();
        pathCreator = GameObject.FindGameObjectWithTag("PathCreator").GetComponent<PathCreator>();
       
    }

    private void Start()
    {
        AssignSpeed();
        AssignFirstPosition();     
    }
    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if (gameManagerScript.GamePlay)
        {
            distanceOnPath += forwardSpeed * Time.deltaTime;
            AssignForwardPosition();
            
        }
    }
    private void AssignFirstPosition()
    {
        distanceOnPath = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        AssignForwardPosition();       
    }
    private void AssignForwardPosition()
    {
        transform.position = pathCreator.path.GetPointAtDistance(distanceOnPath, EndOfPathInstruction.Stop);
        Quaternion rotation = pathCreator.path.GetRotationAtDistance(distanceOnPath, EndOfPathInstruction.Stop);
        transform.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + 90f);
        Vector3 position = pathCreator.path.GetPointAtDistance(distanceOnPath, EndOfPathInstruction.Stop);
        transform.position = position;
    }
    private void AssignSpeed()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            forwardSpeed *= -1;
        }
    }
}
