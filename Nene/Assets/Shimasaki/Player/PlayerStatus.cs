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

    protected override void Awake()
    {
        base.Awake();

        // プレイヤーの参照取得
        player = gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
       
    }


}
