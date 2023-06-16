
using UnityEngine;

public class Badge : MonoBehaviour{
    
    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;


    public void clear(){
        gold.SetActive(false);
        silver.SetActive(false);
        bronze.SetActive(false);
    }
    public void onGold(){
        clear();
        gold.SetActive(true);
    }
    public void onSilver(){
        clear();
        silver.SetActive(true);
    }
    public void onBronze(){
        clear();
        bronze.SetActive(true);
    }

}