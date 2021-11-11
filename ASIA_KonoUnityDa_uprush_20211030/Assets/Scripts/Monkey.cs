using UnityEngine;

public class Monkey : MonoBehaviour
{
    // Start is called before the first frame update

    public int lives = 3;
    public float height = 0;
    public bool dead = false;
    public bool unlock = true;
    public float moveSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 monkeyMove = transform.position;
        monkeyMove.x = monkeyMove.x + Input.GetAxis("Horizontal") * moveSpeed;
        monkeyMove.y = monkeyMove.y + Input.GetAxis("Vertical") * moveSpeed;
        transform.position = monkeyMove;
    }
}