using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    // Update is called once per frame
    private Vector3 m_CameraPosition;
    private float time;
    [Header("Camera Settings")] //Creates a field in Unity where you can add properties you want to edit later
    public float m_cameraSpeed; //Set the camera speed

    DisplayTime instanceOfDisplayTimeScript;
    [SerializeField] GameObject TimeDisplayGameObject;

    void Start()
    {
        instanceOfDisplayTimeScript = TimeDisplayGameObject.GetComponent<DisplayTime>();
        m_CameraPosition = this.transform.position; //Set the initial position of the camera to the initial position of 
        //the object it's attached to.
        time = 0.0f;
    }
    
    void Update ()
    {
        time += Time.deltaTime;
        if(Input.GetKey(KeyCode.W)) // Forward
        {
            m_CameraPosition.y += m_cameraSpeed/10; //Divided by 10 so we can get usable values for camera speed and camera position
        }
        if(Input.GetKey(KeyCode.S)) // Backward
        {
            m_CameraPosition.y -= m_cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.D)) // Right
        {
            m_CameraPosition.x += m_cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.A)) // Left
        {
            m_CameraPosition.x -= m_cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.Q)) // Up
        {
            m_CameraPosition.z += m_cameraSpeed/10;
        }
        if(Input.GetKey(KeyCode.E)) // Down
        {
            m_CameraPosition.z -= m_cameraSpeed/10;
        }
        if((time < 50.0f) && (time > 40.0f))
        {
            m_CameraPosition.z -= m_cameraSpeed/3;
        }
        if((time > 50.1f) && (time < 51.0f))
        {
            m_CameraPosition = new Vector3(-2.0f,0.0f,-10.0f); // reset the camera position after the explosion
        }

        this.transform.position = m_CameraPosition; //update the camera position, so that the code actually runs

    }
}
