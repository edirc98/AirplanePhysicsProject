using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


namespace AirplanePhysics.Feature
{

    public struct CollisionInfo
    {
        public CollisionInfo(Vector3 position, Vector3 normal)
        {
            collisionPoint = position;
            collisionNormal = normal;
        }

        public Vector3 collisionPoint;
        public Vector3 collisionNormal;
    }

    public class Airplane_Collisions : MonoBehaviour
    {

        public List<CollisionInfo> collisions = new List<CollisionInfo>();

        private void OnCollisionEnter(Collision collision)
        {
            //Check the conctacts so we know wich part of the plane an object collided

            for (int i = 0; i < collision.contacts.Length; i++) 
            {
                CollisionInfo newCollision = new CollisionInfo(collision.contacts[i].point, collision.contacts[i].normal);
                collisions.Add(newCollision);
            }
        }


        private void OnDrawGizmos()
        {
            if (collisions.Count > 0) 
            {
                foreach (CollisionInfo collision in collisions) 
                {
                    //Draw Point
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawSphere(collision.collisionPoint, 0.1f);
                    //DrawNormal
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawRay(collision.collisionPoint, collision.collisionNormal);
                }
            }
        }
    }
}

