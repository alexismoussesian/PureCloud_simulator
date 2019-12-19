using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PureCloud_simulator
{
    public class ConversationMetric
    {
        [Key]
        public string SessionId { get; set; }
        public string ConversationId { get; set; }
        public string ParticipantId { get; set; }
        public string attrName { get; set; }
        public long? attrValue { get; set; }
        public DateTime? emitDate { get; set; }
    }
}
