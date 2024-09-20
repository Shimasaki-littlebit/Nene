using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        get=>hitPoint;
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
        get =>moveSpeed;
    }

    /// <summary>
    /// 移動した方向
    /// </summary>
    private Vector2 moveVector;

    /// <summary>
    /// 移動した方向取得
    /// </summary>
    public Vector2 MoveVector
    {
        get => moveVector;
        set => moveVector = value;
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
    }


}
