using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ�
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̏��
    /// </summary>
    private PlayerStatus playerStatus;

    // Start is called before the first frame update
    private void Start()
    {
        playerStatus = PlayerStatus.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveProcess();
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void MoveProcess()
    {
        var pos = transform.position;

        // �O
        if(Input.GetKey(KeyCode.W))
        {
            pos.z += playerStatus.MoveSpeed * Time.deltaTime;
        }

        // ��
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= playerStatus.MoveSpeed * Time.deltaTime;
        }

        // ��
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= playerStatus.MoveSpeed * Time.deltaTime;
        }

        // �E
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += playerStatus.MoveSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
