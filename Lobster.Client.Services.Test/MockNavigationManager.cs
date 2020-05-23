using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Client.Services.Test
{
    public class MockNavigationManager : NavigationManager
    {
        public MockNavigationManager() =>
            Initialize("http://localhost:5001/", "http://localhost:5001/test");

        protected override void NavigateToCore(string uri, bool forceLoad) =>
            WasNavigateInvoked = true;

        public bool WasNavigateInvoked { get; private set; }
    }
}
