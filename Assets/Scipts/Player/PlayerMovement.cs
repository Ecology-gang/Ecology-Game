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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        m_targetForward = transform.forward;
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
        if (Input.GetMouseButtonDown(0))
        {
            m_canMove = true;
        } else if (Input.GetMouseButtonUp(0))
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
            m_dPos = new Vector3(Input.GetAxisRaw(Axis.MOUSE_X))
        }
    }
}
