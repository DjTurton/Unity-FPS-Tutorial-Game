using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] RigidbodyFirstPersonController controller;
    [SerializeField] float zoomedSensitivity = 0.5f;
    [SerializeField] float unZoomedSensitivity = 2f;

    private void Start()
    {

    }

    private void OnDisable()
    {
        FPSCamera.fieldOfView = zoomedOutFOV;
        controller.mouseLook.XSensitivity = unZoomedSensitivity;
        controller.mouseLook.YSensitivity = unZoomedSensitivity;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            FPSCamera.fieldOfView = zoomedInFOV;
            controller.mouseLook.XSensitivity = zoomedSensitivity;
            controller.mouseLook.YSensitivity = zoomedSensitivity;
        } 
        else
        {
            FPSCamera.fieldOfView = zoomedOutFOV;
            controller.mouseLook.XSensitivity = unZoomedSensitivity;
            controller.mouseLook.YSensitivity = unZoomedSensitivity;

        }   

    }
}
