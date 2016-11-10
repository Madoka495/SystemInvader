using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SystemInvader
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Texture2D bullet;
        public  static Vector2 start = new Vector2(200, 200);
        public  static Vector2 dest = new Vector2(500, 50);
        public Projectile projectile = new Projectile(start, dest, 4);
        public int bulletWidth = 50;
        public int bulletHeight = 50;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bullet = Content.Load<Texture2D>("bullet1");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            System.Diagnostics.Debug.WriteLine(projectile.GetPos().X + ", " + projectile.GetPos().Y);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (projectile.DestReached() == false)
            {
                projectile.Update();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (projectile.DestReached() == false)
            {
                spriteBatch.Draw(bullet, new Rectangle((int)projectile.GetPos().X, (int)projectile.GetPos().Y, bulletWidth, bulletHeight), Color.White);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
