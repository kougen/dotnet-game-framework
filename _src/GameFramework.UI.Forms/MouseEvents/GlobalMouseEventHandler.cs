namespace GameFramework.UI.Forms.MouseEvents
{
    public static class GlobalMouseEventHandler
    {
        public delegate void MouseMovedEvent();
        public delegate void LeftButtonDownEvent();
        public delegate void RightButtonDownEvent();

        public class GlobalMouseHandler : IMessageFilter
        {
            private const int WM_MOUSEMOVE = 0x0200;
            private const int WM_LBUTTONDOWN = 0x0201;
            private const int WM_RBUTTONDOWN = 0x0204;

            public event MouseMovedEvent? TheMouseMoved;
            public event LeftButtonDownEvent? TheLeftButtonDown;
            public event RightButtonDownEvent? TheRightButtonDown;

            #region IMessageFilter Members
            public bool PreFilterMessage(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_MOUSEMOVE:
                        TheMouseMoved?.Invoke();
                        break;
                    case WM_LBUTTONDOWN:
                        TheLeftButtonDown?.Invoke();
                        break;
                    case WM_RBUTTONDOWN:
                        TheRightButtonDown?.Invoke();
                        break;
                }

                return false;
            }
            #endregion
        }
    }
}
