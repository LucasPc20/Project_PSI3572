using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRadius : MonoBehaviour
{
    
    public TMP_Text radiusText;
    
    
    int  m_numSecondsEachState, m_nebulosa, m_protoestrela, m_tTauri, m_MainSequence;
    int m_Giant, m_planetaryNebula, m_whiteDwarf; 
    float m_radiusStar, mass, m_years;
    void Start() // Start is called before the first frame update
    {
        mass = MassAcquirer.getMass();
        m_years = 0;
        m_nebulosa = 0;
        m_protoestrela = 1;
        m_tTauri = 2;
        m_MainSequence = 3;
        m_Giant = 4;
        m_planetaryNebula = 5;
        m_whiteDwarf = 6;
        m_numSecondsEachState = 10;
    }
    // Update is called once per frame
    void Update()
    {
        m_years += Time.deltaTime;
        if((m_years < ((m_nebulosa+1)*m_numSecondsEachState)))
        {
            radiusText.text = "Raio indefinido";
        }
        else if((m_years < ((m_protoestrela+1)*m_numSecondsEachState)) || ((m_years >= m_protoestrela*m_numSecondsEachState)))
        {
            radiusText.text = "aprox. 1,5 bilhão RT";
        }
        else if((m_years < ((m_tTauri+1)*m_numSecondsEachState)) || ((m_years >= m_tTauri*m_numSecondsEachState)))
        {
            radiusText.text = "aprox. 300 RT";
        }
        else if(mass < 1.4)
        {
            if((m_years < ((m_MainSequence+1)*m_numSecondsEachState)) || ((m_years >= m_MainSequence*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. 10 RT";
            }
            else if((m_years < ((m_Giant+1)*m_numSecondsEachState)) || ((m_years >= m_Giant*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. ";
            }
            else if((m_years < ((m_planetaryNebula+1)*m_numSecondsEachState)) || ((m_years >= m_planetaryNebula*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. ";
            }
            else if((m_years < ((m_whiteDwarf+1)*m_numSecondsEachState)) || ((m_years >= m_whiteDwarf*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. 1 RT";
            }
            else
            {
                radiusText.text = "aprox. ";
            }
        }
        else
        {
            if((m_years < ((m_MainSequence+1)*m_numSecondsEachState)) || ((m_years >= m_MainSequence*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. ";
            }
            if((m_years < ((m_Giant+1)*m_numSecondsEachState)) || ((m_years >= m_Giant*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. ";
            }
            if((m_years < ((m_planetaryNebula+1)*m_numSecondsEachState)) || ((m_years >= m_planetaryNebula*m_numSecondsEachState)))
            {
                radiusText.text = "aprox. ";
            }
            else
            {
                if(mass < 3)
                {
                    radiusText.text = "aprox. ";
                }
                else
                {
                    radiusText.text = "aprox. ";
                }
            }
        }
    }
}
