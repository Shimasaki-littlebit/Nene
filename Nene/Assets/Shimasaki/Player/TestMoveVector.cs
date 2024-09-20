using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方向確認テスト用
/// </summary>
public class TestMoveVector : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    private PlayerStatus playerStatus;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        playerStatus = PlayerStatus.Instance;
    }

    private void FixedUpdate()
    {
        TestVector();
    }

    private void TestVector()
    {
        var localPos = transform.localPosition;

        localPos.x = playerStatus.MoveVector.x;
        localPos.z = playerStatus.MoveVector.y;

        transform.localPosition = localPos;
    }
}
