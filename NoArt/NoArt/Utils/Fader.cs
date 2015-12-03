using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoArt.Utils {
    class Fader : Game{

        GraphicsDevice gd = new GraphicsDevice();
        public Fader(float time, Color color, bool dir) {
            Texture2D fadeData = new Texture2D(gd, 1, 1, false, SurfaceFormat.Color);
            fadeData.SetData<Color>(color);
        }
}
