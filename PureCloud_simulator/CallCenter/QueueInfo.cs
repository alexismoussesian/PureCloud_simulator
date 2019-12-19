using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;

namespace PureCloud_simulator
{
    public class QueueInfo
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public int? MemberCount { get; set; }
        public List<QueueMember> AllQueueMembers { get; set; }
        public AcwSettings.WrapupPromptEnum? AcwWrapup { get; set; }
        public int? AcwTimeout { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public QueueInfo(string id, string name, int? memberCount)
        {
            Id = id;
            Name = name;
            MemberCount = memberCount;
        }

        public QueueInfo(string id, string name, int? memberCount, int? acw_timeout, AcwSettings.WrapupPromptEnum? acw_wrapup)
        {
            Id = id;
            Name = name;
            MemberCount = memberCount;
            AcwWrapup = acw_wrapup;
            AcwTimeout = acw_timeout;
        }
    }
}
