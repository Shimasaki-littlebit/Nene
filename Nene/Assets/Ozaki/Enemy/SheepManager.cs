using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// Ž~‚Ü‚é
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


public class SheepManager : SingletonMonoBehaviour<SheepManager>
{
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
}
