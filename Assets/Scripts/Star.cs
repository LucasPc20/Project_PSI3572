using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private GameObject m_sphere, m_sphereSun;
    private Material m_sphereMat, m_sphereSunMat; 
    private Vector3 m_scaleChange, m_positionChange, m_positionAfterExplosion;
    private Vector3 m_tamanhoSuperNova, m_tamanhoPlanetaryNebula;
    private Vector3 m_tamanhoAnaBranca, m_tamanhoAnaNegra, m_tamanhoBuracoNegro, m_tamanhoEstrelaNeutrons;

    DisplayTime instanceOfDisplayTimeScript;
    [SerializeField] GameObject TimeDisplayGameObject;
    Rotator instanceOfRotatorScript;
    [SerializeField] GameObject RotationGameObject;

    private int millenium; //I want to pass the variables between scripts
    private float mass;
    private int fps = 200;
    private int factor_Giant = 100;

    void Awake()
    {
        //Camera.main.clearFlags = CameraClearFlags.SolidColor;
        float scaleChangeValue = 1.8f/(17.5f*200);
        mass = MassAcquirer.getMass(); //Store the mass of the object in a variable.
        millenium = 0;

        // Get the script to acquire the time in milleniums.
        instanceOfDisplayTimeScript = TimeDisplayGameObject.GetComponent<DisplayTime>();
        instanceOfRotatorScript = RotationGameObject.GetComponent<Rotator>();
        
        //Instanciate m_positionAfterExplosion and the size of ana branca, ana negra, estrela de neutrons e buraco negro
        m_positionAfterExplosion = new Vector3(-4.0f, 0.0f, -4.0f);
        m_tamanhoPlanetaryNebula = new Vector3(4.0f, 4.0f, 4.0f);
        m_tamanhoSuperNova = new Vector3(6.0f, 6.0f, 6.0f);
        m_tamanhoAnaBranca = new Vector3(0.9f, 0.9f, 0.9f);
        m_tamanhoAnaNegra = new Vector3(0.5f, 0.5f, 0.5f);
        m_tamanhoEstrelaNeutrons = new Vector3(0.3f, 0.3f, 0.3f);
        m_tamanhoBuracoNegro = new Vector3(0.1f, 0.1f, 0.1f);
        


        // Create a m_sphere at the origin.
        m_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        m_sphere.transform.position = new Vector3(0, 0, 0);
        m_sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Renderer sphereRend = m_sphere.GetComponent<Renderer>();
        
        m_sphereMat = Resources.Load("Materials/Nebulosa", typeof(Material)) as Material; //assigning the Nebulosa Mat from the Materials folder in Assets/Resources
        m_sphere.GetComponent<Renderer>().material = m_sphereMat; // change the material of the m_sphere

        m_sphereSun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        m_sphereSun.transform.position = new Vector3(4,0,0);
        m_sphereSun.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        m_sphereSunMat = Resources.Load("Materials/2k_sun", typeof(Material)) as Material;
        m_sphereSun.GetComponent<Renderer>().material = m_sphereSunMat;

        // Create a plane and move down by 0.5.
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //plane.transform.position = new Vector3(0, -0.5f, 0);

        // Change the floor color to blue.
        // The blue material is present in Resources and not created in this script.
        //Renderer rend = plane.GetComponent<Renderer>();
        //rend.material.SetColor("_Color", Color.cyan);

        m_scaleChange = new Vector3(scaleChangeValue, scaleChangeValue, scaleChangeValue);
        m_positionChange = new Vector3(-scaleChangeValue, 0.0f, -scaleChangeValue);
        Debug.Log("Mass: " + mass);
    }

    void Update()
    {
        if(millenium < 40*fps)
        {
            m_sphere.transform.localScale += m_scaleChange;
            m_sphere.transform.position += m_positionChange;
        }

        else if((millenium >= 40*fps) && (millenium <= 50*fps)) //gigante vermelha e superGigante
        {
            m_sphere.transform.localScale += (factor_Giant*m_scaleChange);
            m_sphere.transform.position += (factor_Giant*m_positionChange);
        }

        else if ((millenium > 50*fps) && (millenium < 60*fps)) // ana branca e estrela de neutrons
        {
            m_sphere.transform.position = m_positionAfterExplosion;
            if(mass < 1.4)
            {
                m_sphere.transform.localScale = m_tamanhoAnaBranca;
            }
            else
            {
                m_sphere.transform.localScale = m_tamanhoEstrelaNeutrons;
            }
        }

        else if((millenium > 60*fps) && (millenium < 70*fps)) // ana negra e buraco negro
        {
            m_sphere.transform.position = m_positionAfterExplosion;
            if(mass > 1.4)
            {
                m_sphere.transform.localScale = m_tamanhoAnaNegra;
            }
            else
            {
                m_sphere.transform.localScale = m_tamanhoBuracoNegro;
            }
        }

        else
        {
            m_sphere.transform.localScale = m_sphere.transform.localScale;
            m_sphere.transform.position = m_sphere.transform.position;
        }
        
        m_sphere.transform.Rotate(instanceOfRotatorScript.getPassRotation());

        millenium = instanceOfDisplayTimeScript.get_years();

        // Move upwards when the m_sphere hits the floor or downwards
        // when the m_sphere scale extends 0.01f.

        //if (m_sphere.transform.localScale.y < 0.01f || m_sphere.transform.localScale.y > 2.0f)
        //{
        //    m_scaleChange = -m_scaleChange;
        //    m_positionChange = -m_positionChange;
        //}

        if ((millenium > 10*fps) && (millenium < 20*fps)) //Material Protoestrela
        {
            m_sphereMat = Resources.Load("Materials/Protoestrela", typeof(Material)) as Material;
        }

        if((millenium > 20*fps) && (millenium < 30*fps)) // material T_Tauri
        {
            m_sphereMat = Resources.Load("Materials/T_Tauri", typeof(Material)) as Material;
        }

        if (mass < 1.4) //estrelas de pequena massa em seu nucleo
        {
            if((millenium > 30*fps) && (millenium < 40*fps)) // Material sequencia principal
            {
                m_sphereMat = Resources.Load("Materials/2k_sun", typeof(Material)) as Material;
            }

            else if((millenium > 40*fps) && (millenium < 50*fps)) // material gigante vermelha
            {
                m_sphereMat = Resources.Load("Materials/Gigante_Vermelha", typeof(Material)) as Material;
            }

            else if((millenium > 50*fps) && (millenium < 60*fps)) // material Planetary nebula
            {
                m_sphereMat = Resources.Load("Materials/Planetary_Nebula", typeof(Material)) as Material;
            }

            else if((millenium > 60*fps) && (millenium < 70*fps)) // ana branca
            {
                m_sphereMat = Resources.Load("Materials/White_Dwarf", typeof(Material)) as Material;
            }

            else // ana negra
            {
                m_sphereMat = Resources.Load("Materials/Black_Dwarf", typeof(Material)) as Material;
            }

        }

        else //estrelas de grande massa em seu nucleo
        {
            if((millenium > 30*fps) && (millenium < 40*fps))
            {
                m_sphereMat = Resources.Load("Materials/Sirius_High_Mass_Star", typeof(Material)) as Material;
            }

            else if((millenium > 40*fps) && (millenium < 50*fps))
            {
                m_sphereMat = Resources.Load("Materials/Red_Supergiant", typeof(Material)) as Material;
            }

            else if((millenium > 60*fps) && (millenium < 70*fps))
            {
                m_sphereMat = Resources.Load("Materials/Supernova", typeof(Material)) as Material;
            }

            else
            {
                if(mass < 3) // estrela de neutrons
                {
                    m_sphereMat = Resources.Load("Materials/Neutron_Star", typeof(Material)) as Material;
                }

                else // buraco negro
                {
                    m_sphereMat = Resources.Load("Materials/BlackHole", typeof(Material)) as Material;
                }
            }



        }
        m_sphere.GetComponent<Renderer>().material = m_sphereMat;
    }

    public Vector3[] getStarPosition()
    {
        Vector3[] scaleAndPosition = new Vector3[2];
        scaleAndPosition[0] = m_sphere.transform.position;
        scaleAndPosition[1] = m_sphere.transform.localScale;
        return scaleAndPosition;
    }
}
