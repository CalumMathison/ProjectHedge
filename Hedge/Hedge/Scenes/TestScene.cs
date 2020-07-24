using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Components.Graphics;
using Engine.Components.Physics;
using Engine.Entities.Camera;
using Engine.Entities.TileMap;
using Engine.ECM;
using Engine.Input;
using Engine;

namespace Hedge.Scenes
{
    public class TestScene : Scene
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public TestScene() : base()
        {
            
        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            FreeCamera c = new FreeCamera(Game1.VP);
            EM.AddEntity(c);

            Entity e = new Entity();
            SpriteComponent sc = new SpriteComponent(e);
            sc.Loc = "Graphics/Testing/TestSquare";
            e.AddComponent(sc);
            e.Position = new Vector2(0,0);
            EM.AddEntity(e);

            TileMapLayer tl = new TileMapLayer(100);
            tl.Cam = c;
            EM.AddEntity(tl);

            base.Initialise();
        }

        public override void Load(ContentManager Content)
        {
            base.Load(Content);
        }

        public override void Update(GameTime gt)
        {


            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, null, null, null, null, null, EM.FindEntity<FreeCamera>().Transform);
            base.Draw(sb);
            sb.End();
        }
        #endregion
    }
}
