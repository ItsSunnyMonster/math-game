//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using System.Collections;
using MonoBehaviours.Questions;
using UnityEngine;

namespace MonoBehaviours.Question_Mark
{
    public class QuestionMark : MonoBehaviour
    {
        private QuestionGenerator _questionGenerator;
        private QuestionMarkSpawner _questionMarkSpawner;
        
        public Rigidbody questionMarkRigidBody;
        public GameObject minimapIndicator;
        public MeshRenderer meshRenderer;

        private void Awake()
        {
            //disappear completely
            minimapIndicator.SetActive(false);
            meshRenderer.enabled = false;
            
            //gets question generator
            _questionGenerator = FindObjectOfType<QuestionGenerator>();
            if (_questionGenerator == null)
            {
                Debug.LogException(new NullReferenceException("QuestionGenerator not found! "));
                Destroy(gameObject);
            }

            //gets question mark spawner
            _questionMarkSpawner = FindObjectOfType<QuestionMarkSpawner>();
            if (_questionMarkSpawner == null)
            {
                Debug.LogException(new NullReferenceException("QuestionMarkGenerator not found! "));
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            //if question mark landed on something like trees and houses
            if (collision.collider.CompareTag("Question Mark Not Available"))
            {
                //go to another position. it does the landing check again when it collides with something
                transform.position = _questionMarkSpawner.GenerateRandomPosition();
            }
            //if landed on ground, disable rigidbody and runs after destroy routine
            else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Destroy(questionMarkRigidBody);
                StartCoroutine(AfterDestroy());
            }
        }

        private IEnumerator AfterDestroy()
        {
            //wait one frame (after the destroy is done)
            yield return null;
            
            //set collider to be trigger
            var questionMarkCollider = GetComponent<Collider>();
            questionMarkCollider.isTrigger = true;
            
            //appear in the scene
            minimapIndicator.SetActive(true);
            meshRenderer.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            //display question if touching player
            if (other.CompareTag("Player"))
            {
                _questionGenerator.DisplayQuestion();
            }
        }
    }
}