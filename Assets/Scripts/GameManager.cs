using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameManager : ScriptableObject
{
    public GameObject current_gameObject;
    public GameObject moment_gameObject;
    public enum Side
    {
        Right, Left, Top, Bottom
    }
    public Side side;
    public Side current_side;
    public Side moment_side;
    public bool switch_side;
    public bool ghost_plane_instatiated;
    public Vector3[] instantiated_position;
    public Vector3[] instantiated_wall_N_plane;
    public int planes;
    public int planes_in_stored;
    public bool cabinet_activated;
    public bool chesse_activated;
    public bool tomato_store_activated;
    public bool cabbage_store_activated;
    public bool meat_store_activated;
    public bool cutter_activated;
    public bool deliver_activated;
    public bool dishes_activated;
    public bool cooker_activated;
    public bool trash_can_activated;
    public bool table_activated;
    public bool bread_store_activated;
    public int chesse_stores;
    public int tomato_stores;
    public int cabbage_stores;
    public int meat_stores;
    public int cutters;
    public int delivers;
    public int disheses;
    public int cookers;
    public int trash_cans;
    public int tables;
    public int bread_stores;
    public bool pause;
    public enum Holding
    {
        None, Cheese, Tomato, Meat, Cabbage, Bread, Dish, Cutted_Cheese, Cutted_Tomato, Fried_Meat, Cutted_Cabbage
    }
    public Holding holding;
    public GameObject holdingStuff;
    public Dish order1;
    public Dish order2;
    public Dish order3;
    public Dish order4;
    public GameObject[] instantiated_Stuffs;
}
