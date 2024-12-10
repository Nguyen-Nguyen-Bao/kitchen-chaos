using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tomato_Store_Destruction : MonoBehaviour, IDeSelect
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public GameObject o4;
    public bool selected;
    Tomato_Store_Destruction c1;
    Tomato_Store_Destruction c2;
    Tomato_Store_Destruction c3;
    Tomato_Store_Destruction c4;
    bool interacterable;
    public UnityEvent give_tomato;
    public LayerMask layerMask;
    public GameObject arrow;
    public Transform interact_point;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        c1 = o1.GetComponent<Tomato_Store_Destruction>();
        c2 = o2.GetComponent<Tomato_Store_Destruction>();
        c3 = o3.GetComponent<Tomato_Store_Destruction>();
        c4 = o4.GetComponent<Tomato_Store_Destruction>();
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
                give_tomato.Invoke();
            }
        }
    }
    void Spining2()
    {
        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                o1.transform.eulerAngles = new Vector3(0, 270, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                o1.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                o1.transform.eulerAngles = Vector3.zero;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                o1.transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
    public void DeSelecting()
    {
        selected = false;
        arrow.SetActive(false);
    }
    public void Spining()
    {
        if (selected)
        {
            c1.selected = false;
            c2.selected = false;
            c3.selected = false;
            c4.selected = false;
            arrow.SetActive(false);
        }
        else if (!selected && c1 != null)
        {
            c1.selected = true;
            c2.selected = true;
            c3.selected = true;
            c4.selected = true;
            arrow.SetActive(true);
        }
    }
    public void Destroy()
    {
        Destroy(o1);
    }
}
