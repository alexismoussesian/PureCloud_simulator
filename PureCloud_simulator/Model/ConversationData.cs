using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureCloud_simulator.Model
{
    public class ConversationData
    {
        public string ConversationId { get; set; }
        public DateTime ConversationStart { get; set; }
        public DateTime ConversationEnd { get; set; }
        public string Ani { get; set; }
        public string DivisionIds { get; set; }
        public string Dnis { get; set; }
        public string Media { get; set; }
        public List<string> Queue { get; set; }
        public List<string> Agent { get; set; }
        public long nConnected { get; set; }
        public long nBlindTransferred { get; set; }
        public long tNotResponding { get; set; }
        public int Rona { get; set; }
        public long nError { get; set; }
        public long nConsult { get; set; }
        public long nConsultTransferred { get; set; }
        public long nFlow { get; set; }
        public long nFlowOutcome { get; set; }
        public long nFlowOutcomeFailed { get; set; }
        public long nOffered { get; set; }
        public long nOutbound { get; set; }
        public long nOutboundAbandoned { get; set; }
        public long nOutboundAttempted { get; set; }
        public long nOutboundConnected { get; set; }
        public long nOverSla { get; set; }
        public long nStateTransitionError { get; set; }
        public long nTransferred { get; set; }
        public long oSurveyQuestionGroupScore { get; set; }
        public long oSurveyQuestionScore { get; set; }
        public long oSurveyTotalScore { get; set; }
        public long oTotalCriticalScore { get; set; }
        public long oTotalScore { get; set; }
        public long tAbandon { get; set; }
        public long tAcd { get; set; }
        public long tAcw { get; set; }
        public long tAgentResponseTime { get; set; }
        public long tAgentRoutingStatus { get; set; }
        public long tAlert { get; set; }
        public long tAnswered { get; set; }
        public long tContacting { get; set; }
        public long tDialing { get; set; }
        public long tFlow { get; set; }
        public long tFlowDisconnect { get; set; }
        public long tFlowExit { get; set; }
        public long tFlowOut { get; set; }
        public long tFlowOutcome { get; set; }
        public long tHandle { get; set; }
        public long tHeld { get; set; }
        public long tHeldComplete { get; set; }
        public long tOrganizationPresence { get; set; }
        public long tSystemPresence { get; set; }
        public long tTalk { get; set; }
        public long tTalkComplete { get; set; }
        public long tUserResponseTime { get; set; }
        public long tVoicemail { get; set; }
        public long tWait { get; set; }
        public long tIvr { get; set; }

    }
}
