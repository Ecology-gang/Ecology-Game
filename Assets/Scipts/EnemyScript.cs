using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool m_isSelected = false;

    public static int m_lastClickedIndex = -1;
    [SerializeField] private PhaseCombat m_phaseCombat;

    // Start is called before the first frame update
    void Start()
    {
        //m_phaseCombat = m_phaseCombat.GetComponent<PhaseCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //if this object is clicked by the mouse...
        for(int i = 0;i<m_phaseCombat.m_Enemies.Length;i++)
        { //for each object in the array..
            if(m_phaseCombat.m_Enemies[i] != null && m_phaseCombat.m_Enemies[i].transform == transform)
            {  //if that array object's transform is also *this* transform...
                m_lastClickedIndex = i;
                Debug.Log("You just clicked the object with the Index of " + m_lastClickedIndex.ToString()); //Send a message to the console with the ID we just clicked.
                
            } 
                
        }
    }
     
}
