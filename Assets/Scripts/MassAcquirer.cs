using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MassAcquirer : MonoBehaviour
{
    [SerializeField] static float mass;
    public TMP_InputField user_InputField;

    
    public void setMass()
    {
        mass = (float) Convert.ToDouble(user_InputField.text);
        //user_input.text = "";
        //Debug.Log("Mass: " + mass);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static float  getMass()
    {
        return mass; 
    }
}
