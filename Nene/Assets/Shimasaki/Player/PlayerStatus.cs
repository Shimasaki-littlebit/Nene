using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤー関係の列挙型置き場
namespace PlayerEnum
{
    /// <summary>
    /// 音量レベル
    /// </summary>
    public enum VolumeLevel
    {
        /// <summary>
        /// 最小
        /// </summary>
        VERYSOFT,

        /// <summary>
        /// 小さい
        /// </summary>
        SOFT,

        /// <summary>
        /// 大きい
        /// </summary>
        LOUD,

        /// <summary>
        /// 最大
        /// </summary>
        VERYLOUD,
    }
}

/// <summary>
/// プレイヤーの情報
/// </summary>
public class PlayerStatus : SingletonMonoBehaviour<PlayerStatus>
{
    /// <summary>
    /// プレイヤーの参照
    /// </summary>
    private GameObject player;

    /// <summary>
    /// プレイヤーの参照取得
    /// </summary>
    public GameObject Player
    {
        get => player;
    }

    /// <summary>
    /// 体力
    /// </summary>
    [SerializeField]
    private int hitPoint;

    /// <summary>
    /// 体力取得
    /// </summary>
    public int HitPoint
    {
        get => hitPoint;
        set => hitPoint = value;
    }

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 移動速度取得
    /// </summary>
    public float MoveSpeed
    {
        get => moveSpeed;
    }

    /// <summary>
    /// 移動した方向
    /// </summary>
    private Vector3 moveVector;

    /// <summary>
    /// 移動した方向取得
    /// </summary>
    public Vector3 MoveVector
    {
        get => moveVector;
        set => moveVector = value;
    }

    /// <summary>
    /// ねえねえ中か
    /// </summary>
    private bool isNene;

    /// <summary>
    /// ねえねえ中か取得
    /// </summary>
    public bool IsNene
    {
        get => isNene;
        set => isNene = value;
    }

    /// <summary>
    /// 隠れているか
    /// </summary>
    private bool isHide;

    /// <summary>
    /// 隠れているか取得
    /// </summary>
    public bool IsHide
    {
        get => isHide;
        set => isHide = value;
    }

    /// <summary>
    /// ねえねえのクールダウン
    /// </summary>
    [SerializeField]
    private float neneCoolTime;

    /// <summary>
    /// ねえねえの片方角度(20なら合計40度分範囲とする)
    /// </summary>
    [SerializeField]
    private float neneHalfAngle;

    /// <summary>
    /// ねえねえの片方角度取得
    /// </summary>
    public float NeneHalfAngle
    {
        get => neneHalfAngle;
    }

    /// <summary>
    /// 最小ねえねえ範囲
    /// </summary>
    [SerializeField]
    private float verySoftRange;

    /// <summary>
    /// 最小ねえねえ範囲取得
    /// </summary>
    public float VerySoftRange
    {
        get =>verySoftRange;
    }

    /// <summary>
    /// 小さいねえねえ範囲
    /// </summary>
    [SerializeField]
    private float softRange;

    /// <summary>
    /// 小さいねえねえ範囲取得
    /// </summary>
    public float SoftRange
    {
        get => softRange;
    }

    /// <summary>
    /// 大きいねえねえ範囲
    /// </summary>
    [SerializeField]
    private float loudRange;

    /// <summary>
    /// 大きいねえねえ範囲取得
    /// </summary>
    public float LoudRange
    {
        get => loudRange;
    }

    /// <summary>
    /// 最大ねえねえ範囲
    /// </summary>
    [SerializeField]
    private float veryLoudRange;

    /// <summary>
    /// 最大ねえねえ範囲取得
    /// </summary>
    public float VeryLoudRange
    {
        get => veryLoudRange;
    }

    /// <summary>
    /// ねえねえのクールダウン取得
    /// </summary>
    public float NeneCoolTime
    {
        get => neneCoolTime;
    }

    protected override void Awake()
    {
        base.Awake();

        // プレイヤーの参照取得
        player = gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // 初期化
        moveVector = Vector2.up;

        // ねえねえフラグ初期化
        isNene = false;

        // 隠れていない状態で初期化
        isHide = false;
    }


}
