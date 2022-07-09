using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  
public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    const int enemyTypeNum = 2;
    const int catsTypeNum = 10;
    const int starMax = 3;
    
    public List<GameObject> ActiveCat = new List<GameObject>();
    public List<GameObject> CatsSelect = new List<GameObject>();

    public List<GameObject> ActiveEnemys = new List<GameObject>();
    public List<GameObject> Enemys = new List<GameObject>();
    int Count=0;


    public List<GameObject> Spell = new List<GameObject>(0);

    public GameObject stageSlect;

    private int Wave = 1;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (var enemy in Enemys)
        {
            int enemyType = Random.Range(0, enemyTypeNum);
            enemy.SetActive(true);
            enemy.GetComponent<BasicEnemy>().SpawnEnemy((EnemyType)enemyType);
        }
        foreach (var cat in CatsSelect)
        {
            int catType = Random.Range(0, 3);
            //int catType = Random.Range(0, catsTypeNum);
            int star = Random.Range(0, starMax);
            cat.GetComponent<Cat>().SpawnCat(star, (CatType)catType);
        }
    }

    public void Fight()
    {
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
            GameOver();
        }
        else if (Enemys.Count == 0)
        {
            NextWave();
        }

    }
    private void GameOver()
    {
        print("Die");
    }
    private void NextWave()
    {
        Count = 0;
        Wave++;
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
            //int catType = Random.Range(0, catsTypeNum);
            CatsSelect[Count].GetComponent<Cat>().SpawnCat(star, (CatType)catType);
            Count ++;
        }
    }
    public void Reroll()
    {
        foreach (var cat in CatsSelect)
        {
            int catType = Random.Range(0, 3);

            //int catType = Random.Range(0, catsTypeNum);
            int star = Random.Range(0, starMax);
            cat.GetComponent<Cat>().SpawnCat(star, (CatType)catType);
        }
    }
}
