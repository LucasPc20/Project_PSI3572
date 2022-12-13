using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    public TMP_Text yearsText;
    private int years;
    private int fps = 200;
    //Called in the initial frame
    void Start()
    {
        years = 0;
    }

    //Called in every frame
    void Update()
    {
        years += 1;
        yearsText.text = "approx. 10000 years";
        if((years > 10*fps) && (years < 20*fps)) // Nebulosa
        {
            yearsText.text = "approx. 100000 years";
        }

        else if((years >= 20*fps) && (years < 30*fps)) // Protoestrela
        {
            yearsText.text = "approx. 100000 years";
        }

        else if((years > 30*fps) && (years < 40*fps)) // T-Tauri
        {
            yearsText.text = "approx. 100 million years";
        }

        else if((years > 40*fps) && (years < 50*fps)) // Sequência Principal
        {
            yearsText.text = "about 10 billion years";
        }

        else if((years > 60*fps) && (years < 70*fps)) // Gigante ou SuperGigante Vermelha
        {
            yearsText.text = "about 10 billion years";
        }

        
        
        
    }

    public int get_years()
    {
        return years;
    }
}
