using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�������v���C���[�ɕt�����鏈��
/// </summary>
public class TrackingPlayer : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̏��
    /// </summary>
    private PlayerStatus playerStatus;

    /// <summary>
    /// �J�����̑��Έʒu
    /// </summary>
    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        playerStatus = PlayerStatus.Instance;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        TrackingMove();
    }

    /// <summary>
    /// �ǔ�����
    /// </summary>
    private void TrackingMove()
    {
        // ���W�擾
        var cameraPos = playerStatus.Player.transform.position + offset;

        // ���W���f
        transform.position = cameraPos;
    }
}
