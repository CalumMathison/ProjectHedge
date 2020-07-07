/// Entity Class
/// Dev: Calum Mathison 
/// Created on: 25/06/2020
/// Change Log:
/// 

#region Externs
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Engine.ECM
{
    public class Entity
    {
        #region Fields
        // Position of Entity. Component positions will be calculated in regards to this.
        protected Vector2 _position;
        protected bool _isActive, _isVisible;
        // List of attached components.
        protected List<Component> _components;
        #endregion

        #region Properties
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor. 
        /// Initialises list object.
        /// </summary>
        public Entity()
        {
            _components = new List<Component>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise Method.
        /// Sets entity to active and visible. Calls initialise method for all attached components.
        /// </summary>
        public virtual void Initialise()
        {
            _isActive = true;
            _isVisible = true;

            foreach (Component component in _components)
            {
                component.Initialise();
            }
        }

        /// <summary>
        /// Load Method. 
        /// Calls Load method for all components attached to entity.
        /// </summary>
        /// <param name="content"></param>
        public virtual void Load(ContentManager content)
        {
            foreach (Component component in _components)
            {
                component.Load(content);
            }
        }

        /// <summary>
        /// Update Method.
        /// Calls update method for all components attached to entity.
        /// </summary>
        /// <param name="gt"></param>
        public virtual void Update(GameTime gt)
        {
            if (_isActive)
            {
                foreach (Component component in _components)
                {
                    component.Update(gt);
                }
            }
        }

        /// <summary>
        /// Draw Method.
        /// Calls Draw method for all components attached to entity.
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw(SpriteBatch sb)
        {
            if (_isVisible)
            {
                foreach (Component component in _components)
                {
                    component.Draw(sb);
                }
            }
        }

        /// <summary>
        /// Add Component Method.
        /// Adds a component to the list.
        /// </summary>
        /// <param name="c">Component</param>
        public void AddComponent(Component c)
        {
            _components.Add(c);
        }

        /// <summary>
        /// Find Component.
        /// Finds and returns a component from the list.
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <returns>Type cast component</returns>
        public T FindComponent<T>() where T : Component
        {
            foreach (Component component in _components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }

            return null;
        }

        /// <summary>
        /// Find Components
        /// Finds and returns all components of a certain type as a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> FindComponents<T>() where T : Component
        {
            List<T> list = new List<T>();

            foreach (Component component in _components)
            {
                if (component is T)
                {
                    list.Add((T)component);
                }
            }

            return list;
        }

        /// <summary>
        /// Remove Component Method.
        /// Removes a component of a given type from the list.
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        public void RemoveComponent<T>() where T : Component
        {
            foreach (Component component in _components)
            {
                if (component is T)
                {
                    _components.Remove(component);
                }
            }
        }
        #endregion
    }
}
