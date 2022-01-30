using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    private List<GameObject> _numbersPool = new List<GameObject>();
    public GameObject NumberPrefab;
    public int AmountToPool = 50;
    public int MaxNumbersToSpawn = 10;

    public int MinX = 4;
    public int MaxX = 24;
    public int MaxY = 12;

    private List<GameObject> _numbersSpawned = new List<GameObject>();

    private void Awake() 
    {
        GameObject tmp;
        for(int i = 0; i< AmountToPool; i++)
        {
            tmp = Instantiate(NumberPrefab);
            tmp.SetActive(false);
            _numbersPool.Add(tmp);
        }
    }

    private GameObject GetNumberFromPool()
    {
        for(int i = 0; i< AmountToPool; i++)
        {
            if(!_numbersPool[i].activeInHierarchy)
            {
                return _numbersPool[i];
            }
        }
        return null;
    }

    public void SpawnNumbers(int finalNumber)
    {
        Debug.Log("Final Num: " + finalNumber);
        int amountLeft = finalNumber;
        int[] numberVals = new int[MaxNumbersToSpawn + 2];  //Adding 2 for 2 random ones.
        int numbersFilled = 0;
        for(int i = 0; i < MaxNumbersToSpawn - 1; i++)
        {
            Debug.Log(i + " **** Amount Left: " + amountLeft);

            if(amountLeft < 2) //Nothing left
            {
                Debug.Log(i + ": amountLeft is less than 2: " + amountLeft);
                break;
            }
            else if(amountLeft > 50) //Breaks down bigger numbers so we don't get big number values
            {
                int dividedAmount = amountLeft/2;
                numberVals[i] = Random.Range(1, dividedAmount);
                Debug.Log(i + ": New num created: " + amountLeft + " - " + numberVals[i] + " used diveded val " + dividedAmount);
            }
            else
            {
                numberVals[i] = Random.Range(1, amountLeft);
                Debug.Log(i + ": New num created: " + amountLeft + " - " + numberVals[i] + " : ");
            }
            
            numbersFilled ++;
            amountLeft -= numberVals[i];
            Debug.Log("Filled numbers: " + numbersFilled);
            Debug.Log("###### Amount Left: " + amountLeft);
        }

        //If there's still some amount left fill the last one with it OR it will fill it with a random number
        if(amountLeft > 0)
        {
            Debug.Log(numbersFilled + ": SOME AMOUNT IS LEFT: " + amountLeft);
            numberVals[numbersFilled] = amountLeft;
            numbersFilled ++;
        }
        
        //If we didn't use all MaxNumbersToSpawn to add up to the number throw in some random ones
        Debug.Log("Filled numbers: " + numbersFilled + "/" + MaxNumbersToSpawn);
        for(int i = numbersFilled; i < numberVals.Length; i++)
        {
            numberVals[i] = Random.Range(1, finalNumber/2);
            Debug.Log(i + "Filled numbers: " + numberVals[i]);
        }

        int addRandomNumberAt1 = Random.Range(0, numberVals.Length);
        int addRandomNumberAt2 = Random.Range(0, numberVals.Length);

        Debug.Log("Spawn duplicate numbs: " + addRandomNumberAt1 + " & " + addRandomNumberAt2);

        for(int i = 0; i < numberVals.Length - 1; i++)
        {
            bool addDuplicate = i == addRandomNumberAt1 || i == addRandomNumberAt2? true : false;

            //Left side number
            float xVal = Random.Range(MinX * -1, MaxX * -1);
            float yVal = Random.Range(MaxY * -1, MaxY);
            Debug.Log(numberVals[i] + ": xVal:" + xVal + ", yVal:" + yVal);
            Vector3 spawnPoint = new Vector3(xVal, yVal, 0);
            Vector3 lSideNumber = ActivateNumber(numberVals[i], spawnPoint);
            
            //Right side number
            xVal = Random.Range(MinX, MaxX);
            yVal = Random.Range(MaxY * -1, MaxY);
            Debug.Log(numberVals[i] + ": xVal:" + xVal + ", yVal:" + yVal);
            spawnPoint = new Vector3(xVal, yVal, 0);
            Vector3 rSideNumber = ActivateNumber(numberVals[i] * -1, spawnPoint);

            if(addDuplicate)
            {
                Debug.Log("Add duplicate: " + numberVals[i]);
                if(i % 2 == 0) //Duplicate the left side on the right
                {
                    spawnPoint = new Vector3(lSideNumber.x * -1, lSideNumber.y, lSideNumber.z);
                    ActivateNumber(numberVals[i] * -1, spawnPoint);
                }
                else //Duplicate the right side
                {
                   spawnPoint = new Vector3(rSideNumber.x * -1, rSideNumber.y, rSideNumber.z);
                   ActivateNumber(numberVals[i] , spawnPoint);
                }
            }

        }
    }

    public Vector3 ActivateNumber(int numberValue, Vector3 spawnPoint)
    {
        GameObject newNum = GetNumberFromPool();
        newNum.transform.position = spawnPoint;
        newNum.GetComponent<Number>().Value = numberValue;
        newNum.SetActive(true);
        _numbersSpawned.Add(newNum);
        return newNum.transform.position;
    }

    public void ResetNumbers()
    {
        for(int i = 0; i < _numbersSpawned.Count - 1; i++)
        {
            _numbersSpawned[i].SetActive(true);
        }
    }
}
