using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃L�[���[�h����
/// </summary>
public class PlayerVoiceKeyInput : MonoBehaviour
{
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

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        inputVolume = VoiceInputVolume.Instance;

        // ������
        myKeyRecog = new();

        // �˂��˂��̃L�[���[�h�ƍs����ǉ�
        myKeyRecog.Add(nene, NeneSkill);

        // �J�n
        myKeyRecog.Start();

    }

    /// <summary>
    /// �˂��˂��̃X�L������
    /// </summary>
    private void NeneSkill()
    {
        

        Debug.Log("�˂��˂����m" + inputVolume.GetMaxLastVolume());
    }
}
