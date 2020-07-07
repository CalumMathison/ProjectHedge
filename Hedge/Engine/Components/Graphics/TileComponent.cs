using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;
using Engine.Components.Graphics;
using Engine.Components.Physics;

namespace Engine.Components.Graphics
{
    public class TileComponent : Component
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public TileComponent(Entity e) : base(e)
        {

        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            SpriteComponent sc = new SpriteComponent(_parent);
            sc.Loc = "Graphics/Testing/TestTile";
            _parent.AddComponent(sc);

            ColliderComponent cc = new ColliderComponent(_parent, 32, 32);
            _parent.AddComponent(cc);

            base.Initialise();
        }

        public override void Load(ContentManager content)
        {
            base.Load(content);
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
        #endregion
    }
}
