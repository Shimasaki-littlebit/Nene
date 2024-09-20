using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラがプレイヤーに付随する処理
/// </summary>
public class TrackingPlayer : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    private PlayerStatus playerStatus;

    /// <summary>
    /// カメラの相対位置
    /// </summary>
    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        playerStatus = PlayerStatus.Instance;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        TrackingMove();
    }

    /// <summary>
    /// 追尾処理
    /// </summary>
    private void TrackingMove()
    {
        // 座標取得
        var cameraPos = playerStatus.Player.transform.position + offset;

        // 座標反映
        transform.position = cameraPos;
    }
}
