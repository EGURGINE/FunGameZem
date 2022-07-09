using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public enum EnemyType
{
    Archer,
    Warrior
}
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private Sprite[] EnemysImg;

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
        Debug.Log("die");
        GameManager.Instance.Enemys.Remove(gameObject);
        gameObject.SetActive(false);
    }
    public void Attack()
    {
        Vector3 startPos = transform.position;
        transform.DOMove(GameManager.Instance.CatsSelect[0].transform.position, 0.5f).OnComplete(() =>
        {
            transform.DOMove(startPos, 0.2f);
        });
        GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Hp = dmg;
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
            case EnemyType.Warrior:
                hp = 150;
                dmg = 10;
                break;
            case EnemyType.Archer:
                hp = 75;
                dmg = 15;
                break;
        }
    }
}
