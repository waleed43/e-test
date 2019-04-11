using System;
using System.Collections.Generic;
using System.Text;

namespace ETests.MenuItem
{
    public class NavigationDrawerItem
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public Type TargetType { get; set; }
    }
}
