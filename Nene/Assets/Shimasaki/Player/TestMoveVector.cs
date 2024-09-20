using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����m�F�e�X�g�p
/// </summary>
public class TestMoveVector : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̏��
    /// </summary>
    private PlayerStatus playerStatus;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        playerStatus = PlayerStatus.Instance;
    }

    private void FixedUpdate()
    {
        TestVector();
    }

    private void TestVector()
    {
        var localPos = transform.localPosition;

        localPos.x = playerStatus.MoveVector.x;
        localPos.z = playerStatus.MoveVector.y;

        transform.localPosition = localPos;
    }
}
