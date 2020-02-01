using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftToRight : MonoBehaviour
{
    public float begin;
    public float distance = 5;
    public float speed = 5;
    public int direction;

    private bool changeDirection = false;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        begin = transform.position.x;
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            return;
        }

        if (changeDirection)
        {
            changeDirection = false;
            direction = -direction;
        }
        else if (transform.position.x > begin + distance)
        {
            direction = -1;
        }
        else
        {
            if (transform.position.x < begin - distance)
            {
                direction = 1;
            }
        }

        transform.position = new Vector3(
            transform.position.x + Time.deltaTime * speed * direction,
            transform.position.y,
            transform.position.z
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("josh");
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            changeDirection = true;
        }
        else if (collision.gameObject.CompareTag("Plant"))
        {
            stop = true;
        }
        else
        {
            // Do nothing
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            stop = false;
        }
    }

}
