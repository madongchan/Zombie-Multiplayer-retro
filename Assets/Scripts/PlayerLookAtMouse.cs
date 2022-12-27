using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviourPun
{
    Camera viewCamera;
    public GameObject mousePointSphere;

    private void Start()
    {
        viewCamera = Camera.main;
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if (GameManager.instance != null
            && GameManager.instance.isGameover)
        {
            return;
        }
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 heightCorrentedPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(heightCorrentedPoint);
            mousePointSphere.transform.position = point;
        }
    }
}
