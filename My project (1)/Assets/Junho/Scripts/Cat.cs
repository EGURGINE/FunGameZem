using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public enum CatType
{
    a,
    b,
    c,
    d,
    e,
    f,
    g,
    h,
    i,
    j
}
public class Cat : MonoBehaviour
{
    [SerializeField] private int star;
    [SerializeField] private CatType catType;
    [SerializeField] private Sprite[] CatsImg;

    public bool miss = false;

    private int shilld;
    [SerializeField] private int hp;
    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if (miss)
            {
                miss = false;
                return;
            }
            if (shilld<value)
            {
                hp -= (value - shilld);
            }
            else shilld -= value;

            if (hp - value <= 0)
            {
                Die();
            }

        }
    }

    [SerializeField] private int dmg;

    public int Dmg
    {
        get
        {
            return dmg;
        }
        set
        {
            dmg = value;
        }
    }


    private void Die()
    {
        GameManager.Instance.CatsSelect.Remove(gameObject);
        gameObject.SetActive(false);
    }
    public void Attack()
    {
        Vector3 startPos = transform.position;
        transform.DOMove(GameManager.Instance.Enemys[0].transform.position, 0.5f).OnComplete(() =>
            {
                print("dd");
                transform.DOMove(startPos, 0.2f);
            });
        GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().Hp = dmg;
    }
    public void SpawnCat(int _star, CatType type)
    {
        star = _star;
        catType = type;
        gameObject.GetComponent<Image>().sprite = CatsImg[((int)catType)];
        State();

    }
    public void Item(int _star, ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.AD:
                dmg += 30 * _star;
                break;
            case ItemType.HP:
                hp += 50 * _star;
                break;
            case ItemType.DEF:
                shilld += 50 * _star;
                break;
        }
    }
    private void State()
    {
        switch (catType)
        {
            case CatType.a:
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.b:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.c:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.d:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.e:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.f:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.g:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.h:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.i:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;            
            case CatType.j:       
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;
        }
    }
}
