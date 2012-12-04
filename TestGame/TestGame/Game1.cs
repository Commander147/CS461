using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//Github update test5

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //This is a test push
        SceneManager scenemanager;
        GraphicsDeviceManager graphics;
        SpriteBatch spritebatch;
        Video video;
        VideoPlayer player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = @"Monsterpalooza";
            this.Exiting += Game1_Exiting;
        }

        protected override void Initialize()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = 240 * 3;
            graphics.ApplyChanges();
            scenemanager = new SceneManager(Content, graphics.GraphicsDevice);
            //scenemanager.addScene(new PlaygroundScene(0,0,320,480,Content, graphics.GraphicsDevice));
            string[] menuText = { "New Game", "Continue", "Settings", "End Game" };
            Scene[] menuDest = new Scene[1];
            menuDest[0] = new PlaygroundScene(0, 0, 320, 480, Content, graphics.GraphicsDevice, scenemanager);
            scenemanager.addScene(new MainMenu(0, 0, 320, 480, Content, graphics.GraphicsDevice, scenemanager, menuText, menuDest));
            //add Menu screen here
            player = new VideoPlayer();
            video = Content.Load<Video>("Video/Intro");
            player.Play(video);
        }

        protected override void LoadContent()
        {

        }

        protected override void UnloadContent()
        {
            scenemanager.UnloadContent();
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (scenemanager.exit)
            {
                this.Exit();
            } 
            else
            {
                scenemanager.Update(gameTime);
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            Texture2D videoTexture = null;

            if (player.State != MediaState.Stopped)
            {
                videoTexture = player.GetTexture();
                if (videoTexture != null)
                {
                    spritebatch.Begin();
                    spritebatch.Draw(videoTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                    spritebatch.End();
                }

            }
            else
            {
                this.IsMouseVisible = true;
                scenemanager.Draw(gameTime);
            }
            base.Draw(gameTime);
        }

        void Game1_Exiting(object sender, EventArgs e)
        {
            Console.WriteLine("Exit");
            player.Dispose();
            scenemanager.exit = true;
            scenemanager.UnloadContent();
        }
    }
}
