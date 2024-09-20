using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのキーワード入力
/// </summary>
public class PlayerVoiceKeyInput : MonoBehaviour
{
    /// <summary>
    /// ねえねえに使う文字
    /// </summary>
    private string nene = "ねえねえ";

    /// <summary>
    /// キーワード声入力
    /// </summary>
    private MyKeywordRecognizer myKeyRecog;

    // Start is called before the first frame update
    private void Start()
    {
        // 初期化
        myKeyRecog = new();

        // ねえねえのキーワードと行動を追加
        myKeyRecog.Add(nene, NeneSkill);

        // 開始
        myKeyRecog.Start();

    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /// <summary>
    /// ねえねえのスキル処理
    /// </summary>
    private void NeneSkill()
    {
        Debug.Log("ねえねえ検知");
    }
}
