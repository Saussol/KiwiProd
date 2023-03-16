using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    private int realGolds;

    public TextMeshProUGUI goldText;

    public GameObject[] miners;
    private int inGame = 0;

    public GameObject[] enemys;


    public void OnClickBuyMiner(int _cost)
    {
        if (_cost <= realGolds && inGame != 4)
        {
            miners[inGame].SetActive(true);
            inGame++;
            realGolds += -_cost;
            goldText.text = "Gold : " + realGolds;
        }
        else
        {
            Debug.Log("Taaaaaa pas de thune fils de pute");
        }
    }


    void CostGold(int _cost)
    {
        if (_cost <= realGolds)
        {
            realGolds =- _cost;
            goldText.text = "Gold : " + realGolds;
        }
        else
        {
            Debug.Log("Taaaaaa pas de thune fils de pute");
        }
    }

    private void Start()
    {
        StartCoroutine(WaitAndPrint(5f));
        for (int i = 0; i < miners.Length; i++)
        {
            miners[i].SetActive(false);
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        realGolds += 25;
        goldText.text = "Gold : " + realGolds;

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(WaitAndPrint(5f));
    }
}
