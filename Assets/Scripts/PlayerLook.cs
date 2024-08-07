using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRot = 0f;
    public float xSens = 30f;
    public float ySens = 30f;

    public void ProcessLook(Vector2 input) 
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // rotation
        xRot -= (mouseY * Time.deltaTime) * ySens;
        xRot = Mathf.Clamp(xRot, -80f, 80f);

        // rotate camera
        cam.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        //yRot -= (mouseX * Time.deltaTime) * xSens;

        //rotate character
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSens);
    }
}
