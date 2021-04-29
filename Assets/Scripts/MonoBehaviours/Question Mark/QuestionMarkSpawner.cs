//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MonoBehaviours.Question_Mark
{
    public class QuestionMarkSpawner : MonoBehaviour
    {
        public GameObject questionMarkPeaceful;
        public GameObject questionMarkHostile;
        public Transform parent;

        public float spawnHeight = 50f;
        [Range(0f, 1f)]
        public float hostileRate = 0.5f;
        [Range(0f, 100f)]
        public int questionMarksToSpawn;

        public List<GameObject> questionMarksInScene = new List<GameObject>();

        #region SPAWN_BORDER

        public float maxX;
        public float minX;
        public float maxZ;
        public float minZ;

        #endregion

        public delegate void OnRemoveDel();
        public event OnRemoveDel OnQuestionMarkListUpdate;

        private void OnValidate()
        {
            //clamp the values
            hostileRate = HelperFunctions.RoundToDecimalPlaces(hostileRate, 2);
        }

        private void Start()
        {
            //temporary spawn code
            for (var i = 0; i < questionMarksToSpawn; i++)
            {
                //spawn the question mark based on possibility
                SpawnQuestionMark();
            }
        }

        public void SpawnQuestionMark()
        {
            //generate random type
            var type = Random.Range(0, 101) >= hostileRate * 100
                ? QuestionMarkType.Peaceful
                : QuestionMarkType.Hostile;
            
            //spawn question mark with QuestionMarkType
            switch (type)
            {
                case QuestionMarkType.Peaceful:
                    //instantiate question mark with random position and normal quaternion and add it to the list
                    questionMarksInScene.Add(Instantiate(questionMarkPeaceful, GenerateRandomPosition(),
                        Quaternion.identity, parent));
                    break;
                case QuestionMarkType.Hostile:
                    //instantiate question mark with random position and normal quaternion and add it to the list
                    questionMarksInScene.Add(Instantiate(questionMarkHostile, GenerateRandomPosition(),
                        Quaternion.identity, parent));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            foreach (var questionMark in questionMarksInScene)
            {
                questionMark.GetComponent<QuestionMark>().OnQuestionMarkDestroy -= RemoveQuestionMark;

                questionMark.GetComponent<QuestionMark>().OnQuestionMarkDestroy += RemoveQuestionMark;
            }
            
            OnQuestionMarkListUpdate?.Invoke();
        }

        private void RemoveQuestionMark(GameObject questionMarkToRemove)
        {
            questionMarksInScene.Remove(questionMarkToRemove);
            OnQuestionMarkListUpdate?.Invoke();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            //draw spawn boundary
            HelperFunctions.DrawBoundaryAsGizmos(maxX, minX, maxZ, minZ, spawnHeight);
        }

        public Vector3 GenerateRandomPosition()
        {
            //return random position given a boundary
            return new Vector3(Random.Range(minX, maxX), spawnHeight, Random.Range(minZ, maxZ));
        }
    }
}