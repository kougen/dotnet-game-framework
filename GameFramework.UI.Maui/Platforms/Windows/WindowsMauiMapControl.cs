using GameFramework.Impl.Core.Position;
using GameFramework.UI.Maui.Map;
using Microsoft.Maui.Controls;

namespace GameFramework.UI.Maui.Platforms.Windows
{
    public class WindowsMauiMapControl : AMauiMapControl
    {
        public WindowsMauiMapControl()
        {
            var tappedGestureRecognizer = new TapGestureRecognizer();
            tappedGestureRecognizer.Tapped += OnPointerPressed;

            var moveGestureRecognizer = new PointerGestureRecognizer();
            moveGestureRecognizer.PointerMoved += OnPointerMoved;
        }
        
        private void OnPointerPressed(object sender, TappedEventArgs e)
        {
            var position = e.GetPosition(this);

            if (position is null)
            {
                return;
            }

            foreach (var mouseHandler in MouseHandlers)
            {
                mouseHandler.OnMouseLeftClick(new ScreenSpacePosition(position.Value.X, position.Value.Y));
            }
        }



        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            var position = e.GetPosition(this);

            if (position is null)
            {
                return;
            }

            foreach (var mouseHandler in MouseHandlers)
            {
                mouseHandler.OnMouseMove(new ScreenSpacePosition(position.Value.X, position.Value.Y));
            }
        }
    }
}
