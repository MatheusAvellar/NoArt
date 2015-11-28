using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace NoArt
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int counter;
        float alpha;
        bool isFadeIn;

        SpriteFont PoiretOne;
        Vector2 ScreenCenter;

        public Game1() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            alpha = 1f;
            isFadeIn = true;
            counter = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PoiretOne = Content.Load<SpriteFont>("Fonts\\PoiretOne");
     
            ScreenCenter = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
             || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }
            counter++;

            if (counter >= 100 && counter % 2 == 0) {
                alpha = (alpha > 0 && isFadeIn) ? alpha - 0.05f
                      : (alpha < 1 && !isFadeIn) ? alpha + 0.05f
                      : alpha;
                alpha = alpha < 0 ? 0 : alpha > 1 ? 1 : alpha;
                Console.WriteLine(alpha);
            } else if (counter == 255) {
                isFadeIn = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);
            spriteBatch.Begin();

            Vector2 FontOrigin = PoiretOne.MeasureString("NoArt") / 2;
            spriteBatch.DrawString(
                PoiretOne,          // SpriteFont
                "NoArt",            // Text
                ScreenCenter,       // Position
                Color.Black,        // Color
                0,                  // Rotation
                FontOrigin,         // Origin
                1.0f,               // Scale
                SpriteEffects.None, // Effects (flip)
                0.5f);              // Layer

            Texture2D bg = Content.Load<Texture2D>("Images\\w");
            spriteBatch.Draw(bg, new Rectangle(0, 0,
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height), Color.White * alpha);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
