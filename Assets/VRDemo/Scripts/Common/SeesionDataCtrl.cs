using UnityEngine;

namespace VRDemo.Common
{
	// This class is used to keep time during a game and save
	// the best time to PlayerPrefs.
	public static class SeeionDataCtrl
	{
		// This enum shows all the types of games that use scores.
		public enum GameType
		{
			//积木游戏
			BRICK,
			//漫游游戏
			ROAM
		};
			
		private const string k_brickData = "brickData";
		private const string k_roamData = "roamData";
		private const string k_leftHandTag = "LeftHand";
		private const string k_rightHandTag = "RightHand";

		private const int k_idxOfBrickScene = 0;
		private const int k_ideOfRoamScene = 1;

		private const string k_ui_forward = "UI_Forward";
		private const string k_ui_back = "UI_Back";
		private const string k_ui_left = "UI_Left";
		private const string k_ui_right = "UI_Right";




		private static float s_bestTime;                            // Used to store the best time for the current game type.
		private static float s_time;                                 // Used to time the current game's finish tme.
		private static string s_CurrentGame;                        // The name of the current game type.


		public static float BestTime { get { return s_bestTime; } }
		public static float Time { get { return s_time; } }
		public static string LeftHand{get{ return k_leftHandTag;}}
		public static string RightHand{get{ return k_rightHandTag;}}

		public static int  BrickSceneIdx{get{ return k_idxOfBrickScene;}}
		public static int  RoamSceneIdx{get{ return k_ideOfRoamScene;}}

		public static string UIForward {get{return k_ui_forward;}}
		public static string UIBack {get{return k_ui_back;}}
		public static string UILeft {get{return k_ui_left;}}
		public static string UIRight {get{return k_ui_right;}}


		public static void SetGameType(GameType gameType)
		{
			// Set the name of the current game based on the game type.
			switch (gameType)
			{
			case GameType.BRICK:
				s_CurrentGame = k_brickData;
				break;
			case GameType.ROAM:
				s_CurrentGame = k_roamData;
				break;
			default:
				Debug.LogError("Invalid GameType");
				break;
			}

			restart();
		}


		public static void restart()
		{
			// Reset the current time and get the best time from player prefs.
			s_time = 0;
			s_bestTime= getBestTime();
		}


		public static void setGamTime(float time)
		{
			//set to the best time
			s_time = time;
			checkBestTime();
		}


		public static float getBestTime()
		{
			// Get the value of the best time from the game name.
			return PlayerPrefs.GetFloat(s_CurrentGame, float.MaxValue);
		}


		private static void checkBestTime()
		{
			// If the current time is greater than the best time then set the best time.
			if (s_time < s_bestTime)
				setBestTime();
		}


		private static void setBestTime()
		{
			// Make sure the name of the current game has been set.
			if (string.IsNullOrEmpty(s_CurrentGame))
				Debug.LogError("m_CurrentGame not set");

			// The best time is now equal to the current score.
			s_bestTime = s_time;

			// Set the best time for the current game's name and save it.
			PlayerPrefs.SetFloat(s_CurrentGame, s_time);
			PlayerPrefs.Save();
//			Debug.Log ("best time is" + s_bestTime);
		}
	}
}

