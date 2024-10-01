using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sheep;

public class SheepMove : MonoBehaviour
{
    /// <summary>
    /// マネージャー取得用
    /// </summary>
    private SheepManager sheepManager;

    /// <summary>
    /// ステータス取得用
    /// </summary>
    private SheepStates sheepStates;

    private float walkSpeed;

    private float stopTime;

    private float nowStopTime;
    // Start is called before the first frame update
    void Start()
    {
        sheepManager = SheepManager.Instance;
        sheepStates = sheepManager.SheepStates;

        walkSpeed = sheepManager.SheepWalkSpeed;

        stopTime = 2.0f;
        nowStopTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
    }
}
