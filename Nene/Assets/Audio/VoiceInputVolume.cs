using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 音量取得
/// </summary>
public class VoiceInputVolume : SingletonMonoBehaviour<VoiceInputVolume>
{
    /// <summary>
    /// 音量倍率
    /// </summary>
    [SerializeField, Range(0f, 10f)] 
    private float gain = 1f; 

    /// <summary>
    /// 音量
    /// </summary>
    private int volumeRate;

    /// <summary>
    /// 過去の音量キュー
    /// </summary>
    private CapacityQueue<int> lastVolumes;

    /// <summary>
    /// 保存する過去音量数
    /// </summary>
    private int saveNum = 100;

    /// <summary>
    /// 音量取得
    /// </summary>
    public int VolumeRate
    {
        get => volumeRate;
    }

    // Use this for initialization
    private void Start()
    {
        // キュー初期化
        lastVolumes = new CapacityQueue<int>(saveNum);

        // オーディオソース取得
        AudioSource audio = GetComponent<AudioSource>();

        // オーディオソースとマイクがあれば
        if ((audio != null) && (Microphone.devices.Length > 0)) 
        {
            // とりあえず0番目のマイクを使用
            string deviceName = Microphone.devices[0];

            int minFreq;
            int maxFreq;

            // 最大最小サンプリング数を得る
            Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq);

            // 最小サンプリング
            audio.clip = Microphone.Start(deviceName, true, 2, minFreq);

            //マイクをオーディオソースとして実行
            audio.Play(); 
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        lastVolumes.Enqueue(volumeRate);
    }

    /// <summary>
    /// オーディオが検知される度に実行
    /// </summary>
    /// <param name="data">波形</param>
    /// <param name="channels">チャンネル</param>
    private void OnAudioFilterRead(float[] data, int channels)
    {
        float sum = 0f;

        for (int i = 0; i < data.Length; ++i)
        {
            // データ（波形）の絶対値を足す
            sum += Mathf.Abs(data[i]); 
        }
       
        // データ数で割ったものに倍率をかけて音量とする
        var value = Mathf.Clamp01(sum * gain / (float)data.Length);

        // 100をかけて%表示にしてから少数を切り捨てる
        volumeRate = (int)Mathf.Round(value * 100.0f);
    }

    /// <summary>
    /// キュー内の最大値を取得
    /// </summary>
    /// <returns>最大値</returns>
    public int GetMaxLastVolume()
    {
        return lastVolumes.Max();
    }
}
