using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    public TMP_Text yearsText;
    private float anos;
    private float mass;
    //Called in the initial frame
    void Start()
    {
        anos = 0.0f;
        mass = MassAcquirer.getMass();
        yearsText.text = "";
    }

    //Called in every frame
    void Update()
    {
        anos += Time.deltaTime;
        yearsText.text = "aprox. 10000 anos";
        if((anos > 10f) && (anos <= 20f)) // Protowatrela
        {
            yearsText.text = "aprox. 100000 anos";
            return;
        }

        else if((anos > 20f) && (anos <= 30f)) // T-Tauri
        {
            yearsText.text = "aprox. 100 milhões anos";
            return;
        }


        if (mass < 1.4) //estrelas de pequena massa em seu nucleo
        {
            if((anos > 30f) && (anos < 40f)) //  sequencia principal
            {
                yearsText.text = "aprox. 10 bilhões anos";
                return;
            }

            else if((anos > 40f) && (anos < 50f)) // gigante vermelha
            {
                yearsText.text = "aprox. 1 bilhão anos";
                return;
            }

            else if((anos > 50f) && (anos < 60f)) // Planetary nebula
            {
                yearsText.text = "aprox. 40000 anos";
                return;
            }

            else if((anos > 60f) && (anos < 70f)) // ana branca
            {
                yearsText.text = "aprox. 1 bilhão anos";
                return;
            }

            else if (anos >= 70f) // ana negra
            {
                yearsText.text = "indefinida";
                return;
            }

        }

        else //estrelas de grande massa em seu nucleo
        {
            if((anos > 30f) && (anos < 40f)) // Sequência principal massa grande
            {
                yearsText.text = "aprox. 20 milhões anos";
                return;
            }

            else if((anos > 40f) && (anos < 50f)) // Supergigante vermelha
            {
                yearsText.text = "aprox. 200000 anos";
                return;
            }

            else if((anos > 50f) && (anos < 60f)) // Supernova
            {
                yearsText.text = "aprox. 100 segundos";
                return;
            }

            else if (anos > 60f)
            {
                if(mass < 3) // estrela de neutrons
                {
                    yearsText.text = "indefinida";
                    return;
                }
            }
        }
        
        
    }

    public float get_years()
    {
        return anos;
    }
}
