using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Input;

namespace Hedge
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Viewport VP
        {
            get; set;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            VP = GraphicsDevice.Viewport;
            SceneManager.Instance.Initialise();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SceneManager.Instance.Load(Content);         
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();

            if (InputManager.Instance.IsKeyPressed(Keys.Escape) || 
                InputManager.Instance.IsButtonPressed(Buttons.Start))
            {
                Exit();
            }

            SceneManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
