using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    int m_speed = 10;
    float m_Rotation;


    void Start()
    {
        m_Rotation = 0;
    }

    void FixedUpdate()
    {
        m_Rotation += Input.GetAxis("Horizontal") * 2;
        transform.localRotation = Quaternion.Euler(0, m_Rotation, 0);


        if (Input.GetAxis("Vertical") == 1)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * m_speed, Space.Self);
        }

        if (Input.GetAxis("Vertical") == -1)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * -m_speed, Space.Self);
        }

        if (Input.GetAxis("Vertical") == -1)
        {
            gameObject.transform.Translate(Vector3.forward * 0, Space.Self);
        }


    }
}
