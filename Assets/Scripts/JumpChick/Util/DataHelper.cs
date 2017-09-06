using UnityEngine;
using System.Collections;

namespace JumpChick
{
    public class DataHelper : MonoBehaviour
    {

        public const bool ENABLE_ENCRYPT = false;

        public const string SCORE = "score";
        public const string CHARACTER = "character";
        public const string DIAMOND = "diamond";
        public const string CHARACTERS = "characters";
        public const string MUSIC = "music";

        public static void SaveScore(int score)
        {
            if (score > GetScore())
            {
                string str = score.ToString();
                SaveString(str, SCORE);
            }
        }

        public static int GetScore()
        {
            int score = 0;
            string chaStr = GetString(SCORE);
            if (chaStr != "")
            {
                score = int.Parse(chaStr);
            }
            return score;
        }

        public static void SaveMusic(bool music)
        {
            string str = music.ToString();
            SaveString(str, MUSIC);
        }

        public static bool GetMusic()
        {
            bool musicOn = false;
            string chaStr = GetString(MUSIC);
            if (chaStr != "")
            {
                musicOn = bool.Parse(chaStr);
            }
            return musicOn;
        }

        public static void SaveDiamond(int diamond)
        {
            if (diamond > 999)
                diamond = 999;
            string str = diamond.ToString();
            SaveString(str, DIAMOND);
        }

        public static void AddDiamond(int diamond)
        {
            int curDiamond = GetDiamond();
            int result = curDiamond + diamond;
            if (result < 0)
                result = 0;
            SaveDiamond(result);
        }

        public static int GetDiamond()
        {
            int diamond = 0;
            string chaStr = GetString(DIAMOND);
            if (chaStr != "")
            {
                diamond = int.Parse(chaStr);
            }
            return diamond;
        }

        private static void SaveString(string content, string tag)
        {
            PlayerPrefs.SetString(tag, content);
        }

        private static string GetString(string tag)
        {
            string str = PlayerPrefs.GetString(tag);

            return str;
        }
    }
}
