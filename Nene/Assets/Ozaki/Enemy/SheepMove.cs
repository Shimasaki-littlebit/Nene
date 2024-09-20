using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sheep;

public class SheepMove : MonoBehaviour
{
    private SheepManager sheepManager;

    private SheepStates sheepStates;
    // Start is called before the first frame update
    void Start()
    {
        sheepManager = SheepManager.Instance;
        sheepStates = sheepManager.SheepStates;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
