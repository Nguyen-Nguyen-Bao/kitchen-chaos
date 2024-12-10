using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{
    public GameManager gameManager;
    public Sprite bread;
    public Sprite fried_meat;
    public Sprite cutted_cheese;
    public Sprite cutted_cabbage;
    public Sprite cutted_tomato;
    public Image big_Image;
    public Image slot;
    // Start is called before the first frame update
    void Start()
    {
        Set_Order1();
        Set_Order2();
        Set_Order3();
        Set_Order4();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set_Order1()
    {
        gameManager.order1 = new Dish();
        // Set Bread
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order1.have_bread = true;
        }
        else
        {
            gameManager.order1.have_bread = false;
        }
        // Set Cutted Cabbage
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order1.have_cutted_cabbage = true;
        }
        else
        {
            gameManager.order1.have_cutted_cabbage = false;
        }
        // Set Cutted Cheese
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order1.have_cutted_cheese = true;
        }
        else
        {
            gameManager.order1.have_cutted_cheese = false;
        }
        // Set Cutted Tomato
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order1.have_cutted_tomato = true;
        }
        else
        {
            gameManager.order1.have_cutted_tomato = false;
        }
        // Set Fried Meat
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order1.have_fried_meat = true;
        }
        else
        {
            gameManager.order1.have_fried_meat = false;
        }
    }
    public void Set_Order2()
    {
        gameManager.order2 = new Dish();
        // Set Bread
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order2.have_bread = true;
        }
        else
        {
            gameManager.order2.have_bread = false;
        }
        // Set Cutted Cabbage
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order2.have_cutted_cabbage = true;
        }
        else
        {
            gameManager.order2.have_cutted_cabbage = false;
        }
        // Set Cutted Cheese
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order2.have_cutted_cheese = true;
        }
        else
        {
            gameManager.order2.have_cutted_cheese = false;
        }
        // Set Cutted Tomato
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order2.have_cutted_tomato = true;
        }
        else
        {
            gameManager.order2.have_cutted_tomato = false;
        }
        // Set Fried Meat
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order2.have_fried_meat = true;
        }
        else
        {
            gameManager.order2.have_fried_meat = false;
        }
    }
    public void Set_Order3()
    {
        gameManager.order3 = new Dish();
        // Set Bread
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order3.have_bread = true;
        }
        else
        {
            gameManager.order3.have_bread = false;
        }
        // Set Cutted Cabbage
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order3.have_cutted_cabbage = true;
        }
        else
        {
            gameManager.order3.have_cutted_cabbage = false;
        }
        // Set Cutted Cheese
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order3.have_cutted_cheese = true;
        }
        else
        {
            gameManager.order3.have_cutted_cheese = false;
        }
        // Set Cutted Tomato
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order3.have_cutted_tomato = true;
        }
        else
        {
            gameManager.order3.have_cutted_tomato = false;
        }
        // Set Fried Meat
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order3.have_fried_meat = true;
        }
        else
        {
            gameManager.order3.have_fried_meat = false;
        }
    }
    public void Set_Order4()
    {
        gameManager.order4 = new Dish();
        // Set Bread
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order4.have_bread = true;
        }
        else
        {
            gameManager.order4.have_bread = false;
        }
        // Set Cutted Cabbage
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order4.have_cutted_cabbage = true;
        }
        else
        {
            gameManager.order4.have_cutted_cabbage = false;
        }
        // Set Cutted Cheese
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order4.have_cutted_cheese = true;
        }
        else
        {
            gameManager.order4.have_cutted_cheese = false;
        }
        // Set Cutted Tomato
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order4.have_cutted_tomato = true;
        }
        else
        {
            gameManager.order4.have_cutted_tomato = false;
        }
        // Set Fried Meat
        if (Random.Range(1, 3) == 1)
        {
            gameManager.order4.have_fried_meat = true;
        }
        else
        {
            gameManager.order4.have_fried_meat = false;
        }
    }
}
