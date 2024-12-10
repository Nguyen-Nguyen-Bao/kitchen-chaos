using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
public class Player_Controller : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    float movement_up;
    float movement_down;
    float movement_left;
    float movement_right;
    public float movement_speed;
    Vector3 movement;
    Vector3 facing_direction;
    float rotate_angle;
    float facing_angle;
    enum Rotate {left, right};
    public Transform hand;
    public GameObject cheese;
    public GameObject tomato;
    public GameObject meat;
    public GameObject cabbage;
    public GameObject dish;
    public GameObject bread;
    public GameManager gameManager;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInChildren<Rigidbody>();
        facing_direction = new Vector3 (0, 0, 1);
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Controll();
        Player_Rotate();
    }
    public void Give_Bread()
    {
        if (gameManager.holding != GameManager.Holding.None) return;
        GameObject thing = Instantiate(bread, hand.transform.position, Quaternion.Euler(new Vector3(0, 90 + facing_angle, 0)));
        thing.transform.SetParent(this.hand);
        gameManager.holdingStuff = thing;
        gameManager.holding = GameManager.Holding.Bread;
    }
    public void Give_Dish()
    {
        if (gameManager.holding != GameManager.Holding.None) return;
        GameObject thing = Instantiate(dish, hand.transform.position, Quaternion.Euler(new Vector3(0, 90 + facing_angle, 0)));
        thing.transform.SetParent(this.hand);
        gameManager.holdingStuff = thing;
        gameManager.holding = GameManager.Holding.Dish;
    }
    public void Give_Cabbage()
    {
        if (gameManager.holding != GameManager.Holding.None) return;
        GameObject thing = Instantiate(cabbage, hand.transform.position, Quaternion.Euler(new Vector3(0, 90 + facing_angle, 0)));
        thing.transform.SetParent(this.hand);
        gameManager.holdingStuff = thing;
        gameManager.holding = GameManager.Holding.Cabbage;
    }
    public void Give_Meat()
    {
        if (gameManager.holding != GameManager.Holding.None) return;
        GameObject thing = Instantiate(meat, hand.transform.position, Quaternion.Euler(new Vector3(0, 90 + facing_angle, 0)));
        thing.transform.SetParent(this.hand);
        gameManager.holdingStuff = thing;
        gameManager.holding = GameManager.Holding.Meat;
    }
    public void Give_Tomato()
    {
        if (gameManager.holding != GameManager.Holding.None) return;
        GameObject thing = Instantiate(tomato, hand.transform.position, Quaternion.Euler(new Vector3(0, 90 + facing_angle, 0)));
        thing.transform.SetParent(this.hand);
        gameManager.holdingStuff = thing;
        gameManager.holding = GameManager.Holding.Tomato;
    }
    public void Give_Cheese()
    {
        if (gameManager.holding != GameManager.Holding.None) return;
        GameObject thing = Instantiate(cheese, hand.transform.position, Quaternion.Euler(new Vector3(0, 90 + facing_angle, 0)));
        thing.transform.SetParent(this.hand);
        gameManager.holdingStuff = thing;
        gameManager.holding = GameManager.Holding.Cheese;
    }
    void Player_Rotate()
    {
        Debug.DrawRay(transform.position, rb.velocity * 10, Color.yellow);
        Debug.DrawRay(transform.position, facing_direction * 10, Color.green);
        rotate_angle = Vector3.Angle(facing_direction, rb.velocity);
        Rotate rotate;
        Vector3 try_rotate_vector = Quaternion.AngleAxis(rotate_angle, new Vector3(0, 1, 0)) * facing_direction;
        if (Vector3.Angle(try_rotate_vector, rb.velocity) == 0) rotate = Rotate.right;
        else rotate = Rotate.left;
        if (rb.velocity != Vector3.zero && rotate == Rotate.left)
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - (rotate_angle < 6 ? rotate_angle : 6), 0);
                facing_angle -= rotate_angle < 6 ? rotate_angle : 6;
            } 
        else if (rb.velocity != Vector3.zero && rotate == Rotate.right)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (rotate_angle < 6 ? rotate_angle : 6), 0);
            facing_angle += rotate_angle < 6 ? rotate_angle : 6;
        }
        facing_direction = Quaternion.AngleAxis(facing_angle, new Vector3(0, 1, 0)) * new Vector3(0, 0, 1);
    }
    void Player_Controll()
    {
        if (!gameManager.pause)
        {
            // Control
            if (Input.GetKey(KeyCode.Alpha2))
            {
                if (movement_up < 1) movement_up = movement_up + 4 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (movement_down < 1) movement_down = movement_down + 4 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                if (movement_left < 1) movement_left = movement_left + 4 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                if (movement_right < 1) movement_right = movement_right + 4 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
            {
                animator.SetBool("IsWalking", true);
            }
            else animator.SetBool("IsWalking", false);
            // Minus
            if (movement_up - 2 * Time.deltaTime > 0)
            {
                movement_up = movement_up - 2 * Time.deltaTime;
            }
            else
            {
                movement_up = movement_up = 0;
            }
            if (movement_down - 2 * Time.deltaTime > 0)
            {
                movement_down = movement_down - 2 * Time.deltaTime;
            }
            else
            {
                movement_down = movement_down = 0;
            }
            if (movement_left - 2 * Time.deltaTime > 0)
            {
                movement_left = movement_left - 2 * Time.deltaTime;
            }
            else
            {
                movement_left = movement_left = 0;
            }
            if (movement_right - 2 * Time.deltaTime > 0)
            {
                movement_right = movement_right - 2 * Time.deltaTime;
            }
            else
            {
                movement_right = movement_right = 0;
            }
            movement = new Vector3((movement_right - movement_left) * movement_speed, 0, (movement_up - movement_down) * movement_speed);
            rb.velocity = movement;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
