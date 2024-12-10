using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class Cutter_Destruction : MonoBehaviour, IDeSelect
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public bool selected;
    Cutter_Destruction c1;
    Cutter_Destruction c2;
    Cutter_Destruction c3;
    bool interacterable;
    public LayerMask layerMask;
    Animator animator;
    public GameManager gameManager;
    enum State
    {
        haved, empty
    }
    State state;
    GameObject stuffOntable;
    GameManager.Holding holding;
    public Transform hand;
    public GameObject cutted_cheese;
    public GameObject cutted_tomato;
    public GameObject cutted_cabbage;
    public GameObject arrow;
    public Transform interact_point;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        c1 = o1.GetComponent<Cutter_Destruction>();
        c2 = o2.GetComponent<Cutter_Destruction>();
        c3 = o3.GetComponent<Cutter_Destruction>();
        animator = o1.GetComponent<Animator>();
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
            Vector3 onTable = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            if (Physics.CheckBox(interact_point.position, new Vector3(0.25f, 0.25f, 0.25f), Quaternion.identity, layerMask))
            {
                interacterable = true;
            }
            else { interacterable = false; }
            if (interacterable && state == State.empty && Input.GetKeyDown(KeyCode.Alpha1))
            {
                gameManager.holdingStuff.transform.position = onTable;
                gameManager.holdingStuff.transform.SetParent(transform, true);
                stuffOntable = gameManager.holdingStuff;
                holding = gameManager.holding;
                gameManager.holding = GameManager.Holding.None;
                gameManager.holdingStuff = null;
                state = State.haved;
            }
            else if (interacterable && holding == GameManager.Holding.Cheese && Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetBool("Cut", true);
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("Cut", false);
                Destroy(stuffOntable);
                stuffOntable = Instantiate(cutted_cheese, onTable, Quaternion.identity);
                holding = GameManager.Holding.Cutted_Cheese;
            }
            else if (interacterable && holding == GameManager.Holding.Tomato && Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetBool("Cut", true);
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("Cut", false);
                Destroy(stuffOntable);
                stuffOntable = Instantiate(cutted_tomato, onTable, Quaternion.identity);
                holding = GameManager.Holding.Cutted_Tomato;
            }
            else if (interacterable && holding == GameManager.Holding.Cabbage && Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetBool("Cut", true);
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("Cut", false);
                Destroy(stuffOntable);
                stuffOntable = Instantiate(cutted_cabbage, onTable, Quaternion.identity);
                holding = GameManager.Holding.Cutted_Cabbage;
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
                stuffOntable.transform.SetParent(hand, true);
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
