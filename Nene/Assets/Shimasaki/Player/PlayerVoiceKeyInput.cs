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

    // Start is called before the first frame update
    private void Start()
    {
        // ������
        myKeyRecog = new();

        // �˂��˂��̃L�[���[�h�ƍs����ǉ�
        myKeyRecog.Add(nene, NeneSkill);

        // �J�n
        myKeyRecog.Start();

    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /// <summary>
    /// �˂��˂��̃X�L������
    /// </summary>
    private void NeneSkill()
    {
        Debug.Log("�˂��˂����m");
    }
}
