using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

/// <summary>
/// �L�[���[�h�F�؊ȈՉ�
/// </summary>
public class MyKeywordRecognizer
{
    /// <summary>
    /// �L�[�ƑΉ������֐��̃f�B�N�V���i���[
    /// </summary>
    private Dictionary<string, Action> keyActionDic;

    /// <summary>
    /// �L�[���[�h�F��
    /// </summary>
    private KeywordRecognizer keywordRecognizer;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public MyKeywordRecognizer()
    {
        // �f�B�N�V���i���[�̏�����
        keyActionDic = new Dictionary<string, Action>();
    }

    /// <summary>
    /// �f�X�g���N�^
    /// </summary>
    ~MyKeywordRecognizer() 
    {
        Dispose();
    }

    /// <summary>
    /// �ǂݎ��J�n���ɌĂԊ֐�
    /// </summary>
    public void Start()
    {
        // �f�B�N�V���i���[���L�[���[�h�Ƃ��ēo�^
        keywordRecognizer = new KeywordRecognizer(keyActionDic.Select(value => value.Key).ToArray());

        // �����F�����̃C�x���g
        keywordRecognizer.OnPhraseRecognized += OnPharseRecognized;

        // �F���̊J�n
        keywordRecognizer.Start();
    }

    /// <summary>
    /// �I�����̏���
    /// </summary>
    private void Dispose()
    {
        // �L�[���[�h�F�؂��܂������Ă���Ύ~�߂�
        if(keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
        }

        // �������
        keywordRecognizer.Dispose();
    }

    /// <summary>
    /// �f�B�N�V���i���[�ɃL�[�Ə�����o�^
    /// </summary>
    /// <param name="key">�L�[</param>
    /// <param name="action">����</param>
    /// <exception cref="ArgumentException">�L�[�d����</exception>
    public void Add(string key,Action action)
    {
        // ���ɓ����L�[�����݂���΃G���[
        if (keyActionDic.ContainsKey(key))
        {
            throw new ArgumentException("�L�[�d��");
        }

        // �o�^
        keyActionDic.Add(key, action);
    }

    /// <summary>
    /// �󂯎�����L�[�ɑΉ������������Ă�
    /// </summary>
    /// <param name="args"></param>
    private void OnPharseRecognized(PhraseRecognizedEventArgs args)
    {
        // �󂯎�����L�[���Ȃ���ΏI��
        if (!keyActionDic.ContainsKey(args.text)) return;

        // �L�[�̏��������s
        keyActionDic[args.text]();
    }
}
