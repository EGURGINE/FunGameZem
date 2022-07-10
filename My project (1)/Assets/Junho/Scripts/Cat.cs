using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public enum CatType
{
    a,
    b,
    c,
    d,
    e
}
public class Cat : MonoBehaviour
{
    [SerializeField] private int star;
    [SerializeField] private CatType catType;
    [SerializeField] private Sprite[] CatsImg;
    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private TextMeshProUGUI dmgTxt;
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

            hpTxt.text = hp.ToString();

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
            dmgTxt.text = dmg.ToString();
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
                GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().Hp = dmg;
                transform.DOMove(startPos, 0.2f);
            });
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
                print("dkdk");
                dmg += (30 * _star);
                dmgTxt.text = dmg.ToString();
                break;
            case ItemType.HP:
                print("dkdk");
                hp += (50 * _star);
                hpTxt.text = hp.ToString();
                break;
            case ItemType.DEF:
        print("dkdk");
                shilld += 50 * _star;
                break;
        }
    }
    private void State()
    {
        switch (catType)
        {
            case CatType.a:
                hp = 10 +  star * 10;
                dmg = 35 + star * 10;
                break;                   
            case CatType.b:
                hp = 50 +  star * 10;
                dmg = 15 + star * 10;
                break;                   
            case CatType.c:                  
                hp = 90 +  star * 10;
                dmg = 12 + star * 10;
                break;                   
            case CatType.d:                  
                hp = 100 + star * 10;
                dmg = 10 + star * 10;
                break;                   
            case CatType.e:                  
                hp = 150 + star * 10;
                dmg = 5 +  star * 10;
                break;            
        }
        dmgTxt.text = dmg.ToString();
        hpTxt.text = hp.ToString();
    }
}
