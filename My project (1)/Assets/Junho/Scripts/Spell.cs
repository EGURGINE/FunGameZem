using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType
{
    //물리 공격
    nail,
    bite,
    //심리 공격
    bark,
    //회피
    jump,
    run,
    //회복
    grooming,
    bread,
    //버프
    sleep,
    scratch,
    //??
    golgol,
    lovely
}
public class Spell : MonoBehaviour
{
    public Vector3 invenPos;
    [SerializeField] SpellType type;
    private bool thisCol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpellSlect"))
        {
            thisCol = true;
            Inventory.Instance.isCol = true;
            GameManager.Instance.Spell.Add(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SpellSlect"))
        {
            thisCol = false;
            Inventory.Instance.isCol = false;
            GameManager.Instance.Spell.Remove(gameObject);

        }
    }
    private void OnMouseDrag()
    {
        Inventory.Instance.ReMove(gameObject);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
    }
    private void OnMouseUp()
    {
        if (Inventory.Instance.isCol && thisCol)
        {
            Inventory.Instance.ReMove(gameObject);
            transform.position = GameManager.Instance.stageSlect.transform.position;
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
            //if(GameObject.Find("Inventory").GetComponent<Inventory>().InVen.Length == 10  )
            //{
            //    invenPos = GameManager.Instance.stageSlect.transform.position;
            //}
        }
    }
    public void SpellAbility()
    {
        switch (type)
        {
            case SpellType.nail:
                GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().Hp -= 60;
                break;
            case SpellType.bite:
                GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().DotDeal();
                break;
            case SpellType.bark:
                foreach (var enemy in GameManager.Instance.Enemys)
                {
                    enemy.GetComponent<BasicEnemy>().Dmg -= 3;
                }
                break;
            case SpellType.jump:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().miss = true;
                break;
            case SpellType.run:
                foreach (var cat in GameManager.Instance.CatsSelect)
                {
                    cat.GetComponent<Cat>().miss = true;
                }
                break;
            case SpellType.grooming:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Hp += 50;
                break;
            case SpellType.bread:
                foreach (var cat in GameManager.Instance.CatsSelect)
                {
                    cat.GetComponent<Cat>().Hp += 30;
                }
                break;
            case SpellType.sleep:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Dmg += 5;
                break;
            case SpellType.scratch:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Dmg += 10;
                break;
            case SpellType.golgol:
                print("golgol");
                break;
            case SpellType.lovely:
                print("lovely");
                break;
        }
    }
}
