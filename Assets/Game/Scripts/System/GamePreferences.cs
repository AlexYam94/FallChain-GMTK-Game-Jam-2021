using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences  {
	public static string EasyDifficulty = "EasyDifficulty";
	public static string HardDifficulty = "HardDifficulty";
	public static string MediumDifficulty = "MediumDifficulty";

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";

	//NOTE wea are going to use integer to represent boolean variables
	//0 = false, 1 = true

	public static void SetMusicState(int state){
		PlayerPrefs.SetInt (IsMusicOn, state);
	}

	public static int GetMusicState(){
	 	return	PlayerPrefs.GetInt (IsMusicOn);
		}

	public static void SetEasyDifficultyState(int difficulty){
		PlayerPrefs.SetInt (GamePreferences.EasyDifficulty, difficulty);
	}

	public static int GetEasyDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficulty);
	}

	public static void SetMediumDifficultyState(int difficulty){
		PlayerPrefs.SetInt (GamePreferences.MediumDifficulty, difficulty);
	}

	public static int GetMediumDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficulty);
	}

	public static void SetHardDifficultyState(int difficulty){
		PlayerPrefs.SetInt (GamePreferences.HardDifficulty, difficulty);
	}

	public static int GetHardDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficulty);
	}

	public static void SetEasyDifficultyHighScore(int score){
		PlayerPrefs.SetInt (EasyDifficultyHighScore, score);
	}

	public static int GetEasyDifficultyHighScore(){
		return PlayerPrefs.GetInt (EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore(int score){
		PlayerPrefs.SetInt (MediumDifficultyHighScore, score);
	}

	public static int GetMediumDifficultyHighScore(){
		return PlayerPrefs.GetInt (MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore(int score){
		PlayerPrefs.SetInt (HardDifficultyHighScore, score);
	}

	public static int GetHardDifficultyHighScore(){
		return PlayerPrefs.GetInt (HardDifficultyHighScore);
	}

	public static void SetEasyDifficultyCoinScore(int coin){
		PlayerPrefs.SetInt (EasyDifficultyCoinScore, coin);
	}

	public static int GetEasyDifficultyCoinScore(){
		return PlayerPrefs.GetInt (EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore(int coin){
		PlayerPrefs.SetInt (MediumDifficultyCoinScore, coin);
	}

	public static int GetMediumDifficultyCoinScore(){
		return PlayerPrefs.GetInt (MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore(int coin){
		PlayerPrefs.SetInt (HardDifficultyCoinScore, coin);
	}

	public static int GetHardDifficultyCoinScore(){
		return PlayerPrefs.GetInt (HardDifficultyCoinScore);
	}
}
