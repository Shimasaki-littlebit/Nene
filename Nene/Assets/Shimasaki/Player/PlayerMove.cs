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

    /// <summary>
    /// ステージマネージャー
    /// </summary>
    private StageManager stageManager;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        playerStatus = PlayerStatus.Instance;
        stageManager = StageManager.Instance;
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
        // 座標取得
        var pos = transform.position;

        Vector3 moveDirection = Vector3.zero;

        // 上
        if(Input.GetKey(KeyCode.W))
        {
            pos.z += playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.z += 1.0f;

            // 上に限界の場合修正
            if(pos.z >= stageManager.ArrayHeight -1.0f)
            {
                pos.z = stageManager.ArrayHeight -1.0f;
            }
        }

        // 下
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.z -= 1.0f;

            // 下に限界の場合修正
            if (pos.z <= 0.0f)
            {
                pos.z = 0.0f;
            }
        }

        // 左
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.x -= 1.0f;

            // 左に限界の場合修正
            if (pos.x <= 0.0f)
            {
                pos.x = 0.0f;
            }
        }

        // 右
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += playerStatus.MoveSpeed * Time.deltaTime;

            moveDirection.x += 1.0f;

            if (pos.x >= stageManager.ArrayWidth -1.0f)
            {
                pos.x = stageManager.ArrayWidth -1.0f;
            }
        }

        // 移動方向を取得
        Vector3 moveVector = moveDirection;

        // 移動している場合正規化して
        // 移動方向に代入
        if(moveDirection != Vector3.zero)
        {
            playerStatus.MoveVector = moveDirection;
        }

        // 座標反映
        transform.position = pos;
    }
}
