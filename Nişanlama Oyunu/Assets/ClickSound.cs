using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour {
    public GameObject clickEffect;

    public void ClickEffectFonk()
    {
        GameObject effect = Instantiate(clickEffect);
        Destroy(effect, 0.7f);
    }

}
