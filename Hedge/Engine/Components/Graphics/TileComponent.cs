using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;
using Engine.Components.Graphics;
using Engine.Components.Physics;
using Engine.Input;

namespace Engine.Components.Graphics
{
    public class TileComponent : Component
    {
        #region Fields
        private bool _selected;
        private SpriteComponent _sc;
        private ColliderComponent _cc;
        #endregion

        #region Properties
        public bool IsSelected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public SpriteComponent SC
        {
            get { return _sc; }
            set { _sc = value; }
        }

        public ColliderComponent CC
        {
            get { return _cc; }
            set { _cc = value; }
        }
        #endregion

        #region Constructor
        public TileComponent(Entity e, Vector2 pos) : base(e)
        {
            _selected = false;
            _position = pos;

            _sc = new SpriteComponent(_parent);
            _sc.Loc = "Graphics/Testing/TestTile";
            _sc.Position = pos;
            _parent.AddComponent(_sc);

            _cc = new ColliderComponent(_parent, 32, 32);
            _cc.Position = pos;
            _parent.AddComponent(_cc);
        }
        #endregion

        #region Methods
        public override void Initialise()
        {          
            base.Initialise();          
        }

        public override void Load(ContentManager content)
        {
            base.Load(content);
        }

        public override void Update(GameTime gt)
        {
            if (_selected == true)
            {
                _sc.Col = Color.Blue;
            }
            else
            {
                _sc.Col = Color.White;
            }
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
        #endregion
    }
}
