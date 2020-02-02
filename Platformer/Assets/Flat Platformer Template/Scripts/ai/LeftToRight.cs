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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("art");
        }
        else if (col.gameObject.CompareTag("Block"))
        {
            changeDirection = true;
        }
        else if (col.gameObject.CompareTag("Plant"))
        {
            stop = true;
        }
        else
        {
            // Do nothing
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Plant"))
        {
            stop = false;
        }
    }

}
