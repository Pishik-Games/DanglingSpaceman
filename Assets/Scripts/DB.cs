
using UnityEngine;

public class DB : MonoBehaviour
{
    private static string LastUnlockedLevelKey = "LastUnlockedLevel";

    private static string CoinsKey = "Coins";

    private static string LevelKey = "Level";
    void Awake()
    {
        //PlayerPrefs.DeleteAll(); //TODO Remove This Just For Test
        if (!PlayerPrefs.HasKey(LastUnlockedLevelKey))
        {
            PlayerPrefs.SetInt(LastUnlockedLevelKey, 0);
        }
    }
    public static void SetLevelData(int LevelId, int CoinEarned, int AllCoinsInLevel)
    {
        // if Save and Earn >= All
        if (PlayerPrefs.GetInt(LevelKey + LevelId) + CoinEarned > AllCoinsInLevel)
        {
            PlayerPrefs.SetInt(LevelKey + LevelId.ToString(), AllCoinsInLevel);
        }
        else// if Save And Earn < All
        {
            PlayerPrefs.SetInt(LevelKey + LevelId.ToString(), PlayerPrefs.GetInt(LevelKey + LevelId) + CoinEarned);
        }

        if (PlayerPrefs.GetInt(LastUnlockedLevelKey) == LevelId)
        {
            PlayerPrefs.SetInt(LastUnlockedLevelKey, LevelId + 1);

        }
        else
        {

        }

        Debug.Log("SetLevelData " + PlayerPrefs.GetInt(LevelKey + LevelId.ToString())
                + CoinsKey + PlayerPrefs.GetInt(CoinsKey).ToString()
         );
    }

    public static string LoadLevelData(int LevelId)
    {
        var Packet = LevelKey + LevelId +
        "/" +
        PlayerPrefs.GetInt(LevelKey + LevelId.ToString()).ToString();
        return Packet;
    }

    public static int loadLastUnlockedLevel()
    {
        return (PlayerPrefs.GetInt(LastUnlockedLevelKey));
    }

    public static int LoadNumberOfEarnedCoins()
    {
        var Bool = true;
        int Sum = 0;
        var lvlID = 0;
        while (Bool)
        {
            if (PlayerPrefs.HasKey(LevelKey + lvlID.ToString()))
            {
                Sum += PlayerPrefs.GetInt(LevelKey + lvlID.ToString());
                lvlID++;
            }
            else
            {
                Bool = false;
                break;
            }
        }
        PlayerPrefs.SetInt(CoinsKey, Sum);
        return (PlayerPrefs.GetInt(CoinsKey));
    }

    public static int LoadLevelEarnedCoins(int levelId){
        return PlayerPrefs.GetInt(LevelKey + levelId.ToString());
    }


    public static float getLevelPisPis(int level){

        switch(level){
            case 0: return 100f;
            case 1: return 3f;
            case 2: return 3.5f;
            case 3: return 3f;
            case 4: return 3f;
            case 5: return 1.4f;
            case 6: return 1.5f;
            case 7: return 1.6f;
            case 8: return 1.2f;
            case 9: return 1.2f;
            case 10: return 1.4f;
            case 11: return 1.4f;
            case 12: return 1.1f;
            case 13: return 1.4f;
            case 14: return 1.3f;
            default: return 100f;
        }
    }
}