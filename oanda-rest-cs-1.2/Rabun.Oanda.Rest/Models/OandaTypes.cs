namespace Rabun.Oanda.Rest.Models
{
    public static class OandaTypes
    {
        public enum GranularityType
        {
            S5,
            S10,
            S15,
            S30,
            M1,
            M2,
            M3,
            M5,
            M10,
            M15,
            M30,
            H1,
            H2,
            H3,
            H4,
            H6,
            H8,
            H12,
            D,
            W,
            M
        }

        public enum Side
        {
            buy,
            sell
        }

        public enum OrderType
        {
            limit,
            stop,
            marketIfTouched,
            market
        }

        public enum TransactionType
        {
            MARKET_ORDER_CREATE,
            STOP_ORDER_CREATE,
            LIMIT_ORDER_CREATE,
            MARKET_IF_TOUCHED_ORDER_CREATE,
            ORDER_UPDATE,
            ORDER_CANCEL,
            ORDER_FILLED,
            TRADE_UPDATE,
            TRADE_CLOSE,
            MIGRATE_TRADE_OPEN,
            MIGRATE_TRADE_CLOSE,
            STOP_LOSS_FILLED,
            TAKE_PROFIT_FILLED,
            TRAILING_STOP_FILLED,
            MARGIN_CALL_ENTER,
            MARGIN_CALL_EXIT,
            MARGIN_CLOSEOUT,
            SET_MARGIN_RATE,
            TRANSFER_FUNDS,
            DAILY_INTEREST,
            FEE
        }

        public enum Reason
        {
            CLIENT_REQUEST,
            MIGRATION,
            REPLACES_ORDER,
            ORDER_FILLED
        }

        public enum CandleFormat
        {
            midpoint,
            bidask
        }

        public enum WeeklyAlignment
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public enum AccountCurrency
        {
            EUR,
            USD,
            SGD,
            CHF,
            CAD,
            GBP,
            AUD,
            HKD,
            JPY
        }

        public enum TradeCurrency
        {
            EUR,
            USD,
            SGD,
            CHF,
            CAD,
            GBP,
            JPY,
            AUD,
            ZAR,
            HKD,
            NZD,
            CZK,
            DKK,
            HUF,
            NOK,
            SEK,
            SAR,
            TRY,
            CNH,
            MXN,
            PLN,
            THD
        }
    }
}
