using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mana : MonoBehaviour
{

    public Slider mana;
    public void setMaxMana(int mana)
    {
        this.mana.maxValue = mana;
        this.mana.value = mana;
    }
    public void setMana(int mana)
    {
        this.mana.value = mana;
    }
}
