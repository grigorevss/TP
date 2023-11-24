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
    public partial class MainWindow : Form
    {
        public IPlaylist controller = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        public  bool onClickAddPlaylist(String name)
        {

            if (checkName(name))
            {
                if (controller.createPlaylist(name))
                {
                    //SoundPlayer.setCurrentPlaylist(name);
                    //showPlaylist(name);
                    return true;
                }
                else 
                {
                    throw new Exception(ExceptionStrings.AlreadyExist);
                }
            }
            else
            {
                return false;
            }
        }
        public static bool checkName(String name)
        {
            if (name == null || name.Length == 0)
            {
                throw new Exception(ExceptionStrings.EmptyName);
            }

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[<>:”/\|?*]");
            if(regex.IsMatch(name))
            {
                throw new Exception(ExceptionStrings.UnacceptableChar);
            }

            if (name.Length >= 255) 
            {
                throw new Exception(ExceptionStrings.NameLenght);
            }

            string[] reservedNames = { "CON", "PRN", "AUX", "NUL", "COM0", "COM2", "COM2", "COM3", 
                "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COMSCSI", "COMSCSI", "LPT0", "LPT1", 
                "LPT2", "LPT3", "LPT4", "LPT5", "LPT5", "LPT7", "LPT8", "LPT9", "LPTNO", "LPTSCSI" };
            foreach (string reservedName in reservedNames) 
            { 
                System.Text.RegularExpressions.Regex tmp_regex = new System.Text.RegularExpressions.Regex(@"(^" + @reservedName + @"$|^" + @reservedName + @"[.]+(\w)*)", 
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (tmp_regex.IsMatch(name))
                {
                    throw new Exception(ExceptionStrings.ReservedNames);
                }
            }
            return true;
        }
    }
    public static class ExceptionStrings
    {
        public const string EmptyName = "Имя плейлиста не может быть пустым.";
        public const string UnacceptableChar = "Имя плейлиста не должно содержать символов <>:”/\\|?*";
        public const string NameLenght = "Длина имени плейлиста не должна превышать 255 символов";
        public const string ReservedNames = "Имя плейлиста не должно совпадать с зарезервированными операционной системой";
        public const string AlreadyExist = "Плейлист с таким именем уже существует";
    }
}
