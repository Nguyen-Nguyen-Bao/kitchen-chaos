using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_N_pilliar : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.pause)
        {
            Destroy(gameObject);
        }
    }
}
