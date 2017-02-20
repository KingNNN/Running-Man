using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_Player : Player {

	// Use this for initialization
	void Start () {
        Init();
        myType = PlayerType.NORMAL;
    }

    // Update is called once per frame
    void Update () {
        movePlayer();        

#if (UNITY_EDITOR)
        ButtonPresses(null);
#endif       
    }
}
