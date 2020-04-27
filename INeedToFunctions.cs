using OpenQA.Selenium;
using System;

namespace KeytorcTest
{
    interface INeedToFunctions
    {
        void BasicSettings();

        void LoginProcesses();

        void SearchProcesses();

        void SelectProcesses();

        void MoveToSelected(IWebElement element);

        void Verify(IWebElement element, String actually, String expected);

        void TakenScreenShot(String fileName);
    }
}
