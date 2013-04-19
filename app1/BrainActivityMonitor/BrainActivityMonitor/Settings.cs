﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BrainActivityMonitor
{
    class Settings : ApplicationSettingsBase
    {
        public const String RemoteHostConst = "RemoteHost";
        public const String RemotePortConst = "RemotePort";

        [UserScopedSetting()]
        [DefaultSettingValue("127.0.0.1")]
        public String RemoteHost
        {
            get
            {
                return ((String)this[RemoteHostConst]); //can't we do this in the other way ?
            }

            set
            {
                this[RemoteHostConst] = (String)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("1726")]
        public ushort RemotePort
        {
            get
            {
                return ((ushort)this[RemotePortConst]); //can't we do this in the other way ?
            }

            set
            {
                this[RemotePortConst] = (ushort)value;
            }
        }
    }
}
