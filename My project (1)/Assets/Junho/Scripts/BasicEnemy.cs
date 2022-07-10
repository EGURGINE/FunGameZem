using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public enum EnemyType
{
    Red,
    Yellow,
    Blue,
    Purple,
    Green,
    Boos
}
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private Sprite[] EnemysImg;

    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private TextMeshProUGUI dmgTxt;

    [SerializeField] private int hp;
    const float dotDealDuration = 5;
    public int Hp
    {
        get 
        {
            return hp; 
        }
        set 
        {
            hp -= value;
            hpTxt.text = hp.ToString();
            if (hp-value <= 0)
            {
                Die();
            }
            
        }
    }

    private int dmg;

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
    public void DotDeal()
    {
        Hp -= 30;
        while (Time.deltaTime<dotDealDuration)
        {
            Hp -= 3;
        }
    }
    private void Die()
    {
        if (enemyType == EnemyType.Boos) SceneManager.LoadScene("Clear");
        GameManager.Instance.Enemys.Remove(gameObject);
        gameObject.SetActive(false);
    }
    public void Attack()
    {
        Vector3 startPos = transform.position;
        transform.DOMove(GameManager.Instance.CatsSelect[0].transform.position, 0.5f).OnComplete(() =>
        {
            GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Hp = dmg;
            transform.DOMove(startPos, 0.2f);
        });
        //if (enemyType == EnemyType.Warrior)
        //{
        //}
        //else if (enemyType == EnemyType.Archer)
        //{

        //}
    }
    public void SpawnEnemy(EnemyType type)
    {
        enemyType = type;
        gameObject.GetComponent<Image>().sprite = EnemysImg[((int)enemyType)];
        State();
    }
    private void State()
    {
        switch (enemyType)
        {
            case EnemyType.Red:
                hp = 150;
                dmg = 10;
                break;
            case EnemyType.Yellow:
                hp = 75;
                dmg = 15;
                break;
            case EnemyType.Blue:
                hp = 50;
                dmg = 20;
                break;
            case EnemyType.Purple:
                hp = 10;
                dmg = 30;
                break;
            case EnemyType.Green:
                hp = 100;
                dmg = 12;
                break;
            case EnemyType.Boos:
                hp = 500;
                dmg = 30;
                break;
        }
        hpTxt.text = hp.ToString();
        dmgTxt.text = dmg.ToString();
    }
}
