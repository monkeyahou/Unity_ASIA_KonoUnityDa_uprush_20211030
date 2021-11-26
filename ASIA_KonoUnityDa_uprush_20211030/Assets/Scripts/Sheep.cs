using UnityEngine;

/// <summary>
/// 控制器:2D 橫向卷軸版本
/// </summary>
public class Sheep : MonoBehaviour
{
    #region 欄位:公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 15000)]
    public float jump = 300;
    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyJump = KeyCode.Space;
    public LayerMask canJumpLayer;

    #endregion

    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D A;

    /// <summary>
    /// 繪製圖示
    /// 在 Unity 繪製輔助用圖示
    /// 線條、射線、圓形、方形、扇形、圖片
    /// 圖形 Gizmos 類別
    /// </summary>
    private void OnDrawGizmos()
    {
        // 1. 決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2. 決定繪製圖形
        // transform.position 此物件的世界座標
        // transform.TransformDirection() 根據座標元件的區域座標轉為世界座標
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);

    }

    private void Start()
    {
        A = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update 約 60 FPS
    /// 固定更新事件 : 50 FPS
    /// 處理物理行為
    /// </summary>

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flip();
    }

    #region 方法
    /// <summary>
    /// 1.玩家是否有按移動按鍵 左右方向鍵 或 A、D
    /// 2.物件移動行為(API)
    /// </summary>

    private void Move()
    {
        // h 值 指定為 輸入.取得軸向(水平軸) -水平軸代表左右鍵 或 A、D
        float h = Input.GetAxis("Horizontal");
        print("玩家左右按鍵值:" + h);

        // 剛體元件.加速度 = 新 二維向量(h 值 * 移動速度，0);
        A.velocity = new Vector2(h * speed, 0);

    }

    /// <summary>
    /// 翻面 :
    /// 左 : 角度 Y 180
    /// 右 : 角度 Y 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");
        
        // 如果 h 小於 0 左 : 角度 Y 0
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //如果 h 值 大於 0 右:角度 Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    #endregion
}
