using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    [Tooltip("stage�̃f�[�^�̓Y�����ő�l�c")]
    private int arrayHeight;

    /// <summary>
    /// stage�̃f�[�^�̓Y�����ő�l�c�擾
    /// </summary>
    public int ArrayHeight
    {
        get => arrayHeight;
        set => arrayHeight = value;
    }

    [Tooltip("stage�̃f�[�^�̓Y�����ő�l��")]
    private int arrayWidth;

    /// <summary>
    /// stage�̃f�[�^�̓Y�����ő�l���擾
    /// </summary>
    public int ArrayWidth
    {
        get => arrayWidth;
        set => arrayWidth = value;
    }

    [SerializeField]
    [Tooltip("�z�u�I�u�W�F�N�g")]
    private GameObject[] mapchip;

    /// <summary>
    /// Stage�̃f�[�^�̓񎟌��z��
    /// </summary>
    public int[,] StageArray;

    private StageData data;

    public enum MapChip
    {
        /// <summary>
        /// ��
        /// </summary>
        Empty,
        /// <summary>
        /// ����
        /// </summary>
        Glass,
        /// <summary>
        /// �X
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
        //�X�e�[�W�z��̓Y�����ő�l���擾
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

        //�X�e�[�W�z��̏�����
        StageArray = new int[hoge.Width, hoge.Height];
        //���ォ�珇�Ԃɂ����Ă���
        for (int row = 0; row < hoge.Height; ++row)
        {
            for (int col = 0; col < hoge.Width; ++col)
            {
                //���W���擾�Ɛ����Ă�
                Vector3Int position = new(col, hoge.Height - row - 1);

                //�ꎞ�z��Ȃ̂ō��W����
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
    /// �Ή�����I�u�W�F�N�g��z�u����
    /// </summary>
    /// <param name="chipCode">�I�u�W�F�N�g�ԍ�</param>
    /// <param name="hoge">�|�W�V����</param>
    private void EntryGimmick(MapChip chipCode, Vector3 hoge)
    {
        //�I�u�W�F�N�g�z�u
        Instantiate(mapchip[(int)chipCode], hoge, Quaternion.identity);

    }
}
