using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃L�[���[�h����
/// </summary>
public class PlayerVoiceKeyInput : MonoBehaviour
{
    /// <summary>
    /// ���ʎ擾����Ɏg������
    /// </summary>
    private string getVolumeName = "�˂���";

    /// <summary>
    /// �˂��˂��Ɏg������
    /// </summary>
    private string nene = "�˂��˂�";

    /// <summary>
    /// �L�[���[�h������
    /// </summary>
    private MyKeywordRecognizer myKeyRecog;

    /// <summary>
    /// �����͂̉���
    /// </summary>
    private VoiceInputVolume inputVolume;

    /// <summary>
    /// �擾�{�����[��
    /// </summary>
    private int volumeValue;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        inputVolume = VoiceInputVolume.Instance;

        // ������
        myKeyRecog = new();

        // ���ʔ���ǉ�
        //myKeyRecog.Add(getVolumeName, GetVolume);

        // �˂��˂��̃L�[���[�h�ƍs����ǉ�
        myKeyRecog.Add(nene, NeneSkill);

        // �J�n
        myKeyRecog.Start();

    }

    /// <summary>
    /// ���ʔ���
    /// </summary>
    private void GetVolume()
    {
        volumeValue = inputVolume.VolumeRate;

        Debug.Log(volumeValue);
    }

    /// <summary>
    /// �˂��˂��̃X�L������
    /// </summary>
    private void NeneSkill()
    {


        Debug.Log("�˂��˂����m" + inputVolume.GetMaxLastVolume());
    }
}
