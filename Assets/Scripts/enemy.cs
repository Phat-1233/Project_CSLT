using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Speed of the enemy
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; // Store the initial position of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance; // Calculate the left boundary
        float rightBound = startPos.x + distance; // Calculate the right boundary
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); // Move the enemy to the right
            if (transform.position.x >= rightBound)
            {
                movingRight = false; // Change direction to left
                Flip(); // Flip the enemy's sprite to face the new direction
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // Move the enemy to the left
            if (transform.position.x <= leftBound)
            {
                movingRight = true; // Change direction to right
                Flip(); // Flip the enemy's sprite to face the new direction
            }
        }
    }
    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Flip the x-axis to change the direction the enemy is facing
        transform.localScale = scaler;
    } 
}
