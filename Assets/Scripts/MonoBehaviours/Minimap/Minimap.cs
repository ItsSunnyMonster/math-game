using System;
using UnityEngine;

namespace MonoBehaviours.Minimap
{
    public class Minimap : MonoBehaviour
    {
        public Transform player;

        public float cameraOffset = 0f;

        private void LateUpdate()
        {
            var newPosition = player.localPosition;
            newPosition.y = transform.position.y;
            newPosition += cameraOffset * player.forward;
            transform.position = newPosition;
            
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
    }
}