using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add layer on swerve object with box collider
/// Uncheck that layer pysics on project settings
/// Add swerve object on player as child
/// </summary>
public class Swerve : MonoBehaviour
{
    private float positiionX = 0;
    public float PositionX { get => positiionX; }


    private Camera mainCamera;

    LayerMask swerveLayerMask;

    private float raycastDistance = 10f;

    private void Awake()
    {
        mainCamera = Camera.main;
        swerveLayerMask = LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            SendRay();
    }
    private void SendRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance, swerveLayerMask))
        {
            Vector3 localHit = transform.InverseTransformPoint(hit.point);
            positiionX = localHit.x;
        }
    }
}