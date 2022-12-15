using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayState : MonoBehaviour
{
    public TMP_Text stateText;
    private float mass, years;

    DisplayTime instanceOfDisplayTimeScript;
    [SerializeField] GameObject TimeDisplayGameObject;



    // Start is called before the first frame update
    void Start()
    {
        mass = MassAcquirer.getMass();
        instanceOfDisplayTimeScript = TimeDisplayGameObject.GetComponent<DisplayTime>();
        stateText.text = "Nebulosa";
        years = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        years += Time.deltaTime;
        if ((years > 10f) && (years < 20f))
        {
            stateText.text = "Protoestrela";
        }

        if((years > 20f) && (years < 30f))
        {
            stateText.text = "T-Tauri";
        }

        if (mass < 1.4) //estrelas de pequena massa em seu nucleo
        {
            if((years > 30f) && (years < 40f))
            {
                stateText.text = "Sequencia Principal";
            }

            else if((years > 40f) && (years < 50f))
            {
                stateText.text = "Gigante Vermelha";
            }

            else if((years > 50f) && (years < 60f))
            {
                stateText.text = "Nebula planetaria";
            }

            else if ((years > 60f) && (years < 70f))
            {
                stateText.text = "Ana Branca";
            }

            else if(years > 70f)
            {
                stateText.text = "Ana Negra";
            }

        }

        else //estrelas de grande massa em seu nucleo
        {
            if((years > 30f) && (years < 40f))
            {
                stateText.text = "Estrela de grande massa";
            }

            else if((years > 40f) && (years < 50f))
            {
                stateText.text = "Supergigante Vermelha";
            }

            else if((years > 50f) && (years < 60f))
            {
                stateText.text = "Supernova";
            }

            else if (years >= 60f)
            {
                if(mass < 3)
                {
                    stateText.text = "Estrela de neutrons";
                }

                else
                {
                    stateText.text = "Buraco Negro";
                }
            }
        }
    }
}
