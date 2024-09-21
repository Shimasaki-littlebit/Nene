using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerEnum;
using System.Net;

/// <summary>
/// �˂��˂��̃X�L��
/// </summary>
public class NeneSkill : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̏��
    /// </summary>
    private PlayerStatus playerStatus;

    /// <summary>
    /// �N�[���_�E���p�^�C�}�[
    /// </summary>
    private Timer coolTimer;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        playerStatus = PlayerStatus.Instance;

        // �^�C�}�[������
        coolTimer = new();
    }

    private void FixedUpdate()
    {
        // �^�C�}�[�J�E���g
        coolTimer.Count(Time.deltaTime);
    }

    /// <summary>
    /// �˂��˂��J�n����
    /// </summary>
    public void StartNene(int volume)
    {
        // �˂��˂����Ȃ�I��
        if (playerStatus.IsNene) return;

        // �˂��˂�����
        playerStatus.IsNene = true;

        // �N�[���_�E���̃^�C�}�[�Z�b�g
        coolTimer.SetTimer(playerStatus.NeneCoolTime, FinishNeneCoolTime);

        // �˂��˂��J�n
        Nene(SelectVolumeLevel(volume));
    }

    /// <summary>
    /// �˂��˂��̃N�[���_�E���I������
    /// </summary>
    private void FinishNeneCoolTime()
    {
        // �˂��˂��t���O�����낷
        playerStatus.IsNene = false;
    }

    /// <summary>
    /// ���ʂ��琺�̋�����I��
    /// </summary>
    /// <param name="inputVolume">����</param>
    /// <returns>���̋���</returns>
    private VolumeLevel SelectVolumeLevel(int inputVolume)
    {
        VolumeLevel num;

        // �ŏ�
        if (inputVolume <= 29)
        {
            num = VolumeLevel.VERYSOFT;
        }

        // ������
        else if (inputVolume <= 59)
        {
            num = VolumeLevel.SOFT;
        }

        // �傫��
        else if (inputVolume <= 89)
        {
            num = VolumeLevel.LOUD;
        }

        // �ő�
        else
        {
            num = VolumeLevel.VERYLOUD;
        }

        return num;
    }

    /// <summary>
    /// �˂��˂�����
    /// </summary>
    /// <param name="level">���ʃ��x��</param>
    private void Nene(VolumeLevel level)
    {
        // �U���͈͂�����
       var range = ChooseNeneRange(level);

        //// �����Ń��X�g�܂킵��foreach
        //{
            //// �G�̋������˂��˂��˒��͈͂�艓����΃X�L�b�v
            //if (range < MeasureDistance(enemy.transform)) continue;

            //// �G���˂��˂��̊p�x�O�Ȃ�X�L�b�v
            //if (!IsWithinAngle(enemy.transform)) continue;

            //// �G�̂˂��˂����󂯂���������s
        //}

    }

    /// <summary>
    /// �˂��˂��͈̔͂̑I��
    /// </summary>
    /// <param name="chooseLevel">�I�����鉹�ʃ��x��</param>
    /// <returns>�U���͈�</returns>
    private float ChooseNeneRange(VolumeLevel chooseLevel)
    {
        switch (chooseLevel)
        {
            case VolumeLevel.VERYSOFT:

                return playerStatus.VerySoftRange;

            case VolumeLevel.SOFT:

                return playerStatus.SoftRange;

            case VolumeLevel.LOUD:

                return playerStatus.LoudRange;

            case VolumeLevel.VERYLOUD:

                return playerStatus.VeryLoudRange;

            default:

                return playerStatus.VerySoftRange;
        }
    }

    /// <summary>
    /// �v���C���[�Ƃ̋����𑪂�
    /// </summary>
    /// <param name="enemy">����Ώ�</param>
    /// <returns>����</returns>
    private float MeasureDistance(Transform enemy)
    {
        return Vector3.Distance(transform.position, enemy.position);
    }

    /// <summary>
    /// �˂��˂��̊p�x�ɓ����Ă��邩
    /// </summary>
    /// <param name="enemy">�Ώ�</param>
    /// <returns>true = �����Ă���</returns>
    private bool IsWithinAngle(Transform enemy)
    {
        // �v���C���[�̊p�x�擾
        var playerAngle = Vector3ToAngle(playerStatus.MoveVector);

        // �G�̊p�x�擾
        var enemyAngle = Vector3ToAngle(enemy.position - transform.position);

        // �v���C���[�ƓG�̊p�x�̍����˂��˂��̊p�x���Ȃ�true
        if(NormalizedAngle(playerAngle-enemyAngle) <= playerStatus.NeneHalfAngle )return true;

        // �p�x�O�Ȃ̂�false
        return false;
    }

    /// <summary>
    /// Vector3�������p�x��
    /// </summary>
    /// <returns>�p�x</returns>
    private float Vector3ToAngle(Vector3 targetVector)
    {
        // �������p�x�ɕϊ�
        var angle = Mathf.Atan2(targetVector.x, targetVector.z) * Mathf.Rad2Deg;

        return NormalizedAngle(angle);
    }

    /// <summary>
    /// �p�x�𐳋K������
    /// </summary>
    /// <param name="angle">�p�x</param>
    /// <returns>���K����̊p�x</returns>
    private float NormalizedAngle(float angle)
    {
        // �p�x���}�C�i�X�̏ꍇ���K��
        if (angle < 0.0f)
        {
            angle += 360.0f;
        }

        return angle;
    }
}
