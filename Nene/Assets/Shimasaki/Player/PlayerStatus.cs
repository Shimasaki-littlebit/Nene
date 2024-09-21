using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �v���C���[�֌W�̗񋓌^�u����
namespace PlayerEnum
{
    /// <summary>
    /// ���ʃ��x��
    /// </summary>
    public enum VolumeLevel
    {
        /// <summary>
        /// �ŏ�
        /// </summary>
        VERYSOFT,

        /// <summary>
        /// ������
        /// </summary>
        SOFT,

        /// <summary>
        /// �傫��
        /// </summary>
        LOUD,

        /// <summary>
        /// �ő�
        /// </summary>
        VERYLOUD,
    }
}

/// <summary>
/// �v���C���[�̏��
/// </summary>
public class PlayerStatus : SingletonMonoBehaviour<PlayerStatus>
{
    /// <summary>
    /// �v���C���[�̎Q��
    /// </summary>
    private GameObject player;

    /// <summary>
    /// �v���C���[�̎Q�Ǝ擾
    /// </summary>
    public GameObject Player
    {
        get => player;
    }

    /// <summary>
    /// �̗�
    /// </summary>
    [SerializeField]
    private int hitPoint;

    /// <summary>
    /// �̗͎擾
    /// </summary>
    public int HitPoint
    {
        get => hitPoint;
        set => hitPoint = value;
    }

    /// <summary>
    /// �ړ����x
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// �ړ����x�擾
    /// </summary>
    public float MoveSpeed
    {
        get => moveSpeed;
    }

    /// <summary>
    /// �ړ���������
    /// </summary>
    private Vector3 moveVector;

    /// <summary>
    /// �ړ����������擾
    /// </summary>
    public Vector3 MoveVector
    {
        get => moveVector;
        set => moveVector = value;
    }

    /// <summary>
    /// �˂��˂�����
    /// </summary>
    private bool isNene;

    /// <summary>
    /// �˂��˂������擾
    /// </summary>
    public bool IsNene
    {
        get => isNene;
        set => isNene = value;
    }

    /// <summary>
    /// �B��Ă��邩
    /// </summary>
    private bool isHide;

    /// <summary>
    /// �B��Ă��邩�擾
    /// </summary>
    public bool IsHide
    {
        get => isHide;
        set => isHide = value;
    }

    /// <summary>
    /// �˂��˂��̃N�[���_�E��
    /// </summary>
    [SerializeField]
    private float neneCoolTime;

    /// <summary>
    /// �˂��˂��̕Е��p�x(20�Ȃ獇�v40�x���͈͂Ƃ���)
    /// </summary>
    [SerializeField]
    private float neneHalfAngle;

    /// <summary>
    /// �˂��˂��̕Е��p�x�擾
    /// </summary>
    public float NeneHalfAngle
    {
        get => neneHalfAngle;
    }

    /// <summary>
    /// �ŏ��˂��˂��͈�
    /// </summary>
    [SerializeField]
    private float verySoftRange;

    /// <summary>
    /// �ŏ��˂��˂��͈͎擾
    /// </summary>
    public float VerySoftRange
    {
        get =>verySoftRange;
    }

    /// <summary>
    /// �������˂��˂��͈�
    /// </summary>
    [SerializeField]
    private float softRange;

    /// <summary>
    /// �������˂��˂��͈͎擾
    /// </summary>
    public float SoftRange
    {
        get => softRange;
    }

    /// <summary>
    /// �傫���˂��˂��͈�
    /// </summary>
    [SerializeField]
    private float loudRange;

    /// <summary>
    /// �傫���˂��˂��͈͎擾
    /// </summary>
    public float LoudRange
    {
        get => loudRange;
    }

    /// <summary>
    /// �ő�˂��˂��͈�
    /// </summary>
    [SerializeField]
    private float veryLoudRange;

    /// <summary>
    /// �ő�˂��˂��͈͎擾
    /// </summary>
    public float VeryLoudRange
    {
        get => veryLoudRange;
    }

    /// <summary>
    /// �˂��˂��̃N�[���_�E���擾
    /// </summary>
    public float NeneCoolTime
    {
        get => neneCoolTime;
    }

    protected override void Awake()
    {
        base.Awake();

        // �v���C���[�̎Q�Ǝ擾
        player = gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // ������
        moveVector = Vector2.up;

        // �˂��˂��t���O������
        isNene = false;

        // �B��Ă��Ȃ���Ԃŏ�����
        isHide = false;
    }


}
