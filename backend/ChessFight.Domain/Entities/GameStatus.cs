using System.ComponentModel;

namespace ChessFight.Domain.Entities
{
    public enum GameStatus
    {
        // Игра создана, но ещё не начата (ожидает второго игрока)
        [Description("Waiting for the player")]
        WaitingForPlayers = 0,

        // Идёт активная игра
        [Description("Active game")]
        Active = 1,

        // Игра завершена матом
        [Description("The game ended with a checkmate")]
        Checkmate = 2,

        // Игра завершена патом
        [Description("The game ended in stalemate")]
        Stalemate = 3,

        // Игра завершена сдачей одного из игроков
        [Description("The game ends with the player's surrender")]
        Resignation = 4,

        // Ничья по соглашению
        [Description("Draw by agreement")]
        DrawByAgreement = 5,

        // Игра отменена (например, игрок вышел до начала)
        [Description("The game is abandoned")]
        Abandoned = 6,

        // Игра завершена по времени (у одного из игроков кончился таймер)
        [Description("The game is over due to time")]
        Timeout = 7

        //// Ничья по правилу 50 ходов
        //DrawByFiftyMoveRule = 6,

        //// Ничья из-за троекратного повторения позиции
        //DrawByRepetition = 7
    }
}
