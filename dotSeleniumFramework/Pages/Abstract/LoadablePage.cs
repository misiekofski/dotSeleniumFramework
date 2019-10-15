using System;
using System.Runtime.InteropServices;
using dotSeleniumFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace dotSeleniumFramework.Pages.Abstract
{
    public abstract class LoadablePage<T> : LoadableComponent<T> where T : LoadablePage<T>
    {
        public delegate void PageLoadedEvent(T instance);
        public event PageLoadedEvent RaisePageLoadedEvent;

        public LoadablePage([Optional] ISearchContext searchContext, [Optional] TimeSpan? loadTimeout,
            [Optional] PageLoadedEvent onPageLoadedEventHandler)
        {
            this.searchContext = searchContext ?? Driver.Instance;
            this.timeout = loadTimeout;
            this.RaisePageLoadedEvent = onPageLoadedEventHandler;
            Load();
            RaisePageLoadedEvent?.Invoke(this as T);
        }

        public new bool IsLoaded => EvaluateLoadedStatus();
        protected abstract override bool EvaluateLoadedStatus();
        
        protected readonly ISearchContext searchContext;
        private readonly TimeSpan? timeout;

        protected virtual By componentContainerLocator => By.XPath(".");
        protected virtual IWebElement componentContainer => searchContext.FindElement(componentContainerLocator);

        protected override void HandleLoadError (WebDriverException ex) =>
            throw new LoadableComponentException($"Page {typeof(T).Name} was not loaded", ex);


        protected override void ExecuteLoad()
        { 
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(c => EvaluateLoadedStatus());
        }
    }
}
