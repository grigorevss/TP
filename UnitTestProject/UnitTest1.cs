using System;
using lab_2;


namespace UnitTestProject
{
    public class Tests
    {
        /// <summary>
        /// ���������� � ���������� ��� ���������.
        /// � ������� �������� ��� ��������� ��������������� ���� �����������.
        /// </summary>
        [Test]
        public void Test_01_onClickAddPlaylist_BaseFlow()
        {
            String name = "my_playlist";
            bool expectedReturnValue = true;
            bool actualReturnValue = false;
            //todo zaglushka return 1

            Assert.DoesNotThrow(()=>
            {
                actualReturnValue= MainWindow.onClickAddPlaylist(name);
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
        }

        /// <summary>
        /// ������ ���.
        /// ������������ ������� ��� ��������� ������.
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
        /// ������������ ������.
        /// ��� ��������� �������� ������������ ������.
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
        /// ����������������� �����.
        /// ��� ��������� � ����� �� ����������������� ������������ ��������.
        /// </summary>
        [Test]
        public void Test_04_checkName_ReservedNames()
        {
            String name = "NUL";
            string expectedExceptionMessege = ExceptionStrings.ReservedNames;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                MainWindow.checkName(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }

        /// <summary>
        /// ��� ������.
        /// ��� ��������� � ����� �� ��� ������������ ����������.
        /// </summary>
        [Test]
        public void Test_05_onClickAddPlaylist_AlreadyExist()
        {
            String name = "my_playlist";
            //todo zaglushka return 0
            string expectedExceptionMessege = ExceptionStrings.AlreadyExist;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                MainWindow.onClickAddPlaylist(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessege, exception.Message);
        }
    }
}