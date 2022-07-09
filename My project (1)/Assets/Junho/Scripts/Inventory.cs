using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    static public Inventory Instance;
    const int MaxSpell = 11;

    public List<Image> cell = new List<Image>();
    [SerializeField] GameObject[] spell;
    [SerializeField] GameObject[] items;

    [SerializeReference] public GameObject[] InVen = new GameObject[10];
    public bool isCol = false;
    private void Awake()
    {
        Instance = this;
    }
    public void ReMove(GameObject obj)
    {
        for (int i = 0; i < InVen.Length; i++)
        {
            if (InVen[i] == obj)
            {
                InVen[i] = null;
            }
        }
    }
    public void ItemDrop()
    {
        if (GameManager.Instance.Money -2 < 0) return;
        else GameManager.Instance.Money = -2;
        for (int i = 0; i < InVen.Length; i++)
        {
            if (InVen[i] == null)
            {
                InVen[i] = Instantiate(items[Random.Range(0, items.Length)]);
                //InVen[i] = Instantiate(spell[Random.Range(0, MaxSpell)]);
                //InVen[i].GetComponent<Spell>().invenPos = cell[i].transform.position;
                InVen[i].GetComponent<Items>().invenPos = cell[i].transform.position;
                InVen[i].transform.position = cell[i].transform.position;

                break;
            }
        }
    }
    public void SpellDrop()
    {
        for (int i = 0; i < InVen.Length; i++)
        {
            if (InVen[i] == null)
            {
                InVen[i] = Instantiate(spell[Random.Range(0,spell.Length)]);
                //InVen[i] = Instantiate(spell[Random.Range(0, MaxSpell)]);
                //InVen[i].GetComponent<Spell>().invenPos = cell[i].transform.position;
                InVen[i].GetComponent<Items>().invenPos = cell[i].transform.position;
                InVen[i].transform.position = cell[i].transform.position;

                break;
            }
        }
    }
}
