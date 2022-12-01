﻿using System;
using System.Linq;

namespace Insight
{
    public class InsightArgs
    {
        private readonly string[] _args;

        public ArgNames Names;

        public InsightArgs()
        {
            _args = Environment.GetCommandLineArgs();

            Names = new ArgNames();

            NetworkAddress = ExtractValue(Names.NetworkAddress, "localhost");
            NetworkPort = ExtractValueInt(Names.NetworkPort, 7777);
            UniqueID = ExtractValue(Names.UniqueID, "");
            SceneName = ExtractValue(Names.SceneName, "");
            RoomName = ExtractValue(Names.RoomName, "");
            RoomCreator = ExtractValue(Names.RoomCreator, "");
            CreatorID = ExtractValue(Names.CreatorID, "");
            RoomPassword = ExtractValue(Names.RoomPassword, "");
            RoomMaxPlayers = ExtractValueInt(Names.RoomMaxPlayers);
            RoomExpireDate = ExtractValue(Names.RoomExpireDate, "");
        }

        #region Arguments
        public string NetworkAddress { get; private set; }
        public int NetworkPort { get; private set; }
        public string UniqueID { get; private set; }
        public string SceneName { get; private set; }
        public string RoomName { get; private set; }
        public string RoomCreator { get; private set; }
        public string CreatorID { get; private set; }
        public string RoomPassword { get; private set; }
        public int RoomMaxPlayers { get; private set; }
        public string RoomExpireDate { get; private set; }
        #endregion

        #region Helper methods
        public string ExtractValue(string argName, string defaultValue = null)
        {
            if (!_args.Contains(argName))
                return defaultValue;

            int index = _args.ToList().FindIndex(0, a => a.Equals(argName));
            return _args[index + 1];
        }

        public int ExtractValueInt(string argName, int defaultValue = -1)
        {
            var number = ExtractValue(argName, defaultValue.ToString());
            return Convert.ToInt32(number);
        }

        public bool IsProvided(string argName)
        {
            return _args.Contains(argName);
        }

        #endregion

        public class ArgNames
        {
            public string NetworkAddress { get { return "-NetworkAddress"; } }
            public string NetworkPort { get { return "-NetworkPort"; } }
            public string UniqueID { get { return "-UniqueID"; } }
            public string SceneName { get { return "-SceneName"; } }
            public string RoomName { get { return "-RoomName"; } }
            public string RoomCreator { get { return "-RoomCreator"; } }
            public string CreatorID { get { return "-CreatorID"; } }
            public string RoomPassword { get { return "-RoomPassword"; } }
            public string RoomMaxPlayers { get { return "-RoomMaxPlayers"; } }
            public string RoomExpireDate { get { return "-RoomExpireDate"; } }
        }
    }
}
