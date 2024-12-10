using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using UnityEngine.XR;
using UnityEngine.Events;

public class Deliver_Destruction : MonoBehaviour, IDeSelect
{
    public bool selected;
    bool interacterable;
    public LayerMask layerMask;
    public GameManager gameManager;
    public UnityEvent equal_Order1;
    public UnityEvent equal_Order2;
    public UnityEvent equal_Order3;
    public UnityEvent equal_Order4;
    public GameObject arrow;
    public Transform interact_point;
    public GameObject deliver_success;
    public Transform deliver_success_spawnpoint;
    public Camera camera;
    public GameObject orders;
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
    IEnumerator Deliver_Success()
    {
        GameObject no = Instantiate(deliver_success, camera.WorldToScreenPoint(deliver_success_spawnpoint.position), Quaternion.Euler(new Vector3(0, 0, 15)));
        no.transform.SetParent(orders.transform, true);
        yield return new WaitForSeconds(0.35f);
        Destroy(no);
    }
    void Function()
    {
        if (Physics.CheckBox(interact_point.position, new Vector3(0.25f, 0.25f, 0.25f), Quaternion.identity, layerMask))
        {
            interacterable = true;
        }
        else { interacterable = false; }

        if (interacterable && Input.GetKeyDown(KeyCode.Alpha1) && gameManager.holding == GameManager.Holding.Dish)
        {
            Dish deliver = gameManager.holdingStuff.GetComponent<Dish>();
            Dish order1 = gameManager.order1;
            Dish order2 = gameManager.order2;
            Dish order3 = gameManager.order3;
            Dish order4 = gameManager.order4;
            bool equal_order1 = deliver.have_bread == order1.have_bread && deliver.have_cutted_cabbage == order1.have_cutted_cabbage
                && deliver.have_cutted_cheese == order1.have_cutted_cheese && deliver.have_cutted_tomato == order1.have_cutted_tomato
                && deliver.have_fried_meat == order1.have_fried_meat;
            bool equal_order2 = deliver.have_bread == order2.have_bread && deliver.have_cutted_cabbage == order2.have_cutted_cabbage
                && deliver.have_cutted_cheese == order2.have_cutted_cheese && deliver.have_cutted_tomato == order2.have_cutted_tomato
                && deliver.have_fried_meat == order2.have_fried_meat;
            bool equal_order3 = deliver.have_bread == order3.have_bread && deliver.have_cutted_cabbage == order3.have_cutted_cabbage
                && deliver.have_cutted_cheese == order3.have_cutted_cheese && deliver.have_cutted_tomato == order3.have_cutted_tomato
                && deliver.have_fried_meat == order3.have_fried_meat;
            bool equal_order4 = deliver.have_bread == order4.have_bread && deliver.have_cutted_cabbage == order4.have_cutted_cabbage
                && deliver.have_cutted_cheese == order4.have_cutted_cheese && deliver.have_cutted_tomato == order4.have_cutted_tomato
                && deliver.have_fried_meat == order4.have_fried_meat;
            if (equal_order1)
            {
                equal_Order1.Invoke();
                Destroy(gameManager.holdingStuff);
                gameManager.holdingStuff = null;
                gameManager.holding = GameManager.Holding.None;
                StartCoroutine(Deliver_Success());
            }
            else if (equal_order2)
            {
                equal_Order2.Invoke();
                Destroy(gameManager.holdingStuff);
                gameManager.holdingStuff = null;
                gameManager.holding = GameManager.Holding.None;
                StartCoroutine(Deliver_Success());
            }
            else if (equal_order3)
            {
                equal_Order3.Invoke();
                Destroy(gameManager.holdingStuff);
                gameManager.holdingStuff = null;
                gameManager.holding = GameManager.Holding.None;
                StartCoroutine(Deliver_Success());
            }
            else if (equal_order4)
            {
                equal_Order4.Invoke();
                Destroy(gameManager.holdingStuff);
                gameManager.holdingStuff = null;
                gameManager.holding = GameManager.Holding.None;
                StartCoroutine(Deliver_Success());
            }
        }
    }
    void Spining2()
    {
        if (interact_point != null)
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
