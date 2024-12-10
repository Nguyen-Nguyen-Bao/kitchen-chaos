using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static GameManager;
using UnityEngine.XR;

public class Cooker_Destruction : MonoBehaviour, IDeSelect
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public bool selected;
    Cooker_Destruction c1;
    Cooker_Destruction c2;
    Cooker_Destruction c3;
    bool interacterable;
    public LayerMask layerMask;
    public GameObject cook;
    public GameObject particals;
    public GameManager gameManager;
    enum State
    {
        haved, empty
    }
    State state;
    GameObject stuffOntable;
    GameManager.Holding holding;
    public GameObject hand;
    public GameObject fried_meat;
    public GameObject arrow;
    public Transform interact_point;
    public Transform on_pan;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        c1 = o1.GetComponent<Cooker_Destruction>();
        c2 = o2.GetComponent<Cooker_Destruction>();
        c3 = o3.GetComponent<Cooker_Destruction>();
        state = State.empty;
        holding = GameManager.Holding.None;
    }

    // Update is called once per frame
    void Update()
    {
        Spining2();
        StartCoroutine(Function());
    }
    IEnumerator Function()
    {
        if (interact_point != null)
        {
            if (Physics.CheckBox(interact_point.position, new Vector3(0.25f, 0.25f, 0.25f), Quaternion.identity, layerMask))
            {
                interacterable = true;
            }
            else { interacterable = false; }
            if (interacterable && state == State.empty && gameManager.holding == Holding.Meat && Input.GetKeyDown(KeyCode.Alpha1))
            {
                gameManager.holdingStuff.transform.position = on_pan.position;
                gameManager.holdingStuff.transform.SetParent(transform, true);
                stuffOntable = gameManager.holdingStuff;
                holding = gameManager.holding;
                gameManager.holding = GameManager.Holding.None;
                gameManager.holdingStuff = null;
                state = State.haved;
            }
            else if (interacterable && holding == GameManager.Holding.Meat && Input.GetKeyDown(KeyCode.Alpha1))
            {
                cook.SetActive(true);
                particals.SetActive(true);
                yield return new WaitForSeconds(2f);
                cook.SetActive(false);
                particals.SetActive(false);
                Destroy(stuffOntable);
                stuffOntable = Instantiate(fried_meat, on_pan.position, Quaternion.identity);
                holding = GameManager.Holding.Fried_Meat;
            }
            else if (interacterable && state == State.haved && gameManager.holding == GameManager.Holding.Dish && Input.GetKeyDown(KeyCode.Alpha1))
            {
                Dish the_holding_dish = gameManager.holdingStuff.GetComponent<Dish>();
                if (holding == GameManager.Holding.Cutted_Cheese && !the_holding_dish.have_cutted_cheese)
                {
                    Vector3 ondish = new Vector3(gameManager.holdingStuff.transform.position.x, gameManager.holdingStuff.transform.position.y + 0.355f, gameManager.holdingStuff.transform.position.z);
                    stuffOntable.transform.position = ondish;
                    the_holding_dish.have_cutted_cheese = true;
                }
                else if (holding == GameManager.Holding.Cutted_Tomato && !the_holding_dish.have_cutted_tomato)
                {
                    Vector3 ondish = new Vector3(gameManager.holdingStuff.transform.position.x, gameManager.holdingStuff.transform.position.y + 0.355f, gameManager.holdingStuff.transform.position.z);
                    stuffOntable.transform.position = ondish;
                    the_holding_dish.have_cutted_tomato = true;
                }
                else if (holding == GameManager.Holding.Cutted_Cabbage && !the_holding_dish.have_cutted_cabbage)
                {
                    Vector3 ondish = new Vector3(gameManager.holdingStuff.transform.position.x, gameManager.holdingStuff.transform.position.y + 0.355f, gameManager.holdingStuff.transform.position.z);
                    stuffOntable.transform.position = ondish;
                    the_holding_dish.have_cutted_cabbage = true;
                }
                else if (holding == GameManager.Holding.Fried_Meat && !the_holding_dish.have_fried_meat)
                {
                    Vector3 ondish = new Vector3(gameManager.holdingStuff.transform.position.x, gameManager.holdingStuff.transform.position.y + 0.254f, gameManager.holdingStuff.transform.position.z);
                    stuffOntable.transform.position = ondish;
                    the_holding_dish.have_fried_meat = true;
                }
                else if (holding == GameManager.Holding.Bread && !the_holding_dish.have_bread)
                {
                    Vector3 ondish = new Vector3(gameManager.holdingStuff.transform.position.x, gameManager.holdingStuff.transform.position.y + 0.122f, gameManager.holdingStuff.transform.position.z);
                    stuffOntable.transform.position = ondish;
                    the_holding_dish.have_bread = true;
                }
                stuffOntable.transform.SetParent(gameManager.holdingStuff.transform, true);
                stuffOntable = null;
                holding = GameManager.Holding.None;
                state = State.empty;
            }
            else if (interacterable && state == State.haved && gameManager.holding == GameManager.Holding.None && Input.GetKeyDown(KeyCode.Alpha1))
            {
                stuffOntable.transform.position = hand.transform.position;
                stuffOntable.transform.SetParent(hand.transform, true);
                gameManager.holdingStuff = stuffOntable;
                stuffOntable = null;
                gameManager.holding = holding;
                holding = GameManager.Holding.None;
                stuffOntable = null;
                state = State.empty;
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
            arrow.SetActive(false);
        }
        else if (!selected && c1 != null)
        {
            c1.selected = true;
            c2.selected = true;
            c3.selected = true;
            arrow.SetActive(true);
        }
    }
    public void Destroy()
    {
        Destroy(o1);
    }
}
