using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Timers;

namespace NoArt
{
    public class NoArtGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int counter;
        bool isFadeIn;
        float fadeAlpha;

        int scene;
        /*
         * Scenes:
         *     0 = Intro
         *     1 = Menu
         *     2 = Game
         *     3 = Credits
         *     4 = ?
         */

        SpriteFont PoiretOne;
        Vector2 ScreenCenterVector;
        Texture2D bg;

        int ScreenCenterX;
        int ScreenCenterY;

        int ScreenWidth;
        int ScreenHeight;

        int GameWidth;
        int GameHeight;

        int playerX;
        int playerY;
        int playerW;
        int playerH;

        bool controlsAreLocked;

        #region START
        public NoArtGame() : base() {

            ScreenWidth = 1280;
            ScreenHeight = 720;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
        }

        protected override void Initialize()
        {
            fadeAlpha = 1f;
            isFadeIn = true;
            counter = scene = 0;
            controlsAreLocked = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PoiretOne = Content.Load<SpriteFont>("Fonts\\PoiretOne");
            bg = Content.Load<Texture2D>("Images\\w");

            GameWidth = graphics.GraphicsDevice.Viewport.Width;
            GameHeight = graphics.GraphicsDevice.Viewport.Height;
            ScreenCenterX = GameWidth / 2;
            ScreenCenterY = GameHeight / 2;
            ScreenCenterVector = new Vector2(ScreenCenterX, ScreenCenterY);

            playerX = ScreenCenterX;
            playerY = ScreenCenterY;
            playerW = playerH = 1;
        }
        #endregion

    //----------------------------//
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }

            if (scene == 0) {
                updateIntro(gameTime);
            } else if (scene == 1) {
                updateGame(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (scene == 0) {
                drawIntro(gameTime);
            } else if (scene == 1) {
                drawGame(gameTime);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

    //----------------------------//

        #region INTRO
        void drawIntro(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            Vector2 FontOrigin = PoiretOne.MeasureString("NoArt") / 2;
            spriteBatch.DrawString(
                PoiretOne,          // SpriteFont
                "NoArt",            // Text
                ScreenCenterVector, // Position
                Color.Black,        // Color
                0,                  // Rotation
                FontOrigin,         // Origin
                1.0f,               // Scale
                SpriteEffects.None, // Effects (flip)
                0.5f);              // Layer

            spriteBatch.Draw(bg, new Rectangle(0, 0,
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height), Color.White * fadeAlpha);
        }
        void updateIntro(GameTime gameTime)
        {
            counter++;

            if (counter >= 100 && counter % 2 == 0) {
                fadeAlpha = (fadeAlpha > 0 && isFadeIn) ? fadeAlpha - 0.05f
                        : (fadeAlpha < 1 && !isFadeIn) ? fadeAlpha + 0.05f
                        : fadeAlpha;
                fadeAlpha = fadeAlpha < 0 ? 0 : fadeAlpha > 1 ? 1 : fadeAlpha;
            } else if (counter == 255) {
                isFadeIn = false;
            } else if (counter == 399) {
                counter = 0;
                fadeAlpha = 1f;
                scene = 1;
            }
        }
        #endregion

        #region GAME
        void drawGame(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            spriteBatch.Draw(bg, new Rectangle(playerX, playerY, playerW, playerH), null, Color.Gray, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
        }
        void updateGame(GameTime gameTime)
        {
            if (playerW != 50) counter++;

            if (counter % 2 == 0 && counter > 50 && playerW < 50) {
                playerW = playerH = playerW + counter / 2;
                playerX = ScreenCenterX - (playerW / 2);
                playerY = ScreenCenterY - (playerH / 2);
            } else if (counter > 50 && playerW > 50) {
                playerW = playerH = 50;
                controlsAreLocked = false;
            }
            if (!controlsAreLocked) {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
                    playerX = playerX > 0 ? playerX - 5 : playerX;
                if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                    playerX = playerX < ScreenWidth - playerW ? playerX + 5 : playerX;
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                    playerY = playerY > 0 ? playerY - 5 : playerY;
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                    playerY = playerY < ScreenHeight - playerH ? playerY + 5 : playerY;
            }
        }
        #endregion
    }
}
