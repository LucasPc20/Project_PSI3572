 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class RotatingCamera : MonoBehaviour
 {
   private float x;
   private float y;
   private Vector3 rotateValue;
   [Header("Camera Rotation Settings")]
   public float camRotationSpeed;
 
   void Update()
   {
      if (Input.GetMouseButton(1)) //Left Click = 0; Right Click = 1; Wheel = 2
      {
         x = Input.GetAxis("Mouse X");
         y = Input.GetAxis("Mouse Y");
         Debug.Log(x + ":" + y);
         rotateValue = new Vector3(y, x * -1, 0);
         transform.eulerAngles = transform.eulerAngles - rotateValue;
         transform.eulerAngles +=  rotateValue * camRotationSpeed;
      }
   }
 }