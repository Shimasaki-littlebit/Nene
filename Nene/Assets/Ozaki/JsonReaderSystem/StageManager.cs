using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    [Tooltip("stageのデータの添え字最大値縦")]
    private int arrayHeight;

    /// <summary>
    /// stageのデータの添え字最大値縦取得
    /// </summary>
    public int ArrayHeight
    {
        get => arrayHeight;
        set => arrayHeight = value;
    }

    [Tooltip("stageのデータの添え字最大値横")]
    private int arrayWidth;

    /// <summary>
    /// stageのデータの添え字最大値横取得
    /// </summary>
    public int ArrayWidth
    {
        get => arrayWidth;
        set => arrayWidth = value;
    }

    [SerializeField]
    [Tooltip("配置オブジェクト")]
    private GameObject[] mapchip;

    /// <summary>
    /// Stageのデータの二次元配列
    /// </summary>
    public int[,] StageArray;

    private StageData data;

    public enum MapChip
    {
        /// <summary>
        /// 空
        /// </summary>
        Empty,
        /// <summary>
        /// 草原
        /// </summary>
        Glass,
        /// <summary>
        /// 森
        /// </summary>
        Forest,
    }

    // Start is called before the first frame update
    void Start()
    {
        DataInput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void StageDownload(int hoge)
    //{

    //    switch (hoge)
    //    {
    //        case 0:
    //            data = JsonReader.LoadStage("stage01");
    //            StageGenerator(data);
    //            break;
    //        case 1:
    //            data = JsonReader.LoadStage("stage02");
    //            StageGenerator(data);
    //            break;
    //        case 2:
    //            data = JsonReader.LoadStage("stage03");
    //            StageGenerator(data);
    //            break;
    //    }
    //}

    private void DataInput()
    {
        data = JsonReader.LoadStage("stage01");

        StageGenerator(data);
    }

    private void StageGenerator(StageData hoge)
    {
        //ステージ配列の添え字最大値を取得
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

        //ステージ配列の初期化
        StageArray = new int[hoge.Width, hoge.Height];
        //左上から順番においていく
        for (int row = 0; row < hoge.Height; ++row)
        {
            for (int col = 0; col < hoge.Width; ++col)
            {
                //座標を取得と整えてる
                Vector3Int position = new(col, hoge.Height - row - 1);

                //一時配列なので座標足す
                var chip = (MapChip)hoge.Mapchip[col + row * hoge.Width];

                switch (chip)
                {
                    case MapChip.Empty:
                        break;
                    case MapChip.Glass:
                        EntryGimmick(chip, new(col, 0, hoge.Height - (row + 1)));
                        break;
                    case MapChip.Forest:
                        EntryGimmick(chip, new(col, 0, hoge.Height - (row + 1)));
                        break;

                }
            }
        }
    }

    /// <summary>
    /// 対応するオブジェクトを配置する
    /// </summary>
    /// <param name="chipCode">オブジェクト番号</param>
    /// <param name="hoge">ポジション</param>
    private void EntryGimmick(MapChip chipCode, Vector3 hoge)
    {
        //オブジェクト配置
        Instantiate(mapchip[(int)chipCode], hoge, Quaternion.identity);

    }
}
