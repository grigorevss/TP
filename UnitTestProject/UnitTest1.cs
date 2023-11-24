using System;
using lab_2;


namespace UnitTestProject
{
    public class MockPlaylist_AlreadyExist : IPlaylist
    {
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int> list { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool createPlaylist(string name) 
        {
            return false;
        }
    }
    public class MockPlaylist_OK : IPlaylist
    {
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int> list { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool createPlaylist(string name)
        {
            return true;
        }
    }
    public class Tests
    {
        /// <summary>
        /// Правильное и уникальное имя плейлиста.
        /// В функцию передано имя плейлиста соответствующее всем требованиям.
        /// </summary>
        [Test]
        public void Test_01_onClickAddPlaylist_BaseFlow()
        {
            String name = "my_playlist";
            bool expectedReturnValue = true;
            bool actualReturnValue = false;

            MainWindow mainWindow= new MainWindow();
            mainWindow.controller=new MockPlaylist_OK();

            Assert.DoesNotThrow(()=>
            {
                actualReturnValue= mainWindow.onClickAddPlaylist(name);
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
        }

        /// <summary>
        /// Пустое имя.
        /// Пользователь оставил имя плейлиста пустым.
        /// </summary>
        [Test]
        public void Test_02_checkName_EmptyName()
        {
            String name = "";
            string expectedExceptionMessege = ExceptionStrings.EmptyName;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                MainWindow.checkName(name);
            });
            
            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }

        /// <summary>
        /// Недопустимый символ.
        /// Имя плейлиста содержит недопустимый символ.
        /// </summary>
        [Test]
        public void Test_03_checkName_UnacceptableChar()
        {
            String name = "is_this_my_playlist?";
            string expectedExceptionMessege = ExceptionStrings.UnacceptableChar;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                MainWindow.checkName(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }

        /// <summary>
        /// Длина имени.
        /// Длина имени превышает 255 символов.
        /// </summary>
        [Test]
        public void Test_04_checkName_NameLenght()
        {
            String name = "12345678901234567890123456789012345678901234567890" +
                          "12345678901234567890123456789012345678901234567890" +
                          "12345678901234567890123456789012345678901234567890" +
                          "12345678901234567890123456789012345678901234567890" +
                          "12345678901234567890123456789012345678901234567890" +
                          "12345678901234567890123456789012345678901234567890";
            string expectedExceptionMessege = ExceptionStrings.NameLenght;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                MainWindow.checkName(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }
        /// <summary>
        /// Зарезервированные имена.
        /// Имя совпадает с одним из зарезервированных операционной системой.
        /// </summary>
        [Test]
        [TestCase("NUL")]
        [TestCase("COM8")]
        [TestCase("con")]
        [TestCase("lPt0")]
        [TestCase("aux.txt")]
        [TestCase("COMSCSI.")]
        public void Test_05_checkName_ReservedNames(string value)
        {
            String name = value;
            string expectedExceptionMessege = ExceptionStrings.ReservedNames;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                MainWindow.checkName(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }

        /// <summary>
        /// Имя занято.
        /// Имя совпадает с одним из уже существующих плейлистов.
        /// </summary>
        [Test]
        public void Test_06_onClickAddPlaylist_AlreadyExist()
        {
            String name = "my_playlist";
            MainWindow mainWindow = new MainWindow();
            mainWindow.controller = new MockPlaylist_AlreadyExist();

            string expectedExceptionMessege = ExceptionStrings.AlreadyExist;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                mainWindow.onClickAddPlaylist(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }
    }
}