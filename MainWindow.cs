using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2
{
    public static class ExceptionStrings 
    {
        public const string EmptyName = "Имя плейлиста не может быть пустым.";
        public const string UnacceptableChar = "Имя плейлиста не должно содержать символов<>:”/\\|?*";
        public const string ReservedNames = "Имя плейлиста не должно совпадать с зарезервированными операционной системой";
        public const string AlreadyExist = "Плейлист с таким именем уже существует";
    }
    public partial class MainWindow : Form
    {
        public IPlaylist controller = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        public static bool onClickAddPlaylist(String name)
        {
            return true;
        }
        public static bool checkName(String name)
        {
            return true;
        }


    }
}
