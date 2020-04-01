using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCombat : MonoBehaviour
{

    [SerializeField] private GameObject[] m_EnemyPos;
    [SerializeField] private GameObject[] m_Enemies;
    [SerializeField] private Camera m_CombatCamera;
    [SerializeField] private ParticleSystem m_selectedParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlaceEnemies();
        }

        SelectEnemyToAttack();
        
    }

    void PlaceEnemies()
    {
        if (m_Enemies[0] !=null)
        {
            m_Enemies[0].transform.position = m_EnemyPos[0].transform.position;
        }
        if (m_Enemies[1] != null)
        {
            m_Enemies[1].transform.position = m_EnemyPos[1].transform.position;
        }
        if (m_Enemies[2] != null)
        {
            m_Enemies[2].transform.position = m_EnemyPos[2].transform.position;
        }
        if (m_Enemies[3] != null)
        {
            m_Enemies[3].transform.position = m_EnemyPos[3].transform.position;
        }
    }

    void SelectEnemyToAttack()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = m_CombatCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.tag);

                if(hit.transform.tag == "Enemy")
                {
                    m_selectedParticle.transform.position = hit.transform.gameObject.transform.position;

                    hit.transform.gameObject.GetComponent<EnemyScript>().m_isSelected = true;
                    m_selectedParticle.Play();
                }
            }
        }

    }
}
