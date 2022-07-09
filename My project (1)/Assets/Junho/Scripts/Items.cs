using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    AD,
    HP,
    DEF
}
public class Items : MonoBehaviour
{
    public ItemType itemType;
    public int star;
    public Vector3 invenPos;
    private bool isThouching;
    private bool isPlayer;
    private bool isItem;
    private GameObject target;
    public void Upgrade()
    {
        star++;
    }
    private void OnMouseDrag()
    {
        isThouching = true;
        Inventory.Instance.ReMove(gameObject);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isThouching && collision.CompareTag("Item")&& collision.GetComponent<Items>().itemType == itemType 
            && collision.GetComponent<Items>().star == star)
        {
            target = collision.gameObject;
            isItem = true;
        }
        else if (isThouching && collision.CompareTag("Player"))
        {
            isPlayer = true;
            target = collision.gameObject;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isThouching && collision.CompareTag("Item") && collision.GetComponent<Items>().itemType == itemType
            && collision.GetComponent<Items>().star == star)
        {
            target = null;
            isItem= false;
        }
        else if (isThouching && collision.CompareTag("Player"))
        {
            isPlayer = true;
            target = null;
        }
    }
    private void OnMouseUp()
    {
        isThouching = false;

        if (isPlayer)
        {
            transform.position = target.transform.position;
            Inventory.Instance.ReMove(gameObject);
            target.GetComponent<Cat>().Item(star, itemType);
            Destroy(gameObject);
        }
        else if (isItem)
        {
            isItem = false;
            Inventory.Instance.ReMove(gameObject);
            target.GetComponent<Items>().Upgrade();
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < Inventory.Instance.InVen.Length; i++)
            {
                if (Inventory.Instance.InVen[i] == null)
                {
                    Inventory.Instance.InVen[i] = gameObject;
                    transform.position = Inventory.Instance.cell[i].transform.position;
                    break;
                }
            }
        }
    }

}
