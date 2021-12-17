using UnityEngine;

public class Monkey : MonoBehaviour
{
    // Start is called before the first frame update
    #region ���}
    public int lives = 3;
    public float height = 0;
    public bool dead = false;
    public bool unlock = true;

    public float moveSpeed;
    [Range(300, 1000)]
    public float jump = 300;

    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    #endregion

    #region �p�H
    [SerializeField]
    private bool isGrounded;
    
    private Rigidbody2D mrig;
    private Animator mAnim;
    #endregion

    #region �ƥ�
    private void Start()
    {
        mrig = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();

    }
    private void Update()

    {
        Flip();
        CheckGround();
        Jump();

    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);

    }
#endregion

    #region ��k
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        // �p�G h �p�� 0 �� : ���� Y 0
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //�p�G h �� �j�� 0 �k:���� Y 0
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
        transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        isGrounded = hit;
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //print("���a���k�����:" + h);
        mrig.velocity = new Vector2(h * moveSpeed, mrig.velocity.y);

        if (h != 0)
        {
            mAnim.SetBool("�����}��", true);
        }
        else
        {
            mAnim.SetBool("�����}��", false);
        }

    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(keyJump))
        {
            mrig.AddForce(new Vector2(0, jump));
        }

        if (!isGrounded)
        {
            mAnim.SetBool("���D�}��", true);
        }
        else
        {
            mAnim.SetBool("���D�}��", false);
        }
    }
    #endregion
}


