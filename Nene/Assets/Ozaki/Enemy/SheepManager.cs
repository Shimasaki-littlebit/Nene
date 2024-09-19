using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SheepStates
{
    /// <summary>
    /// ��
    /// </summary>
    None,
    /// <summary>
    /// ����
    /// </summary>
    Walk,
    /// <summary>
    /// ������
    /// </summary>
    Found,
    /// <summary>
    /// �~�܂�
    /// </summary>
    Stop,
    /// <summary>
    /// ������Ƃ�������
    /// </summary>
    ShortMove,
    /// <summary>
    /// ����
    /// </summary>
    Move,
    /// <summary>
    /// ����
    /// </summary>
    Clamor,
}


public class SheepManager : SingletonMonoBehaviour<SheepManager>
{
    /// <summary>
    /// �r�̕�������
    /// </summary>
    [SerializeField]
    private float sheepWalkSpeed;
    public float SheepWalkSpeed
    { get =>  sheepWalkSpeed; set => sheepWalkSpeed = value;}

    /// <summary>
    /// �r�̑��鑬��
    /// </summary>
    [SerializeField]
    private float sheepRunSpeed;
    public float SheepRunSpeed
    { get => sheepRunSpeed; set => sheepRunSpeed = value;}

    /// <summary>
    /// �r�̓����鑬��
    /// </summary>
    [SerializeField]
    private float sheepEscapeSpeed;
    public float SheepEscapeSpeed
    { get=> sheepEscapeSpeed; set => sheepEscapeSpeed = value;}
}
