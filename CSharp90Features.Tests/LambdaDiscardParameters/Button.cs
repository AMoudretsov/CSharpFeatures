using System;

namespace CSharp90Features.Tests.LambdaDiscardParameters
{
    public class Button
    {
        public event EventHandler<EventArgs> Click;

        public void InitiateClick()
        {
            if (Click == null)
            {
                return;
            }

            Click(this, new EventArgs());
        }
    }
}
