using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Added On Main Camera
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target; //Camera Position Gamne Object in President's Car

    private void LateUpdate()
    {
        if (target != null)
        {
            this.transform.position = target.position;
            this.transform.rotation = target.rotation;
        }
        

    }
}
