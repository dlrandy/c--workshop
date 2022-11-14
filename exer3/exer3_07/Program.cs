using System;
namespace exer03_07
{
    public class MouseClickedEventArgs
    {
        public int Clicks { get; }
        public MouseClickedEventArgs(int clicks)
        {
            Clicks = clicks;
        }
    }
    public class MouseClickPublisher
    {
        public event EventHandler<MouseClickedEventArgs> MouseClicked = delegate { };

        protected virtual void OnMouseClicked(MouseClickedEventArgs e)
        {
            var evt = MouseClicked;
            evt?.Invoke(this, e);
        }
        private void TrackMouseClicks()
        {
            OnMouseClicked(new MouseClickedEventArgs(2));
        }
    }
    public class MouseSingleClickPublisher : MouseClickPublisher
    {
        protected override void OnMouseClicked(MouseClickedEventArgs e)
        {
            if (e.Clicks == 1)
            {
                base.OnMouseClicked(e);
            }
        }
    }
}