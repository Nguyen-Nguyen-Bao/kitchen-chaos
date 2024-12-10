using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_Can_Destruction : MonoBehaviour, IDeSelect
{
    public bool selected;
    bool interacterable;
    public LayerMask layerMask;
    public GameManager gameManager;
    public GameObject arrow;
    public Transform interact_point;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Spining2();
        Function();
    }
    void Function()
    {
        if (interact_point != null)
        {
            if (Physics.CheckBox(interact_point.position, new Vector3(0.25f, 0.25f, 0.25f), Quaternion.identity, layerMask))
            {
                interacterable = true;
            }
            else { interacterable = false; }
            if (interacterable && Input.GetKeyDown(KeyCode.Alpha1))
            {
                Destroy(gameManager.holdingStuff);
                gameManager.holdingStuff = null;
                gameManager.holding = GameManager.Holding.None;
            }
        }
    }
    void Spining2()
    {
        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.eulerAngles = new Vector3(0, 270, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.eulerAngles = Vector3.zero;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
    public void Spining()
    {
        if (selected)
        {
            selected = false;
            arrow.SetActive(false);
        }
        else if (!selected)
        {
            selected = true;
            arrow.SetActive(true);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void DeSelecting()
    {
        selected = false;
        arrow.SetActive(false);
    }
}
