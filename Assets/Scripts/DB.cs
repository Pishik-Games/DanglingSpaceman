
using UnityEngine;

public class DB : MonoBehaviour
{
    private static string LastUnlockedLevelKey = "LastUnlockedLevel";

    private static string CoinsKey = "Coins";

    private static string LevelKey = "Level";
    void Awake()
    {
        PlayerPrefs.SetInt(LastUnlockedLevelKey, 0);
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
            PlayerPrefs.SetInt(CoinsKey, PlayerPrefs.GetInt(CoinsKey) + PlayerPrefs.GetInt(LevelKey + LevelId));
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
        return (PlayerPrefs.GetInt(CoinsKey));
    }

}