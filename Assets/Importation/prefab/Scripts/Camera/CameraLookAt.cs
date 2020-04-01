using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    GameObject m_target = null;
    Transform m_tragetPos;

    void Start()
    {
        m_target = GameObject.FindWithTag("Player");
        m_tragetPos = m_target.transform;
    }

    void Update()
    {
        gameObject.transform.LookAt(m_tragetPos);
        
    }
}
