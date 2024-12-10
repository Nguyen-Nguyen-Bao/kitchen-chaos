using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
public class DrawRay : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask_plane;
    public LayerMask layerMask_chesse_store;
    public LayerMask layerMask_tomato_store;
    public LayerMask layerMask_cabbage_store;
    public LayerMask layerMask_meat_store;
    public LayerMask layerMask_cutter;
    public LayerMask layerMask_deliver;
    public LayerMask layerMask_dishes;
    public LayerMask layerMask_cooker;
    public LayerMask layerMask_trash_can;
    public LayerMask layerMask_table;
    public LayerMask layerMask_bread_store;
    public GameManager gameManager;
    public GameObject ghost_plane;
    public GameObject real_plane;
    public GameObject chesse_store;
    public GameObject tomato_store;
    public GameObject cabbage_store;
    public GameObject meat_store;
    public GameObject cutter;
    public GameObject deliver;
    public GameObject dishes;
    public GameObject cooker;
    public GameObject trash_can;
    public GameObject table;
    public GameObject bread_store;
    public GameObject wall;
    public GameObject pillar;
    public GameObject editing;
    public GameObject order;
    public TextMeshProUGUI textMeshProUGUI1;
    public TextMeshProUGUI textMeshProUGUI2;
    public TextMeshProUGUI textMeshProUGUI3;
    public TextMeshProUGUI textMeshProUGUI4;
    public TextMeshProUGUI textMeshProUGUI5;   
    public TextMeshProUGUI textMeshProUGUI6;   
    public TextMeshProUGUI textMeshProUGUI7;   
    public TextMeshProUGUI textMeshProUGUI8;
    public TextMeshProUGUI textMeshProUGUI9;
    public TextMeshProUGUI textMeshProUGUI10;
    public TextMeshProUGUI textMeshProUGUI11;
    public TextMeshProUGUI textMeshProUGUI12;
    public GameObject cinemachine1;
    public GameObject cinemachine2;
    // Start is called before the first frame update
    void Start()
    {
        GameManager_Setup();
        order.SetActive(false);
        Number_Of_Stuffs();
        cinemachine1.SetActive(true);
        cinemachine2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RLTB_plane_N_SwitchSides();
        Pause();
    }
    void Number_Of_Stuffs()
    {
        textMeshProUGUI1.text = "x"+gameManager.planes.ToString();
        textMeshProUGUI2.text = "x" + gameManager.chesse_stores.ToString();
        textMeshProUGUI3.text = "x" + gameManager.tomato_stores.ToString();
        textMeshProUGUI4.text = "x" + gameManager.cabbage_stores.ToString();
        textMeshProUGUI5.text = "x" + gameManager.meat_stores.ToString();
        textMeshProUGUI6.text = "x" + gameManager.cutters.ToString();
        textMeshProUGUI7.text = "x" + gameManager.delivers.ToString();
        textMeshProUGUI8.text = "x" + gameManager.disheses.ToString();
        textMeshProUGUI9.text = "x" + gameManager.cookers.ToString();
        textMeshProUGUI10.text = "x" + gameManager.trash_cans.ToString();
        textMeshProUGUI11.text = "x" + gameManager.tables.ToString();
        textMeshProUGUI12.text = "x" + gameManager.bread_stores.ToString();

    }
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            editing.SetActive(true);
            gameManager.pause = true;
            order.SetActive(false);
            cinemachine1.SetActive(true);
            cinemachine2.SetActive(false);
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
        }
    }
    public void Build_Wall()
    {
        Array.Resize(ref gameManager.instantiated_wall_N_plane, gameManager.instantiated_position.Length);
        for (int i = 0; i < gameManager.instantiated_wall_N_plane.Length; i++)
        {
            gameManager.instantiated_wall_N_plane[i] = gameManager.instantiated_position[i];
        }
        Vector3 huongbac = new Vector3(0, 0, 0);
        Vector3 huongdong = new Vector3(0, 90, 0);
        Vector3 huongnam = new Vector3(0, 180, 0);
        Vector3 huongtay = new Vector3(0, 270, 0);
        foreach (var position in gameManager.instantiated_position)
        {
            bool bac = true;
            bool dong = true;
            bool nam = true;
            bool tay = true;
            Vector3 xyz_bac = new Vector3(position.x, position.y, position.z + 1);
            Vector3 xyz_dong = new Vector3(position.x + 1, position.y, position.z);
            Vector3 xyz_nam = new Vector3(position.x, position.y, position.z - 1);
            Vector3 xyz_tay = new Vector3(position.x - 1, position.y, position.z);
            foreach (var xyz in gameManager.instantiated_position)
            {
                if (xyz_bac == xyz)
                {
                    bac = false;
                }
                else if (xyz_dong == xyz)
                {
                    dong = false;
                }
                else if (xyz_nam == xyz)
                {
                    nam = false;
                }
                else if (xyz_tay == xyz)
                {
                    tay = false;
                }
            }
            if (bac)
            {
                Instantiate(wall, position, Quaternion.Euler(huongbac));
                Add_wall(xyz_bac);
            }
            if (dong)
            {
                Instantiate(wall, position, Quaternion.Euler(huongdong));
                Add_wall(xyz_dong);
            }
            if (nam)
            {
                Instantiate(wall, position, Quaternion.Euler(huongnam));
                Add_wall(xyz_nam);
            }
            if (tay)
            {
                Instantiate(wall, position, Quaternion.Euler(huongtay));
                Add_wall(xyz_tay);
            }
        }
        foreach (var position in gameManager.instantiated_position)
        {
            bool dongbac = true;
            bool dongnam = true;
            bool taynam = true;
            bool taybac = true;
            Vector3 xyz_dongbac = new Vector3(position.x + 1, position.y, position.z + 1);
            Vector3 xyz_dongnam = new Vector3(position.x + 1, position.y, position.z - 1);
            Vector3 xyz_taynam = new Vector3(position.x - 1, position.y, position.z - 1);
            Vector3 xyz_taybac = new Vector3(position.x - 1, position.y, position.z + 1);
            foreach (var xyz in gameManager.instantiated_wall_N_plane)
            {
                if (xyz_dongbac == xyz)
                {
                    dongbac = false;
                }
                else if (xyz_dongnam == xyz)
                {
                    dongnam = false;
                }
                else if (xyz_taynam == xyz)
                {
                    taynam = false;
                }
                else if (xyz_taybac == xyz)
                {
                    taybac = false;
                }
            }
            if (dongbac)
            {
                Instantiate(pillar, position, Quaternion.Euler(huongbac));
            }
            if (dongnam)
            {
                Instantiate(pillar, position, Quaternion.Euler(huongdong));
            }
            if (taynam)
            {
                Instantiate(pillar, position, Quaternion.Euler(huongnam));
            }
            if (taybac)
            {
                Instantiate(pillar, position, Quaternion.Euler(huongtay));
            }
        }
    }
    void GameManager_Setup()
    {
        gameManager.current_gameObject = null;
        gameManager.moment_gameObject = null;
        gameManager.switch_side = false;
        gameManager.ghost_plane_instatiated = false;
        gameManager.instantiated_position = new Vector3[0];
        gameManager.instantiated_wall_N_plane = new Vector3[0];
        gameManager.planes = 45;
        gameManager.planes_in_stored = gameManager.planes;
        gameManager.cabinet_activated = false;
        gameManager.chesse_activated = false;
        gameManager.tomato_store_activated = false;
        gameManager.cabbage_store_activated = false;
        gameManager.meat_store_activated = false;
        gameManager.cutter_activated = false;
        gameManager.deliver_activated = false;
        gameManager.dishes_activated = false;
        gameManager.cooker_activated = false;
        gameManager.trash_can_activated = false;
        gameManager.chesse_stores = 1;
        gameManager.tomato_stores = 1;
        gameManager.cabbage_stores = 1;
        gameManager.meat_stores = 1;
        gameManager.cutters = 1;
        gameManager.delivers = 1;
        gameManager.disheses = 1;
        gameManager.cookers = 1;
        gameManager.trash_cans = 1;
        gameManager.tables = 3;
        gameManager.bread_stores = 1;
        gameManager.pause = true;
        gameManager.holding = GameManager.Holding.None;
        gameManager.instantiated_Stuffs = new GameObject[0];
}
    void RLTB_plane_N_SwitchSides()
    {
        Vector3 mouse_position = Input.mousePosition;
        mouse_position.z = 100;
        mouse_position = cam.ScreenToWorldPoint(mouse_position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (gameManager.pause && Physics.Raycast(ray, out raycastHit, 100))
        {
            if (raycastHit.transform.gameObject.layer != 3)
            {

            }
            else if (raycastHit.transform.gameObject.layer == 3)
            {
                Vector3 point = raycastHit.point;
                Vector3 plane = raycastHit.transform.position;
                // ---- PLANE ----
                if (gameManager.cabinet_activated)
                {
                    //Check Right
                    float cor_percent_R = (point.x - plane.x) * 100 / (0.5f);
                    float z1_R = plane.z + (cor_percent_R * (0.5f) / 100);
                    float z2_R = plane.z + (cor_percent_R * (-0.5f) / 100);
                    if (plane.x < point.x && point.x < plane.x + 0.5f && z2_R < point.z && point.z < z1_R)
                    {
                        gameManager.side = GameManager.Side.Right;
                    }
                    // Check Left
                    float cor_percent_L = (point.x - plane.x) * 100 / (-0.5f);
                    float z1_L = plane.z + cor_percent_L * (0.5f) / 100;
                    float z2_L = plane.z + cor_percent_L * (-0.5f) / 100;
                    if (plane.x - 0.5f < point.x && point.x < plane.x && z2_L < point.z && point.z < z1_L)
                    {
                        gameManager.side = GameManager.Side.Left;
                    }
                    // Check Top
                    float cor_percent_T = (point.z - plane.z) * 100 / (0.5f);
                    float x1_T = plane.x + cor_percent_T * (0.5f) / 100;
                    float x2_T = plane.x + cor_percent_T * (-0.5f) / 100;
                    if (plane.z < point.z && point.z < plane.z + 0.5f && x2_T < point.x && point.x < x1_T)
                    {
                        gameManager.side = GameManager.Side.Top;
                    }
                    // Check Bottom
                    float cor_percent_B = (point.z - plane.z) * 100 / (-0.5f);
                    float x1_B = plane.x + cor_percent_B * (0.5f) / 100;
                    float x2_B = plane.x + cor_percent_B * (-0.5f) / 100;
                    if (plane.z - 0.5f < point.z && point.z < plane.z && x2_B < point.x && point.x < x1_B)
                    {
                        gameManager.side = GameManager.Side.Bottom;
                    }
                    // Check If Switch Sides
                    gameManager.moment_gameObject = raycastHit.transform.gameObject;
                    gameManager.moment_side = gameManager.side;
                    if (gameManager.moment_gameObject != gameManager.current_gameObject || gameManager.moment_side != gameManager.current_side)
                    {
                        gameManager.switch_side = true;
                        gameManager.current_gameObject = gameManager.moment_gameObject;
                        gameManager.current_side = gameManager.moment_side;
                    }
                    // Instantiate Ghost_Plane
                    if (!gameManager.ghost_plane_instatiated)
                    {
                        if (gameManager.side == GameManager.Side.Right)
                        {
                            Instantiate(ghost_plane, new Vector3(plane.x + 1, plane.y, plane.z), Quaternion.identity);
                            gameManager.ghost_plane_instatiated = true;
                        }
                        else if (gameManager.side == GameManager.Side.Left)
                        {
                            Instantiate(ghost_plane, new Vector3(plane.x - 1, plane.y, plane.z), Quaternion.identity);
                            gameManager.ghost_plane_instatiated = true;
                        }
                        else if (gameManager.side == GameManager.Side.Top)
                        {
                            Instantiate(ghost_plane, new Vector3(plane.x, plane.y, plane.z + 1), Quaternion.identity);
                            gameManager.ghost_plane_instatiated = true;
                        }
                        else if (gameManager.side == GameManager.Side.Bottom)
                        {
                            Instantiate(ghost_plane, new Vector3(plane.x, plane.y, plane.z - 1), Quaternion.identity);
                            gameManager.ghost_plane_instatiated = true;
                        }
                    }
                    // Instantiate Right_Plane
                    if (gameManager.side == GameManager.Side.Right && Input.GetMouseButton(0))
                    {
                        bool already_spawned = false;
                        foreach (Vector3 vector3 in gameManager.instantiated_position)
                        {
                            if (vector3 == new Vector3(plane.x + 1, plane.y, plane.z))
                            {
                                already_spawned = true;
                            }
                        }
                        if (!already_spawned && gameManager.planes != 0)
                        {
                            Instantiate(real_plane, new Vector3(plane.x + 1, plane.y, plane.z), Quaternion.identity);
                            Add_plane(new Vector3(plane.x + 1, plane.y, plane.z));
                            --gameManager.planes;
                            textMeshProUGUI1.text = "x" + gameManager.planes.ToString();
                        }
                    }
                    // Instantiate Left_Plane
                    if (gameManager.side == GameManager.Side.Left && Input.GetMouseButton(0))
                    {
                        bool already_spawned = false;
                        foreach (Vector3 vector3 in gameManager.instantiated_position)
                        {
                            if (vector3 == new Vector3(plane.x - 1, plane.y, plane.z))
                            {
                                already_spawned = true;
                            }
                        }
                        if (!already_spawned && gameManager.planes != 0)
                        {
                            Instantiate(real_plane, new Vector3(plane.x - 1, plane.y, plane.z), Quaternion.identity);
                            Add_plane(new Vector3(plane.x - 1, plane.y, plane.z));
                            --gameManager.planes;
                            textMeshProUGUI1.text = "x" + gameManager.planes.ToString();
                        }
                    }
                    // Instantiate Top_Plane
                    if (gameManager.side == GameManager.Side.Top && Input.GetMouseButton(0))
                    {
                        bool already_spawned = false;
                        foreach (Vector3 vector3 in gameManager.instantiated_position)
                        {
                            if (vector3 == new Vector3(plane.x, plane.y, plane.z + 1))
                            {
                                already_spawned = true;
                            }
                        }
                        if (!already_spawned && gameManager.planes != 0)
                        {
                            Instantiate(real_plane, new Vector3(plane.x, plane.y, plane.z + 1), Quaternion.identity);
                            Add_plane(new Vector3(plane.x, plane.y, plane.z + 1));
                            --gameManager.planes;
                            textMeshProUGUI1.text = "x" + gameManager.planes.ToString();
                        }
                    }
                    // Instantiate Bottom_Plane
                    if (gameManager.side == GameManager.Side.Bottom && Input.GetMouseButton(0))
                    {
                        bool already_spawned = false;
                        foreach (Vector3 vector3 in gameManager.instantiated_position)
                        {
                            if (vector3 == new Vector3(plane.x, plane.y, plane.z - 1))
                            {
                                already_spawned = true;
                            }
                        }
                        if (!already_spawned && gameManager.planes != 0)
                        {
                            Instantiate(real_plane, new Vector3(plane.x, plane.y, plane.z - 1), Quaternion.identity);
                            Add_plane(new Vector3(plane.x, plane.y, plane.z - 1));
                            --gameManager.planes;
                            textMeshProUGUI1.text = "x" + gameManager.planes.ToString();
                        }
                    }
                    // Plane Go !!!
                    if (Input.GetMouseButton(1))
                    {
                        Plane_Extention plane_extention;
                        if (raycastHit.transform.TryGetComponent<Plane_Extention>(out plane_extention))
                        {
                            plane_extention.Destroy();
                            ++gameManager.planes;
                            textMeshProUGUI1.text = "x" + gameManager.planes.ToString();
                        }
                        for (int i = 0; i < gameManager.instantiated_position.Length; ++i)
                        {
                            if (gameManager.instantiated_position[i] == plane)
                            {
                                gameManager.instantiated_position = gameManager.instantiated_position.Except(new Vector3[] { plane }).ToArray();
                            }
                        }
                    }
                }
                // ---- INSTANTIATE STUFF ----
                Vector3 up_of_plane = new Vector3(plane.x, plane.y + 0.005f, plane.z);
                // ---- CHEESE STORE ----
                if (gameManager.chesse_activated && gameManager.chesse_stores != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(chesse_store, up_of_plane, Quaternion.identity);
                        --gameManager.chesse_stores;
                        textMeshProUGUI2.text = "x" + gameManager.chesse_stores.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- TOMATO STORE ----
                if (gameManager.tomato_store_activated && gameManager.tomato_stores != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(tomato_store, up_of_plane, Quaternion.identity);
                        --gameManager.tomato_stores;
                        textMeshProUGUI3.text = "x" + gameManager.tomato_stores.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- CABBAGE STORE ----
                if (gameManager.cabbage_store_activated && gameManager.cabbage_stores != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(cabbage_store, up_of_plane, Quaternion.identity);
                        --gameManager.cabbage_stores;
                        textMeshProUGUI4.text = "x" + gameManager.cabbage_stores.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- MEAT STORE ----
                if (gameManager.meat_store_activated && gameManager.meat_stores != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(meat_store, up_of_plane, Quaternion.identity);
                        --gameManager.meat_stores;
                        textMeshProUGUI5.text = "x" + gameManager.meat_stores.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- CUTTER ----
                if (gameManager.cutter_activated && gameManager.cutters != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(cutter, up_of_plane, Quaternion.identity);
                        --gameManager.cutters;
                        textMeshProUGUI6.text = "x" + gameManager.cutters.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- DELIVER ----
                if (gameManager.deliver_activated && gameManager.delivers != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(deliver, up_of_plane, Quaternion.identity);
                        --gameManager.delivers;
                        textMeshProUGUI7.text = "x" + gameManager.delivers.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- DISHES ----
                if (gameManager.dishes_activated && gameManager.disheses != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(dishes, up_of_plane, Quaternion.identity);
                        --gameManager.disheses;
                        textMeshProUGUI8.text = "x" + gameManager.disheses.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- COOKER ----
                if (gameManager.cooker_activated && gameManager.cookers != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(cooker, up_of_plane, Quaternion.identity);
                        --gameManager.cookers;
                        textMeshProUGUI9.text = "x" + gameManager.cookers.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- TRASH CAN ----
                if (gameManager.trash_can_activated && gameManager.trash_cans != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(trash_can, up_of_plane, Quaternion.identity);
                        --gameManager.trash_cans;
                        textMeshProUGUI10.text = "x" + gameManager.trash_cans.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- TABLE ----
                if (gameManager.table_activated && gameManager.tables != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(table, up_of_plane, Quaternion.identity);
                        --gameManager.tables;
                        textMeshProUGUI11.text = "x" + gameManager.tables.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
                // ---- BREAD STORE ----
                if (gameManager.bread_store_activated && gameManager.bread_stores != 0)
                {
                    // Instantiate
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject o = Instantiate(bread_store, up_of_plane, Quaternion.identity);
                        --gameManager.bread_stores;
                        textMeshProUGUI12.text = "x" + gameManager.bread_stores.ToString();
                        Add_instantiated_Stuff(o);
                    }
                }
            }
        }
        //Destroy Stuff
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out raycastHit, 100, layerMask_chesse_store))
            {
                raycastHit.transform.GetComponent<Cheese_Store_Destruction>().Destroy();
                ++gameManager.chesse_stores;
                textMeshProUGUI2.text = "x" + gameManager.chesse_stores.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_tomato_store))
            {
                raycastHit.transform.GetComponent<Tomato_Store_Destruction>().Destroy();
                ++gameManager.tomato_stores;
                textMeshProUGUI3.text = "x" + gameManager.tomato_stores.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_cabbage_store))
            {
                raycastHit.transform.GetComponent<Cabbage_Store_Destruction>().Destroy();
                ++gameManager.cabbage_stores;
                textMeshProUGUI4.text = "x" + gameManager.cabbage_stores.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_meat_store))
            {
                raycastHit.transform.GetComponent<Meat_Store_Destruction>().Destroy();
                ++gameManager.meat_stores;
                textMeshProUGUI5.text = "x" + gameManager.meat_stores.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_cutter))
            {
                raycastHit.transform.GetComponent<Cutter_Destruction>().Destroy();
                ++gameManager.cutters;
                textMeshProUGUI6.text = "x" + gameManager.cutters.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_deliver))
            {
                raycastHit.transform.GetComponent<Deliver_Destruction>().Destroy();
                ++gameManager.delivers;
                textMeshProUGUI7.text = "x" + gameManager.delivers.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_dishes))
            {
                raycastHit.transform.GetComponent<Dishes_Destruction>().Destroy();
                ++gameManager.disheses;
                textMeshProUGUI8.text = "x" + gameManager.disheses.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_cooker))
            {
                raycastHit.transform.GetComponent<Cooker_Destruction>().Destroy();
                ++gameManager.cookers;
                textMeshProUGUI9.text = "x" + gameManager.cookers.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_trash_can))
            {
                raycastHit.transform.GetComponent<Trash_Can_Destruction>().Destroy();
                ++gameManager.trash_cans;
                textMeshProUGUI10.text = "x" + gameManager.trash_cans.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_table))
            {
                raycastHit.transform.GetComponent<table_Destruction>().Destroy();
                ++gameManager.tables;
                textMeshProUGUI11.text = "x" + gameManager.tables.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
            else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_bread_store))
            {
                Debug.Log(raycastHit.transform.gameObject.name);
                raycastHit.transform.GetComponent<bread_store_Destruction>().Destroy();
                ++gameManager.bread_stores;
                textMeshProUGUI12.text = "x" + gameManager.bread_stores.ToString();
                gameManager.instantiated_Stuffs = gameManager.instantiated_Stuffs.Except(new GameObject[] { raycastHit.transform.gameObject }).ToArray();
            }
        }
        // Rotate Stuff
        if (Physics.Raycast(ray, out raycastHit, 100, layerMask_chesse_store) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Cheese_Store_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_tomato_store) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Tomato_Store_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_cabbage_store) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Cabbage_Store_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_meat_store) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Meat_Store_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_cutter) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Cutter_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_deliver) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Deliver_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_dishes) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Dishes_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_cooker) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Cooker_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_trash_can) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<Trash_Can_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_table) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<table_Destruction>().Spining();
        }
        else if (Physics.Raycast(ray, out raycastHit, 100, layerMask_bread_store) && Input.GetMouseButtonDown(0))
        {
            raycastHit.transform.GetComponent<bread_store_Destruction>().Spining();
        }
        // Instantiate A Plane When There Is Nothing
        if (gameManager.planes == gameManager.planes_in_stored)
        {
            Instantiate(real_plane, Vector3.zero, Quaternion.identity);
            --gameManager.planes;
            Add_plane(Vector3.zero);
        }
    }
    void Add_instantiated_Stuff(GameObject o)
    {
        Array.Resize(ref gameManager.instantiated_Stuffs, gameManager.instantiated_Stuffs.Length + 1);
        gameManager.instantiated_Stuffs[gameManager.instantiated_Stuffs.Length - 1] = o;
    }
    void Add_plane(Vector3 xyz)
    {
        Array.Resize(ref gameManager.instantiated_position, gameManager.instantiated_position.Length + 1);
        gameManager.instantiated_position[gameManager.instantiated_position.Length - 1] = xyz;
    }
    void Add_wall(Vector3 xyz)
    {
        Array.Resize(ref gameManager.instantiated_wall_N_plane, gameManager.instantiated_wall_N_plane.Length + 1);
        gameManager.instantiated_wall_N_plane[gameManager.instantiated_wall_N_plane.Length - 1] = xyz;
    }
}
