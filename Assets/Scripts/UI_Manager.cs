using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameManager gameManager;
    public Animator cabinet_anim;
    public Animator chesse_anim;
    public Animator tomato_store_anim;
    public Animator cabbage_store_anim;
    public Animator meat_store_anim;
    public Animator cutter_anim;
    public Animator deliver_anim;
    public Animator dishes_anim;
    public Animator cooker_anim;
    public Animator trash_can_anim;
    public Animator table_anim;
    public Animator bread_store_anim;
    public GameObject editing;
    public GameObject orders;
    public Sprite bread;
    public Sprite cutted_cheese;
    public Sprite cutted_tomato;
    public Sprite fried_meat;
    public Sprite cutted_cabbage;
    public Image big_Image;
    public Image slot;
    Vector2 position_order1 = new Vector2(-600, 252);
    Vector2 position_order2 = new Vector2(-600, 252 - 181);
    Vector2 position_order3 = new Vector2(-600, 252 - 181*2);
    Vector2 position_order4 = new Vector2(-600, 252 - 181*3);
    GameObject order1;
    GameObject order2;
    GameObject order3;
    GameObject order4;
    public Transform buttom_group;
    Vector2 fixed_position;
    public GameObject cinemachine1;
    public GameObject cinemachine2;
    // Stuff Number is In DrawRay
    void Start()
    {
        position_order1 = new Vector2(orders.transform.position.x - 600, orders.transform.position.y + 252);
        position_order2 = new Vector2(orders.transform.position.x - 600, orders.transform.position.y + 252 - 181);
        position_order3 = new Vector2(orders.transform.position.x - 600, orders.transform.position.y + 252 - 181 * 2);
        position_order4 = new Vector2(orders.transform.position.x - 600, orders.transform.position.y + 252 - 181 * 3);
        Instantia_Order1();
        Instantia_Order2();
        Instantia_Order3();
        Instantia_Order4();
        fixed_position = buttom_group.position;
    }
    public void Slider( float change)
    {
        buttom_group.position = fixed_position + new Vector2 (- change, 0); 
    }
    public void Done()
    {
        //if ( gameManager.planes == 0 && gameManager.chesse_stores == 0 && gameManager.tomato_stores == 0
        //    && gameManager.cabbage_stores == 0 && gameManager.meat_stores == 0 && gameManager.cutters == 0
        //    && gameManager.delivers == 0 && gameManager.disheses == 0 && gameManager.cookers == 0
        //    && gameManager.trash_cans == 0)
        //{
        editing.SetActive(false);
        gameManager.pause = false;
        orders.SetActive(true);
        cinemachine1.SetActive(false);
        cinemachine2.SetActive(true);
        foreach (var o in gameManager.instantiated_Stuffs)
        {
            o.GetComponent<IDeSelect>().DeSelecting();
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //}
    }
    public void Instantia_Order1()
    {
        Destroy(order1);
        gameManager.order1.big_Image = big_Image;
        order1 = Instantiate(gameManager.order1.big_Image.gameObject);
        order1.transform.SetParent(orders.transform, true);
        order1.transform.position = position_order1;
        gameManager.order1.slot1 = slot; gameManager.order1.slot2 = slot; gameManager.order1.slot3 = slot; gameManager.order1.slot4 = slot; gameManager.order1.slot5 = slot;
        Image slot1 = Instantiate(gameManager.order1.slot1);
        slot1.transform.SetParent(order1.transform, true);
        slot1.transform.position = new Vector2(position_order1.x - 260, position_order1.y);
        Image slot2 = Instantiate(gameManager.order1.slot2);
        slot2.transform.SetParent(order1.transform, true);
        slot2.transform.position = new Vector2(position_order1.x - 260 + 106, position_order1.y);
        Image slot3 = Instantiate(gameManager.order1.slot3);
        slot3.transform.SetParent(order1.transform, true);
        slot3.transform.position = new Vector2(position_order1.x - 260 + 106 * 2, position_order1.y);
        Image slot4 = Instantiate(gameManager.order1.slot4);
        slot4.transform.SetParent(order1.transform, true);
        slot4.transform.position = new Vector2(position_order1.x - 260 + 106 * 3, position_order1.y);
        Image slot5 = Instantiate(gameManager.order1.slot5);
        slot5.transform.SetParent(order1.transform, true);
        slot5.transform.position = new Vector2(position_order1.x - 260 + 106 * 4, position_order1.y);
        Sprite[] sprites = new Sprite[5] { bread, fried_meat, cutted_cheese, cutted_cabbage, cutted_tomato };
        bool[] haves = new bool[5] { gameManager.order1.have_bread, gameManager.order1.have_fried_meat, gameManager.order1.have_cutted_cheese, gameManager.order1.have_cutted_cabbage, gameManager.order1.have_cutted_tomato };
        Image[] images = new Image[5] { slot1, slot2, slot3, slot4, slot5 };
        int i = 0;
        int j = 0;
        while (j < sprites.Length)
        {
            if (haves[j])
            {
                images[i].GetComponent<Image>().sprite = sprites[j];
                i++;
            }
            ++j;
        }
        while (i < sprites.Length)
        {
            Destroy(images[i]);
            i++;
        }
    }
    public void Instantia_Order2()
    {
        Destroy(order2);
        gameManager.order2.big_Image = big_Image;
        order2 = Instantiate(gameManager.order2.big_Image.gameObject);
        order2.transform.SetParent(orders.transform, true);
        order2.transform.position = position_order2;
        gameManager.order2.slot1 = slot; gameManager.order2.slot2 = slot; gameManager.order2.slot3 = slot; gameManager.order2.slot4 = slot; gameManager.order2.slot5 = slot;
        Image slot1 = Instantiate(gameManager.order2.slot1);
        slot1.transform.SetParent(order2.transform, true);
        slot1.transform.position = new Vector2(position_order2.x - 260, position_order2.y);
        Image slot2 = Instantiate(gameManager.order2.slot2);
        slot2.transform.SetParent(order2.transform, true);
        slot2.transform.position = new Vector2(position_order2.x - 260 + 106, position_order2.y);
        Image slot3 = Instantiate(gameManager.order2.slot3);
        slot3.transform.SetParent(order2.transform, true);
        slot3.transform.position = new Vector2(position_order2.x - 260 + 106 * 2, position_order2.y);
        Image slot4 = Instantiate(gameManager.order2.slot4);
        slot4.transform.SetParent(order2.transform, true);
        slot4.transform.position = new Vector2(position_order2.x - 260 + 106 * 3, position_order2.y);
        Image slot5 = Instantiate(gameManager.order2.slot5);
        slot5.transform.SetParent(order2.transform, true);
        slot5.transform.position = new Vector2(position_order2.x - 260 + 106 * 4, position_order2.y);
        Sprite[] sprites = new Sprite[5] { bread, fried_meat, cutted_cheese, cutted_cabbage, cutted_tomato };
        bool[] haves = new bool[5] { gameManager.order2.have_bread, gameManager.order2.have_fried_meat, gameManager.order2.have_cutted_cheese, gameManager.order2.have_cutted_cabbage, gameManager.order2.have_cutted_tomato };
        Image[] images = new Image[5] { slot1, slot2, slot3, slot4, slot5 };
        int i = 0;
        int j = 0;
        while (j < sprites.Length)
        {
            if (haves[j])
            {
                images[i].GetComponent<Image>().sprite = sprites[j];
                i++;
            }
            ++j;
        }
        while (i < sprites.Length)
        {
            Destroy(images[i]);
            i++;
        }
    }
    public void Instantia_Order3()
    {
        Destroy(order3);
        gameManager.order3.big_Image = big_Image;
        order3 = Instantiate(gameManager.order3.big_Image.gameObject);
        order3.transform.SetParent(orders.transform, true);
        order3.transform.position = position_order3;
        gameManager.order3.slot1 = slot; gameManager.order3.slot2 = slot; gameManager.order3.slot3 = slot; gameManager.order3.slot4 = slot; gameManager.order3.slot5 = slot;
        Image slot1 = Instantiate(gameManager.order3.slot1);
        slot1.transform.SetParent(order3.transform, true);
        slot1.transform.position = new Vector2(position_order3.x - 260, position_order3.y);
        Image slot2 = Instantiate(gameManager.order3.slot2);
        slot2.transform.SetParent(order3.transform, true);
        slot2.transform.position = new Vector2(position_order3.x - 260 + 106, position_order3.y);
        Image slot3 = Instantiate(gameManager.order3.slot3);
        slot3.transform.SetParent(order3.transform, true);
        slot3.transform.position = new Vector2(position_order3.x - 260 + 106 * 2, position_order3.y);
        Image slot4 = Instantiate(gameManager.order3.slot4);
        slot4.transform.SetParent(order3.transform, true);
        slot4.transform.position = new Vector2(position_order3.x - 260 + 106 * 3, position_order3.y);
        Image slot5 = Instantiate(gameManager.order3.slot5);
        slot5.transform.SetParent(order3.transform, true);
        slot5.transform.position = new Vector2(position_order3.x - 260 + 106 * 4, position_order3.y);
        Sprite[] sprites = new Sprite[5] { bread, fried_meat, cutted_cheese, cutted_cabbage, cutted_tomato };
        bool[] haves = new bool[5] { gameManager.order3.have_bread, gameManager.order3.have_fried_meat, gameManager.order3.have_cutted_cheese, gameManager.order3.have_cutted_cabbage, gameManager.order3.have_cutted_tomato };
        Image[] images = new Image[5] { slot1, slot2, slot3, slot4, slot5 };
        int i = 0;
        int j = 0;
        while (j < sprites.Length)
        {
            if (haves[j])
            {
                images[i].GetComponent<Image>().sprite = sprites[j];
                i++;
            }
            ++j;
        }
        while (i < sprites.Length)
        {
            Destroy(images[i]);
            i++;
        }
    }
    public void Instantia_Order4()
    {
        Destroy(order4);
        gameManager.order4.big_Image = big_Image;
        order4 = Instantiate(gameManager.order4.big_Image.gameObject);
        order4.transform.SetParent(orders.transform, true);
        order4.transform.position = position_order4;
        gameManager.order4.slot1 = slot; gameManager.order4.slot2 = slot; gameManager.order4.slot3 = slot; gameManager.order4.slot4 = slot; gameManager.order4.slot5 = slot;
        Image slot1 = Instantiate(gameManager.order4.slot1);
        slot1.transform.SetParent(order4.transform, true);
        slot1.transform.position = new Vector2(position_order4.x - 260, position_order4.y);
        Image slot2 = Instantiate(gameManager.order4.slot2);
        slot2.transform.SetParent(order4.transform, true);
        slot2.transform.position = new Vector2(position_order4.x - 260 + 106, position_order4.y);
        Image slot3 = Instantiate(gameManager.order4.slot3);
        slot3.transform.SetParent(order4.transform, true);
        slot3.transform.position = new Vector2(position_order4.x - 260 + 106 * 2, position_order4.y);
        Image slot4 = Instantiate(gameManager.order4.slot4);
        slot4.transform.SetParent(order4.transform, true);
        slot4.transform.position = new Vector2(position_order4.x - 260 + 106 * 3, position_order4.y);
        Image slot5 = Instantiate(gameManager.order4.slot5);
        slot5.transform.SetParent(order4.transform, true);
        slot5.transform.position = new Vector2(position_order4.x - 260 + 106 * 4, position_order4.y);
        Sprite[] sprites = new Sprite[5] { bread, fried_meat, cutted_cheese, cutted_cabbage, cutted_tomato };
        bool[] haves = new bool[5] { gameManager.order4.have_bread, gameManager.order4.have_fried_meat, gameManager.order4.have_cutted_cheese, gameManager.order4.have_cutted_cabbage, gameManager.order4.have_cutted_tomato };
        Image[] images = new Image[5] { slot1, slot2, slot3, slot4, slot5 };
        int i = 0;
        int j = 0;
        while (j < sprites.Length)
        {
            if (haves[j])
            {
                images[i].GetComponent<Image>().sprite = sprites[j];
                i++;
            }
            ++j;
        }
        while (i < sprites.Length)
        {
            Destroy(images[i]);
            i++;
        }
    }
    public void Cabinet_activated()
    {
        if (!gameManager.cabinet_activated)
        {
            gameManager.cabinet_activated = true;
            cabinet_anim.SetBool("cabinet_activated", true);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
        }
    }
    public void Chesse_activated()
    {
        if (!gameManager.chesse_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = true;
            chesse_anim.SetBool("chesse_activated", true);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
        }
    }
    public void Tomato_store_activated()
    {
        if (!gameManager.tomato_store_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = true;
            tomato_store_anim.SetBool("tomato_store_activated", true);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
        }
    }
    public void Cabbage_store_activated()
    {
        if (!gameManager.cabbage_store_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = true;
            cabbage_store_anim.SetBool("cabbage_store_activated", true);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
        }
    }
    public void Meat_store_activated()
    {
        if (!gameManager.meat_store_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = true;
            meat_store_anim.SetBool("meat_store_activated", true);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
        }
    }
    public void Cutter_activated()
    {
        if (!gameManager.cutter_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = true;
            cutter_anim.SetBool("cutter_activated", true);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
        }
    }
    public void Deliver_activated()
    {
        if (!gameManager.deliver_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = true;
            deliver_anim.SetBool("deliver_activated", true);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
        }
    }
    public void Dishes_activated()
    {
        if (!gameManager.dishes_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = true;
            dishes_anim.SetBool("dishes_activated", true);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
        }
    }
    public void Cooker_activated()
    {
        if (!gameManager.cooker_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = true;
            cooker_anim.SetBool("cooker_activated", true);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
        }
    }
    public void Trash_can_activated()
    {
        if (!gameManager.trash_can_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = true;
            trash_can_anim.SetBool("trash_can_activated", true);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
        }
    }
    public void Table_activated()
    {
        if (!gameManager.table_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = true;
            table_anim.SetBool("table_activated", true);
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
        else
        {
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
        }
    }
    public void Bread_Store_activated()
    {
        if (!gameManager.bread_store_activated)
        {
            gameManager.cabinet_activated = false;
            cabinet_anim.SetBool("cabinet_activated", false);
            gameManager.chesse_activated = false;
            chesse_anim.SetBool("chesse_activated", false);
            gameManager.tomato_store_activated = false;
            tomato_store_anim.SetBool("tomato_store_activated", false);
            gameManager.cabbage_store_activated = false;
            cabbage_store_anim.SetBool("cabbage_store_activated", false);
            gameManager.meat_store_activated = false;
            meat_store_anim.SetBool("meat_store_activated", false);
            gameManager.cutter_activated = false;
            cutter_anim.SetBool("cutter_activated", false);
            gameManager.deliver_activated = false;
            deliver_anim.SetBool("deliver_activated", false);
            gameManager.dishes_activated = false;
            dishes_anim.SetBool("dishes_activated", false);
            gameManager.cooker_activated = false;
            cooker_anim.SetBool("cooker_activated", false);
            gameManager.trash_can_activated = false;
            trash_can_anim.SetBool("trash_can_activated", false);
            gameManager.table_activated = false;
            table_anim.SetBool("table_activated", false);
            gameManager.bread_store_activated = true;
            bread_store_anim.SetBool("bread_store_activated", true);
        }
        else
        {
            gameManager.bread_store_activated = false;
            bread_store_anim.SetBool("bread_store_activated", false);
        }
    }
}
