using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    const int enemyTypeNum = 2;
    const int catsTypeNum = 5;
    const int starMax = 3;
    
    public List<GameObject> ActiveCat = new List<GameObject>();
    public List<GameObject> CatsSelect = new List<GameObject>();

    public List<GameObject> ActiveEnemys = new List<GameObject>();
    public List<GameObject> Enemys = new List<GameObject>();
    [SerializeField] private GameObject boss;

    int Count=0;
    public List<GameObject> Spell = new List<GameObject>(0);

    public GameObject stageSlect;

    private int Waeve = 1;
    [SerializeField] private TextMeshProUGUI waeveNum;
    private int money;
    [SerializeField] private TextMeshProUGUI moneyTxt;

    private bool isFighting = false;
    int locknum = 0;
    public int Money
    {
        get { return money; }
        set 
        {
            money += value; 
            moneyTxt.text = money.ToString();
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Money = 5;
        waeveNum.text = Waeve.ToString();
        foreach (var enemy in Enemys)
        {
            int enemyType = Random.Range(0, enemyTypeNum);
            enemy.SetActive(true);
            enemy.GetComponent<BasicEnemy>().SpawnEnemy((EnemyType)enemyType);
        }
        foreach (var cat in CatsSelect)
        {
            int catType = Random.Range(0, catsTypeNum);
            int star = Random.Range(0, starMax);
            cat.GetComponent<Cat>().SpawnCat(star, (CatType)catType);
        }
    }
    public void Lock(int num)
    {
        locknum = num;
    }
    public void Fight()
    {
        if (isFighting) return;
        isFighting = true;
        StartCoroutine(FightCoroutine());
    }
    private IEnumerator FightCoroutine()
    {
        if(Spell.Count > 0)
        {
            Spell[0].GetComponent<Spell>().SpellAbility();
            Destroy(Spell[0]); 
            Spell.Clear();
        }
        while (true)
        {
            if (Enemys.Count == 0 || CatsSelect.Count == 0) break;
            foreach (var cat in CatsSelect)
            {
                if (Enemys.Count == 0) break;
                cat.GetComponent<Cat>().Attack();
                yield return new WaitForSeconds(1f);
            }
            foreach (var enemy in Enemys)
            {
                if (CatsSelect.Count == 0) break;
                enemy.GetComponent<BasicEnemy>().Attack();
                yield return new WaitForSeconds(1f);
            }

        }
        if(CatsSelect.Count == 0)
        {
            isFighting = false;
            GameOver();
        }
        else if (Enemys.Count == 0)
        {
            isFighting = false;
            NextWave();
        }

    }
    private void GameOver()
    {
        print("Die");
    }
    private void NextWave()
    {
        locknum = 0;
        Money = 5;
        Count = 0;
        Waeve++;
        waeveNum.text = Waeve.ToString();
        Spell.Clear();
        foreach (var enemy in ActiveEnemys)
        {
            Enemys.Add(enemy);
            int enemyType = Random.Range(0, enemyTypeNum);
            Enemys[Count].SetActive(true);
            Enemys[Count].GetComponent<BasicEnemy>().SpawnEnemy((EnemyType)enemyType);
            Count++;
        }
        Count = 0;
        foreach (var cat in ActiveCat)
        {
            CatsSelect.Add(cat);
            int catType = Random.Range(0, 2);
            int star = Random.Range(0, 3);
            CatsSelect[Count].SetActive(true);
            CatsSelect[Count].GetComponent<Cat>().SpawnCat(star, (CatType)catType);
            Count ++;
        }
        Inventory.Instance.SpellDrop();
    }
    public void Reroll()
    {
        if (money > 0) Money = -1;
        else return;

        for (int i = 0; i < CatsSelect.Count; i++)
        {
            if (i != locknum - 1)
            {
                int catType = Random.Range(0, catsTypeNum);
                int star = Random.Range(0, starMax);
                CatsSelect[i].GetComponent<Cat>().SpawnCat(star, (CatType)catType);
            }
        }
    }
}
