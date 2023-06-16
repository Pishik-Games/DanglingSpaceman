
using UnityEngine;

public class Badge : MonoBehaviour{
    
    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;

    public void onGold(){
        gold.SetActive(true);
        silver.SetActive(false);
        bronze.SetActive(false);
    }
    public void onSilver(){
        gold.SetActive(false);
        silver.SetActive(true);
        bronze.SetActive(false);
    }
    public void onBronze(){
        gold.SetActive(false);
        silver.SetActive(false);
        bronze.SetActive(true);
    }

}