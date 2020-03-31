using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject m_target = null;
    Transform m_tragetPos;
    float m_DistanceCamTarget;

    void Start()
    {
        m_target = GameObject.FindWithTag("Player");
        m_tragetPos = m_target.transform;
    }

    void FixedUpdate()
    {
        var lookPos = m_target.transform.position - gameObject.transform.position;
        lookPos.y = 0;

        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime );



        ///gameObject.transform.LookAt(m_tragetPos);

        m_DistanceCamTarget = Vector3.Distance(m_tragetPos.position, transform.position);

        if (m_DistanceCamTarget > 10)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * m_DistanceCamTarget, Space.Self);
        }

    }

    
}
