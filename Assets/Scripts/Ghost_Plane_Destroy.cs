using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Plane_Destroy : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.switch_side)
        {
            StartCoroutine(Go());
        }
    }
    IEnumerator Go()
    {
        yield return null;
        gameManager.switch_side = false;
        gameManager.ghost_plane_instatiated = false;
        Destroy(gameObject); 
    }
}
