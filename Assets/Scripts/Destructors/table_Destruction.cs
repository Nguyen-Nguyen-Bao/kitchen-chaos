using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class table_Destruction : MonoBehaviour, IDeSelect
{
    public bool selected;
    bool interacterable;
    public LayerMask layerMask;
    public GameManager gameManager;
    enum State 
    { 
    haved, empty
    }
    State state;
    GameObject stuffOntable;
    GameManager.Holding holding;
    public Transform hand;
    public GameObject arrow;
    public Transform interact_point;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        state = State.empty;
        holding = GameManager.Holding.None;
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
            if (interacterable && state == State.empty && Input.GetKeyDown(KeyCode.Alpha1))
            {
                Vector3 onTable = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                gameManager.holdingStuff.transform.position = onTable;
                gameManager.holdingStuff.transform.SetParent(transform, true);
                stuffOntable = gameManager.holdingStuff;
                holding = gameManager.holding;
                gameManager.holding = GameManager.Holding.None;
                gameManager.holdingStuff = null;
                state = State.haved;
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
    public void DeSelecting()
    {
        selected = false;
        arrow.SetActive(false);
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
}
