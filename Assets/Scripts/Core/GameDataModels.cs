using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#region Server Communication Models

[Serializable]
internal class JackpotOpenRequest
{
    public string type = "JACKPOT_OPEN";
    public JackpotOpenPayload payload = new JackpotOpenPayload();
}

[Serializable]
internal class ScatterFeature
{
    public bool enabled;
    public Dictionary<string, int> anyCountPayouts;
    public int scatterSymbolId;
}

[Serializable]
internal class AnyBarsPayoutFeature
{
    public double payout;
    public bool enabled;
    public string groupName;
}

[Serializable]
internal class AnySevensGroupFeature
{
    public bool enabled;
    public string groupName;
    public double redBlue7Payout;
}

[Serializable]
internal class WildSubstitutionFeature
{
    public bool enabled;
    public int wildSymbolId;
    public List<int> substituteAllExcept;
}

[Serializable]
internal class ResultFeatures
{
    public ResultScatter scatter;
}

[Serializable]
internal class ResultScatter
{
    public bool triggered;
    public int scatterCount;
    public List<List<int>> positions;
    public double award;
}

[Serializable]
internal class JackpotOpenPayload
{
    public string tier;
}

[Serializable]
internal class InitData
{
    public string id = "initData";
    public ServerGameData gameData;
    public ServerFeatures features;
    public ServerUIData uiData;
    public ServerPlayer player;
    public JackpotData jackpotData;
}

[Serializable]
internal class JackpotData
{
    public JackpotValues values;
}

[Serializable]
internal class JackpotValues
{
    public string miniJackpot;
    public string minorJackpot;
    public string majorJackpot;
    public string grandJackpot;
}

[Serializable]
internal class JackpotSyncData
{
    public string gameId;
    public JackpotValues values;
}

[Serializable]
internal class ServerGameData
{
    public List<List<int>> lines;
    public List<double> bets;
    public double creditDivisor = 1;
    public int totalLines = 1;
}

[Serializable]
internal class ServerFeatures
{
    public double baseCoinValue = 1;

    public MoneyBagFeature moneyBag;
    public FreeGamesFeature freeGames;
    public int betMultiplier;
    public int maxWinMultiplier;
    public int minWinMultiplier;

    public ScatterFeature scatter;
    public AnyBarsPayoutFeature anyBarsPayout;
    public AnySevensGroupFeature anySevensGroup;
    public WildSubstitutionFeature wildSubstitution;
}

[Serializable]
internal class MoneyBagFeature
{
    public bool enabled;
    public int minTrigger;
    public int symbolId;
    public int bagCount;
}

[Serializable]
internal class FreeGamesFeature
{
    public bool enabled;
    public double payMultiplier;
    public int maxTotalFreeGames;
}

[Serializable]
internal class ExtraSpinsData
{
    [JsonProperty("2")] public int _2;
    [JsonProperty("3")] public int _3;
    [JsonProperty("4")] public int _4;
    [JsonProperty("5")] public int _5;
}

[Serializable]
internal class ServerUIData
{
    public PaylineData paylines;
}

[Serializable]
internal class PaylineData
{
    public List<ServerSymbolInfo> symbols;
}

[Serializable]
internal class ServerSymbolInfo
{
    public int id;
    public string name;
    public string group;
    public List<double> multiplier;
    public double payout;
    public string description;
    public int minMatch;
}

[Serializable]
internal class ServerPlayer
{
    public double balance;
}

[Serializable]
internal class ServerSpinResponse
{
    public string id = "spinResult";
    public bool success;
    public List<List<string>> matrix;
    public ServerPlayerBalance player;
    public ServerPayload payload;
}

[Serializable]
internal class ServerPlayerBalance
{
    public double? balance;
}

[Serializable]
internal class ServerPayload
{
    public List<List<string>> reels;
    public double totalWin;
    public double winAmount;
    public double grandTotalWin;
    public List<ServerWinLine> winningLines;
    public ResultFeatures features;

    public int scatterCount;
    public bool scatterTriggered;
    public bool isRoundOver;
    public double totalRoundWin;
    public double netReturnRatio;
    public List<ServerWaysWin> waysWins;
    public ServerMoneyBagResult moneyBag;
    public ServerFreeGamesResult freeGames;
}

[Serializable]
internal class ServerWinLine
{
    public int lineId = -1;
    public int lineIndex = -1;
    public int symbolId;
    public string symbolName;
    public object positions;
    public List<ServerPosition> matchedPositions;
    public double payout;
    public double winAmount;
    public double multiplier;
    public double wildMultiplier;
}

[Serializable]
internal class ServerWaysWin
{
    public int symbolId;
    public int matchCount;
    public int waysCount;
    public List<ServerPosition> matchedPositions;
    public double basePayout;
    public double appliedMultiplier;
    public double winInCredits;
    public double winInCash;
    public string winType;
}

[Serializable]
internal class ServerPosition
{
    public int row;
    public int col;
}

[Serializable]
internal class ServerMoneyBagResult
{
    public bool triggered;
    public ServerMoneyBagResultDetail result;
}

[Serializable]
internal class ServerMoneyBagResultDetail
{
    public int pickedIndex;
    public List<int> revealed;
    public int creditsAwarded;
    public double winInCash;
}

[Serializable]
internal class ServerFreeGamesResult
{
    public bool triggered;
    public int totalAwarded;
    public int played;
    public double totalFreeGamesWin;
}

[Serializable]
internal class SpinRequest
{
    public string type = "SPIN";
    public SpinPayload payload;
}

[Serializable]
internal class SpinPayload
{
    public int betIndex;
    public bool isFreeSpin;
}

#endregion

#region Game Configuration (Client Side Converted)

[Serializable]
internal class GameConfig
{
    public int reelCount = 3;
    public int rowCount = 3;
    public int symbolCount = 14;
    public int paylineCount = 1;
    public List<List<int>> paylines;
    public List<double> availableBets;
    public List<SymbolInfo> symbols;

    public int wildSymbolId = 1;

    public int scatterSymbolId = 10;

    public double baseCoinValue = 1.0;
    public int betMultiplier = 1;
    public double creditDivisor = 1.0;
    public int maxWinMultiplier = 10000;
    public int minWinMultiplier = 10;
    public int initialFreeSpins = 12;
    public ExtraSpinsData extraSpinsData;

    public ScatterFeature scatterFeature;
    public AnyBarsPayoutFeature anyBarsPayout;
    public AnySevensGroupFeature anySevensGroup;
    public WildSubstitutionFeature wildSubstitution;
}

[Serializable]
internal class SymbolInfo
{
    public int id;
    public string name;
    public string group;
    public List<double> multipliers;
    public bool isWild;
    public bool isScatter;
    public int wildMultiplier = 1;
    public int minMatch;
}

#endregion

#region Player & Game State (Client Side)

[Serializable]
internal class PlayerData
{
    public double balance;
    public int currentBetIndex;
}

[Serializable]
internal class SpinResult
{
    public List<List<int>> resultMatrix;
    public double winAmount;
    public double grandTotalWin;
    public List<WinLine> winLines;
    public PlayerData playerData;
    public FreeSpinData freeSpinData;
    public ScatterData scatterData;
    public OverlayScatterData overlayScatterData;
    public Dictionary<string, int> stickyWilds;

    public int serverSpinsRemaining;
    public int serverSpinsUsed;
    public int serverTotalSpins;
    public double serverTotalRoundWin;
    public bool isRoundOver;

    public MoneyBagResultData moneyBagData;
}

[Serializable]
internal class WinLine
{
    public int lineId;
    public int symbolId;
    public List<int> positions;
    public double winAmount;
}

[Serializable]
internal class FreeSpinData
{
    public bool isTriggered;
    public int spinsAwarded;
    public int remainingSpins;
    public bool isBought;
}

[Serializable]
internal class ScatterData
{
    public bool isTriggered;
    public int scatterCount;
    public double winAmount;
    public List<int> positions;
}

[Serializable]
internal class OverlayScatterData
{
    public bool isTriggered;
    public int count;
    public int extraSpins;
    public List<List<int>> positions;
}

[Serializable]
internal class MoneyBagResultData
{
    public bool triggered;
    public int pickedIndex;
    public List<int> revealed;
    public int creditsAwarded;
    public double winInCash;
}

#endregion

#region Platform Communication

[Serializable]
internal class AuthData
{
    public string token;
    public string socketURL;
    public string nameSpace;
}

#endregion

#region Enums

internal enum GameState
{
    Initializing,
    Idle,
    Spinning,
    Stopping,
    ShowingWin,
    FreeSpinMode
}

internal enum SpinSpeed
{
    Normal,
    Turbo,
    QuickSpin
}

internal enum WinPopupType
{
    RegularWin,
    BigWin,
    FreeSpinTrigger,
    MoneyBagCollect,
    FreeSpinComplete
}

#endregion

#region Helper Classes for Conversion

internal static class InitDataConverter
{
    internal static GameConfig ConvertToGameConfig(InitData serverData)
    {
        var config = new GameConfig
        {
            reelCount = 3,
            rowCount = 3,
            symbolCount = (serverData?.uiData?.paylines?.symbols != null) ? serverData.uiData.paylines.symbols.Count : 14,
            paylineCount = (serverData?.gameData != null) ? serverData.gameData.totalLines : 1,
            paylines = serverData?.gameData?.lines,
            availableBets = serverData?.gameData?.bets,
            creditDivisor = (serverData?.features != null && serverData.features.baseCoinValue > 0) ? serverData.features.baseCoinValue : 1.0,
            baseCoinValue = (serverData?.features != null && serverData.features.baseCoinValue > 0) ? serverData.features.baseCoinValue : 1.0,
            symbols = new List<SymbolInfo>()
        };

        if (serverData?.uiData?.paylines?.symbols != null)
        {
            foreach (var serverSymbol in serverData.uiData.paylines.symbols)
            {
                var symbolInfo = new SymbolInfo
                {
                    id = serverSymbol.id,
                    name = serverSymbol.name,
                    group = serverSymbol.group,
                    multipliers = new List<double>(),
                    isWild = (serverSymbol.group == "wild"),
                    isScatter = (serverSymbol.group == "scatter"),
                    minMatch = serverSymbol.minMatch > 0 ? serverSymbol.minMatch : 3
                };

                symbolInfo.multipliers.Add(serverSymbol.payout);
                config.symbols.Add(symbolInfo);
            }
        }

        if (serverData?.features != null)
        {
            config.scatterFeature = serverData.features.scatter;
            config.anyBarsPayout = serverData.features.anyBarsPayout;
            config.anySevensGroup = serverData.features.anySevensGroup;
            config.wildSubstitution = serverData.features.wildSubstitution;
            config.betMultiplier = serverData.features.betMultiplier > 0 ? serverData.features.betMultiplier : 1;
            config.maxWinMultiplier = serverData.features.maxWinMultiplier;
            config.minWinMultiplier = serverData.features.minWinMultiplier;

            config.scatterSymbolId = serverData.features.scatter?.scatterSymbolId ?? config.scatterSymbolId;
            config.wildSymbolId = serverData.features.wildSubstitution?.wildSymbolId ?? config.wildSymbolId;

            if (serverData.features.freeGames != null)
            {
                config.initialFreeSpins = serverData.features.freeGames.maxTotalFreeGames;
            }
        }

        return config;
    }

    internal static PlayerData ConvertToPlayerData(ServerPlayer serverPlayer, int defaultBetIndex = 0)
    {
        return new PlayerData
        {
            balance = serverPlayer != null ? serverPlayer.balance : 0,
            currentBetIndex = defaultBetIndex
        };
    }

    internal static SpinResult ConvertServerResponseToSpinResult(ServerSpinResponse serverResponse, double currentBalance, double betAmount, GameConfig gameConfig)
    {
        double winAmountVal = 0;
        if (serverResponse.payload != null)
        {
            winAmountVal = serverResponse.payload.winAmount > 0 ? serverResponse.payload.winAmount : serverResponse.payload.totalWin;
        }

        double totalPay = (gameConfig != null && gameConfig.creditDivisor > 0) ? betAmount * gameConfig.creditDivisor : betAmount;
        double newBalance = serverResponse.player?.balance ?? CalculateNewBalance(currentBalance, totalPay, winAmountVal);

        int spinsRemaining = 0;
        int spinsUsed = 0;
        int totalSpins = 0;
        double totalRoundWin = 0;
        bool isRoundOver = false;

        if (serverResponse.payload?.freeGames != null)
        {
            spinsRemaining = serverResponse.payload.freeGames.totalAwarded - serverResponse.payload.freeGames.played;
            spinsUsed = serverResponse.payload.freeGames.played;
            totalSpins = serverResponse.payload.freeGames.totalAwarded;
            totalRoundWin = serverResponse.payload.freeGames.totalFreeGamesWin;
            isRoundOver = serverResponse.payload.freeGames.played >= serverResponse.payload.freeGames.totalAwarded && serverResponse.payload.freeGames.totalAwarded > 0;
        }
        else if (serverResponse.payload != null)
        {
            isRoundOver = serverResponse.payload.isRoundOver;
            totalRoundWin = serverResponse.payload.totalRoundWin;
        }

        double featureWins = 0;
        if (serverResponse.payload != null)
        {
            if (serverResponse.payload.moneyBag?.result != null)
            {
                featureWins += serverResponse.payload.moneyBag.result.winInCash;
            }
        }

        double grandTotalWinVal = (serverResponse.payload != null && serverResponse.payload.grandTotalWin > 0)
            ? serverResponse.payload.grandTotalWin
            : Math.Max(winAmountVal, featureWins);

        int reelCountForScatter = gameConfig != null ? gameConfig.reelCount : 3;
        var combinedWinLines = ConvertWinningLines(serverResponse.payload?.winningLines, serverResponse.payload?.waysWins, gameConfig);

        ResultScatter scatterInfo = serverResponse.payload?.features?.scatter;
        bool scatterTriggered = scatterInfo != null && scatterInfo.triggered;
        List<int> scatterFlatPositions = scatterTriggered ? FlattenPositions(scatterInfo.positions, reelCountForScatter) : null;

        if (scatterTriggered && scatterFlatPositions != null && scatterFlatPositions.Count > 0)
        {
            combinedWinLines.Add(new WinLine
            {
                lineId = -1,
                symbolId = gameConfig != null ? gameConfig.scatterSymbolId : 0,
                positions = scatterFlatPositions,
                winAmount = scatterInfo.award
            });
        }

        var result = new SpinResult
        {
            resultMatrix = ConvertReelsToMatrix(serverResponse.payload?.reels, serverResponse.matrix, serverResponse.payload?.waysWins, gameConfig),
            winAmount = winAmountVal,
            grandTotalWin = grandTotalWinVal,
            winLines = combinedWinLines,

            playerData = new PlayerData
            {
                balance = newBalance,
                currentBetIndex = 0
            },

            freeSpinData = (serverResponse.payload?.freeGames != null && serverResponse.payload.freeGames.triggered)
                ? new FreeSpinData
                {
                    isTriggered = true,
                    spinsAwarded = serverResponse.payload.freeGames.totalAwarded,
                    remainingSpins = serverResponse.payload.freeGames.totalAwarded - serverResponse.payload.freeGames.played,
                    isBought = false
                }
                : null,

            scatterData = scatterTriggered
                ? new ScatterData
                {
                    isTriggered = true,
                    scatterCount = scatterInfo.scatterCount,
                    winAmount = scatterInfo.award,
                    positions = scatterFlatPositions
                }
                : null,

            overlayScatterData = null,
            stickyWilds = null,

            serverSpinsRemaining = spinsRemaining,
            serverSpinsUsed = spinsUsed,
            serverTotalSpins = totalSpins,
            serverTotalRoundWin = totalRoundWin,
            isRoundOver = isRoundOver,

            moneyBagData = (serverResponse.payload?.moneyBag != null && serverResponse.payload.moneyBag.triggered && serverResponse.payload.moneyBag.result != null)
                ? new MoneyBagResultData
                {
                    triggered = true,
                    pickedIndex = serverResponse.payload.moneyBag.result.pickedIndex,
                    revealed = serverResponse.payload.moneyBag.result.revealed,
                    creditsAwarded = serverResponse.payload.moneyBag.result.creditsAwarded,
                    winInCash = serverResponse.payload.moneyBag.result.winInCash
                }
                : null
        };

        return result;
    }

    private static List<List<int>> ConvertReelsToMatrix(List<List<string>> serverReels, List<List<string>> serverMatrix, List<ServerWaysWin> waysWins, GameConfig gameConfig)
    {
        var sourceReels = serverMatrix ?? serverReels;
        int rowCount = gameConfig != null ? gameConfig.rowCount : 3;
        int reelCount = gameConfig != null ? gameConfig.reelCount : 3;

        if (sourceReels == null || sourceReels.Count == 0)
        {
            UnityEngine.Debug.LogError("Invalid server reels/matrix: sourceReels is null or empty");
            return GenerateDefaultMatrix(rowCount, reelCount);
        }

        int totalRows = sourceReels.Count;
        int totalCols = sourceReels[0].Count;

        var matrix = new List<List<int>>();

        for (int col = 0; col < totalCols; col++)
        {
            var column = new List<int>();
            for (int row = 0; row < totalRows; row++)
            {
                if (col < sourceReels[row].Count)
                {
                    string symbolStr = sourceReels[row][col];
                    if (int.TryParse(symbolStr, out int symbolId))
                    {
                        column.Add(symbolId);
                    }
                    else
                    {
                        column.Add(0);
                    }
                }
                else
                {
                    column.Add(0);
                }
            }
            matrix.Add(column);
        }

        return matrix;
    }

    private static List<List<int>> GenerateDefaultMatrix(int rowCount = 3, int reelCount = 3)
    {
        var matrix = new List<List<int>>();
        for (int col = 0; col < reelCount; col++)
        {
            var column = new List<int>();
            for (int row = 0; row < rowCount; row++)
            {
                column.Add(0);
            }
            matrix.Add(column);
        }
        return matrix;
    }

    private static List<int> FlattenPositions(List<List<int>> positions, int reelCount)
    {
        var flat = new List<int>();
        if (positions == null) return flat;
        foreach (var pos in positions)
        {
            if (pos != null && pos.Count >= 2)
            {
                flat.Add(pos[0] * reelCount + pos[1]);
            }
        }
        return flat;
    }

    private static List<WinLine> ConvertWinningLines(List<ServerWinLine> serverWinLines, List<ServerWaysWin> serverWaysWins, GameConfig gameConfig)
    {
        var winLines = new List<WinLine>();
        int reelCount = gameConfig != null ? gameConfig.reelCount : 3;

        if (serverWinLines != null && serverWinLines.Count > 0)
        {
            int index = 0;
            foreach (var line in serverWinLines)
            {
                var flatPositions = new List<int>();
                if (line.matchedPositions != null && line.matchedPositions.Count > 0)
                {
                    foreach (var pos in line.matchedPositions)
                    {
                        int flatIndex = pos.row * reelCount + pos.col;
                        flatPositions.Add(flatIndex);
                    }
                }
                else if (line.positions != null)
                {
                    if (line.positions is Newtonsoft.Json.Linq.JArray jArr)
                    {
                        foreach (var item in jArr)
                        {
                            if (item is Newtonsoft.Json.Linq.JArray subArr && subArr.Count >= 2)
                            {
                                int row = (int)subArr[0];
                                int col = (int)subArr[1];
                                flatPositions.Add(row * reelCount + col);
                            }
                            else if (item is Newtonsoft.Json.Linq.JArray subArr1 && subArr1.Count == 1)
                            {
                                flatPositions.Add((int)subArr1[0]);
                            }
                            else if (int.TryParse(item.ToString(), out int pVal))
                            {
                                flatPositions.Add(pVal);
                            }
                        }
                    }
                    else if (line.positions is List<List<int>> list2D)
                    {
                        foreach (var pair in list2D)
                        {
                            if (pair.Count >= 2)
                            {
                                int row = pair[0];
                                int col = pair[1];
                                flatPositions.Add(row * reelCount + col);
                            }
                            else if (pair.Count == 1)
                            {
                                flatPositions.Add(pair[0]);
                            }
                        }
                    }
                    else if (line.positions is List<int> list1D)
                    {
                        flatPositions.AddRange(list1D);
                    }
                }

                int effectiveLineId = line.lineIndex >= 0 ? line.lineIndex : (line.lineId >= 0 ? line.lineId : index++);
                double effectiveWinAmount = line.payout > 0 ? line.payout : line.winAmount;

                winLines.Add(new WinLine
                {
                    lineId = effectiveLineId,
                    symbolId = line.symbolId,
                    positions = flatPositions,
                    winAmount = effectiveWinAmount
                });
            }
            return winLines;
        }

        if (serverWaysWins != null && serverWaysWins.Count > 0)
        {
            int index = 0;
            foreach (var waysWin in serverWaysWins)
            {
                var flatPositions = new List<int>();
                if (waysWin.matchedPositions != null)
                {
                    foreach (var pos in waysWin.matchedPositions)
                    {
                        int flatIndex = pos.row * reelCount + pos.col;
                        flatPositions.Add(flatIndex);
                    }
                }

                winLines.Add(new WinLine
                {
                    lineId = index++,
                    symbolId = waysWin.symbolId,
                    positions = flatPositions,
                    winAmount = waysWin.winInCash
                });
            }
        }

        return winLines;
    }

    private static double CalculateNewBalance(double currentBalance, double totalPay, double winAmount)
    {
        return currentBalance + winAmount;
    }
}

#endregion