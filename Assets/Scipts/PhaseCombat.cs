using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCombat : MonoBehaviour
{

    [SerializeField] private GameObject[] m_EnemyPos;
    public GameObject[] m_Enemies;
    [SerializeField] private Camera m_CombatCamera;
    [SerializeField] private ParticleSystem m_selectedParticle;

    public bool m_playersTurn;


    // Start is called before the first frame update
    void Start()
    {
        m_playersTurn = true;
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
        if (m_Enemies[0] != null)
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

    public void SelectEnemyToAttack()
    {
        switch(EnemyScript.m_lastClickedIndex){

            case 0:
            m_selectedParticle.transform.position = m_EnemyPos[0].transform.position;
            m_selectedParticle.Play();
            break;

            case 1:
            m_selectedParticle.transform.position = m_EnemyPos[1].transform.position;
            m_selectedParticle.Play();
            break;

            case 2:
            m_selectedParticle.transform.position = m_EnemyPos[2].transform.position;
            m_selectedParticle.Play();
            break;

            case 3:
            m_selectedParticle.transform.position = m_EnemyPos[3].transform.position;
            m_selectedParticle.Play();
            break;
        }
    }

    public void Pouvoir_1()
    {
        if(m_playersTurn == true)
        {
            Debug.Log("200 dmgs appliqués à l'ennemie " + EnemyScript.m_lastClickedIndex);
            EnemiesTurn();
            m_playersTurn = false;
        }
        

    }

    public void EnemiesTurn()
    {

        Debug.Log("Player's turn is finished, enemies will attack him !");

        
    }
}
