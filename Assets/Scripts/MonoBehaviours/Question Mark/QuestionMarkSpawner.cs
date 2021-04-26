//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using Classes;
using UnityEngine;

namespace MonoBehaviours.Question_Mark
{
    public class QuestionMarkSpawner : MonoBehaviour
    {
        public GameObject questionMark;

        public float spawnDelay = 10f;
        public float spawnHeight = 50f;

        #region SPAWN_BORDER

        public float maxX;
        public float minX;
        public float maxZ;
        public float minZ;

        #endregion 

        private void Start()
        {
            //repeatedly spawn question mark
            InvokeRepeating(nameof(SpawnQuestionMark), spawnDelay, spawnDelay);
        }

        private void SpawnQuestionMark()
        {
            //instantiate question mark with random position and normal quaternion
            Instantiate(questionMark, GenerateRandomPosition(), Quaternion.identity);
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