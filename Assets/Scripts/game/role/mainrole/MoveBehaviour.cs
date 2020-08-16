using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimationBehavior))]
public class MoveBehaviour : MonoBehaviour
{
    [Header("H/V Move")]
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;//ADD One force whenn jump
    [HideInInspector] public float moveH;
    [SerializeField] private float moveSpeed;
    private SpriteRenderer sp;

    [Header("Check IsGround")]
    [SerializeField] private bool isGround;
    public Transform checkPoint;
    [SerializeField] private float checkRadius;
    public LayerMask layerMask;
    [SerializeField] private Vector2 checkBoxSize;

    [Header("Better Jump")]
    //[SerializeField] private float jumpFactor;
    [SerializeField] private float fallFactor;
    [SerializeField] private float shortJumpFactor;

    [Header("Second Jump")]
    [SerializeField] private float jumpTimes;//MARKER Double Jump

    //[Header("VFX")]
    //[SerializeField] private GameObject jumpEffect;

    [SerializeField] private bool canJump;
    private AnimationBehavior  animationBehavior;

    private PlayerAttackBehaviour playerAttackBehaviour;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animationBehavior = GetComponent<AnimationBehavior>();
        playerAttackBehaviour = GetComponentInChildren<PlayerAttackBehaviour>();
        Physics2D.queriesStartInColliders = false;//确保游戏一开始，射线从某个含有Collider组件的内部发出，会忽略这个Collider组件对象的检测

        isGround = false;
        canJump = false;
    }

    #region 备份
    //private void Update()//0.02s
    //{
    //    if(Input.GetKeyDown(KeyCode.Space) && isGround)
    //    //if(Input.GetKeyDown(KeyCode.Space) && jumpTimes > 1)//MARKER Double Jump
    //    {
    //        rb.velocity = Vector2.up * jumpForce;
    //        Instantiate(jumpEffect, transform.position - Vector3.up, Quaternion.identity);

    //        //jumpTimes--;//MARKER Double Jump
    //        //Debug.Log(jumpTimes);//MARKER Double Jump
    //    }

    //    moveH = Input.GetAxis("Horizontal") * moveSpeed;
    //    rb.velocity = new Vector2(moveH, rb.velocity.y);

    //    //Debug.Log(moveH);//MARKER 如果角色向左移动，moveH为负数；如果向右边移动，则大于零

    //    Flip();
    //    CheckGround();
    //    BetterJump();
    //}
    #endregion

    private void Update()//0.02s
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            canJump = true;
            //Instantiate(jumpEffect, transform.position - Vector3.up, Quaternion.identity);
            jumpTimes--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpTimes > 0 && !canJump)
        {
            jumpTimes--;
            canJump = true;
        }
        else if (Input.GetButtonDown("Attack"))
        {
            playerAttackBehaviour.OneAttack();
        }


        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        Flip();
        CheckGround();

        if (isGround && !canJump)
            jumpTimes = 2;

    }

    private void FixedUpdate()
    {
        if(canJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            canJump = false;
        }

        rb.velocity = new Vector2(moveH, rb.velocity.y);

        BetterJump();
    }

    //检测能否跳跃 => 二段跳 TODO Later
    private void CheckGround()
    {
        #region Raycast Method has Disadvantage
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, -transform.up, sp.bounds.extents.y + 0.1f);
        //Debug.DrawRay(transform.position, -transform.up * (sp.bounds.extents.y + 0.1f), Color.red);
        #endregion

        //Collider2D collider = Physics2D.OverlapCircle(checkPoint.position, checkRadius, layerMask);
        Collider2D collider = Physics2D.OverlapBox(checkPoint.position, checkBoxSize, 0, layerMask);

        if (collider != null)//我们检测到了平台
        {
            isGround = true;
            //jumpTimes = 2;//MARKER Double Jump
        }
        else
        {
            isGround = false;
        }
    }

    //可视化
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(checkPoint.position, checkRadius);
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
        Gizmos.color = Color.green;
    }

    //TODO 其他翻转的方法:LocalScale.x / RotationY / trans.eulerAngles / transform.Rotate(Vector3.up * 180)
    private void Flip()
    {
        if (moveH > 0)
        {
            //sp.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveH < 0)
        {
            //sp.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    //更好的跳跃效果
    private void BetterJump()
    {
        if(rb.velocity.y < 0)//MARKER 角色下落时，速度会越来越快
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallFactor * Time.deltaTime;
        } 
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * shortJumpFactor * Time.deltaTime;
        }
    }

    //MARKER 跳跃的几种方式
    //private void PlayerJump()
    //{
    //rb.AddForce(new Vector2(0, jumpForce));//f * t = m * v => v = jumpForce * 0.02 / 1 OPTIONAL 1
    //rb.AddForce(Vector2.up * jumpForce);//OPTIONAL 2
    //rb.AddForce(transform.up * jumpForce);//OPTIONAL 3
    //}

}
