using UnityEngine;

public class Monkey : MonoBehaviour
{
    // Start is called before the first frame update

    public int lives = 3;
    public float height = 0;
    public bool dead = false;
    public bool unlock = true;

    public float moveSpeed;

    public Rigidbody2D mrig;
    public Animator mAnim;
    public bool mjump;

    private void Start()
    {
        mrig = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow))
        {
            mjump = true;
        }
        else 
        {
            mjump = false;
        }

        if(mjump == true)
        {
            mAnim.SetBool("走路開關", true);
        }
        else
        {
            mAnim.SetBool("走路開關", false);
        }
    }
    private void FixedUpdate()
    {
        Vector2 monkeyPosition = transform.position;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        monkeyPosition.x += moveSpeed * moveX * Time.deltaTime;
        monkeyPosition.y += moveSpeed * moveY * Time.deltaTime;

        
        


        mrig.MovePosition(monkeyPosition);
    }
}