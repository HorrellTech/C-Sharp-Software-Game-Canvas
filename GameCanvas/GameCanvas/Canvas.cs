/*
 * The canvas is used to draw everything. We will handle the Game Objects in here aswell
 * to keep the number of classes to a minimum.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCanvas
{
    public partial class Canvas : PictureBox
    {
        // Delegates for being able to directly access the game loop do do our own drawing
        public delegate void OnLoop(object sender);
        public delegate void OnDraw(object sender);
        public delegate void OnDrawGui(object sender);
        public event OnLoop Loop;
        public event OnDraw Draw;
        public event OnDrawGui DrawGui;

        private List<GameObject> objects = new List<GameObject>(); // Store a list of Game Objects

        public int FPS = 30; // The frames per second
        public int ViewX = 0; // The viewport X position
        public int ViewY = 0; // The viewport Y position
        public int ViewW = 320; // The viewport width
        public int ViewH = 240; // The viewport height
        public Color BackgroundColor = Color.LightGray; // The background clear color

        //private Graphics g; // Main drawing graphics to show the drawn frames
        private Graphics bufferGraphics; // The buffer graphics we will draw to
        private Bitmap bufferImage; // The image we will call on

        private Timer gameLoop; // The main game loop

        // Constructor
        public Canvas()
        {
            InitializeComponent();

            ResizeViewPort(ViewW, ViewH);

            gameLoop = new Timer(); // Create the game loop timer

            gameLoop.Interval = 1000 / FPS;
            gameLoop.Tick += GameLoop_Tick;

            gameLoop.Enabled = true;

            // Make the game view adjust for window size, and keep Aspect ratio
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Main Loop
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            var fpsOld = FPS; // Store the current FPS

            // Clear the canvas
            bufferGraphics.Clear(BackgroundColor);

            // DO STUFF Here

            // Perform the loop event on the objects
            if(objects.Count > 0) // If there are objects in the list
            {
                for(var i = 0; i < objects.Count; i++) // Loop through the objects
                {
                    var ob = objects[i];
                    if(ob.Instances.Count > 0)
                    {
                        for(var j = 0; j < ob.Instances.Count; j++)
                        {
                            ob.Instances[j].LoopEvent();
                        }
                    }
                }
            }

            // Perform the users custom Loop
            if(Loop != null)
            {
                Loop(this);
            }

            // Perform the draw event on the objects
            if (objects.Count > 0) // If there are objects in the list
            {
                for (var i = 0; i < objects.Count; i++) // Loop through the objects
                {
                    var ob = objects[i];
                    if (ob.Instances.Count > 0)
                    {
                        for (var j = 0; j < ob.Instances.Count; j++)
                        {
                            ob.Instances[j].DrawEvent();
                        }
                    }
                }
            }

            // Perform the users custom Draw
            if(Draw != null)
            {
                Draw(this);
            }

            // Perform the users custom Draw GUI (Will draw over top of everything
            if (DrawGui != null)
            {
                DrawGui(this);
            }

            bufferGraphics.DrawLine(Pens.Red, 0, 0, ViewW, ViewH);

            // Draw the image to the canvas
            //g.DrawImage(bufferImage, 0, 0, Width, Height);
            Image = bufferImage;

            // If the FPS changes mid way through the simulation, then update the change
            if (FPS != fpsOld)
            {
                gameLoop.Interval = FPS;
            }
        }

        /// <summary>
        /// Resize the ViewPort for the game. DO NOT resize the ViewPort using the variables
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void ResizeViewPort(int width, int height)
        {
            //g = CreateGraphics(); // Create the main graphics

            // Dispose of the old graphics
            if(bufferImage != null)
            {
                bufferImage.Dispose();
                bufferImage = null;
            }
            if (bufferGraphics != null)
            {
                bufferGraphics.Dispose();
                bufferGraphics = null;
            }

            ViewW = width;
            ViewH = height;

            // Create new graphics
            bufferImage = new Bitmap(ViewW, ViewH); // Create the buffer image based on the width and height of the Canvas
            bufferGraphics = Graphics.FromImage(bufferImage); // Link the drawing buffer graphics to the bitmap
        }

        /// <summary>
        /// Return the graphics object for direct drawing to the canvas
        /// </summary>
        public Graphics GetGraphics
        {
            get { return (bufferGraphics); }
        }
    }
}
