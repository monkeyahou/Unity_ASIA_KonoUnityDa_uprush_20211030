using UnityEngine;

public class EnimiesIndigenous : MonoBehaviour
{
    [Header("�����T")]
    public int lives = 20;
    public int attack = 1;
    public float moveRange = 10;

    #region ���
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("���ʳt��")]
    public float speed = 1.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    #endregion

}
