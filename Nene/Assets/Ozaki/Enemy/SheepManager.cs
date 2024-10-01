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
        /// ‹ó
        /// </summary>
        None,
        /// <summary>
        /// •à‚«
        /// </summary>
        Walk,
        /// <summary>
        /// Œ©‚Â‚¯‚é
        /// </summary>
        Found,
        /// <summary>
        /// ~‚Ü‚é
        /// </summary>
        Stop,
        /// <summary>
        /// ‚¿‚å‚Á‚Æ‚¾‚¯“®‚­
        /// </summary>
        ShortMove,
        /// <summary>
        /// “®‚­
        /// </summary>
        Move,
        /// <summary>
        /// ‘›‚®
        /// </summary>
        Clamor,
    }
}


public class SheepManager : SingletonMonoBehaviour<SheepManager>
{
    /// <summary>
    /// ƒXƒe[ƒ^ƒX
    /// </summary>
    private SheepStates sheepStates;
    public SheepStates SheepStates
    { get => sheepStates; set => sheepStates = value;}

    /// <summary>
    /// —r‚Ì•à‚­‘¬‚³
    /// </summary>
    [SerializeField]
    private float sheepWalkSpeed;
    public float SheepWalkSpeed
    { get =>  sheepWalkSpeed; set => sheepWalkSpeed = value;}

    /// <summary>
    /// —r‚Ì‘–‚é‘¬‚³
    /// </summary>
    [SerializeField]
    private float sheepRunSpeed;
    public float SheepRunSpeed
    { get => sheepRunSpeed; set => sheepRunSpeed = value;}

    /// <summary>
    /// —r‚Ì“¦‚°‚é‘¬‚³
    /// </summary>
    [SerializeField]
    private float sheepEscapeSpeed;
    public float SheepEscapeSpeed
    { get=> sheepEscapeSpeed; set => sheepEscapeSpeed = value;}

    /// <summary>
    /// ã©‚É‚©‚©‚é
    /// </summary>
    [SerializeField]
    private bool sheepStan;
    public bool SheepStan
    { get => sheepStan; set => sheepStan = value;}

    /// <summary>
    /// ~‚Ü‚éŠÔ
    /// </summary>
    [SerializeField]
    private float stopTime;
    public float StopTime
    {get => stopTime; set => stopTime = value;}
    private void Start()
    {
        // ó‘Ô‚ğ•à‚«ó‘Ô‚Å‰Šú‰»
        sheepStates = SheepStates.Walk;
    }
}