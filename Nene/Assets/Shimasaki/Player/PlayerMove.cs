using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    private PlayerStatus playerStatus;

    // Start is called before the first frame update
    private void Start()
    {
        playerStatus = PlayerStatus.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveProcess();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void MoveProcess()
    {
        var pos = transform.position;

        // 前
        if(Input.GetKey(KeyCode.W))
        {
            pos.z += playerStatus.MoveSpeed * Time.deltaTime;
        }

        // 後
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= playerStatus.MoveSpeed * Time.deltaTime;
        }

        // 左
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= playerStatus.MoveSpeed * Time.deltaTime;
        }

        // 右
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += playerStatus.MoveSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
