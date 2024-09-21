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

    /// <summary>
    /// �X�e�[�W�}�l�[�W���[
    /// </summary>
    private StageManager stageManager;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        playerStatus = PlayerStatus.Instance;
        stageManager = StageManager.Instance;
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
        // ���W�擾
        var pos = transform.position;

        Vector3 moveDirection = Vector3.zero;

        // ��
        if(Input.GetKey(KeyCode.W))
        {
            pos.z += playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.z += 1.0f;

            // ��Ɍ��E�̏ꍇ�C��
            if(pos.z >= stageManager.ArrayHeight -1.0f)
            {
                pos.z = stageManager.ArrayHeight -1.0f;
            }
        }

        // ��
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.z -= 1.0f;

            // ���Ɍ��E�̏ꍇ�C��
            if (pos.z <= 0.0f)
            {
                pos.z = 0.0f;
            }
        }

        // ��
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.x -= 1.0f;

            // ���Ɍ��E�̏ꍇ�C��
            if (pos.x <= 0.0f)
            {
                pos.x = 0.0f;
            }
        }

        // �E
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.x += 1.0f;

            if (pos.x >= stageManager.ArrayWidth -1.0f)
            {
                pos.x = stageManager.ArrayWidth -1.0f;
            }
        }

        // �ړ��������擾
        Vector3 moveVector = moveDirection;

        // �ړ����Ă���ꍇ���K������
        // �ړ������ɑ��
        if(moveDirection != Vector3.zero)
        {
            playerStatus.MoveVector = moveDirection;
        }

        // ���W���f
        transform.position = pos;
    }
}
