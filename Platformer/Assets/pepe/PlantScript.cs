using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    // LineRenderer lineRender;
    public GameObject PlantHead;
    public Sprite[] arrows;
    public GameObject arrowsRender;
    public GameObject PlantCollider;
    private GameObject headI;
    public GameObject VerticalBranch;
    public GameObject HorizontalBranch;
    int lineLen = 2;
    float speed = 3f;
    public float destroyTime = 10f;
    bool canUp, canDown, canRight, canLeft;
    void Start()
    {

        //Destroy(gameObject, 5);
        //  lineRender = GetComponentInChildren<LineRenderer>();
        actual = transform.position;
        nextStop = actual + new Vector3(0, lineLen, 0);
        isMoving = true;
        // lineRender.SetPosition(0, transform.position);
        // lineRender.positionCount = aPoint +1;
        print("here");
        headI = Instantiate(PlantHead, gameObject.transform.position, Quaternion.Euler(0, 0, 0), gameObject.transform);
        //gameObject.SetActive(false);

        canUp = true;
        canDown = false;
        canRight = true;
        canLeft = true;
        //lineRender.SetWidth(.15f, .15f);

        //DrawLine(transform.position, transform.position + new Vector3(2, 2,0), Color.red, 0.2f);
    }
    bool isMoving = false;
    float step;
    private Vector3 nextStop;
    private Vector3 actual;
    private int aPoint = 1;
    bool isDone = false;
    public void init()
    {
        actual = gameObject.transform.position;
    }
    void AllTrue()
    {
        canUp = true;
        canDown = true;
        canRight = true;
        canLeft = true;
    }
    void Update()
    {
        if (!isDone)
        {
            if (!isMoving)
            {

                if (Input.GetKeyDown("up") && canUp)
                {
                    AllTrue();
                    canDown = false;
                    actual = nextStop;
                    nextStop = actual + new Vector3(0, lineLen, 0);
                    isMoving = true;
                    arrowsRender.SetActive(false);
                    headI.transform.rotation = Quaternion.Euler(0, 0, 0);
                    //if (lineRender.positionCount < (aPoint + 1))
                    //{
                    //    lineRender.positionCount++;
                    //}
                    // lineRender.positionCount++;
                    print("up key pressed");
                }
                else
                    if (Input.GetKeyDown("left") && canLeft)
                {
                    AllTrue();
                    canRight = false;
                    actual = nextStop;
                    nextStop = actual + new Vector3(-lineLen, 0, 0);
                    isMoving = true;
                    arrowsRender.SetActive(false);
                    headI.transform.rotation = Quaternion.Euler(0, 0, 90);

                    //if (lineRender.positionCount < (aPoint + 1))
                    //{
                    //    lineRender.positionCount++;
                    //}
                    print("left key pressed");
                }
                else
                    if (Input.GetKeyDown("right") && canRight)
                {
                    AllTrue();
                    canLeft = false;
                    actual = nextStop;
                    nextStop = actual + new Vector3(lineLen, 0, 0);
                    isMoving = true;
                    arrowsRender.SetActive(false);
                    headI.transform.rotation = Quaternion.Euler(0, 0, -90);
                    //if (lineRender.positionCount < (aPoint + 1))
                    //{
                    //    lineRender.positionCount++;
                    //}
                    print("right key pressed");
                }
                else
                    if (Input.GetKeyDown("down") && canDown)
                {
                    AllTrue();
                    canUp = false;
                    actual = nextStop;
                    nextStop = actual + new Vector3(0, -lineLen, 0);
                    isMoving = true;
                    arrowsRender.SetActive(false);
                    headI.transform.rotation = Quaternion.Euler(0, 0, 180);
                    //if (lineRender.positionCount < (aPoint + 1))
                    //{
                    //    lineRender.positionCount++;
                    //}
                    print("down key pressed");
                }
                else if (Input.GetKeyDown("h"))
                {
                    //stop
                    isDone = true;
                    LevelController.instance.isPlant = false;

                    Destroy(gameObject, 13);

                    print("p key pressed");
                }

            }
            else
            {

                step = speed * Time.deltaTime;
                headI.transform.position = Vector3.MoveTowards(headI.transform.position, nextStop, step);
                //  lineRender.SetPosition(aPoint, headI.transform.position);

                // Debug.Log(aPoint);
                if (Vector3.Distance(headI.transform.position, nextStop) < 0.001 && isMoving)
                {
                    //  Debug.Log("reach");
                   // arrowsRender.SetActive(true);
                   // arrowsRender.GetComponentInChildren<SpriteRenderer>().sprite = arrows[0];
                  //  arrowsRender.transform.position = nextStop + new Vector3(0, 1, +5);
                    isMoving = false;
                    aPoint++;

                    // new collider collider
                    if (!canLeft)
                    {
                        Instantiate(HorizontalBranch, actual + new Vector3(lineLen / 2, 0, 0), Quaternion.Euler(0, 0, -90), gameObject.transform);

                    }
                    else if (!canRight)
                    {
                        Instantiate(HorizontalBranch, actual + new Vector3(-lineLen / 2, 0, 0), Quaternion.Euler(0, 0, -90), gameObject.transform);
                    }
                    else if (!canDown)
                    {
                        Instantiate(VerticalBranch, actual + new Vector3(0, lineLen / 2,0), Quaternion.Euler(0, 0, 0), gameObject.transform);
                    }else
                    {
                        Instantiate(VerticalBranch, actual + new Vector3(0, -lineLen / 2, 0), Quaternion.Euler(0, 0, 0), gameObject.transform);
                    }

                }
            }
        }
    }





    private void FixedUpdate()
    {

    }
    public void DrawLine2d()
    {

    }


    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}

internal class LineRendered
{
}