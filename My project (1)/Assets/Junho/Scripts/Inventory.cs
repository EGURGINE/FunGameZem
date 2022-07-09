using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    static public Inventory Instance;
    const int MaxSpell = 11;
    [SerializeField] List<Image> cell = new List<Image>();
    [SerializeField] Image[] spell;
    private void Awake()
    {
        Instance = this;
    }

    public void SpellDrop()
    {
    }
}
