using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Sheep;

namespace Sheep
{
    public enum SheepStates
    {
        /// <summary>
        /// 空
        /// </summary>
        None,
        /// <summary>
        /// 歩き
        /// </summary>
        Walk,
        /// <summary>
        /// 見つける
        /// </summary>
        Found,
        /// <summary>
        /// 止まる
        /// </summary>
        Stop,
        /// <summary>
        /// ちょっとだけ動く
        /// </summary>
        ShortMove,
        /// <summary>
        /// 動く
        /// </summary>
        Move,
        /// <summary>
        /// 騒ぐ
        /// </summary>
        Clamor,
    }
}


public class SheepManager : SingletonMonoBehaviour<SheepManager>
{
    /// <summary>
    /// ステータス
    /// </summary>
    private SheepStates sheepStates;
    public SheepStates SheepStates
    { get => sheepStates; set => sheepStates = value;}

    /// <summary>
    /// 羊の歩く速さ
    /// </summary>
    [SerializeField]
    private float sheepWalkSpeed;
    public float SheepWalkSpeed
    { get =>  sheepWalkSpeed; set => sheepWalkSpeed = value;}

    /// <summary>
    /// 羊の走る速さ
    /// </summary>
    [SerializeField]
    private float sheepRunSpeed;
    public float SheepRunSpeed
    { get => sheepRunSpeed; set => sheepRunSpeed = value;}

    /// <summary>
    /// 羊の逃げる速さ
    /// </summary>
    [SerializeField]
    private float sheepEscapeSpeed;
    public float SheepEscapeSpeed
    { get=> sheepEscapeSpeed; set => sheepEscapeSpeed = value;}

    /// <summary>
    /// 罠にかかる
    /// </summary>
    [SerializeField]
    private bool sheepStan;
    public bool SheepStan
    { get => sheepStan; set => sheepStan = value;}

    private void Start()
    {
        // 状態を歩き状態で初期化
        sheepStates = SheepStates.Walk;
    }
}