using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerEnum;
using System.Net;

/// <summary>
/// ねえねえのスキル
/// </summary>
public class NeneSkill : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    private PlayerStatus playerStatus;

    /// <summary>
    /// クールダウン用タイマー
    /// </summary>
    private Timer coolTimer;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        playerStatus = PlayerStatus.Instance;

        // タイマー初期化
        coolTimer = new();
    }

    private void FixedUpdate()
    {
        // タイマーカウント
        coolTimer.Count(Time.deltaTime);
    }

    /// <summary>
    /// ねえねえ開始処理
    /// </summary>
    public void StartNene(int volume)
    {
        // ねえねえ中なら終了
        if (playerStatus.IsNene) return;

        // ねえねえ中に
        playerStatus.IsNene = true;

        // クールダウンのタイマーセット
        coolTimer.SetTimer(playerStatus.NeneCoolTime, FinishNeneCoolTime);

        // ねえねえ開始
        Nene(SelectVolumeLevel(volume));
    }

    /// <summary>
    /// ねえねえのクールダウン終了処理
    /// </summary>
    private void FinishNeneCoolTime()
    {
        // ねえねえフラグを下ろす
        playerStatus.IsNene = false;
    }

    /// <summary>
    /// 音量から声の強さを選択
    /// </summary>
    /// <param name="inputVolume">音量</param>
    /// <returns>声の強さ</returns>
    private VolumeLevel SelectVolumeLevel(int inputVolume)
    {
        VolumeLevel num;

        // 最小
        if (inputVolume <= 29)
        {
            num = VolumeLevel.VERYSOFT;
        }

        // 小さい
        else if (inputVolume <= 59)
        {
            num = VolumeLevel.SOFT;
        }

        // 大きい
        else if (inputVolume <= 89)
        {
            num = VolumeLevel.LOUD;
        }

        // 最大
        else
        {
            num = VolumeLevel.VERYLOUD;
        }

        return num;
    }

    /// <summary>
    /// ねえねえ処理
    /// </summary>
    /// <param name="level">音量レベル</param>
    private void Nene(VolumeLevel level)
    {
        // 攻撃範囲を決定
       var range = ChooseNeneRange(level);

        //// ここでリストまわしてforeach
        //{
            //// 敵の距離がねえねえ射程範囲より遠ければスキップ
            //if (range < MeasureDistance(enemy.transform)) continue;

            //// 敵がねえねえの角度外ならスキップ
            //if (!IsWithinAngle(enemy.transform)) continue;

            //// 敵のねえねえを受けた動作を実行
        //}

    }

    /// <summary>
    /// ねえねえの範囲の選択
    /// </summary>
    /// <param name="chooseLevel">選択する音量レベル</param>
    /// <returns>攻撃範囲</returns>
    private float ChooseNeneRange(VolumeLevel chooseLevel)
    {
        switch (chooseLevel)
        {
            case VolumeLevel.VERYSOFT:

                return playerStatus.VerySoftRange;

            case VolumeLevel.SOFT:

                return playerStatus.SoftRange;

            case VolumeLevel.LOUD:

                return playerStatus.LoudRange;

            case VolumeLevel.VERYLOUD:

                return playerStatus.VeryLoudRange;

            default:

                return playerStatus.VerySoftRange;
        }
    }

    /// <summary>
    /// プレイヤーとの距離を測る
    /// </summary>
    /// <param name="enemy">測る対象</param>
    /// <returns>距離</returns>
    private float MeasureDistance(Transform enemy)
    {
        return Vector3.Distance(transform.position, enemy.position);
    }

    /// <summary>
    /// ねえねえの角度に入っているか
    /// </summary>
    /// <param name="enemy">対象</param>
    /// <returns>true = 入っている</returns>
    private bool IsWithinAngle(Transform enemy)
    {
        // プレイヤーの角度取得
        var playerAngle = Vector3ToAngle(playerStatus.MoveVector);

        // 敵の角度取得
        var enemyAngle = Vector3ToAngle(enemy.position - transform.position);

        // プレイヤーと敵の角度の差がねえねえの角度内ならtrue
        if(NormalizedAngle(playerAngle-enemyAngle) <= playerStatus.NeneHalfAngle )return true;

        // 角度外なのでfalse
        return false;
    }

    /// <summary>
    /// Vector3方向を角度に
    /// </summary>
    /// <returns>角度</returns>
    private float Vector3ToAngle(Vector3 targetVector)
    {
        // 方向を角度に変換
        var angle = Mathf.Atan2(targetVector.x, targetVector.z) * Mathf.Rad2Deg;

        return NormalizedAngle(angle);
    }

    /// <summary>
    /// 角度を正規化する
    /// </summary>
    /// <param name="angle">角度</param>
    /// <returns>正規化後の角度</returns>
    private float NormalizedAngle(float angle)
    {
        // 角度がマイナスの場合正規化
        if (angle < 0.0f)
        {
            angle += 360.0f;
        }

        return angle;
    }
}
