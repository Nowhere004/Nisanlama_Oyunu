using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelButon : MonoBehaviour {
    
	void Start () {
        if (gameObject.name=="Level-1")
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
                GetComponent<Button>().interactable = true;
            else
                GetComponent<Button>().interactable = false;
        }
	}

}
