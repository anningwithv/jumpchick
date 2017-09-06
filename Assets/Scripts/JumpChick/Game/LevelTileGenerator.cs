using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformBasic;

namespace JumpChick
{
    public class LevelTileGenerator : MonoBehaviour
    {
        public List<LevelTile> m_levels = new List<LevelTile>();

        private List<LevelTile> m_easyLevels = new List<LevelTile>();
        private List<LevelTile> m_normalLevels = new List<LevelTile>();
        private List<LevelTile> m_hardLevels = new List<LevelTile>();
        private List<LevelTile> m_curLevels = new List<LevelTile>();

        private readonly string LevelTilePath = "LevelTiles";

        private Transform m_target;

        private LevelTile m_curLastLevel;
        private Score m_score;

        void Start()
        {
            Init();
        }

        private void Update()
        {
            if (!GameBasic._game.IsRuning())
            {
                return;
            }

            if (NeedToSpawnNextLevel())
            {
                SpawnNextLevel();
            }
        }

        private void Init()
        {
            foreach (LevelTile level in m_levels)
            {
                if (level.m_type == LevelTile.LevelType.Easy)
                {
                    m_easyLevels.Add(level);
                }
                else if (level.m_type == LevelTile.LevelType.Normal)
                {
                    m_normalLevels.Add(level);
                }
                else if (level.m_type == LevelTile.LevelType.Hard)
                {
                    m_hardLevels.Add(level);
                }
            }

            m_target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
            m_score = GameController._instance.GetComponent<Score>();
        }

        private bool NeedToSpawnNextLevel()
        {
            if (m_curLastLevel == null)
                return true;

            if (m_target.position.y - m_curLastLevel.GetEndPos() < 30)
            {
                //Debug.Log ("need to spawn next obstacles");
                return true;
            }

            return false;
        }

        private void SpawnNextLevel()
        {
            GetCurList();

            int index = Random.Range(0, m_curLevels.Count);
            var levelPrefab = m_curLevels[index];
            Debug.Log("spawn obstacle name is: " + levelPrefab.name);

            //Transform prefab = PoolManager.Instance.SpawnObject(levelPrefab.transform);
            Transform prefab = (GameObject.Instantiate(levelPrefab.gameObject) as GameObject).transform ;
            if (m_curLastLevel == null)
            {
                prefab.position = new Vector3(0, -2, 0);
            }
            else
            {
                prefab.position = new Vector3(0, m_curLastLevel.GetEndPos(), 0);
            }
            //m_curLastObstacles = obstaclesObject.GetComponent<ObstaclesController>();
            m_curLastLevel = prefab.GetComponent<LevelTile>();
        }

        private void GetCurList()
        {
            m_curLevels = m_easyLevels;
            return;

            int score = m_score.GetScore();
            int random = Random.Range(0, 100);
            if (score < 300)
            {
                if (random < 90)
                {
                    m_curLevels = m_easyLevels;
                }
                else
                {
                    m_curLevels = m_normalLevels;
                }
            }
            else if (score >= 300 && score < 500)
            {
                if (random < 80)
                {
                    m_curLevels = m_easyLevels;
                }
                else
                {
                    m_curLevels = m_normalLevels;
                }
            }
            else if (score >= 500 && score < 700)
            {
                if (random < 50)
                {
                    m_curLevels = m_easyLevels;
                }
                else if (random >= 50 && random < 95)
                {
                    m_curLevels = m_normalLevels;
                }
                else
                {
                    m_curLevels = m_hardLevels;
                }
            }
            else if (score >= 700 && score < 1000)
            {
                if (random < 30)
                {
                    m_curLevels = m_easyLevels;
                }
                else if (random >= 30 && random < 95)
                {
                    m_curLevels = m_normalLevels;
                }
                else
                {
                    m_curLevels = m_hardLevels;
                }
            }
            else
            {
                if (random < 20)
                {
                    m_curLevels = m_easyLevels;
                }
                else if (random >= 20 && random < 95)
                {
                    m_curLevels = m_normalLevels;
                }
                else
                {
                    m_curLevels = m_hardLevels;
                }
            }
        }
    }
}
