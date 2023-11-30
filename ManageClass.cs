using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class ManageClass
    {
        public static int index = 2;
        public static IPlaylist GetPlaylist()
        {
#if DEBUG
            switch (index)
            {
                case 0: throw new NotImplementedException();
                case 1: return new MockPlaylist_AlreadyExist();
                case 2: return new MockPlaylist_OK();
            }
            return null;
#else        
            throw new NotImplementedException();
#endif
        }
#if DEBUG
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
#endif
    }
}