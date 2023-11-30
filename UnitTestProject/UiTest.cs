using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using lab_2;

namespace UnitTestProject
{
    internal class UiTest
    {
        string PathTestingApp = @"C:\Users\GrigorevSS\YandexDisk\_stud\ТП\rep\lab_2\bin\Debug\lab_2.exe";
        int N = 5000;

        const string mainWindowTitleString = "Main";
        const string createPlaylistButtonString = "Создать плейлист";
        const string currentPlaylistNameString= "Tmp";

        const string idCreatePlaylistButton = "CreatePlaylistButton";
        const string idCurrentPlaylistName = "CurrentPlaylistName";
        const string idCurrentPlaylist = "CurrentPlaylist";
        const string idNewPlaylistName = "NewPlaylistName";

        public T WaitForElement<T>(Func<T> getter)
        {
            var retry = Retry.WhileNull<T>(
            getter,
            TimeSpan.FromMilliseconds(N));
            if (!retry.Success)
            {
                Assert.Fail($"Невозможно найти элемент {N} ms");
            }
            return retry.Result;
        }

        /// <summary>
        /// тест для проверки некорректных имен плейлистов
        /// </summary>
        [Test]
        public void Test_01_MainWindow() 
        {
            //step 1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "2");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                string title = window.Title;
                Assert.AreEqual(mainWindowTitleString, title);

                var createPlaylistButton = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCreatePlaylistButton)).AsButton());
                var currentPlaylistName = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCurrentPlaylistName)).AsLabel());
                var currentPlaylist = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCurrentPlaylist)).AsListBox());
                var newPlaylistName = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idNewPlaylistName)).AsTextBox());

                Assert.AreEqual(createPlaylistButtonString, createPlaylistButton.AsLabel().Text);
                Assert.AreEqual(currentPlaylistNameString, currentPlaylistName.Text);

                Assert.AreEqual("", currentPlaylist.AsLabel().Text);
                Assert.AreEqual("", newPlaylistName.Text);

                //step 2
                createPlaylistButton.Click();
                Thread.Sleep(1000);
                window.CaptureToFile("_EmptyName.png");

                var retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();
                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText(ExceptionStrings.EmptyName)).AsLabel();
                    
                    Assert.NotNull(message);

                    var okButton = msg.FindFirstChild(cf => cf.ByClassName("Button")).AsButton();

                    Assert.NotNull(okButton);

                    msg.CaptureToFile("_EmptyName_Dialog.png");

                    okButton.Click();
                }, TimeSpan.FromMilliseconds(N));
                    
                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна ошибки EmptyName");
                }

                //step 3
                newPlaylistName.Enter("is_this_my_playlist?");

                createPlaylistButton.Click();
                Thread.Sleep(1000);
                window.CaptureToFile("_UnacceptableChar.png");

                retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();

                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText(ExceptionStrings.UnacceptableChar)).AsLabel();

                    Assert.NotNull(message);

                    var okButton = msg.FindFirstChild(cf => cf.ByClassName("Button")).AsButton();
                    Assert.NotNull(okButton);

                    msg.CaptureToFile("_UnacceptableChar_Dialog.png");
                    okButton.Click();
                }, TimeSpan.FromMilliseconds(N));

                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна ошибки UnacceptableChar");
                }

                //step 4
                newPlaylistName.Enter("12345678901234567890123456789012345678901234567890" +
                                      "12345678901234567890123456789012345678901234567890" +
                                      "12345678901234567890123456789012345678901234567890" +
                                      "12345678901234567890123456789012345678901234567890" +
                                      "12345678901234567890123456789012345678901234567890" +
                                      "12345678901234567890123456789012345678901234567890");

                createPlaylistButton.Click();
                Thread.Sleep(1000);
                window.CaptureToFile("_NameLenght.png");

                retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();

                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText(ExceptionStrings.NameLenght)).AsLabel();

                    Assert.NotNull(message);

                    var okButton = msg.FindFirstChild(cf => cf.ByClassName("Button")).AsButton();
                    Assert.NotNull(okButton);

                    msg.CaptureToFile("_NameLenght_Dialog.png");
                    okButton.Click();
                }, TimeSpan.FromMilliseconds(N));

                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна ошибки NameLenght");
                }

                //step 5
                newPlaylistName.Enter("NUL");

                createPlaylistButton.Click();
                Thread.Sleep(1000);
                window.CaptureToFile("_ReservedNames.png");

                retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();

                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText(ExceptionStrings.ReservedNames)).AsLabel();

                    Assert.NotNull(message);

                    var okButton = msg.FindFirstChild(cf => cf.ByClassName("Button")).AsButton();
                    Assert.NotNull(okButton);

                    msg.CaptureToFile("_ReservedNames_Dialog.png");
                    okButton.Click();
                }, TimeSpan.FromMilliseconds(N));

                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна ошибки ReservedNames");
                }

                app.Close();
            }
        }

        /// <summary>
        /// тест для проверки существующего имени плейлиста
        /// </summary>
        [Test]
        public void Test_02_MainWindow()
        {
            //step 1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "1");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                string title = window.Title;
                Assert.AreEqual(mainWindowTitleString, title);

                var createPlaylistButton = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCreatePlaylistButton)).AsButton());
                var currentPlaylistName = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCurrentPlaylistName)).AsLabel());
                var currentPlaylist = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCurrentPlaylist)).AsListBox());
                var newPlaylistName = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idNewPlaylistName)).AsTextBox());

                Assert.AreEqual(createPlaylistButtonString, createPlaylistButton.AsLabel().Text);
                Assert.AreEqual(currentPlaylistNameString, currentPlaylistName.Text);

                Assert.AreEqual("", currentPlaylist.AsLabel().Text);
                Assert.AreEqual("", newPlaylistName.Text);

                //step 2
                newPlaylistName.Enter("my_playlist");

                createPlaylistButton.Click();
                Thread.Sleep(1000);
                window.CaptureToFile("_AlreadyExist.png");

                var retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();
                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText(ExceptionStrings.AlreadyExist)).AsLabel();

                    Assert.NotNull(message);

                    var okButton = msg.FindFirstChild(cf => cf.ByClassName("Button")).AsButton();

                    Assert.NotNull(okButton);

                    msg.CaptureToFile("_AlreadyExist_Dialog.png");

                    okButton.Click();
                }, TimeSpan.FromMilliseconds(N));

                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна ошибки AlreadyExist");
                }
                
                app.Close();
            }
        }

        /// <summary>
        /// тест для проверки успешного создания плейлиста
        /// </summary>
        [Test]
        public void Test_03_MainWindow()
        {
            //step 1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "2");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                string title = window.Title;
                Assert.AreEqual(mainWindowTitleString, title);

                var createPlaylistButton = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCreatePlaylistButton)).AsButton());
                var currentPlaylistName = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCurrentPlaylistName)).AsLabel());
                var currentPlaylist = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idCurrentPlaylist)).AsListBox());
                var newPlaylistName = WaitForElement(() 
                    => window.FindFirstDescendant(cf => cf.ByAutomationId(idNewPlaylistName)).AsTextBox());

                Assert.AreEqual(createPlaylistButtonString, createPlaylistButton.AsLabel().Text);
                Assert.AreEqual(currentPlaylistNameString, currentPlaylistName.Text);

                Assert.AreEqual("", currentPlaylist.AsLabel().Text);
                Assert.AreEqual("", newPlaylistName.Text);

                //step 2
                newPlaylistName.Enter("my_playlist");

                createPlaylistButton.Click();
                Thread.Sleep(1000);
                window.CaptureToFile("_OK.png");

                var retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual("my_playlist", currentPlaylistName.Text);
                }, TimeSpan.FromMilliseconds(N));

                if (!retry.Success)
                {
                    Assert.AreEqual("my_playlist", currentPlaylistName.Text);
                }

                app.Close();
            }
        }



    }
}
