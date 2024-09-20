using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̏��
/// </summary>
public class PlayerStatus : SingletonMonoBehaviour<PlayerStatus>
{
    /// <summary>
    /// �v���C���[�̎Q��
    /// </summary>
    private GameObject player;

    /// <summary>
    /// �v���C���[�̎Q�Ǝ擾
    /// </summary>
    public GameObject Player
    {
        get => player;
    }

    /// <summary>
    /// �̗�
    /// </summary>
    [SerializeField]
    private int hitPoint;

    /// <summary>
    /// �̗͎擾
    /// </summary>
    public int HitPoint
    {
        get=>hitPoint;
        set => hitPoint = value;
    }

    /// <summary>
    /// �ړ����x
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// �ړ����x�擾
    /// </summary>
    public float MoveSpeed
    {
        get =>moveSpeed;
    }

    protected override void Awake()
    {
        base.Awake();

        // �v���C���[�̎Q�Ǝ擾
        player = gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
       
    }


}
