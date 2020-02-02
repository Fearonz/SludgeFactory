using UnityEngine;

public class Button : MonoBehaviour
{
    public string doorName;
    private bool closed;

    public Sprite closedSprite;

    void Start()
    {
        closed = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collider");
        if (collider.gameObject.transform.parent.CompareTag("Player"))
        {
            if (closed)
            {
                GameObject door = GameObject.Find(doorName);
                if (door)
                {
                    Destroy(door);
                }
                closed = false;
            }
        }
        else
        {
            // Do nothing
        }
    }

}
