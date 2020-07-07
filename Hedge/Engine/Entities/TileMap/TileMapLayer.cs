using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;
using Engine.Components.Graphics;
using Engine.Components.Physics;
using Engine.Input;

namespace Engine.Entities.TileMap
{
    public class TileMapLayer : Entity
    {
        #region Fields
        private int _size;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public TileMapLayer(int size) : base()
        {
            _size = size;
        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    TileComponent tc = new TileComponent(this, new Vector2(x * 32, y * 32));
                    AddComponent(tc);
                }
            }

            base.Initialise();
        }

        public override void Load(ContentManager content)
        {
            base.Load(content);
        }

        public override void Update(GameTime gt)
        {
            foreach (ColliderComponent c in FindComponents<ColliderComponent>())
            {
                if (InputManager.Instance.IsMouseColliding(c.Rect) && 
                    InputManager.Instance.IsMousePressed(InputManager.MouseButtons.Left))
                {
                    Console.WriteLine("Clicked"); 
                }
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
