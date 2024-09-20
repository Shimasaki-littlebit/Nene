using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのキーワード入力
/// </summary>
public class PlayerVoiceKeyInput : MonoBehaviour
{
    /// <summary>
    /// 音量取得判定に使う文字
    /// </summary>
    private string getVolumeName = "ねえね";

    /// <summary>
    /// ねえねえに使う文字
    /// </summary>
    private string nene = "ねえねえ";

    /// <summary>
    /// キーワード声入力
    /// </summary>
    private MyKeywordRecognizer myKeyRecog;

    /// <summary>
    /// 声入力の音量
    /// </summary>
    private VoiceInputVolume inputVolume;

    /// <summary>
    /// 取得ボリューム
    /// </summary>
    private int volumeValue;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        inputVolume = VoiceInputVolume.Instance;

        // 初期化
        myKeyRecog = new();

        // 音量判定追加
        //myKeyRecog.Add(getVolumeName, GetVolume);

        // ねえねえのキーワードと行動を追加
        myKeyRecog.Add(nene, NeneSkill);

        // 開始
        myKeyRecog.Start();

    }

    /// <summary>
    /// 音量判定
    /// </summary>
    private void GetVolume()
    {
        volumeValue = inputVolume.VolumeRate;

        Debug.Log(volumeValue);
    }

    /// <summary>
    /// ねえねえのスキル処理
    /// </summary>
    private void NeneSkill()
    {


        Debug.Log("ねえねえ検知" + inputVolume.GetMaxLastVolume());
    }
}
