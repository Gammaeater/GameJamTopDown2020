using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {
	
	void Update () {


      GetComponent<Renderer>().sortingLayerName = "Player";
        //Destroy(gameObject, 0.5f);
    }

}



