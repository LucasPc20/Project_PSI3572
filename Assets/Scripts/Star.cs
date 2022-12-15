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

    //I want to pass the variables between scripts
    DisplayTime instanceOfDisplayTimeScript;
    [SerializeField] GameObject TimeDisplayGameObject;
    Rotator instanceOfRotatorScript;
    [SerializeField] GameObject RotationGameObject;

    
    private float m_mass;
    private int factor_Giant = 100;
    private float m_time;

    void Awake()
    {
        //Camera.main.clearFlags = CameraClearFlags.SolidColor;
        float scaleChangeValue = 0.9f/(17.5f);
        m_mass = MassAcquirer.getMass(); //Store the m_mass of the object in a variable.
        m_time = 0;
        m_time = 0.0f;

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
        m_sphereSun.transform.position = new Vector3(6,0,0);
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

        m_scaleChange = new Vector3(scaleChangeValue*Time.deltaTime, scaleChangeValue*Time.deltaTime, scaleChangeValue*Time.deltaTime);
        m_positionChange = new Vector3(-scaleChangeValue*Time.deltaTime, 0.0f, -scaleChangeValue*Time.deltaTime);
        Debug.Log("Mass: " + m_mass);
    }

    void Update()
    {
        m_time += Time.deltaTime;

        if(m_time < 40)
        {
            m_sphere.transform.localScale += m_scaleChange;
            m_sphere.transform.position += m_positionChange;
        }

        else if((m_time >= 40) && (m_time <= 50)) //gigante vermelha e superGigante
        {
            m_sphere.transform.localScale += (factor_Giant*m_scaleChange);
            m_sphere.transform.position += (factor_Giant*m_positionChange);
        }

        else if ((m_time > 50) && (m_time < 60)) // ana branca e estrela de neutrons
        {
            m_sphere.transform.position = m_positionAfterExplosion;
            if(m_mass < 1.4)
            {
                m_sphere.transform.localScale = m_tamanhoAnaBranca;
            }
            else
            {
                m_sphere.transform.localScale = m_tamanhoEstrelaNeutrons;
            }
        }

        else if((m_time > 50) && (m_time < 60)) // ana negra e buraco negro
        {
            m_sphere.transform.position = m_positionAfterExplosion;
            if(m_mass > 1.4)
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


        // Move upwards when the m_sphere hits the floor or downwards
        // when the m_sphere scale extends 0.01f.

        //if (m_sphere.transform.localScale.y < 0.01f || m_sphere.transform.localScale.y > 2.0f)
        //{
        //    m_scaleChange = -m_scaleChange;
        //    m_positionChange = -m_positionChange;
        //}

        if ((m_time > 10) && (m_time < 20)) //Material Protoestrela
        {
            m_sphereMat = Resources.Load("Materials/Protoestrela", typeof(Material)) as Material;
            m_sphere.GetComponent<Renderer>().material = m_sphereMat;
            return;
        }

        if((m_time > 20) && (m_time < 30)) // material T_Tauri
        {
            m_sphereMat = Resources.Load("Materials/T_Tauri", typeof(Material)) as Material;
            m_sphere.GetComponent<Renderer>().material = m_sphereMat;
            return;
        }

        if (m_mass < 1.4) //estrelas de pequena massa em seu nucleo
        {
            if((m_time > 30) && (m_time < 40)) // Material sequencia principal
            {
                m_sphereMat = Resources.Load("Materials/2k_sun", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else if((m_time > 40) && (m_time < 50)) // material gigante vermelha
            {
                m_sphereMat = Resources.Load("Materials/Gigante_Vermelha", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else if((m_time > 50) && (m_time < 60)) // material Planetary nebula
            {
                m_sphereMat = Resources.Load("Materials/Planetary_Nebula", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else if((m_time > 60) && (m_time < 70)) // ana branca
            {
                m_sphereMat = Resources.Load("Materials/White_Dwarf", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else // ana negra
            {
                m_sphereMat = Resources.Load("Materials/Black_Dwarf", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

        }

        else //estrelas de grande massa em seu nucleo
        {
            if((m_time > 30) && (m_time < 40))
            {
                m_sphereMat = Resources.Load("Materials/Sirius_High_Mass_Star", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else if((m_time > 40) && (m_time < 50))
            {
                m_sphereMat = Resources.Load("Materials/Red_Supergiant", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else if((m_time > 50) && (m_time < 60))
            {
                m_sphereMat = Resources.Load("Materials/Supernova", typeof(Material)) as Material;
                m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                return;
            }

            else if (m_time > 60)
            {
                if(m_mass < 3) // estrela de neutrons
                {
                    m_sphereMat = Resources.Load("Materials/Neutron_Star", typeof(Material)) as Material;
                    m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                    return;
                }

                else // buraco negro
                {
                    m_sphereMat = Resources.Load("Materials/Black_Hole", typeof(Material)) as Material;
                    m_sphere.GetComponent<Renderer>().material = m_sphereMat;
                    return;
                }
            }



        }
    }

    public Vector3[] getStarPosition()
    {
        Vector3[] scaleAndPosition = new Vector3[2];
        scaleAndPosition[0] = m_sphere.transform.position;
        scaleAndPosition[1] = m_sphere.transform.localScale;
        return scaleAndPosition;
    }
}
