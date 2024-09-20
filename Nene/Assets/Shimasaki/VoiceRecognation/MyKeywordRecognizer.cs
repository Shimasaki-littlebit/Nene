using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

/// <summary>
/// キーワード認証簡易化
/// </summary>
public class MyKeywordRecognizer
{
    /// <summary>
    /// キーと対応した関数のディクショナリー
    /// </summary>
    private Dictionary<string, Action> keyActionDic;

    /// <summary>
    /// キーワード認証
    /// </summary>
    private KeywordRecognizer keywordRecognizer;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public MyKeywordRecognizer()
    {
        // ディクショナリーの初期化
        keyActionDic = new Dictionary<string, Action>();
    }

    /// <summary>
    /// デストラクタ
    /// </summary>
    ~MyKeywordRecognizer() 
    {
        Dispose();
    }

    /// <summary>
    /// 読み取り開始時に呼ぶ関数
    /// </summary>
    public void Start()
    {
        // ディクショナリーをキーワードとして登録
        keywordRecognizer = new KeywordRecognizer(keyActionDic.Select(value => value.Key).ToArray());

        // 音声認識時のイベント
        keywordRecognizer.OnPhraseRecognized += OnPharseRecognized;

        // 認識の開始
        keywordRecognizer.Start();
    }

    /// <summary>
    /// 終了時の処理
    /// </summary>
    private void Dispose()
    {
        // キーワード認証がまだ動いていれば止める
        if(keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
        }

        // 解放処理
        keywordRecognizer.Dispose();
    }

    /// <summary>
    /// ディクショナリーにキーと処理を登録
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="action">処理</param>
    /// <exception cref="ArgumentException">キー重複時</exception>
    public void Add(string key,Action action)
    {
        // 既に同じキーが存在すればエラー
        if (keyActionDic.ContainsKey(key))
        {
            throw new ArgumentException("キー重複");
        }

        // 登録
        keyActionDic.Add(key, action);
    }

    /// <summary>
    /// 受け取ったキーに対応した処理を呼ぶ
    /// </summary>
    /// <param name="args"></param>
    private void OnPharseRecognized(PhraseRecognizedEventArgs args)
    {
        // 受け取ったキーがなければ終了
        if (!keyActionDic.ContainsKey(args.text)) return;

        // キーの処理を実行
        keyActionDic[args.text]();
    }
}
