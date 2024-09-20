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
}


public class SheepManager : SingletonMonoBehaviour<SheepManager>
{
    /// <summary>
    /// �X�e�[�^�X
    /// </summary>
    private SheepStates sheepStates;
    public SheepStates SheepStates
    { get => sheepStates; set => sheepStates = value;}

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

    /// <summary>
    /// 㩂ɂ�����
    /// </summary>
    [SerializeField]
    private bool sheepStan;
    public bool SheepStan
    { get => sheepStan; set => sheepStan = value;}

    private void Start()
    {
        // ��Ԃ������Ԃŏ�����
        sheepStates = SheepStates.Walk;
    }
}