using GameFramework.Impl.Core.Position;
using GameFramework.UI.Maui.Core;
using Microsoft.Maui.Controls;

namespace GameFramework.UI.Maui.Map
{
    public class MauiMapControl : AMauiMapControl
    {
        public MauiMapControl()
        {
            var tappedGestureRecognizer = new TapGestureRecognizer();
            tappedGestureRecognizer.Tapped += OnPointerPressed;

            var moveGestureRecognizer = new PointerGestureRecognizer();
            moveGestureRecognizer.PointerMoved += OnPointerMoved;

            GestureRecognizers.Add(tappedGestureRecognizer);
            GestureRecognizers.Add(moveGestureRecognizer);
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
            if (sender is not AMauiMapControl mauiMapControl)
            {
                return;
            }

            var position = e.GetPosition(mauiMapControl);

            if (position is null)
            {
                return;
            }

            var config = GameApp2D.Current.ConfigurationService;

            foreach (var mouseHandler in MouseHandlers)
            {
                mouseHandler.OnMouseMove(new ScreenSpacePosition(position.Value.X - config.Dimension, position.Value.Y - config.Dimension));
            }
        }
    }
}
