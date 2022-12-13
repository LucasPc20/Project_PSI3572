using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayState : MonoBehaviour
{
    public TMP_Text stateText;
    private int years, fps;
    private float mass;

    DisplayTime instanceOfDisplayTimeScript;
    [SerializeField] GameObject TimeDisplayGameObject;



    // Start is called before the first frame update
    void Start()
    {
        fps = 200;
        mass = MassAcquirer.getMass();
        instanceOfDisplayTimeScript = TimeDisplayGameObject.GetComponent<DisplayTime>();
        stateText.text = "Nebulosa";
        years = 0;
    }

    // Update is called once per frame
    void Update()
    {
        years = instanceOfDisplayTimeScript.get_years();
        if ((years > 10*fps) && (years < 20*fps))
        {
            stateText.text = "Protoestrela";
        }

        if((years > 20*fps) && (years < 30*fps))
        {
            stateText.text = "T-Tauri";
        }

        if (mass < 1.4) //estrelas de pequena massa em seu nucleo
        {
            if((years > 30*fps) && (years < 40*fps))
            {
                stateText.text = "Sequencia Principal";
            }

            else if((years > 40*fps) && (years < 50*fps))
            {
                stateText.text = "Gigante Vermelha";
            }

            else if((years > 50*fps) && (years < 60*fps))
            {
                stateText.text = "Nebula planetaria";
            }

            else if ((years > 60*fps) && (years < 70*fps))
            {
                stateText.text = "Ana Branca";
            }

            else if(years > 70*fps)
            {
                stateText.text = "Ana Negra";
            }

        }

        else //estrelas de grande massa em seu nucleo
        {
            if((years > 30*fps) && (years < 40*fps))
            {
                stateText.text = "Estrela de grande massa";
            }

            else if((years > 40*fps) && (years < 50*fps))
            {
                stateText.text = "Supergigante Vermelha";
            }

            else if((years > 50*fps) && (years < 60*fps))
            {
                stateText.text = "Supernova";
            }

            else if (years >= 60*fps)
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
