using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ���ʎ擾
/// </summary>
public class VoiceInputVolume : SingletonMonoBehaviour<VoiceInputVolume>
{
    /// <summary>
    /// ���ʔ{��
    /// </summary>
    [SerializeField, Range(0f, 10f)] 
    private float gain = 1f; 

    /// <summary>
    /// ����
    /// </summary>
    private int volumeRate;

    /// <summary>
    /// �ߋ��̉��ʃL���[
    /// </summary>
    private CapacityQueue<int> lastVolumes;

    /// <summary>
    /// �ۑ�����ߋ����ʐ�
    /// </summary>
    private int saveNum = 100;

    /// <summary>
    /// ���ʎ擾
    /// </summary>
    public int VolumeRate
    {
        get => volumeRate;
    }

    // Use this for initialization
    private void Start()
    {
        // �L���[������
        lastVolumes = new CapacityQueue<int>(saveNum);

        // �I�[�f�B�I�\�[�X�擾
        AudioSource audio = GetComponent<AudioSource>();

        // �I�[�f�B�I�\�[�X�ƃ}�C�N�������
        if ((audio != null) && (Microphone.devices.Length > 0)) 
        {
            // �Ƃ肠����0�Ԗڂ̃}�C�N���g�p
            string deviceName = Microphone.devices[0];

            int minFreq;
            int maxFreq;

            // �ő�ŏ��T���v�����O���𓾂�
            Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq);

            // �ŏ��T���v�����O
            audio.clip = Microphone.Start(deviceName, true, 2, minFreq);

            //�}�C�N���I�[�f�B�I�\�[�X�Ƃ��Ď��s
            audio.Play(); 
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        lastVolumes.Enqueue(volumeRate);
    }

    /// <summary>
    /// �I�[�f�B�I�����m�����x�Ɏ��s
    /// </summary>
    /// <param name="data">�g�`</param>
    /// <param name="channels">�`�����l��</param>
    private void OnAudioFilterRead(float[] data, int channels)
    {
        float sum = 0f;

        for (int i = 0; i < data.Length; ++i)
        {
            // �f�[�^�i�g�`�j�̐�Βl�𑫂�
            sum += Mathf.Abs(data[i]); 
        }
       
        // �f�[�^���Ŋ��������̂ɔ{���������ĉ��ʂƂ���
        var value = Mathf.Clamp01(sum * gain / (float)data.Length);

        // 100��������%�\���ɂ��Ă��班����؂�̂Ă�
        volumeRate = (int)Mathf.Round(value * 100.0f);
    }

    /// <summary>
    /// �L���[���̍ő�l���擾
    /// </summary>
    /// <returns>�ő�l</returns>
    public int GetMaxLastVolume()
    {
        return lastVolumes.Max();
    }
}
