using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMass : MonoBehaviour
{
    public TMP_Text displayMass;
    // Update is called once per frame
    void Update()
    {
        displayMass.text = "Initial Mass: " + MassAcquirer.getMass(); 
    }
}
