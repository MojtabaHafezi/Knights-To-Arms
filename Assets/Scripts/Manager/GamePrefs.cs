using UnityEngine;
using System.Collections;

public class GamePrefs : MonoBehaviour
{

	public static string SPLASHSCREEN = "00 Splash";
	public static string MAINMENU = "01 MainMenu";
	public const string COINS = "Coins";
	public static string TUTORIAL = "Tutorial";


	public static void SetCoins (int coins)
	{
		PlayerPrefs.SetInt (COINS, coins);
		PlayerPrefs.Save ();
	}

	public static int GetCoins ()
	{
		return PlayerPrefs.GetInt (COINS, 0);
	}
}
