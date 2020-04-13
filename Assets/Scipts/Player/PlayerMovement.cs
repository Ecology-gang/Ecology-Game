using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float m_moveSpeed = 3f;
    private float m_smoothMovement = 15f;

    private Vector3 m_targetForward;

    private bool m_canMove;

    private Vector3 m_dPos;


    private Camera m_mainCam;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        m_targetForward = transform.forward;

        m_mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateForward();
        GetInput();
    }



    private void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_canMove = true;
            
        } else if (Input.GetButtonUp("Fire1"))
        {
            m_canMove = false;
        }
    }

    void UpdateForward()
    {
        transform.forward = Vector3.Slerp(
            transform.forward, m_targetForward, Time.deltaTime * m_smoothMovement);
    }
    void MovePlayer()
    {
        if (m_canMove)
        {
            m_dPos = new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y);

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            m_dPos.Normalize();

            m_dPos *= m_moveSpeed * Time.fixedDeltaTime;
            m_dPos = Quaternion.Euler(0f, m_mainCam.transform.eulerAngles.y, 0f) * m_dPos;
            rb.MovePosition(rb.position + m_dPos);

            if (m_dPos != Vector3.zero)
            {
                m_targetForward = Vector3.ProjectOnPlane(-m_dPos, Vector3.up);
            }
            Debug.Log(mousePos);


        }
    }
}
