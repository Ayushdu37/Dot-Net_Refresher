using System.Collections.Generic;

namespace Question5_MetroSmartCardSystem
{
    public interface MetroOperations
    {
        void issueCard(int cardNumber, string commuterName, string commuterType);
        bool tapIn(int cardNumber, int stationId, long epochTime);
        bool tapOut(int cardNumber, int stationId, long epochTime);
        Commuter? getCommuterInfo(int cardNumber);
        List<double> fareHistory(int cardNumber);
        Dictionary<string, double> getZoneWiseRevenue(long startTime, long endTime);
        List<string> getFrequentRoute(int cardNumber);
        double getDailyPassSavings(int cardNumber, long date);
    }
}
