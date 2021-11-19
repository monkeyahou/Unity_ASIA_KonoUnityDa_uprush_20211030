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
    

    private void Start()
    {
        mrig = GetComponent<Rigidbody2D>();
        
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