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

    [SerializeField] private float hp;
    public float Hp
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
            if (hp - value <= 0)
            {
                Die();
            }
            hp = value;

        }
    }

    [SerializeField] private float dmg;

    public float Dmg
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
        gameObject.SetActive(false);
    }
    public void Attack()
    {
        GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().Hp -= dmg;
    }
    public void SpawnCat(int _star, CatType type)
    {
        star = _star;
        catType = type;
        this.GetComponent<Image>().sprite = CatsImg[((int)catType)];
        State();

    }
    private void State()
    {
        switch (catType)
        {
            case CatType.a:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.b:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.c:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.d:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.e:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.f:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.g:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.h:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.i:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
            case CatType.j:
                hp = 100 + star * 50;
                dmg = 10 + star * 50;
                break;
        }
    }
}
