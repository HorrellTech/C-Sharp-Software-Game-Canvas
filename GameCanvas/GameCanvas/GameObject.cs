/*
 * Game objects are important for a basic way of handling everything in the game world.
 * 
 * This can be a player, enemy, wall, anything you desire. The object is like a casing,
 * where an Instance of the object will be like a clone, which you will be able to access
 * in the game world.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCanvas
{
    public class GameObject
    {
        // Delegates for the main events
        public delegate void OnLoop();
        public delegate void OnDraw();
        public event OnLoop Loop;
        public event OnDraw Draw;

        private List<GameObject> instances = new List<GameObject>(); // Store a list of instances based off this Game Object

        public float X = 0; // X Position
        public float Y = 0; // Y Position
        public float Depth = 0; // The Z Buffer Depth

        // Constructor
        public GameObject()
        {
        }

        // The event that the canvas will call to loop through game logic
        public void LoopEvent()
        {
            if (Loop != null)
            {
                Loop();
            }
        }

        // The event that the canvas will call to loop through game drawing
        public void DrawEvent()
        {
            if(Draw != null)
            {
                Draw();
            }
        }

        /// <summary>
        /// Return a list of the instances within the object
        /// </summary>
        public List<GameObject> Instances
        {
            get { return (instances); }
        }
    }
}
